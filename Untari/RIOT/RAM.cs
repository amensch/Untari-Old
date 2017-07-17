using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untari.Console;

namespace Untari.RIOT
{
    public class RAM : IBusDevice
    {
        private byte[] ram = new byte[128];

        // Chip select and mask
        private const int RAM_CHIP_SELECT = 0x0080;
        private const int RAM_MASK = 0x1280;

        // I/O address mask
        private const int RAM_ADDRESS_MASK = 0x007f;

        public void Boot()
        {
            ram = new byte[128];
        }

        public byte GetByte(int address)
        {
            return ram[address & RAM_ADDRESS_MASK];
        }

        public bool IsChipSelected(int address)
        {
            return (address & RAM_CHIP_SELECT) == RAM_MASK;
        }

        public void WriteByte(int address, byte data)
        {
            ram[address & RAM_ADDRESS_MASK] = data;
        }
    }
}
