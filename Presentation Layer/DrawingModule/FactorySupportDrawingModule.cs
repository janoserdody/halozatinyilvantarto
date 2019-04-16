using BusinessLayer.DrawingModule;
using BusinessLayer.DrawingModule._interfaces;
using BusinessLayer.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DrawingModule
{
    public class FactorySupportDrawingModule : IFactorySupportDrawingModule
    {
        private IDrawingModulePL drawingModulePL;
        private IFrameWork frameWork;
        private IPrintPath printPath;
        private IDrawingModuleBL drawingModuleBL;
        private IDijkstra dijkstra;

        public FactorySupportDrawingModule(IDrawingModulePL drawingModulePL, IFrameWork frameWork)
        {
            this.drawingModulePL = drawingModulePL;
            this.frameWork = frameWork;
            dijkstra = new Dijkstra();
        }

        IPrintPath IFactorySupportDrawingModule.CreatePrintPath()
        {
            printPath = new PrintPath(frameWork, drawingModulePL, dijkstra);
            return printPath;
        }

        IDrawingModuleBL IFactorySupportDrawingModule.CreateDrawingModuleBL()
        {
            drawingModuleBL = new DrawingModuleBL(frameWork, printPath);
            return drawingModuleBL;
        }

       
    }
}
