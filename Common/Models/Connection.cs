using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Connection : IConnection
    {
        private int id;
        private string name;
        private int sourceItemId;
        private int sourcePortId;
        private int destinationItemId;
        private int destinationPortId;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int SourceItemID { get => sourceItemId; set => sourceItemId = value; }
        public  int SourcePortID { get => sourcePortId; set => sourcePortId = value; }
        public  int DestinationItemID { get => destinationItemId; set => destinationItemId = value; }
        public  int DestinationPortID { get => destinationPortId; set => destinationPortId = value; }
    }
}
