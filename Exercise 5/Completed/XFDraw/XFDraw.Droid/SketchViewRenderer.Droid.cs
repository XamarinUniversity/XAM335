using XFDraw;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFDraw.Droid;
using System.ComponentModel;
using Android.Content;

[assembly: ExportRenderer(typeof(SketchView), typeof(SketchViewRenderer))]
namespace XFDraw.Droid
{
    class SketchViewRenderer : ViewRenderer<SketchView, PaintView>
    {
        Context context;

        public SketchViewRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SketchView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var paintView = new PaintView(context);
                paintView.SetInkColor(Element.InkColor.ToAndroid());
                paintView.LineDrawn += PaintViewLineDrawn;
                SetNativeControl(paintView);

                MessagingCenter.Subscribe<SketchView>(this, "Clear", OnMessageClear);
            }
        }

        void OnMessageClear(SketchView sender)
        {
            if (sender == Element)
                Control.Clear();
        }

        private void PaintViewLineDrawn(object sender, System.EventArgs e)
        {
            ((ISketchController)Element)?.SendSketchUpdated();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SketchView.InkColorProperty.PropertyName)
            {
                Control.SetInkColor(Element.InkColor.ToAndroid());
            }
        }

        protected override void Dispose (bool disposinf)
        {
            MessagingCenter.Unsubscribe<SketchView>(this, "Clear");
            Control.LineDrawn -= PaintViewLineDrawn;
        }
    }
}