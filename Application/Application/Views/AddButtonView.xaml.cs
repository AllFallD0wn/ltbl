using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Base;
using LTBLApplication.Models;
using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class AddButtonView : ContentPage
    {
        public AddButtonView()
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
