using Android.Graphics;
using Android.Widget;
using LTBLApplication.Controls;
using LTBLApplication.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontLabel), typeof(FontRenderer))]
namespace LTBLApplication.Droid.Renderers
{
    public class FontRenderer : EntryRenderer
    {
        private const string FontName = "Roboto-Light.ttf";

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> _e)
        {
            base.OnElementChanged(_e);

            if (Control == null)
            {
                return;
            }
            var label = (TextView) Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, FontName);
            label.Typeface = font;
        }
    }
}