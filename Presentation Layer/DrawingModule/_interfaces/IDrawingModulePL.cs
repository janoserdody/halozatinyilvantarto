using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DrawingModule._interfaces
{
    public interface IDrawingModulePL
    {
        void ImageLoad(int x, int y, Bitmap image);

        int RowNumber { get; }

        int ColumnNumber { get; }


    }
}
