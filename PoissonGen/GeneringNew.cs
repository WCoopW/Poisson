using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoissonGen
{
    public class GeneringNew
    {
        List<double> AvgTimeAsync = new List<double>();
        List<double> AvgReqAsync = new List<double>();
        List<double> AvgReq = new List<double>();
        List<double> AvgTime = new List<double>();
        int N = 100000;


        PoissonRND rnd = new PoissonRND(DateTime.Now.Millisecond);
        public void Work()
        {
            Genering();
            GeneringAsync();
            Forms(AvgTime, AvgReq, AvgTimeAsync, AvgReqAsync);
        }
        public void Genering()
        {
            for (double lambda = 0.01; lambda < 1; lambda += 0.01)
            {
                double time_sum = 0;
                int numRequest = 0;
                double serv_req = 0;
                var queue = new Queue<Request>();
                int[] windows = new int[N];
                for (int i = 0; i < N; i++)
                {
                    windows[i] = rnd.Generate(Math.Round(lambda, 3));
                }
                for (int i = 0; i < N; i++)
                {
                    for (int k = 0; k < windows[i]; k++)
                    {
                        queue.Enqueue(new Request(rnd.NextDouble() + i));   
                    }
                    numRequest += queue.Count;
                    if (queue.Count != 0)
                    {
                        var first = queue.Peek();
                        time_sum += (i + 1.5) - first.app_time;        
                        queue.Dequeue();
                        serv_req++;
                    }
                }

                double avg_req = Math.Round(numRequest / (double)N, 3);
                double avg_time = Math.Round(time_sum / serv_req, 3);
                AvgTime.Add(avg_time);
                AvgReq.Add(avg_req);
            }
       
        }
        public void GeneringAsync()
        {
            for (double lambda = 0.01; lambda < 1; lambda += 0.01)
            {
                double next_send_time = 0;
                double time_sum = 0;
                int numRequest = 0;
                double serv_req = 0;

                var queue = new Queue<Request>();
                int[] windows = new int[N];
                for (int i = 0; i < N; i++)
                {
                    windows[i] = rnd.Generate(Math.Round(lambda, 3));
                }
                for (int i = 0; i < N; i++)
                {
                    for (int k = 0; k < windows[i]; k++)
                    {
                        queue.Enqueue(new Request(rnd.NextDouble() + i));

                    }
                    numRequest += queue.Count;
                    if (i == 0)
                    {
                        if (queue.Count != 0)
                        {
                            var first = queue.Peek();
                            next_send_time = first.app_time + 1;
                            queue.Dequeue();
                            time_sum++;
                        }
                    }
                    if (queue.Count != 0)
                    {
                        var first = queue.Peek();
                        if (first.app_time < next_send_time)
                        {
                            time_sum += next_send_time - first.app_time + 1;
                            next_send_time++;
                        }
                        else
                        {
                            time_sum++;
                            next_send_time = first.app_time + 1;
                        }
                        queue.Dequeue();
                        serv_req++; 
                    }
                }
                double avg_req = Math.Round(numRequest / (double)N, 3);
                double avg_time = Math.Round(time_sum / serv_req, 3);
                AvgTimeAsync.Add(avg_time);
                AvgReqAsync.Add(avg_req);
            }
           
        }
        void Forms(List<double> AvgTime, List<double> AvgReq, List<double> AvgTimeAsync, List<double> AvgReqAsync)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1(AvgTime, AvgReq, AvgTimeAsync, AvgReqAsync));
        }
    }
}