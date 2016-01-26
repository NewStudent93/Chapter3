using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
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
}
