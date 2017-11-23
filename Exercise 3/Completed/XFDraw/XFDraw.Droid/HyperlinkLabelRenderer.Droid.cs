using Android.Text.Util;
using Android.Widget;
using XFDraw;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFDraw.Droid;
using Android.Content;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace XFDraw.Droid
{
    class HyperlinkLabelRenderer : LabelRenderer
    {
        public HyperlinkLabelRenderer (Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Linkify.AddLinks(Control, MatchOptions.All);
        }
    }
}
