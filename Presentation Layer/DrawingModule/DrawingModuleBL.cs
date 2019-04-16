using BusinessLayer.DrawingModule;
using BusinessLayer.Interfaces;
using Common.Interfaces;
using static Common.Helpers;

namespace PresentationLayer.DrawingModule
{
    public class DrawingModuleBL
    {
        private PrintPath printPath;

        private IFrameWork frameWork;

        private DrawingModulePL view;

        public DrawingModuleBL(IFrameWork frameWork, DrawingModulePL view)
        {
            this.frameWork = frameWork;
            this.view = view;
        }

        public void Drawing()
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

            printPath = new PrintPath(frameWork, view);
            int sourceNode = 101;
            int destinationNode = 102;
            printPath.Print(halozat, sourceNode, destinationNode);
        }
    }
}
