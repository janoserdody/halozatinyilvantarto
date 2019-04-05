using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ItemActive : IItemActive
    {
        private int id;
        private int locationID;
        private int symbolID;
        private string deviceID;
        private string deviceName;
        private string notes;

        // adatbázisból lekérni az eltárolt item id-ját
        // ha id = 0, akkor el kell tárolni az adatbázisba
        public int Id { get => id; set => id = value; } 

        public int LocationID { get => locationID; set => locationID = value; }

        public int SymbolID { get => symbolID; set => symbolID = value; }

        public string DeviceID
        {
            get => deviceID;
            set => deviceID = value;
        }
        public string DeviceName
        {
            get => deviceName;
            set => deviceName = value;
        }
        public string Notes
        {
            get => notes;
            set => notes = value;
        }

        public IError AddConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        public IError AddPort(IPortActive port)
        {
            throw new NotImplementedException();
        }

        public IItemActive Clone(int id)
        {
            this.id = id;
            return this;
        }

        public IConnection GetConnection(int id)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetConnectionsIDList()
        {
            throw new NotImplementedException();
        }

        public IPortActive GetPort(int id)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetPortsIDList()
        {
            throw new NotImplementedException();
        }

        public IError RemoveConnection(IConnection connection)
        {
            throw new NotImplementedException();
        }

        public IError RemoveConnection(int id)
        {
            throw new NotImplementedException();
        }

        public IError RemovePort(IPortActive port)
        {
            throw new NotImplementedException();
        }

        public IError RemovePort(int id)
        {
            throw new NotImplementedException();
        }
    }
}
