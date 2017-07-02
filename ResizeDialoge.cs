using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN__conf
{
    public partial class ResizeDialoge : Form
    {
        public Size SetedSize
        {
            get
            {
                return new Size(    decimal.ToInt32(nud_HorizontalSize.Value),
                                    decimal.ToInt32(nud_VerticalSize.Value  )); 
            }
        }

        public ResizeDialoge(Size sizeNow)
        {
            InitializeComponent();

            nud_HorizontalSize.Value = sizeNow.Width;
            nud_VerticalSize.Value = sizeNow.Height;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
            Close();
        }
    }
}
