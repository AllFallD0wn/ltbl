using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using LTBLApplication.Views;

namespace LTBLApplication
{
    public static class Resources
    {
        public static List<IDevice> Devices = new List<IDevice>();

        public static void AddDevice(IDevice _device)
        {
            Devices.Add(_device);
            SaveDevices();
            HomeView.DeviceAdded(new object(), new EventArgs());
        }

        public static void SaveDevices()
        {
        }

        public static void LoadDevices()
        {
        }
    }
}
