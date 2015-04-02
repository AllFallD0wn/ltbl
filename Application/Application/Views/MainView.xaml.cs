﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Get rid of SelectedItem and hide the menu
            Master = new MainMenu();
            IsPresented = false;
        }
    }
}
