using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untari.Console
{
    public class SystemBus
    {
        List<IBusDevice> devices;

        public SystemBus()
        {
            devices = new List<IBusDevice>();
        }

        public void AddBusDevice(IBusDevice device)
        {
            devices.Add(device);
        }

        public byte GetByte(int address)
        {
            foreach(IBusDevice device in devices)
            {
                if(device.IsChipSelected(address))
                {
                    return GetByte(address);
                }
            }
            throw new InvalidOperationException("No device for address " + address.ToString("X4"));
        }

        public void WriteByte(int address, byte data)
        {
            foreach(IBusDevice device in devices)
            {
                if(device.IsChipSelected(address))
                {
                    device.WriteByte(address, data);
                    break;
                }
            }
        }
    }
}
