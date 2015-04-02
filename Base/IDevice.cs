using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base
{
    public interface IDevice
    {
        //Name of the device
        string Name { get; set; }
        //IP Address of the device
        string Address { get; set; }
        //Port of the device
        int Port { get; set; }
        //Type of packet to send
        NetworkType Type { get; set; }
    }
}
