using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untari.Console;

namespace Untari.RIOT
{
    public class RIOT : IBusDevice, IClockedDevice
    {
        private int _timerCount;

        // RIOT addresses
        private const int SWCHA_ADDRESS = 0x00;
        private const int SWACNT_ADDRESS = 0x01;
        private const int SWCHB_ADDRESS = 0x02;


        public RIOT()
        {
            _timerCount = 0;
        }

        public void Tick()
        {
            _timerCount--;
            if(_timerCount <= 0)
            {

            }
        }

        // Chip Select Mask (A7=1, A12=0)
        private const int CHIP_SELECT_MASK = 0x1280;
        private const int CHIP_SELECT = 0x0280;
        private const int CHIP_RAM_SELECT = 0x0080;

        public byte GetByte(int address)
        {
            if( (address & CHIP_SELECT_MASK) == CHIP_SELECT)
            {

            }
            else if((address & CHIP_SELECT_MASK) == CHIP_SELECT)
            {

            }
            else if((address & CHIP_SELECT_MASK) == CHIP_SELECT)
            {

            }
            return 0;
        }

        public void WriteByte(int address, byte data)
        {
            
        }
    }
}
