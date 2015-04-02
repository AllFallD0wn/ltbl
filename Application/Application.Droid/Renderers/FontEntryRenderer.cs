using Android.Graphics;
using LTBLApplication.Controls;
using LTBLApplication.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontEntry), typeof(FontEntryRenderer))]
namespace LTBLApplication.Droid.Renderers
{
    public class FontEntryRenderer : EntryRenderer
    {
        private const string FontName = "Roboto-Regular.ttf";

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> _e)
        {
            base.OnElementChanged(_e);
            var label = Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, FontName);
            label.Typeface = font;
        }
    }
}