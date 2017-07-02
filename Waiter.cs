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
    public partial class Waiter : Form
    {
        bool closed = false;

        public bool Closed
        {
            get { return closed; }
        }

        public Waiter(int Epochs)
        {
            InitializeComponent();
            progressBar1.Maximum = Epochs;
            closed = false;
        }

        public void CurrEpoch(int Epoch)
        {
            progressBar1.Value = Epoch;
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                Close();
                closed = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            closed = true;
        }


    }
}
