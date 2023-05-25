using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PoissonGen
{
    public class Request
    {
        public double app_time;
        public Request(double a)
        {
            this.app_time = a;
        }
    }
}
