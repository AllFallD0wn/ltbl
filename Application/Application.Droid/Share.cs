using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LTBLApplication.Droid;
using Share.Forms.Plugin.Abstractions;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sharer))]
namespace LTBLApplication.Droid
{
    public class Sharer : IShare
    {
        public void ShareStatus(string status)
        {
            throw new NotImplementedException();
        }

        public void ShareLink(string title, string status, string link)
        {
            throw new NotImplementedException();
        }
    }
}