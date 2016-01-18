using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chapter3
{
    /// <summary>
    /// Interaction logic for PerpendicularLine.xaml
    /// </summary>
    public partial class PerpendicularLine : Window
    {

        public enum MouseHandlingMode
        {
            // The user is left-dragging rectangles with the mouse
            None,

            // The user is left-mouse-button-dragging to pan the viewport
            Panning,

            // The user is holding down shift and left-clicking or right-clicking to zoom in or out
            Zooming,
        }

        // Specifies the current state of the mouse handling logic
        private MouseHandlingMode mouseHandlingMode = MouseHandlingMode.None;

        // The point that was clicked relative to the ZoomAndPanControl
        private Point origZoomAndPanControlMouseDownPoint;

        /// The point that was clicked relative to the content that is contained within the ZoomAndPanControl.
        /// </summary>
        private Point origContentMouseDownPoint;

        // Records which mouse button clicked during mouse dragging
        private MouseButton mouseButtonDown;

        private Line line1;
        private Line line2;
        public PerpendicularLine()
        {
            InitializeComponent();

            Rectangle rect = new Rectangle();
            rect.Stroke = Brushes.Black;
            rect.Width = canvas1.Width;
            rect.Height = canvas1.Height;
            canvas1.Children.Add(rect);
            line1 = new Line();
            line2 = new Line();
            AddLines();
        }

        private void AddLines()
        {
            Point pt1 = new Point();
            Point pt2 = new Point();
            pt1.X = Convert.ToDouble(tbX1.Text);
            pt1.Y = Convert.ToDouble(tbY1.Text);
            pt2.X = Convert.ToDouble(tbX2.Text);
            pt2.Y = Convert.ToDouble(tbY2.Text);
            double length = 0.5 * Convert.ToDouble(tbLength.Text);
            line1 = new Line();
            line1.X1 = pt1.X;
            line1.Y1 = pt1.Y;
            line1.X2 = pt2.X;
            line1.Y2 = pt2.Y;
            line1.Stroke = Brushes.Gray;
            line1.StrokeThickness = 4;
            canvas1.Children.Add(line1);
            Canvas.SetLeft(tbPoint1, pt1.X);
            Canvas.SetTop(tbPoint1, pt1.Y);
            Canvas.SetLeft(tbPoint2, pt2.X);
            Canvas.SetTop(tbPoint2, pt2.Y);
            tbPoint1.Text = "Pt1(" + pt1.ToString() + ")";
            tbPoint2.Text = "Pt2(" + pt2.ToString() + ")";
            Vector v1 = pt1 - pt2;
            Matrix m1 = new Matrix();
            Point pt3 = new Point();
            Point pt4 = new Point();
            m1.Rotate(-90);
            v1.Normalize();
            v1 *= length;
            line2 = new Line();
            line2.Stroke = Brushes.Gray;
            line2.StrokeThickness = 4;
            line2.StrokeDashArray = DoubleCollection.Parse("3, 1");
            pt3 = pt2 + v1 * m1;
            m1 = new Matrix();
            m1.Rotate(90);
            pt4 = pt2 + v1 * m1;
            line2.X1 = pt3.X;
            line2.Y1 = pt3.Y;
            line2.X2 = pt4.X;
            line2.Y2 = pt4.Y;
            canvas1.Children.Add(line2);
            Canvas.SetLeft(tbPoint3, pt3.X);
            Canvas.SetTop(tbPoint3, pt3.Y);
            Canvas.SetLeft(tbPoint4, pt4.X);
            Canvas.SetTop(tbPoint4, pt4.Y);
            pt3.X = Math.Round(pt3.X, 0);
            pt3.Y = Math.Round(pt3.Y, 0);
            pt4.X = Math.Round(pt4.X, 0);
            pt4.Y = Math.Round(pt4.Y, 0);
            tbPoint3.Text = "Pt3(" + pt3.ToString() + ")";
            tbPoint4.Text = "Pt4(" + pt4.ToString() + ")";
        }
        public void BtnApply_Click(object sender, EventArgs e)
        {
            if (line1 != null)
                canvas1.Children.Remove(line1);
            if (line2 != null)
                canvas1.Children.Remove(line2);
            AddLines();
        }
        public void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event raised on mouse down in the ZoomAndPanControl
        private void zoomAndPanControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canvas1.Focus();
            Keyboard.Focus(canvas1);

            mouseButtonDown = e.ChangedButton;
            origZoomAndPanControlMouseDownPoint = e.GetPosition(zoomAndPanControl);
            origContentMouseDownPoint = e.GetPosition(canvas1);

            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 &&
                (e.ChangedButton == MouseButton.Left ||
                 e.ChangedButton == MouseButton.Right))
            {
                // Shift + left- or right-down initiates zooming mode.
                mouseHandlingMode = MouseHandlingMode.Zooming;
            }
            else if (mouseButtonDown == MouseButton.Left)
            {
                // Just a plain old left-down initiates panning mode.
                mouseHandlingMode = MouseHandlingMode.Panning;
            }

            if (mouseHandlingMode != MouseHandlingMode.None)
            {
                // Capture the mouse so that we eventually receive the mouse up event.
                zoomAndPanControl.CaptureMouse();
                e.Handled = true;
            }
        }

        // Event raised on mouse up in the ZoomAndPanControl
        private void zoomAndPanControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (mouseHandlingMode != MouseHandlingMode.None)
            {
                if (mouseHandlingMode == MouseHandlingMode.Zooming)
                {
                    if (mouseButtonDown == MouseButton.Left)
                    {
                        // Shift + left-click zooms in on the content.
                        ZoomIn();
                    }
                    else if (mouseButtonDown == MouseButton.Right)
                    {
                        // Shift + left-click zooms out from the content.
                        ZoomOut();
                    }
                }

                zoomAndPanControl.ReleaseMouseCapture();
                mouseHandlingMode = MouseHandlingMode.None;
                e.Handled = true;
            }
        }

        // Event raised on mouse move in the ZoomAndPanControl
        private void zoomAndPanControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHandlingMode == MouseHandlingMode.Panning)
            {
                //
                // The user is left-dragging the mouse.
                // Pan the viewport by the appropriate amount.
                //
                Point curContentMousePoint = e.GetPosition(canvas1);
                Vector dragOffset = curContentMousePoint - origContentMouseDownPoint;

                zoomAndPanControl.ContentOffsetX -= dragOffset.X;
                zoomAndPanControl.ContentOffsetY -= dragOffset.Y;

                e.Handled = true;
            }
        }

        // Event raised by rotating the mouse wheel
        private void zoomAndPanControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            if (e.Delta > 0)
            {
                ZoomIn();
            }
            else if (e.Delta < 0)
            {
                ZoomOut();
            }
        }

        // Zoom the viewport out by a small increment
        private void ZoomOut()
        {
            zoomAndPanControl.ContentScale -= 0.1;
        }

        // Zoom the viewport in by a small increment
        private void ZoomIn()
        {
            zoomAndPanControl.ContentScale += 0.1;
        }


        private void zoomAndPanControl_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

        }

    }
}
