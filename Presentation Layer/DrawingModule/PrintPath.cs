using BusinessLayer;
using BusinessLayer.DrawingModule;
using BusinessLayer.Interfaces;
using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Helpers;

namespace PresentationLayer.DrawingModule
{
    public class PrintPath
    {
        private Dijkstra dijkstra = new Dijkstra();

        private IFrameWork frameWork;

        private DrawingModulePL view;

        private int pathIndex;

        public PrintPath(IFrameWork frameWork, DrawingModulePL view)
        {
            this.frameWork = frameWork;
            this.view = view;
        }
    public void Print(int[,] graph, int sourceNode, int destinationNode, HalozatiElemek[] adatok, Vonal[] vonalak)
    {
        //Console.WriteLine(
        //     "Útvonal [{0} -> {1}] között: ",
        //     sourceNode,
        //     destinationNode);
        List<int> path = dijkstra.DijkstraAlg(graph, sourceNode, destinationNode);

            if (path == null)
            {
                MessageBox.Show("Nincs út [{0} és {1}] között!");
            }
            else
            {
                int pathLength = 0;
                for (int z = 0; z < 5; z++)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        pathLength += graph[path[i], path[i + 1]];
                        PrintItem(adatok[path[i]].ItemType);
                        //Console.Write(adatok[path[i]].nev);
                        //if (i != path.Count - 2) Console.Write(" -> ");
                    }
                }
                

                //var formattedPath = string.Join(" -> ", path);
                //Console.WriteLine("{0}   ({1} összerendelés)", formattedPath, pathLength);
            }
        }

        private void PrintItem(SymbolName symbolName)
        {
            ISymbol symbol = frameWork.GetSymbol(symbolName);
            int pathX, pathY;
            ConvertPath(out pathX, out pathY);
            view.ImageLoad(pathX, pathY, symbol.GetImage());
            pathIndex++;
            ConvertPath(out pathX, out pathY);
            ISymbol link;
            // TODO javítani bal vagy jobb kanyar
            if (pathX == view.ColumnNumber - 1 || pathX == 0)
            {
             link = frameWork.GetSymbol(SymbolName.Linevertical);
            }
            else
            {
             link = frameWork.GetSymbol(SymbolName.Linehorizontal);
            }
            view.ImageLoad(pathX, pathY , link.GetImage());
            pathIndex++;

        }

        private void ConvertPath(out int pathX, out int pathY)
        {
            pathX = pathIndex % (view.ColumnNumber);
            pathY = pathIndex / (view.ColumnNumber);
            if (pathY % 2 > 0)
            {
                pathX = view.ColumnNumber -1 - pathX;
            }
        }
    }
}
