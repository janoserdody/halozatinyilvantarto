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
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathLength += graph[path[i], path[i + 1]];
                    PrintItem(adatok[path[i]].ItemType, i);
                    //Console.Write(adatok[path[i]].nev);
                    //if (i != path.Count - 2) Console.Write(" -> ");
                }

                //var formattedPath = string.Join(" -> ", path);
                //Console.WriteLine("{0}   ({1} összerendelés)", formattedPath, pathLength);
            }
        }

        private void PrintItem(SymbolName symbolName, int pathNumber)
        {
            ISymbol symbol = frameWork.GetSymbol(symbolName);
            view.ImageLoad( pathNumber % view.ColumnNumber , pathNumber / view.ColumnNumber, symbol.GetImage());
           // ISymbol link = frameWork.GetSymbol(SymbolName.Linehorizontal);
            //view.ImageLoad()
        }
    }
}
