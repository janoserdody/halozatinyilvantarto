﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRegisterConnector
    {
        IConnectorWall this[int ID] { get; }

        bool Add(IConnectorWall connector);

        bool Remove(IConnectorWall connector);

        bool Remove(int id);
    }
}
