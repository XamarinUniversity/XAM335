using System;
using Xamarin.Forms;

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

            ToolbarItems.Add(new ToolbarItem("New Color", "pencil.png", OnColorClicked));
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