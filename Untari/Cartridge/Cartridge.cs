using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untari.Console;

namespace Untari.Cartridge
{
    // Cartridges come in a variety of memory mappings.  
    // Each map will have its own subclass.
    public abstract class Cartridge : IBusDevice, IClockedDevice
    {
        // Chip select and mask
        private const int CART_CHIP_SELECT = 0x1000;
        private const int CART_MASK = 0x1000;

        // I/O address mask
        private const int CART_ADDRESS_MASK = 0x0fff;

        // Placeholder for ROM
        protected byte[] rom;

        public byte GetByte(int address)
        {
            return rom[address & CART_ADDRESS_MASK];
        }

        public bool IsChipSelected(int address)
        {
            return (address & CART_CHIP_SELECT) == CART_MASK;
        }

        public void Tick()
        {
            // do nothing
        }

        public void WriteByte(int address, byte data)
        {
            // writing does nothing
        }
    }
}
