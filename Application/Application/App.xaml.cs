using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Dictionary<int, string> Defaults = new Dictionary<int, string>
        {
            {0, "M"},
            {1, "N"},
            {2, "G"},
            {3, "Q"},
            {4, "H"},
            {5, "R"},
            {6, "I"},
            {7, "S"},
            {8, "J"},
            {9, "T"},
            {10, "K"},
            {11, "U"},
            {12, "L"},
            {13, "V"}
        };

        public App()
        {
            InitializeComponent();

            //COMMENTED OUT FOR DEBUG
            //LTBLApplication.Resources.LoadDevices();

            //FIRST TIME SETUP
            //if (Devices.Devices.Count == 0)
            //{
            //    //config
            //    Config();
            //}
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
            var text = DependencyService.Get<IMessage>().Invoke(btn.Message);
            if (text.Result != null)
                MainPage.DisplayAlert("Returned", text.Result, "OK");
        }

        public void SliderSlided(object _sender, ValueChangedEventArgs _e)
        {
            var slider = (UniqueSlider) _sender;
            var slide = ((App) Current).Devices.Devices.Single(a => a.Id == slider.UniqueId);
            var text = DependencyService.Get<IMessage>().Invoke(slide.Message);
                MainPage.DisplayAlert("Returned", text.Result, "OK");
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

        private void MakeButtons(int count)
        {
            for(var i = 0; i < (count * 2) + 2; i++)
            {
                var value = "";
                var toAdd = Defaults.TryGetValue(i, out value);
                var raiseLower = "";
                if (i%2 == 0)
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
                Devices.Add(btn);
            }
        }
    }
}
