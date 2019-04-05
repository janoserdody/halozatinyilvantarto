using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }

        string DeviceID {get; set;} 

        string DeviceName {get; set;}
        
        int LocationID  {get; set;}

        int SymbolID { get; set; }

        string Notes {get; set;}

        /// <summary>
        /// Get the list of the IDs of connections
        /// </summary>
        /// <returns></returns>
        IList<int> GetConnectionsIDList();

        IError AddConnection(IConnection connection);

        IError RemoveConnection(IConnection connection);

        IConnection GetConnection(int id);

        IError RemoveConnection(int id);
        
    }
}
