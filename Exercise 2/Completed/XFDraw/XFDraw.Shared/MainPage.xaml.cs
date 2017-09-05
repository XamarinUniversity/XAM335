using System;
using Xamarin.Forms;

#if __ANDROID__
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Support.Design.Widget;
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
            var actionButton = new FloatingActionButton(Forms.Context);

            actionButton.SetImageResource(XFDraw.Droid.Resource.Drawable.pencil);
            actionButton.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Color.Green.ToAndroid());

            actionButton.Click += (s, e) =>
            {
            	OnColorClicked();
            };

            var actionButtonFrame = new FrameLayout(Forms.Context);
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

        }

        Random rand = new Random();
        Color GetRandomColor ()
        {
            return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
        }
    }
}