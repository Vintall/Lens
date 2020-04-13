using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lens
{
    public static class MouseEvents
    {
        static PointF mouse_up; //Событие мышки (поднять)
        static PointF mouse_down;//Событие мышки (опустить)
        static PointF mouse_move; //Событие мышки (передвинуть)
        static int cursor_on_object = -1;

        public static PointF MouseUp
        {
            get
            {
                return mouse_up;
            }
            set
            {
                mouse_up = value;
            }
        }

        public static PointF MouseDown
        {
            get
            {
                return mouse_down;
            }
            set
            {
                mouse_down = value;
            }
        }

        public static PointF MouseMove
        {
            get
            {
                return mouse_move;
            }
            set
            {
                mouse_move = value;
            }
        }

        public static int CursorOnObject
        {
            get
            {
                return cursor_on_object;
            }
            set
            {
                cursor_on_object = value;
            }
        }
    }
}
