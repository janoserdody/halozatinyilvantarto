using BusinessLayer.DrawingModule;
using BusinessLayer.Interfaces;
using Common.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using static Common.Helpers;

namespace PresentationLayer.DrawingModule
{
    public class DrawingModuleBL : IDrawingModuleBL
    {
        private IPrintPath printPath;

        private IFrameWork frameWork;

        public DrawingModuleBL(IFrameWork frameWork, IPrintPath printPath)
        {
            this.frameWork = frameWork;
            this.printPath = printPath;
        }

        void IDrawingModuleBL.Drawing()
        {
            int[,] halozat = new int[frameWork.ItemActiveCount + 1, frameWork.ItemActiveCount + 1];

            // Kapcsolatok feltöltése
            for (int i = 1; i < frameWork.ConnectionCount; i++)
            {
                IConnection connection = frameWork.GetConnection(i);
                halozat[connection.SourceItemId, connection.DestinationItemId] = 1;
                // Ellentétesen is, mindegyiket kétirányúnak véljük, nem súlyozunk, de azt is lehetne
                halozat[connection.DestinationItemId, connection.SourceItemId] = 1;
            }

            int sourceNode = 101;
            int destinationNode = 102;
            printPath.Print(halozat, sourceNode, destinationNode);
        }
    }
}
