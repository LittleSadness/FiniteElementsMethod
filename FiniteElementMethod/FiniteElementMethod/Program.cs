using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElementMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 5;
            double b = 5;
            double feSize = 1;
            bool use8Nodes = true;
            ModelBuilder.buildModel(new Tuple<double, double>(a, b), feSize, use8Nodes);
            System.Console.ReadKey(true);
        }
    }
}
