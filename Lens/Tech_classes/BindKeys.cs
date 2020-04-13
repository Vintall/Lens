using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lens
{
    public static class BindKeys
    {
        static public Keys cam_move_up = Keys.W;
        static public Keys cam_move_down = Keys.S;
        static public Keys cam_move_left = Keys.A;
        static public Keys cam_move_right = Keys.D;
        static public Keys cam_scale_up = Keys.Q;
        static public Keys cam_scale_down = Keys.E;
        static public Keys new_object = Keys.N;
        static public Keys delete = Keys.Delete;

        static public Keys[] binds;
        
        public static void KeyEvents()
        {

        }
    }
}
