using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN__conf
{
    [Serializable]
    class Template
    {
        public string Name;

        public Size CountOfTemplates
        {
            get;
            set;
        }
        Size AvailibleSize;

        List<List<Rectangle>> TemplateImage = new List<List<Rectangle>>();
        List<List<int>> Values = new List<List<int>>();

        public List<List<int>> ValuesData
        {
            get { return Values; }
        }

        Point LastChanged;
        int ValueToChange;

        public Template(Size SizeOfTemplate, Size SizeOfDrawField)
        {
            SetSize(SizeOfTemplate, SizeOfDrawField);
        }

        public Template(Template copy, string TemplateName)
        {
            Name = TemplateName;
            CountOfTemplates = copy.CountOfTemplates;
            AvailibleSize = copy.AvailibleSize;

            for (int i = 0; i < copy.TemplateImage.Count; i++)
            {
                TemplateImage.Add(new List<Rectangle>());
                Values.Add(new List<int>());

                for (int j = 0; j < copy.TemplateImage[i].Count; j++)
                {
                    int x = copy.TemplateImage[i][j].X, y = copy.TemplateImage[i][j].Y,
                        width = copy.TemplateImage[i][j].Width, height = copy.TemplateImage[i][j].Height;

                    TemplateImage[i].Add(new Rectangle(x, y, width, height));

                    Values[i].Add(copy.Values[i][j]);
                }
            }

            LastChanged = copy.LastChanged;
            ValueToChange = copy.ValueToChange;
        }

        public void SetSize(Size SizeOfTemplate, Size SizeOfDrawField)
        {
            CountOfTemplates = SizeOfTemplate;
            AvailibleSize = SizeOfDrawField;


            Size RectanglesSize = new Size(AvailibleSize.Width / CountOfTemplates.Width,
                                           AvailibleSize.Height / CountOfTemplates.Height);

            for (int i = 0; i < SizeOfTemplate.Height; i++)
            {
                TemplateImage.Add(new List<Rectangle>());
                Values.Add(new List<int>());

                for (int j = 0; j < SizeOfTemplate.Width; j++)
                {
                    TemplateImage[i].Add(new Rectangle(
                                            new Point(j * RectanglesSize.Width, i * RectanglesSize.Height),
                                            RectanglesSize));
                    Values[i].Add(0);
                }
            }
        }

        public void Resize(Size SizeOfTemplate, Size SizeOfDrawField)
        {
            Size RectanglesSize = new Size(SizeOfDrawField.Width / SizeOfTemplate.Width,
                                           SizeOfDrawField.Height / SizeOfTemplate.Height);

            List<List<Rectangle>> bufTemplateImage = new List<List<Rectangle>>();
            List<List<int>> bufValues = new List<List<int>>();

            for (int i = 0; i < SizeOfTemplate.Height; i++)
            {
                bufTemplateImage.Add(new List<Rectangle>());
                bufValues.Add(new List<int>());

                for (int j = 0; j < SizeOfTemplate.Width; j++)
                {
                    bufTemplateImage[i].Add(new Rectangle
                                                           (
                                                            new Point(j * RectanglesSize.Width,
                                                            i * RectanglesSize.Height),
                                                            RectanglesSize
                                                           )
                                            );
                    bufValues[i].Add(0);

                    if (i < TemplateImage.Count && j < TemplateImage[i].Count)
                    {
                        bufValues[i][j] = Values[i][j];
                    }
                }
            }

            TemplateImage = bufTemplateImage;
            Values = bufValues;

            CountOfTemplates = SizeOfTemplate;
            AvailibleSize = SizeOfDrawField;
        }

        public void DrawRectangles(Graphics g)
        {
            for (int i = 0; i < TemplateImage.Count; i++ )
            {
                for (int j = 0; j < TemplateImage[i].Count; j++)
                {
                    g.FillRectangle((Values[i][j] == 1? Brushes.Red: Brushes.Black),
                                    TemplateImage[i][j]);
                }
            }
        }

        public void ProcessMouseSignal(Point MousePosition)
        {
            for (int i = 0; i < TemplateImage.Count; i++)
            {
                for (int j = 0; j < TemplateImage[i].Count; j++)
                {
                    if (TemplateImage[i][j].Contains(MousePosition) && LastChanged != new Point(j, i))
                    {
                        Values[i][j] = ValueToChange;
                        LastChanged = new Point(j, i);
                    }
                }
            }
        }

        public void SetToDraw(Point MousePosition)
        {
            for (int i = 0; i < TemplateImage.Count; i++)
            {
                for (int j = 0; j < TemplateImage[i].Count; j++)
                {
                    if (TemplateImage[i][j].Contains(MousePosition))
                    {
                        ValueToChange = Values[i][j] == 1? 0: 1;
                    }
                }
            }
        }

        public void Reset()
        {
            LastChanged = new Point(-1, -1);
        }

        public void Clear()
        {
            for (int i = 0; i < Values.Count; i++)
            {
                for (int j = 0; j < Values[i].Count; j++)
                {
                    Values[i][j] = 0;
                }
            }
        }
    }
}
