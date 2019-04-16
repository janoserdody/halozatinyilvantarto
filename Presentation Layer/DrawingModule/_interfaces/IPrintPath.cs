using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DrawingModule._interfaces
{
    public interface IPrintPath
    {
        void Print(int[,] graph, int sourceNode, int destinationNode);
    }
}
