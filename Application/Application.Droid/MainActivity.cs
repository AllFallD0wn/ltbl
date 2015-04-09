using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Share.Forms.Plugin.Droid;

namespace LTBLApplication.Droid
{
    [Activity(Label = "Application", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle _bundle)
        {
            base.OnCreate(_bundle);

            global::Xamarin.Forms.Forms.Init(this, _bundle);
            LoadApplication(new App());
            ShareImplementation.Init();
        }
    }
}

