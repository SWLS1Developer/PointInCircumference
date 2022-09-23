using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
       private static Form2 frm;
        public Form2()
        {
            InitializeComponent();
            frm = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public static void SetText(string text)
        {
            frm.richTextBox1.Text = text;
        }

        private static int count = 0;
        public static void SetChart(double cos, double sin)
        {
            frm.chart1.Series[0].Points.Add(cos);
            frm.chart1.Series[1].Points.Add(sin);
        }
    }
}
