﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Interfaces
{
    public interface IConnection
    {
        int Id { get; set; }

        string Name { get; set;}

        int SourceItemID { get; set; }

        int SourcePortID { get; set; }

        int DestinationItemID { get; set; }

        int DestinationPortID { get; set; }

    }
}
