using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using LTBLApplication.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
            var sliders = ((App) Application.Current).Devices.Devices.Where(a => a is Base.Slider).ToList();
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            
            for (int i = 0; i < (buttons.Count / 2) + sliders.Count; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            }

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var columnCount = 0;
            var rowCount = 0;
            foreach (var b in buttons)
            {
                AddChild(grid, MakeButton(b), rowCount, columnCount, 1, 1);
                columnCount += 1;
                if (columnCount != 2)
                {
                    continue;
                }
                rowCount += 1;
                columnCount = 0;
            }
            if (columnCount != 0)
            {
                rowCount += 1;
            }
            foreach (var s in sliders)
            {
                AddChild(grid, 
                    new Label() {
                    Text = s.Name, 
                    TextColor = new Color(0,0,0), 
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    }, rowCount, 0);

                var slider = MakeSlider((Base.Slider)s);
                AddChild(grid, slider, rowCount, 1, 1, 2);
                rowCount += 1;
            }
            Content = grid;
        }

        public static void AddChild(Grid grid, View view, int row, int column, int rowspan = 1, int columnspan = 1)
        {
            if (row < 0)
                throw new ArgumentOutOfRangeException("row");
            if (column < 0)
                throw new ArgumentOutOfRangeException("column");
            if (rowspan <= 0)
                throw new ArgumentOutOfRangeException("rowspan");
            if (columnspan <= 0)
                throw new ArgumentOutOfRangeException("columnspan");
            if (view == null)
                throw new ArgumentNullException("view");

            try
            {
                Grid.SetRow((BindableObject)view, row);
                Grid.SetRowSpan((BindableObject)view, rowspan);
                Grid.SetColumn((BindableObject)view, column);
                Grid.SetColumnSpan((BindableObject)view, columnspan);

                grid.Children.Add(view);
            }
            catch (Exception e)
            {
                throw e;
            }

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

        private UniqueSlider MakeSlider(Base.Slider _s)
        {
            var slider = new UniqueSlider()
            {
                UniqueId = _s.Id,
                
            };
            if (_s.MaxValue > 0)
                slider.Maximum = _s.MaxValue;
            slider.ValueChanged += SliderOnValueChanged;
            return slider;
        }

        private void SliderOnValueChanged(object _sender, ValueChangedEventArgs _valueChangedEventArgs)
        {
            ((App)Application.Current).SliderSlided(_sender, _valueChangedEventArgs);
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
