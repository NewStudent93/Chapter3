using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter3
{
    class drawCoordinateSystem
    {

        private double xmin = 0;
        private double xmax = 1;
        private double ymin = 0;
        private double ymax = 1;
        private Canvas coordinateCanvas;
        private Brush gridlineColor = Brushes.Gray;
        private GridlinePatternEnum gridlinePattern;
        private double xTick = 1;
        private double yTick = 1;
        private Line gridline = new Line();
        private Line tick = new Line();
        private double dx, dy;
        private TextBlock tb = new TextBlock();

        public drawCoordinateSystem() { }

        public drawCoordinateSystem(Canvas c)
        {
            coordinateCanvas = c;
        }

        public Canvas CoordinateCanvas
        {
            get { return coordinateCanvas; }
            set { coordinateCanvas = value; }
        }

        public double Xmin
        {
            get { return xmin; }
            set { xmin = value; }
        }
        public double Xmax
        {
            get { return xmax; }
            set { xmax = value; }
        }
        public double Ymin
        {
            get { return ymin; }
            set { ymin = value; }
        }
        public double Ymax
        {
            get { return ymax; }
            set { ymax = value; }
        }

        public GridlinePatternEnum GridlinePattern
        {
            get { return gridlinePattern; }
            set { gridlinePattern = value; }
        }

        public double XTick
        {
            get { return xTick; }
            set { xTick = value; }
        }
        public double YTick
        {
            get { return yTick; }
            set { yTick = value; }
        }
        public Brush GridlineColor
        {
            get { return gridlineColor; }
            set { gridlineColor = value; }
        }

        public void AddCoordinateSystem()
        {

            double i = XTick;

            //create x axis
            gridline = new Line();
            gridline.Stroke = Brushes.Black;
            gridline.StrokeThickness = 1;
            gridline.X1 = 0;
            gridline.Y1 = Ymin;
            gridline.X2 = Xmax;
            gridline.Y2 = Ymin;
            coordinateCanvas.Children.Add(gridline);

            //create y axis
            gridline = new Line();
            gridline.Stroke = Brushes.Black;
            gridline.StrokeThickness = 1;
            gridline.X1 = Xmin;
            gridline.Y1 = 0;
            gridline.X2 = Xmin;
            gridline.Y2 = Ymax;
            coordinateCanvas.Children.Add(gridline);

            //mark the origin
            tb = new TextBlock();
            tb.Text = "0";
            tb.FontSize = 10;
            coordinateCanvas.Children.Add(tb);
            Canvas.SetLeft(tb, Xmin);
            Canvas.SetTop(tb, Ymin);


            //create vertical gridlines for positive x values
            for (dx = Xmin + XTick; dx < Xmax; dx += XTick)
            {
                gridline = new Line();
                AddLinePattern();
                gridline.X1 = dx;
                gridline.Y1 = 0;
                gridline.X2 = dx;
                gridline.Y2 = Ymax;
                coordinateCanvas.Children.Add(gridline);

                //create tick marks
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.StrokeThickness = 1;
                tick.X1 = dx;
                tick.Y1 = Ymin - 5;
                tick.X2 = dx;
                tick.Y2 = Ymin + 5;
                coordinateCanvas.Children.Add(tick);

                tb = new TextBlock();
                tb.Text = i.ToString();
                tb.FontSize = 10;
                i += XTick;
                coordinateCanvas.Children.Add(tb);
                Canvas.SetLeft(tb, dx);
                Canvas.SetTop(tb, Ymin);
            }

            //create vertical gridlines for negative x values
            i = -XTick;
            for (dx = Xmin - XTick; dx > 0; dx -= XTick)
            {
                gridline = new Line();
                AddLinePattern();
                gridline.X1 = dx;
                gridline.Y1 = 0;
                gridline.X2 = dx;
                gridline.Y2 = Ymax;
                coordinateCanvas.Children.Add(gridline);

                //create tick marks
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.StrokeThickness = 1;
                tick.X1 = dx;
                tick.Y1 = Ymin - 5;
                tick.X2 = dx;
                tick.Y2 = Ymin + 5;
                coordinateCanvas.Children.Add(tick);

                tb = new TextBlock();
                tb.Text = i.ToString();
                tb.FontSize = 10;
                i -= XTick;
                coordinateCanvas.Children.Add(tb);
                Canvas.SetLeft(tb, dx);
                Canvas.SetTop(tb, Ymin);
            }

            //create horisontal gridlines for positive y values
            i = -YTick;
            for (dy = Ymin + YTick; dy < Ymax; dy += YTick)
            {
                gridline = new Line();
                AddLinePattern();
                gridline.X1 = 0;
                gridline.Y1 = dy;
                gridline.X2 = Xmax;
                gridline.Y2 = dy;
                coordinateCanvas.Children.Add(gridline);

                //create tick marks
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.StrokeThickness = 1;
                tick.X1 = Xmin - 5;
                tick.Y1 = dy;
                tick.X2 = Xmin + 5;
                tick.Y2 = dy;
                coordinateCanvas.Children.Add(tick);

                tb = new TextBlock();
                tb.Text = i.ToString();
                tb.FontSize = 10;
                i -= YTick;
                coordinateCanvas.Children.Add(tb);
                Canvas.SetLeft(tb, Xmin + 2);
                Canvas.SetTop(tb, dy);
            }

            //create horisontal gridlines for negative y values
            i = YTick;
            for (dy = Ymin - YTick; dy > 0; dy -= YTick)
            {
                gridline = new Line();
                AddLinePattern();
                gridline.X1 = 0;
                gridline.Y1 = dy;
                gridline.X2 = Xmax;
                gridline.Y2 = dy;
                coordinateCanvas.Children.Add(gridline);

                //create tick marks
                tick = new Line();
                tick.Stroke = Brushes.Black;
                tick.StrokeThickness = 1;
                tick.X1 = Xmin - 5;
                tick.Y1 = dy;
                tick.X2 = Xmin + 5;
                tick.Y2 = dy;
                coordinateCanvas.Children.Add(tick);

                tb = new TextBlock();
                tb.Text = i.ToString();
                tb.FontSize = 10;
                i += YTick;
                coordinateCanvas.Children.Add(tb);
                Canvas.SetLeft(tb, Xmin + 2);
                Canvas.SetTop(tb, dy);
            }
        }

        public void AddLinePattern()
        {
            gridline.Stroke = GridlineColor;
            gridline.StrokeThickness = 1;
            switch (GridlinePattern)
            {
                case GridlinePatternEnum.Dash:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 4, 3 });
                    break;
                case GridlinePatternEnum.Dot:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 1, 2 });
                    break;
                case GridlinePatternEnum.DashDot:
                    gridline.StrokeDashArray =
                    new DoubleCollection(
                    new double[4] { 4, 2, 1, 2 });
                    break;
            }
        }
        public enum GridlinePatternEnum
        {
            Solid = 1,
            Dash = 2,
            Dot = 3,
            DashDot = 4
        }


    }
}
