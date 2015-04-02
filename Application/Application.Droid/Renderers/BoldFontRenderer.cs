using Android.Graphics;
using LTBLApplication.Controls;
using LTBLApplication.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BoldFontLabel), typeof(BoldFontRenderer))]
namespace LTBLApplication.Droid.Renderers
{
    public class BoldFontRenderer : LabelRenderer
    {
        private const string FontName = "Roboto-Bold.ttf";

        protected override void OnElementChanged(ElementChangedEventArgs<Label> _e)
        {
            base.OnElementChanged(_e);
            var label = Control;
            var font = Typeface.CreateFromAsset(Forms.Context.Assets, FontName);
            label.Typeface = font;
        }
    }
}