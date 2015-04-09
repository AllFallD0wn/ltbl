using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LTBLApplication.Views
{
    public partial class MainView
    {
        public static EventHandler Appeared;
        public MainView()
        {
            InitializeComponent();
            Appeared += AppearedEvent;
        }

        private void AppearedEvent(object _sender, EventArgs _eventArgs)
        {
            IsPresented = false;
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
