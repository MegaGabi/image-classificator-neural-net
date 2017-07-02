using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection;
using Accord.Math;

namespace NN__conf
{
    class NeuralNet
    {

        Graph grph = new Graph();

        double          alpha = 0.1;
        double          MinError = 0.1;

        int             Epoch = 0;

        double[,] input,
                  output;

        double[][,] hidden;//layers

        double[,] input_weights;
        double[][,] hidden_weights;

        public bool Stop
        {
            get;
            set;
        }

        public delegate void UpdateCallback(DataPoint pos);

        public int CurrentEpoch
        {
            get { return Epoch; }
        }

        public Size NetSize 
        {
            get { return new Size(input.GetLength(1), output.GetLength(1)); }
        }

        public NeuralNet(int InputSize, int HiddenLayersCount, int OutputSize)
        {
            Resize(InputSize, HiddenLayersCount, OutputSize);
        }

        public void Resize(int InputSize, int HiddenLayersCount, int OutputSize)
        {
            int hidden_size = (int)Math.Sqrt(InputSize + OutputSize);

            input = new double[1, InputSize];

            hidden = new double[HiddenLayersCount][,];
            for (int i = 0; i < hidden.GetLength(0); i++)
                hidden[i] = new double[1, hidden_size];

            output = new double[1, OutputSize];

            input_weights = Matrix.Random(InputSize + 1, hidden_size, -1.0, 1.0);

            hidden_weights = new double[HiddenLayersCount][,];
            for (int i = 0; i < hidden_weights.GetLength(0) - 1; i++)
                hidden_weights[i] = Matrix.Random(hidden_size + 1, hidden_size, -1.0, 1.0);
            hidden_weights[hidden_weights.GetLength(0) - 1] = Matrix.Random(hidden_size + 1, OutputSize, -1.0, 1.0);
        }

        public double[,] FeedForward(Template temp)
        {
            input = NormalizeData(temp);
            input = input.InsertColumn(new double[] { 1 });

            hidden[0] = sigmoid(input.Dot(input_weights));
            hidden[0] = hidden[0].InsertColumn(new double[] { 1 });

            for (int i = 1; i < hidden.GetLength(0); i++)
            {
                hidden[i] = sigmoid(hidden[i - 1].Dot(hidden_weights[i - 1]));
                hidden[i] = hidden[i].InsertColumn(new double[] { 1 });
            }

            output = sigmoid(hidden[hidden.GetLength(0) - 1].Dot(hidden_weights[hidden_weights.GetLength(0) - 1]));
            return output;
        }

        public void Learning(List<Template> Learn_Templates, double[][,] DesiredOutput, int Epochs, int EpError)
        {
            grph = new Graph();
            grph.Show();
            new Thread(() =>
            {
            //    Thread.CurrentThread.IsBackground = true;
                Learn(Learn_Templates, DesiredOutput, Epochs, EpError);
            }).Start();
        }

        private void Learn(List<Template> Learn_Templates, double[][,] DesiredOutput, int Epochs, int EpError)
        {
            double preverr = 0;
            double[] log = new double[DesiredOutput.Length];
            bool DrawNow = false, EpToDraw = false;
            int f = 0, l = output.GetLength(1);

            for (Epoch = 0; Epoch < Epochs; Epoch++)
            {
                for (int j = f; j < l; j++)
                {
                    var ans = FeedForward(Learn_Templates[j]);
                    var exp = DesiredOutput[j];

                    double mx = Error(output, DesiredOutput[j], false)[0, 0];

                    if (mx > MinError)
                        Backprop(ans, exp);

                    log[j] = mx;

                    if (preverr < mx)
                        preverr = mx;
                }

                f = l;
                l += output.GetLength(1);

                if (l > DesiredOutput.Length)
                {
                    f = 0;
                    l = output.GetLength(1);
                    DrawNow = true;

                    if (preverr < MinError || Stop)
                    {
                        //MessageBox.Show(log.ToString(DefaultMatrixFormatProvider.CurrentCulture));
                        MessageBox.Show("Обучение окончено, максимальная ошибка из обучающей выборки: " + preverr);

                        if (grph.Visible)
                            grph.Invoke(new System.Threading.ThreadStart(delegate { grph.Update(new DataPoint(Epoch, preverr)); }));

                        Epoch = Epochs - 1;

                        break;
                    }

                    if (DrawNow && EpToDraw)
                    {
                        if (grph.Visible)
                            grph.Invoke(new System.Threading.ThreadStart(delegate { grph.Update(new DataPoint(Epoch, preverr)); }));

                        DrawNow = EpToDraw = false;
                    }
                    else if (DrawNow)
                    {
                        DrawNow = false;
                    }

                    preverr = 0;
                }

                if (Epoch % EpError == 0)
                    EpToDraw = true;

            }
        }

        private void Backprop(double[,] result, double[,] expected)
        {
            int hs = hidden.Length;

            double[][,] DeltaHiddenWeights = new double[hs][,];
            DeltaHiddenWeights[hs - 1] = new double[1, output.GetLength(1)];
            for (int i = hs - 2; i >= 0; i--)
            {
                DeltaHiddenWeights[i] = new double[1, hs];
            }
            double[,] DeltaInputWeights = new double[1, hs];

            var err = Error(result, expected);//вродь правильно

            DeltaHiddenWeights[hs - 1] = Elementwise.Multiply(sigmoid(output, true), err);//вродь правильно
            double[,] PreviousLayerError = DeltaHiddenWeights[hs - 1].Dot(hidden_weights[hs - 1].Transpose());//вродь правильно

            for (int i = hs - 2; i >= 0; i--)
            {
                DeltaHiddenWeights[i] = Elementwise.Multiply(sigmoid(hidden[i + 1].RemoveColumn(hidden[i].Columns() - 1), true), PreviousLayerError);
                PreviousLayerError = DeltaHiddenWeights[i].Dot(hidden_weights[i].Transpose());
            }

            DeltaInputWeights = Elementwise.Multiply(sigmoid(hidden[0].RemoveColumn(hidden[0].Columns() - 1), true), PreviousLayerError);

            for (int i = hs - 1; i >= 0; i--)
            {
                hidden_weights[i] = hidden_weights[i].Add(hidden[i].Transpose().Dot(DeltaHiddenWeights[i].Multiply(alpha)));
            }
            input_weights = input_weights.Add(input.Transpose().Dot(DeltaInputWeights.Multiply(alpha)));
        }

        private static double[,] NormalizeData(Template temp)
        {
            var RawData = temp.ValuesData;

            double[,] buf = new double[1,(RawData.Count * RawData[0].Count)];

            int index;
            for (int i = 0; i < RawData.Count; i++)
            {
                for (int j = 0; j < RawData[i].Count; j++)
                {
                    index = (i * RawData[i].Count) + j;
                    buf[0,index] = RawData[i][j];
                }
            }

            return buf;
        }

        private double[,] Error(double[,] y_real, double[,] y_exp, bool derivative = true)
        {
            if (derivative)
                return Elementwise.Subtract(y_exp, y_real);
            else
                return new double[1, 1] { { 0.5 * (Matrix.Sum(Elementwise.Pow(Elementwise.Subtract(y_real, y_exp), 2))) }};
        }

        private double[,] sigmoid(double[,] x, bool derivative = false)
        {
            if (derivative)
                return Elementwise.Multiply(x, Elementwise.Subtract(1, x));
            else
            {
                var buf = (x.Multiply(-1)).Exp();
                buf = buf.Add(1);
                buf = Elementwise.Divide(1, buf);
                return buf;
            }
        }
    }
}
