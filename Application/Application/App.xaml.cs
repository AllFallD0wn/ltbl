using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base;
using LTBLApplication.Controls;
using LTBLApplication.Views;
using Xamarin.Forms;

namespace LTBLApplication
{
    public partial class App : Application
    {
        public DeviceManager Devices = new DeviceManager();
        public App()
        {
            InitializeComponent();

            LTBLApplication.Resources.LoadDevices();
            // The root page of your application
            MainPage = GetMainPage();

        }

        /// <summary>
        /// Returns the main (first) page
        /// </summary>
        /// <returns></returns>
        public static Page GetMainPage()
        {
            return new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void ButtonClicked(object _sender, EventArgs _e)
        {
            var button = (UniqueButton)_sender;
            var btn = ((App) Current).Devices.Devices.Single(a => a.Id == button.UniqueId);
            var text = btn.Invoke();
            MainPage.DisplayAlert("Returned", text, "OK");
        }
    }
}
