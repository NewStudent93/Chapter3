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
    /// Interaction logic for RotateTransforms.xaml
    /// </summary>
    public partial class RotateTransforms : Window
    {
        Ellipse rotationCenter = new Ellipse();
        Point positionMouse;

        public RotateTransforms()
        {
            InitializeComponent();
            rotationCenter = CreateEllipse(6, 6, Canvas.GetLeft(rect), Canvas.GetTop(rect));
            canvas1.Children.Add(rotationCenter);
        }

        private void canvas1_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            positionMouse = e.GetPosition(this);
            
        }
        
        Ellipse CreateEllipse(double width, double height, double desiredCenterX, double desiredCenterY)
        {
            Ellipse ellipse = new Ellipse { Width = width, Height = height };
            double left = desiredCenterX - (width / 2);
            double top = desiredCenterY - (height / 2);
            ellipse.Fill = Brushes.Red;

            ellipse.Margin = new Thickness(left, top, 0, 0);
            return ellipse;
        }


        // Event raised on mouse down in the ZoomAndPanControl
        private void zoomAndPanControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoomAndPanEvents.MouseDown(sender, e, canvas1, zoomAndPanControl);
        }

        // Event raised on mouse up in the ZoomAndPanControl
        private void zoomAndPanControl_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (positionMouse == e.GetPosition(this))
            {
                canvas1.Children.Remove(rotationCenter);

                double x1 = Canvas.GetLeft(rect);
                double y1 = Canvas.GetTop(rect);

                Point p = new Point();
                p = e.GetPosition(canvas1);

                rotationCenter = CreateEllipse(6, 6, p.X, p.Y);
                canvas1.Children.Add(rotationCenter);

                rotate.CenterX = p.X - x1;
                rotate.CenterY = p.Y - y1;
            }

            ZoomAndPanEvents.MouseUp(sender, e, zoomAndPanControl);
        }

        // Event raised on mouse move in the ZoomAndPanControl
        private void zoomAndPanControl_MouseMove(object sender, MouseEventArgs e)
        {

            ZoomAndPanEvents.MouseMove(sender, e, canvas1, zoomAndPanControl);

        }

        // Event raised by rotating the mouse wheel
        private void zoomAndPanControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ZoomAndPanEvents.MouseWheel(sender, e, zoomAndPanControl,canvas1);
        }


        // Event raised on mouse down in the ZoomAndPanControl1
        private void zoomAndPanControl1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoomAndPanEvents.MouseDown(sender, e, canvas2, zoomAndPanControl1);
        }

        // Event raised on mouse up in the ZoomAndPanControl
        private void zoomAndPanControl1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ZoomAndPanEvents.MouseUp(sender, e, zoomAndPanControl1);
        }

        // Event raised on mouse move in the ZoomAndPanControl
        private void zoomAndPanControl1_MouseMove(object sender, MouseEventArgs e)
        {
            ZoomAndPanEvents.MouseMove(sender, e, canvas2, zoomAndPanControl1);

        }

        // Event raised by rotating the mouse wheel
        private void zoomAndPanControl1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ZoomAndPanEvents.MouseWheel(sender, e, zoomAndPanControl1,canvas2);
        }


    }
}
