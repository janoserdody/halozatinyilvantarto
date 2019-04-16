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

        public void Print(int[,] graph, int sourceNode, int destinationNode)
        {
            List<int> path = dijkstra.DijkstraAlg(graph, sourceNode, destinationNode);

            if (path == null)
            {
                IItemActive source = frameWork.GetItemActive(sourceNode);
                IItemActive destination = frameWork.GetItemActive(sourceNode);
                MessageBox.Show("Nincs út " + source.DeviceName + source.DeviceID +
                    " és " + destination.DeviceName  + destination.DeviceID + " között!");
            }
            else
            {
                int pathLength = 0;
                int index = 0;
                IItemActive item;
                    for ( ; index < path.Count-1 ; index++)
                    {
                        item = frameWork.GetItemActive(path[index]);
                        pathLength += graph[path[index], path[index + 1]];
                        PrintItem((SymbolName)item.SymbolID);
                    }
                   item = frameWork.GetItemActive(path[index]);
                   PrintSingleItem((SymbolName)item.SymbolID);
            }
        }

        private void PrintItem(SymbolName symbolName)
        {
            int pathX, pathY;
            PrintSingleItem(symbolName);
            pathIndex++;
            ConvertPath(out pathX, out pathY);
            ISymbol link;
            if (pathX == view.ColumnNumber - 1 || pathX == 0)
            {
                if (pathX == 0)
                {
                link = frameWork.GetSymbol(SymbolName.Turnleft);
                }
                else
                {
                    link = frameWork.GetSymbol(SymbolName.Turnright);
                }
            }
            else
            {
             link = frameWork.GetSymbol(SymbolName.Linehorizontal);
            }
            view.ImageLoad(pathX, pathY , link.GetImage());
            pathIndex++;

        }
        private void PrintSingleItem(SymbolName symbolName)
        {
            ISymbol symbol = frameWork.GetSymbol(symbolName);
            int pathX, pathY;
            ConvertPath(out pathX, out pathY);
            view.ImageLoad(pathX, pathY, symbol.GetImage());
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
