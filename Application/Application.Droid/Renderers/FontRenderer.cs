using Android.Graphics;
using Android.Widget;
using LTBLApplication.Controls;
using LTBLApplication.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontLabel), typeof(FontRenderer))]
namespace LTBLApplication.Droid.Renderers
{

    public class FontRenderer : LabelRenderer
    {
        private const string FontName = "Roboto-Light.ttf";

        protected override void OnElementChanged(ElementChangedEventArgs<Label> _e)
        {
            base.OnElementChanged(_e);
            var label = Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, FontName);
            label.Typeface = font;
        }
    }
}


