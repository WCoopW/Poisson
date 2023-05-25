using System;
namespace PoissonGen
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region tcp
            //const string ip = "127.0.0.1";
            //const int port = 8080;

            //var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // tcpSocket.Bind(tcpEndPoint);
            // tcpSocket.Listen(5);

            // var timer = new Stopwatch();
            // timer.Start();
            // while(timer.Elapsed.TotalSeconds < 5)
            // {
            //     var listener = tcpSocket.Accept();
            //     var buffer = new byte[256];
            //     var size = 0;
            //     var data = new StringBuilder();
            //     do
            //     {
            //         size = listener.Receive(buffer);
            //         data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            //     }
            //     while (listener.Available > 0);
            //     Console.WriteLine(data);
            // }
            // timer.Reset();
            #endregion
            var k = new GeneringNew();
            k.Work();
            Console.ReadLine();
            }

        }
    }

