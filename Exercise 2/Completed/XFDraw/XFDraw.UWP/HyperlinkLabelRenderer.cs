using XFDraw;
using XFDraw.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.System;

[assembly: ExportRenderer(typeof(HyperlinkLabel), typeof(HyperlinkLabelRenderer))]
namespace XFDraw.UWP
{
    class HyperlinkLabelRenderer : LabelRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
       {
            if (Control != null && Element != null)
                Control.Tapped += (sender, args) => Launcher.LaunchUriAsync(new System.Uri(Element.Text)).GetResults();
       }
    }
}