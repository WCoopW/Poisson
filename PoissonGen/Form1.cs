using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoissonGen
{
    public partial class Form1 : Form
    {
      

        public List<double> AvgTime = new List<double>();
        public List<double> AvgReq = new List<double>();
        public List<double> AvgTimeAsync = new List<double>();
        public List<double> AvgReqAsync = new List<double>();


        public Form1(List<double> time, List<double> req, List<double> timeAsync, List<double> reqAsync)
        {
            this.AvgTime = time;
            this.AvgReq = req;
            this.AvgReqAsync = reqAsync;
            this.AvgTimeAsync = timeAsync;
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.chart4.Series[0].Points.Clear();

            this.chart4.Series[1].Points.Clear();
            chart4.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisX.Maximum = 1.1;
            chart4.ChartAreas[0].AxisX.Maximum = 1.1;

            int j = 0;
            for (double lambda = 0.01; lambda < 1; lambda += 0.01)
            {
                if (j < AvgReq.Count)
                {
                    double N = (double)(lambda * (2 - lambda)) / (2 * (1 - lambda));
                    this.chart4.Series[2].Points.AddXY(lambda, N);
                    this.chart4.Series[1].Points.AddXY(lambda, AvgReq[j]);
                    this.chart4.Series[0].Points.AddXY(lambda, AvgReqAsync[j]);
                }
                j++;
            }
            j = 0;
            for (double lambda = 0.01; lambda < 1; lambda += 0.01)
            { 
                double N = (double)(lambda * (2 - lambda)) / (2*(1 - lambda));
                double wq = (double)((N / lambda));
             
                this.chart1.Series[2].Points.AddXY(lambda, wq);
                this.chart1.Series[1].Points.AddXY(lambda, AvgTime[j]);
                this.chart1.Series[0].Points.AddXY(lambda, AvgTimeAsync[j]);

                j++;
             
            }
            Console.ReadLine();  
        }

    }
    
}
    

