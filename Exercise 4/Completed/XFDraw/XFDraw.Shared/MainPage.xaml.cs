using System;
using Xamarin.Forms;

#if __ANDROID__
using XFDraw.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Support.Design.Widget;
using Android.Widget;
#endif

namespace XFDraw
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var trash = new ToolbarItem()
            {
                Text = "Clear",
                Icon = "trash.png",
            };
            trash.Clicked += (o, s) => OnClearClicked();
            
            ToolbarItems.Add(trash);

#if __ANDROID__
            var actionButton = new FloatingActionButton(MainActivity.Activity);

            actionButton.SetImageResource(XFDraw.Droid.Resource.Drawable.pencil);
            actionButton.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Color.Green.ToAndroid());

            actionButton.Click += (s, e) =>
            {
            	OnColorClicked();
            	actionButton.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(sketchView.InkColor.ToAndroid());
            };

            var actionButtonFrame = new FrameLayout(MainActivity.Activity);
            actionButtonFrame.SetClipToPadding(false);
            actionButtonFrame.SetPadding(0, 0, 50, 50);
            actionButtonFrame.AddView(actionButton);

            var actionButtonFrameView = actionButtonFrame.ToView();
            actionButtonFrameView.HorizontalOptions = LayoutOptions.End;
            actionButtonFrameView.VerticalOptions = LayoutOptions.End;

            mainLayout.Children.Add(actionButtonFrameView);
#else
            ToolbarItems.Add(new ToolbarItem("New Color", "pencil.png", OnColorClicked));
#endif
        }

        void OnClearClicked ()
        {

        }

        void OnColorClicked ()
        {
            sketchView.InkColor = GetRandomColor();
        }

        Random rand = new Random();
        Color GetRandomColor ()
        {
            return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
        }
    }
}