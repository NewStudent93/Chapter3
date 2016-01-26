using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZoomAndPan;

namespace Chapter3
{
    public static class ZoomAndPanEvents
    {

        // Specifies the current state of the mouse handling logic
        public static MouseHandlingMode mouseHandlingMode = MouseHandlingMode.None;

        // The point that was clicked relative to the ZoomAndPanControl
        public static Point origZoomAndPanControlMouseDownPoint;

        /// The point that was clicked relative to the content that is contained within the ZoomAndPanControl
        public static Point origContentMouseDownPoint;

        // Records which mouse button clicked during mouse dragging
        public static MouseButton mouseButtonDown;

        // Event raised on mouse down in the ZoomAndPanControl
        public static void MouseDown(object sender, MouseButtonEventArgs e,Panel p, ZoomAndPanControl z)
        {
            p.Focus();
            Keyboard.Focus(p);

            mouseButtonDown = e.ChangedButton;
            origZoomAndPanControlMouseDownPoint = e.GetPosition(z);
            origContentMouseDownPoint = e.GetPosition(p);

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
                z.CaptureMouse();
                e.Handled = true;
            }
        }

        // Event raised on mouse up in the ZoomAndPanControl
        public static void MouseUp(object sender, MouseButtonEventArgs e,ZoomAndPanControl z)
        {
            if (mouseHandlingMode != MouseHandlingMode.None)
            {
                if (mouseHandlingMode == MouseHandlingMode.Zooming)
                {
                    if (mouseButtonDown == MouseButton.Left)
                    {
                        // Shift + left-click zooms in on the content.
      
                        ZoomIn(z,origContentMouseDownPoint);
                    }
                    else if (mouseButtonDown == MouseButton.Right)
                    {
                        // Shift + left-click zooms out from the content.
                        ZoomOut(z, origContentMouseDownPoint);
                    }
                }

                z.ReleaseMouseCapture();
                mouseHandlingMode = MouseHandlingMode.None;
                e.Handled = true;
            }
        }

        // Event raised on mouse move in the ZoomAndPanControl
        public static void MouseMove(object sender, MouseEventArgs e, Panel p,ZoomAndPanControl z)
        {
            if (mouseHandlingMode == MouseHandlingMode.Panning)
            {
                //
                // The user is left-dragging the mouse.
                // Pan the viewport by the appropriate amount.
                //
                Point curContentMousePoint = e.GetPosition(p);
                Vector dragOffset = curContentMousePoint - origContentMouseDownPoint;

                z.ContentOffsetX -= dragOffset.X;
                z.ContentOffsetY -= dragOffset.Y;

                e.Handled = true;
            }
        }

        // Event raised by rotating the mouse wheel
        public static void MouseWheel(object sender, MouseWheelEventArgs e, ZoomAndPanControl z,Panel p)
        {
            e.Handled = true;

            if (e.Delta > 0)
            {
                Point curContentMousePoint = e.GetPosition(p);
                ZoomIn(z,curContentMousePoint);
            }
            else if (e.Delta < 0)
            {
                Point curContentMousePoint = e.GetPosition(p);
                ZoomOut(z,curContentMousePoint);
            }
        }

        // Zoom the viewport out by a small increment
        public static void ZoomOut(ZoomAndPanControl z,Point contentZoomCenter)
        {
            z.ZoomAboutPoint(z.ContentScale - 0.1, contentZoomCenter);
        }

        // Zoom the viewport in by a small increment
        public static void ZoomIn(ZoomAndPanControl z, Point contentZoomCenter)
        {
            z.ZoomAboutPoint(z.ContentScale + 0.1, contentZoomCenter);
        }
    
        // Zoom in/out centered on the specified point (in content coordinates).
        public static void ZoomAboutPoint(double newContentScale, Point contentZoomFocus,ZoomAndPanControl z)
        {
            newContentScale = Math.Min(Math.Max(newContentScale, z.MinContentScale), z.MaxContentScale);

            double screenSpaceZoomOffsetX = (contentZoomFocus.X - z.ContentOffsetX) * z.ContentScale;
            double screenSpaceZoomOffsetY = (contentZoomFocus.Y - z.ContentOffsetY) * z.ContentScale;
            double contentSpaceZoomOffsetX = screenSpaceZoomOffsetX / newContentScale;
            double contentSpaceZoomOffsetY = screenSpaceZoomOffsetY / newContentScale;
            double newContentOffsetX = contentZoomFocus.X - contentSpaceZoomOffsetX;
            double newContentOffsetY = contentZoomFocus.Y - contentSpaceZoomOffsetY;


            z.ContentScale = newContentScale;
            z.ContentOffsetX = newContentOffsetX;
            z.ContentOffsetY = newContentOffsetY;
        }
    }
}
