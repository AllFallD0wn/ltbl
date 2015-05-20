using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class AddSliderView : ContentPage
    {
        public AddSliderView()
        {
            InitializeComponent();
            TypePicker.Items.Add("TCP");
            TypePicker.Items.Add("UDP");
        }

        private void Button_OnClicked(object _sender, EventArgs _e)
        {
            Navigation.PopAsync();
        }
    }
}
