using System;
using System.Collections.Generic;
using Base;
using LTBLApplication.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xamarin.Forms;

namespace LTBLApplication
{
    public static class Resources
    {
        public static void AddDevice(IDevice _device)
        {
            ((App)Application.Current).Devices.Add(_device);
            SaveDevices();
            HomeView.DeviceAdded(new object(), new EventArgs());
        }

        public static void SaveDevices()
        {
            var text = JsonConvert.SerializeObject(((App)Application.Current).Devices, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });
            DependencyService.Get<ISaveLoad>().Save("devices.abc", text);
        }

        public static void LoadDevices()
        {
            var text = DependencyService.Get<ISaveLoad>().Load("devices.abc");
            if (text == null)
                return;
            ((App)Application.Current).Devices = JsonConvert.DeserializeObject<DeviceManager>(text, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            });
        }
    }

}
