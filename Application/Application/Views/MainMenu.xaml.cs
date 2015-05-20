using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Base;
using LTBLApplication.Controls;
using Share.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class MainMenu : ContentPage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
            SetupMenu();
        }

        /// <summary>
        /// Sets up the menu view
        /// </summary>
        public void SetupMenu()
        {
            Menu.ItemsSource = new List<string>
            {
                "New Button",
                "New Slider",
                "Import View",
                "Export View",
                "About",
                "Delete Data",
                "Auto Configure"
            };
            Menu.ItemTapped += Menu_ItemSelected;
        }

        /// <summary>
        /// Called when a menu item is selected by the user
        /// </summary>
        /// <param name="_sender">List View</param>
        /// <param name="_e"></param>
        private async void Menu_ItemSelected(object _sender, ItemTappedEventArgs _e)
        {
            var view = (ListView) _sender;
            var selected = (String)view.SelectedItem;

            switch (selected)
            {
                case "New Button":
                {
                    //navigate to new device page
                    await Navigation.PushAsync(new AddButtonView(), true);
                    break;
                }
                case "New Slider":
                {
                    //navigate to new slider page
                    await Navigation.PushAsync(new AddSliderView(), true);
                    break;
                }
                case "New Switch":
                {
                    //navigate to new switch page
                    await Navigation.PushAsync(new AddSwitchView(), true);
                    break;
                }
                case "Import View":
                {
                    //navigate to Import View page
                    break;
                }
                case "Export View":
                {            
                    break;
                }
                case "About":
                {
                    //navigate to about page
                    break;
                }
                case "Delete Data":
                {
                    ((App)Application.Current).Devices = new DeviceManager();
                    LTBLApplication.Resources.SaveDevices();
                    HomeView.DeviceAdded(this, new EventArgs());
                    break;
                }
                case "Auto Configure":
                {
                    Config();
                    LTBLApplication.Resources.SaveDevices();
                    HomeView.DeviceAdded(this, new EventArgs());
                    break;
                }
            }
            view.SelectedItem = null;
            MainView.Appeared(this, new EventArgs());
        }

        private void Config()
        {
            AbstractMessage message = new AbstractMessage
            {
                Ack = true,
                Address = "192.168.10.26",
                Port = 5050,
                Message = "HYDRACC 0 x",
                Type = NetworkType.TCP
            };
            var result = DependencyService.Get<IMessage>().Invoke(message);
            string text = result.Result;
            string[] lines = text.Split('\r');
            var count = lines.Length - 2;
            MakeButtons(count);
        }

        private void MakeButtons(int _count)
        {
            for (var i = 0; i < (_count * 2) + 2; i++)
            {
                var value = "";
                var toAdd = ((App)Application.Current).Defaults.TryGetValue(i, out value);
                var raiseLower = "";
                if (i % 2 == 0)
                    raiseLower = "Raise";
                else
                {
                    raiseLower = "Lower";
                }
                var btn = new Base.Button()
                {
                    Address = "192.168.10.26",
                    Ack = false,
                    Id = Guid.NewGuid(),
                    MessageText = "HYDRACC 0 " + value,
                    Message = new AbstractMessage
                    {
                        Ack = false,
                        Address = "192.168.10.26",
                        Port = 5050,
                        Message = "HYDRACC 0 " + value,
                        Type = NetworkType.TCP
                    }
                };
                btn.Name = raiseLower;
                var temp = i;
                if (i < 2)
                    btn.Name += " All";
                else
                {
                    if (raiseLower == "Lower")
                        temp -= 1;
                    btn.Name += " " + Math.Round((double)temp / 2, 0);
                }
                ((App)Application.Current).Devices.Add(btn);
            }
        }
    }
}
