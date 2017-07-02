using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NN__conf
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        public void Update(DataPoint pos)
        {
            chart1.Series["Error"].Points.Add(pos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Graph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Close();
        }
    }
}
