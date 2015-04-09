using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Base;
using Newtonsoft.Json;

namespace LayoutCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeviceModel context = new DeviceModel();
        DeviceManager manager = new DeviceManager();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = context;
        }

        private void ButtonBase_OnClick(object _sender, RoutedEventArgs _e)
        {
            manager.Devices.Add(context.CreateDevice());
            Save();
        }

        private void Save()
        {
            var text = JsonConvert.SerializeObject(manager, Formatting.Indented, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = 0
            });
            var file = "devices.abc";
            System.IO.StreamWriter writer = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), file));
            writer.Write(text);
            writer.Flush();
            writer.Close();
        }
    }
}
