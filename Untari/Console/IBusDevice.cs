using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untari.Console
{
    public interface IBusDevice
    {
        bool IsChipSelected(int address);
        byte GetByte(int address);
        void WriteByte(int address, byte data);
    }
}
