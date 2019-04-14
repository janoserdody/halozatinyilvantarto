using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Helpers;

namespace BusinessLayer.DrawingModule
{
    public class HalozatiElemek
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public SymbolName ItemType { get; set; }

        public HalozatiElemek(int id, string name, SymbolName symbolName)
        {
            this.ID = id;
            Name = name;
            this.ItemType = symbolName;
        }
    }
}
