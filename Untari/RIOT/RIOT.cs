using System;
using Untari.Console;

namespace Untari.RIOT
{
    public class RIOT : IBusDevice, IClockedDevice
    {
        // Chip Select bits
        // A12 = /CS2
        // A7 = CS1
        //
        // RAM select
        // A9 = /RS

        // Chip select and mask
        private const int PIA_CHIP_SELECT = 0x0280;
        private const int PIA_MASK = 0x1280;

        // I/O address mask
        private const int PIA_ADDRESS_MASK = 0x0007;

        // RIOT addresses
        private const int SWCHA_ADDRESS = 0x00;
        private const int SWACNT_ADDRESS = 0x01;
        private const int SWCHB_ADDRESS = 0x02;
        private const int SWBCNT_ADDRESS = 0x03;
        private const int INTIM_ADDRESS = 0x04;

        // RIOT registers
        private byte SWCHA;      // Port A (bits 0-3 player 1 UDLR, bits 4-7 player 0 UDLR)
        //private byte SWACNT;     // Port A data direction register (DDR)  NOT USED
        private byte SWCHB;      // Port B (input only, console switches)
        //private byte SWBCNT;     // Port B data direction register (DDR)  NOT USED
        private byte INTIM;      // Timer output (read only)
        private byte TIM1T;      // set timer to 1 clock intervals
        private byte TIM8T;      // set timer to 8 clock intervals
        private byte TIM64T;     // set timer to 64 clock intervals
        private byte T1024T;     // set timer to 1024 clock intervals

        // timer counters
        private int _timerCount;
        private int _currentInterval;
        private int _lastInterval;

        public RIOT()
        {
            Boot();
        }

        public void Boot()
        {
            // chip initializes to the largest interval
            _timerCount = 1024;
            _currentInterval = 1024;
            _lastInterval = 1024;

            // initialize registers
            SWCHA = 0xff;
            SWCHB = 0x0b;

            // timer output is a random value on power up between 0x00 - 0xff
            System.Random rnd = new Random();
            INTIM = (byte)(rnd.Next(0, 0x100) & 0xff);
        }

        public void Tick()
        {
            _timerCount--;
            if(_timerCount <= 0)
            {
                DecrementTimer();
            }
        }

        public bool IsChipSelected(int address)
        {
            return (address & PIA_CHIP_SELECT) == PIA_MASK;
        }


        public byte GetByte(int address)
        {
            int reg = address & PIA_ADDRESS_MASK;
            byte result = 0;
            switch(reg)
            {
                case 0x00:  // 0x0280
                    result = SWCHA;
                    break;
                case 0x02:  // 0x0282
                    result = SWCHB;
                    break;
                case 0x04:  // 0x0284
                case 0x06:
                    if (_currentInterval == 1)
                    {
                        _currentInterval = _lastInterval;
                        _timerCount = _lastInterval;
                    }
                    result = INTIM;
                    break;
                // 0x01 (0x0281) and 0x03 (0x0283) are reading SWACNT.  For emulation this can return 0.
                // default:
                    //throw new InvalidOperationException("Invalid PIA read address " + address.ToString("X4"));
                    // do nothing
                    // the RIOT has an interrupt flag register at 0x0285 but it is unused by the 6507 used in the 2600.
            }
            return result;
        }

        public void WriteByte(int address, byte data)
        {
            int reg = address & PIA_ADDRESS_MASK;
            switch(reg)
            {
                case 0x04:
                    SetTimer(data, 1);
                    TIM1T = data;
                    break;
                case 0x05:
                    SetTimer(data, 8);
                    TIM8T = data;
                    break;
                case 0x06:
                    SetTimer(data, 64);
                    TIM64T = data;
                    break;
                case 0x07:
                    SetTimer(data, 1024);
                    T1024T = data;
                    break;
            }
        }

        private void SetTimer(byte timer_value, int timer_interval)
        {
            INTIM = timer_value;
            _timerCount = timer_interval;
            _currentInterval = timer_interval;
            _lastInterval = timer_interval;
            DecrementTimer();
        }

        private void DecrementTimer()
        {
            INTIM--;

            if(INTIM < 0)
            {
                INTIM = 0xff;
                _timerCount = 1;
                _currentInterval = 1;           // docs state interval reverts to 1 upon overflow
            }
            else
            {
                _timerCount = _currentInterval;
            }
        }
    }
}
