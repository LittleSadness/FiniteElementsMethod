using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElementMethod
{
    class FENode
    {
        double x = 0;
        double y = 0;
        double value = 0;

        public FENode()
        {

        }

        public FENode(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public FENode(double x, double y, double value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }

        public override string ToString()
        {
            return "(" + x.ToString() + "," + y.ToString() + ")";
        }
    }
}
