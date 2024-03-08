using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2labIM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.2, step = 1;
        double time = 0, dollarPrice, kronPrice;      

        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            dollarPrice = (double)edDollar.Value;
            kronPrice = (double)edKron.Value;
           

            chart1.Series[0].Points.AddXY(0, dollarPrice);
            chart1.Series[1].Points.AddXY(0, kronPrice);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time += step;

            dollarPrice = dollarPrice * (1 + k * (rnd.NextDouble() - 0.5));
            kronPrice = kronPrice * (1 + k * (rnd.NextDouble() - 0.5));

            chart1.Series[0].Points.AddXY(time, dollarPrice);
            chart1.Series[1].Points.AddXY(time, kronPrice);

            if(time == 10)
            {
                timer1.Stop();
                time = 0;
            }
            
        }
    }
}
