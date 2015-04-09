using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class DeviceManager
    {
        public DeviceManager()
        {
            this.Devices = new List<IDevice>();
        }

        public void Add(IDevice _device)
        {
            Devices.Add(_device);
        }
        public List<IDevice> Devices { get; set; }
    }
}
