using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiniteElementMethod
{
    static class ModelBuilder
    {
        public static void buildModel(Tuple<double,double> rectangle, double feSize, bool use8NodesElements)
        {
            List<FENode> FENodes = buildListOfNodes(rectangle, feSize, use8NodesElements);
            List<FElement> FElements = buildListOfElements(FENodes, rectangle, feSize, use8NodesElements);
            foreach(FElement elem in FElements){
                System.Console.WriteLine(elem);
            }
        }

        private static List<FElement> buildListOfElements(List<FENode> FENodes, Tuple<double, double> rectangle, double feSize, bool use8NodesElements)
        {
            int dimX = (int)(rectangle.Item1 / feSize);
            int dimY = (int)(rectangle.Item1 / feSize);
            List<FElement> FElements = new List<FElement>(dimX * dimY);
            for (int i = 0; i < dimX; ++i)
            {
                for (int j = 0; j < dimY; ++j)
                {
                    FElements.Add(new FElement(getElementNodes(i, j, dimX, dimY, FENodes, use8NodesElements)));
                }
            }
            return FElements;
        }

        private static List<FENode> buildListOfNodes(Tuple<double, double> rectangle, double feSize, bool use8NodesElements)
        {
            if (use8NodesElements) feSize /= 2;
            int numberOfNodes = (int)((rectangle.Item1 * rectangle.Item2) / (feSize * feSize));
            List<FENode> FENodes = new List<FENode>(numberOfNodes);
            for (double x = 0; x <= rectangle.Item1; x += feSize)
            {
                for (double y = 0; y <= rectangle.Item2; y += feSize)
                {
                    FENodes.Add(new FENode(x, y));
                }
            }
            return FENodes;
        }

        private static List<FENode> getElementNodes(int i, int j, int dimX, int dimY, List<FENode> FENodes, bool use8NodesElements)
        {
            int[] nodesIndexes = new int[use8NodesElements ? 8 : 4];

            if (use8NodesElements)
            {
                nodesIndexes[0] = 2 * ((2 * dimX + 1) * j + i);
                nodesIndexes[1] = nodesIndexes[0] + 1;
                nodesIndexes[2] = nodesIndexes[1] + 1;

                nodesIndexes[3] = nodesIndexes[0] + dimX * 2 + 1;
                nodesIndexes[4] = nodesIndexes[3] + 2;

                nodesIndexes[5] = nodesIndexes[3] + dimX * 2 + 1;
                nodesIndexes[6] = nodesIndexes[5] + 1;
                nodesIndexes[7] = nodesIndexes[6] + 1;
            }
            else
            {
                nodesIndexes[0] = (dimX + 1) * j + i;
                nodesIndexes[1] = nodesIndexes[0] + 1;

                nodesIndexes[2] = nodesIndexes[1] + dimX;
                nodesIndexes[3] = nodesIndexes[2] + 1;

            }
            List<FENode> elementNodes = new List<FENode>(nodesIndexes.Length);
            foreach (int index in nodesIndexes)
                elementNodes.Add(FENodes[index]);

            return elementNodes;
        }
    }
}
