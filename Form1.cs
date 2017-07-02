using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;

namespace NN__conf
{
    public partial class Form1 : Form
    {
        int Hidden_Leyers_Count = 2;
        bool drawing = false;

        List<Template> Templates = new List<Template>();
        Template CurrTemp;

        Waiter wait_for_me;

        NeuralNet NN;

        double[][,]  Answers;//answers to ALL templates
        double[][,]  UniqueAnswers;//answers
        string[] AnswersTXT;//Answers in text form(to convert from binary classiffication to text)
        

        public Form1()
        {
            InitializeComponent();
            CurrTemp = new Template(new Size(20,20),p_DrawHere.Size);

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, p_DrawHere, new object[] { true });
        }

        private void MouseDownTemplate(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                drawing = true;

                CurrTemp.SetToDraw(e.Location);
                CurrTemp.ProcessMouseSignal(e.Location);
            
                p_DrawHere.Invalidate();
            }
        }

        private void MouseMoveTemplate(object sender, MouseEventArgs e)
        {
            if(drawing)
            {
                CurrTemp.ProcessMouseSignal(e.Location);
                p_DrawHere.Invalidate();
            }
        }

        private void MouseUpTemplate(object sender, MouseEventArgs e)
        {
            drawing = false;

            CurrTemp.Reset();
        }

        private void p_DrawHere_Paint(object sender, PaintEventArgs e)
        {
            CurrTemp.DrawRectangles(e.Graphics);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if(btn_AddTemplate == sender)
            {
                Templates.Add(new Template(CurrTemp, tb_TemplateName.Text));
                lb_Patterns.Items.Add(tb_TemplateName.Text);
            }
            else if(btn_DeleteTemplate == sender)
            {
                if(lb_Patterns.SelectedItem != null)
                {
                    int i = lb_Patterns.SelectedIndex;

                    Templates.RemoveAt(i);
                    lb_Patterns.Items.RemoveAt(i);

                    if(i < lb_Patterns.Items.Count)
                    {
                        lb_Patterns.SelectedItem = lb_Patterns.Items[i];
                    }
                }
            }
            else if(btn_LearnNeuro == sender)
            {
                InitAnswers();

                if (NN != null)
                {
                    if (NN.NetSize.Width != (CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width + 1)
                        ||
                        NN.NetSize.Height != AnswersTXT.Length)
                    {
                        NN = new NeuralNet(CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width,
                                            Hidden_Leyers_Count,
                                            AnswersTXT.Length);
                    }
                }
                else
                {
                    NN = new NeuralNet(CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width,
                                            Hidden_Leyers_Count,
                                            AnswersTXT.Length);
                }

                int Epochs = decimal.ToInt32(nud_EpochsCount.Value);
                int EpError = decimal.ToInt32(nud_ErrorEpoch.Value);

                NN.Stop = false;
                NN.Learning(Templates, Answers, Epochs, EpError);

                wait_for_me = new Waiter(Epochs);
                wait_for_me.Show();

                Ping.Enabled = true;
                btn_LearnNeuro.Enabled = false;
                btn_Recognize.Enabled = false;
                btn_AddTemplate.Enabled = false;
                btn_DeleteTemplate.Enabled = false;
                btn_Load.Enabled = false;
            }
            else if(btn_Load == sender)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(ofd.FileName, FileMode.Open, 
                                                                   FileAccess.Read, FileShare.Read))
                    {
                        var bformatter = new BinaryFormatter();

                        Templates.Clear();
                        lb_Patterns.Items.Clear();

                        Templates = (List<Template>)bformatter.Deserialize(stream);

                        foreach(var item in Templates)
                        {
                            lb_Patterns.Items.Add(item.Name);
                        }

                        CurrTemp.Resize(Templates[0].CountOfTemplates, p_DrawHere.Size);

                        InitAnswers();

                        NN = new NeuralNet(CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width,
                                            Hidden_Leyers_Count,
                                            AnswersTXT.Length);
                    }
                }
            }
            else if(btn_Recognize == sender)
            {
                if (NN != null)
                {
                    if (NN.NetSize.Width == (CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width + 1)
                        &&
                        NN.NetSize.Height == AnswersTXT.Length)
                    {
                        var answr = NN.FeedForward(CurrTemp);

                        string toShow = "";

                        for (int i = 0; i < answr.GetLength(1); i++)
                            toShow += AnswersTXT[i] + " = " + answr[0, i] + "\n";

                        MessageBox.Show(toShow);

                        tb_Answer.Text = Translate(answr.Reshape());
                    }
                }
            }
            else if(btn_SaveTemplate == sender)
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        bformatter.Serialize(stream, Templates);
                    }
                }
            }
        }

        private void tsctx_Click(object sender, EventArgs e)
        {
            if(tsctx_Clear == sender)
            {
                CurrTemp.Clear();
                p_DrawHere.Invalidate();
            }
            else if(tsctx_Resize == sender)
            {
                ResizeDialoge rd = new ResizeDialoge(CurrTemp.CountOfTemplates);

                if(rd.ShowDialog() == DialogResult.OK)
                {
                    CurrTemp.Resize(rd.SetedSize, p_DrawHere.Size);

                    for (int i = 0; i < Templates.Count; i++)
                        Templates[i].Resize(rd.SetedSize, p_DrawHere.Size);

                    p_DrawHere.Invalidate();
                }
            }
        }

        private void InitAnswers()
        {
            List<string> a = lb_Patterns.Items.Cast<string>().ToList();

            AnswersTXT = a.Distinct().ToArray<string>();

            UniqueAnswers = new double[AnswersTXT.Length][,];
            for (int i = 0; i < UniqueAnswers.GetLength(0); i++)
                UniqueAnswers[i] = new double[1,AnswersTXT.Length];

            for (int i = 0; i < AnswersTXT.Length; i++)
            {
                for (int j = 0; j < AnswersTXT.Length; j++)
                {
                    if (i == j)
                    {
                        UniqueAnswers[i][0,j] = 1;
                    }
                    else
                        UniqueAnswers[i][0,j] = 0;
                }
            }

            Answers = new double[a.Count][,];
            for (int i = 0; i < a.Count; i++)
                Answers[i] = new double[1,AnswersTXT.Length];

            for (int i = 0; i < a.Count; i++)
            {
                int j = Array.IndexOf(AnswersTXT, a[i]);

                for (int z = 0; z < UniqueAnswers[j].GetLength(1); z++)
                {
                        
                    Answers[i][0,z] = UniqueAnswers[j][0,z];
                }

                //MessageBox.Show(a[i] + "\n" + String.Join(",\n", Answers[i]));
            }
        }

        public  string Translate(double[] ToHumans)
        {
            double a = ToHumans.Max();
            string text = AnswersTXT[Array.IndexOf(ToHumans, a)];

            return text;
        }

        private void Ping_Tick(object sender, EventArgs e)
        {
            if (!wait_for_me.Closed)
            {
                wait_for_me.CurrEpoch(NN.CurrentEpoch);
            }
            else
            {
                NN.Stop = true;
                Ping.Enabled = false;
                btn_LearnNeuro.Enabled = true;
                btn_Recognize.Enabled = true;
                btn_AddTemplate.Enabled = true;
                btn_DeleteTemplate.Enabled = true;
                btn_Load.Enabled = true;
            }
        }

        private void lb_Patterns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Patterns.SelectedIndex >= 0)
            {
                CurrTemp = new Template(Templates[lb_Patterns.SelectedIndex],
                            lb_Patterns.SelectedItem.ToString());
                p_DrawHere.Invalidate();

                if(NN != null)
                {
                    if (NN.NetSize.Width == (CurrTemp.CountOfTemplates.Height * CurrTemp.CountOfTemplates.Width + 1)
                        &&
                        NN.NetSize.Height == AnswersTXT.Length)
                    {
                        tb_Answer.Text = Translate(NN.FeedForward(CurrTemp).Reshape());
                    }
                }
            }
        }
    }
}
