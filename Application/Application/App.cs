using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LTBLApplication.Views;
using Xamarin.Forms;

namespace LTBLApplication
{
    public class App : Application
    {
        public DeviceManager Devices = new DeviceManager();
        public App()
        {
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
    }
}
