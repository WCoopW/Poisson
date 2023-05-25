using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoissonGen
{
    internal class PoissonRND : Random
    {
        private Random _random;
        public PoissonRND(int seed)
        {
            _random = new Random(seed);
        }

        public int Generate(double lambda)
        {
            double L = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;

            do
            {
                k++;
                double u = _random.NextDouble();
                p *= u;
            } while (p > L);

            return k - 1;
        }
    }
}
