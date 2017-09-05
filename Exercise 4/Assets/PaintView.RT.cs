using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace XFDraw.Windows
{
    public class PaintView : Canvas
    {
        public event EventHandler LineDrawn;

        SolidColorBrush brush = new SolidColorBrush(Colors.Green);

        Point oldPoint;

        public PaintView()
        {
            Background = new SolidColorBrush(Colors.Transparent);

            PointerPressed += SketchCanvasPointerPressed;
            PointerMoved += SketchCanvasPointerMoved;
        }

        private void SketchCanvasPointerMoved(object sender, global::Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed == false)
                return;

            var newPoint = e.GetCurrentPoint(this).Position;

            var line = new Line()
            {
                X1 = oldPoint.X,
                Y1 = oldPoint.Y,
                X2 = newPoint.X,
                Y2 = newPoint.Y,
                StrokeThickness = 2.0,
                Stroke = brush
            };

            oldPoint = newPoint;

            Children.Add(line);

            LineDrawn?.Invoke(this, EventArgs.Empty);
        }

        private void SketchCanvasPointerPressed(object sender, global::Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            oldPoint = e.GetCurrentPoint(this).Position;
        }

        public void Clear ()
        {
            Children.Clear();
        }

        public void SetInkColor (Color color)
        {
            brush = new SolidColorBrush(color);
        }
    }
}
