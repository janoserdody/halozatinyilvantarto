﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRegisterSymbol
    {
        ISymbol this[int ID] { get; }

        bool Add(ISymbol symbol);

        bool Remove(ISymbol symbol);

        bool Remove(int id);
    }
}