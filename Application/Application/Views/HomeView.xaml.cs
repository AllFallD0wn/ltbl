using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using LTBLApplication.Controls;
using Xamarin.Forms;
using Button = Base.Button;

namespace LTBLApplication.Views
{
    public partial class HomeView : ContentPage
    {
        public static EventHandler DeviceAdded;
        public HomeView()
        {
            InitializeComponent();
            DeviceAdded += DeviceAddedEvent;
            BuildDisplay();
        }
        //private void MainViewOnItemSelected(object _sender, SelectedItemChangedEventArgs _selectedItemChangedEventArgs)
        //{
        //    var view = (ListView) _sender;
        //    var sender = (IDevice)view.SelectedItem;
        //    string reply = sender.Invoke();
        //    if (reply != null)
        //    {
        //        DisplayAlert("RETURNED", reply, "OK", "Cancel");
        //    }
        //}

        private void BuildDisplay()
        {
            var grid = new Grid { Padding = 10 };

            var buttons = ((App)Application.Current).Devices.Devices.Where(a => a is Button).ToList();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            for (int i = 0; i < buttons.Count / 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var columnCount = 0;
            var rowCount = 0;
            foreach (var b in buttons)
            {
                grid.Children.Add(MakeButton(b), columnCount, rowCount);
                columnCount += 1;
                if (columnCount != 3)
                {
                    continue;
                }
                rowCount += 1;
                columnCount = 0;
            }

            Content = grid;
        }

        private UniqueButton MakeButton(IDevice _b)
        {
            var btn = new UniqueButton()
            {
                UniqueId = _b.Id,
                Text = _b.Name,
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                BorderRadius = 0
            };
            
            btn.Clicked += ButtonClicked;
            return btn;
        }

        protected void ButtonClicked(object _sender, EventArgs _e)
        {
            ((App)Application.Current).ButtonClicked(_sender, _e);
        }

        private void DeviceAddedEvent(object _sender, EventArgs _eventArgs)
        {
            BuildDisplay();
        }
    }
}
