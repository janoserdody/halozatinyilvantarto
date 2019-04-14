using BusinessLayer;
using BusinessLayer.DrawingModule;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            // Hálózati elemek
            HalozatiElemek[] Htomb = SetupNetworkItems();

            // Összerendelések
            Vonal[] Vtomb = SetupConnections();

            int[,] halozat = new int[Htomb.Length, Htomb.Length];
            // Kapcsolatok feltöltése
            for (int i = 0; i < Vtomb.Length; i++)
            {
                halozat[Vtomb[i].Obj1, Vtomb[i].Obj2] = 1;
                // Ellentétesen is, mindegyiket kétirányúnak véljük, nem súlyozunk, de azt is lehetne
                halozat[Vtomb[i].Obj2, Vtomb[i].Obj1] = 1;
            }

            // Igy néz ki a gráfunk
            //Console.WriteLine("A gráfunk:");
            //for (int i = 0; i < Htomb.Length; i++)
            //{
            //    for (int j = 0; j < Htomb.Length; j++)
            //    {
            //        //Console.Write(halozat[i, j].ToString() + ' ');
            //    }
            //    //Console.WriteLine();
            //}

            printPath = new PrintPath(frameWork, view);
            int sourceNode = 8;
            int destinationNode = 9;
            printPath.Print(halozat, sourceNode, destinationNode, Htomb, Vtomb);
        }

        private static Vonal[] SetupConnections()
        {
            Vonal[] Vtomb = new Vonal[9];
            Vtomb[0] = new Vonal(0, "Eszk.belül", 0, 1);
            Vtomb[1] = new Vonal(1, "Eszk.belül", 0, 2);
            Vtomb[2] = new Vonal(2, "Eszk.belül", 0, 3);
            Vtomb[3] = new Vonal(3, "Eszk.belül", 0, 4);
            Vtomb[4] = new Vonal(4, "UTP", 1, 6);
            Vtomb[5] = new Vonal(5, "UTP", 3, 7);
            Vtomb[6] = new Vonal(6, "UTP", 4, 8);
            Vtomb[7] = new Vonal(7, "UTP", 6, 5);
            Vtomb[8] = new Vonal(8, "UTP", 7, 9);
            return Vtomb;
        }

        private static HalozatiElemek[] SetupNetworkItems()
        {
            HalozatiElemek[] Htomb = new HalozatiElemek[10];
            Htomb[0] = new HalozatiElemek(0, "switch", SymbolName.Switch);
            Htomb[1] = new HalozatiElemek(1, "switch p1", SymbolName.Switch);
            Htomb[2] = new HalozatiElemek(2, "router P2", SymbolName.Router);
            Htomb[3] = new HalozatiElemek(3, "router P3", SymbolName.Router);
            Htomb[4] = new HalozatiElemek(4, "switch P4", SymbolName.Switch);
            Htomb[5] = new HalozatiElemek(5, "2/1 faliport", SymbolName.Bridge);
            Htomb[6] = new HalozatiElemek(6, "iroda", SymbolName.Server);
            Htomb[7] = new HalozatiElemek(7, "tárgyaló", SymbolName.Pc);
            Htomb[8] = new HalozatiElemek(8, "titkárnő", SymbolName.Pc);
            Htomb[9] = new HalozatiElemek(9, "2/1 fali port", SymbolName.Pc);
            return Htomb;
        }
    }
}
