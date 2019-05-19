using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer.DrawingModule;
using BusinessLayer.DrawingModule._interfaces;
using BusinessLayer.Interfaces;
using Common.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using static Common.Helpers;

namespace PresentationLayer.DrawingModule
{
    public class PrintPath : IPrintPath
    {
        private IDijkstra dijkstra = new Dijkstra();

        private IFrameWork frameWork;

        private IDrawingModulePL view;

        private int pathIndex;

        private List<int> path;

        List<int> IPrintPath.Path { get => path;  }

        public PrintPath(IFrameWork frameWork, IDrawingModulePL view, IDijkstra dijkstra)
        {
            this.frameWork = frameWork;
            this.view = view;
            this.dijkstra = dijkstra;
            path = new List<int>();
        }

        void IPrintPath.Print(int[,] graph, int sourceNode, int destinationNode)
        {
            InitializePrint();

            path = dijkstra.DijkstraAlg(graph, sourceNode, destinationNode);

            if (path == null)
            {
                IItemActive source = frameWork.GetItemActive(sourceNode);
                IItemActive destination = frameWork.GetItemActive(sourceNode);
                MessageBox.Show("Nincs út " + source.DeviceID +
                    " és " + destination.DeviceID + " között!");
            }
            else
            {
                int pathLength = 0;
                int index = 0;
                IItemActive item;
                for (; index < path.Count - 1; index++)
                {
                    item = frameWork.GetItemActive(path[index]);
                    pathLength += graph[path[index], path[index + 1]];
                    PrintItemAndConnection((SymbolName)item.SymbolID);
                }
                item = frameWork.GetItemActive(path[index]);
                PrintSingleItem((SymbolName)item.SymbolID);
            }
        }

        private void InitializePrint()
        {
            view.ClearPath();
            pathIndex = 0;
            path = new List<int>();
        }

        private void PrintItemAndConnection(SymbolName symbolName)
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
