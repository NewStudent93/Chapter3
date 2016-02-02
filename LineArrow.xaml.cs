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
    /// Interaction logic for LineArrow.xaml
    /// </summary>
    public partial class LineArrow : Window
    {
        private Line line1;
        private Line line2;
        private Line line3;
        public LineArrow()
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
            double length = 0.2 * Convert.ToDouble(tbLength.Text);
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
            m1.Rotate(-45);
            v1.Normalize();
            v1 *= length;
            line2 = new Line();
            line2.Stroke = Brushes.Gray;
            line2.StrokeThickness = 4;
            line2.StrokeEndLineCap = PenLineCap.Square;
        //    line2.StrokeDashArray = DoubleCollection.Parse("3, 1");
            pt3 = pt2 + v1 * m1;
            m1 = new Matrix();
            m1.Rotate(45);
            pt4 = pt2 + v1 * m1;
            line2.X1 = pt3.X;
            line2.Y1 = pt3.Y;
            line2.X2 = pt2.X;
            line2.Y2 = pt2.Y;
            canvas1.Children.Add(line2);

            line3 = new Line();
            line3.Stroke = Brushes.Gray;
            line3.StrokeThickness = 4;
            line3.StrokeStartLineCap = PenLineCap.Square;
            line3.X1 = pt2.X;
            line3.Y1 = pt2.Y;
            line3.X2 = pt4.X;
            line3.Y2 = pt4.Y;
            canvas1.Children.Add(line3);
            
            Canvas.SetLeft(tbPoint3, pt3.X);
            Canvas.SetTop(tbPoint3, pt3.Y);
            Canvas.SetLeft(tbPoint4, pt4.X);
            Canvas.SetTop(tbPoint4, pt4.Y-20);
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
            if (line3 != null)
                canvas1.Children.Remove(line3);
            AddLines();
        }
        public void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event raised on mouse down in the ZoomAndPanControl
        private void zoomAndPanControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ZoomAndPanEvents.MouseDown(sender, e, canvas1, zoomAndPanControl);
        }

        // Event raised on mouse up in the ZoomAndPanControl
        private void zoomAndPanControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
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


    }
}
