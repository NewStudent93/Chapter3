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

        public RotateTransforms()
        {
            InitializeComponent();
            rotationCenter = CreateEllipse(6, 6, Canvas.GetLeft(rect), Canvas.GetTop(rect));
            canvas1.Children.Add(rotationCenter);
        }

        private void canvas1_OnMouseLeftButtonDown(object sender, MouseEventArgs e)
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

        Ellipse CreateEllipse(double width, double height, double desiredCenterX, double desiredCenterY)
        {
            Ellipse ellipse = new Ellipse { Width = width, Height = height };
            double left = desiredCenterX - (width / 2);
            double top = desiredCenterY - (height / 2);
            ellipse.Fill = Brushes.Red;

            ellipse.Margin = new Thickness(left, top, 0, 0);
            return ellipse;
        }

    }
}
