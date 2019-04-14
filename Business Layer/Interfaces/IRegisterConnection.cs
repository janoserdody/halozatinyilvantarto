﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRegisterConnection
    {
        IConnection this[int ID] { get; }

        bool Add(IConnection connection);

        bool Remove(IConnection connection);

        bool Remove(int id);
    }
}
