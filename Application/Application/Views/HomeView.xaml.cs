using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class HomeView : ContentPage
    {
        public static EventHandler DeviceAdded;
        public HomeView()
        {
            InitializeComponent();
            MainView.ItemsSource = LTBLApplication.Resources.Devices;
            DeviceAdded += DeviceAddedEvent;
            MainView.ItemSelected += MainViewOnItemSelected;
        }

        private void MainViewOnItemSelected(object _sender, SelectedItemChangedEventArgs _selectedItemChangedEventArgs)
        {
            var view = (ListView) _sender;
            var sender = (IDevice)view.SelectedItem;
            string reply = sender.Invoke();
            if (reply != null)
            {
                DisplayAlert("RETURNED", reply, "OK", "Cancel");
            }
        }

        private void DeviceAddedEvent(object _sender, EventArgs _eventArgs)
        {
            MainView.ItemsSource = null;
            MainView.ItemsSource = LTBLApplication.Resources.Devices;
        }
    }
}
