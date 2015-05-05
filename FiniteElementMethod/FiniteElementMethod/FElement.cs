using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElementMethod
{
    class FElement
    {
        List<FENode> hull;

        public FElement(List<FENode> listOfFENodes)
        {
            this.hull = listOfFENodes;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (FENode node in hull)
                str.Append(node.ToString() + " ");
            return str.ToString();
        }
    }
}
