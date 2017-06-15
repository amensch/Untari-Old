﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untari
{
    public interface IBusDevice
    {
        byte GetByte(int address);
        void WriteByte(int address, byte data);
    }
}
