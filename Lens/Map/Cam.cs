using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lens
{
    public class Cam
    {
        PointF pos; // Позиция камеры
        PointF speed_move; //Скорость перемещения
        float speed_scale; //Скорость перемещения
        float scale; //Увеличение

        public Cam(PointF pos)
        {
            this.pos = pos;
            scale = 10f;
            speed_move = new PointF(0, 0);
            speed_scale = 0;
        }
        public Cam(PointF pos, float scale)
        {
            this.pos = pos;
            this.scale = scale;
            speed_move = new PointF(0, 0);
            speed_scale = 0;
        }
        public Cam(Cam cam)
        {
            this.pos = cam.pos;
            this.scale = cam.scale;
            speed_move = new PointF(0, 0);
            speed_scale = 0;
        }

        public void ChangeSpeed(Keys key)
        {
            if (key == BindKeys.cam_move_up) { speed_move.Y = -5; }
            else if (key == BindKeys.cam_move_left) { speed_move.X = -5; }
            else if (key == BindKeys.cam_move_down) { speed_move.Y = 5; }
            else if (key == BindKeys.cam_move_right) { speed_move.X = 5; }
        }

        public void ChangeScaleSpeed(Keys key)
        {
            if (key == BindKeys.cam_scale_up) { speed_scale = -0.1f; }
            else if (key == BindKeys.cam_scale_down) { speed_scale = 0.1f; }
        }

        public void AnulateSpeed(Keys key)
        {
            if (key == BindKeys.cam_move_up) { speed_move.Y -= -5; if (speed_move.Y != 0) speed_move.Y = 0; }
            else if (key == BindKeys.cam_move_left) { speed_move.X -= -5; if (speed_move.X != 0) speed_move.X = 0; }
            else if (key == BindKeys.cam_move_down) { speed_move.Y -= 5; if (speed_move.Y != 0) speed_move.Y = 0; }
            else if (key == BindKeys.cam_move_right) { speed_move.X -= 5; if (speed_move.X != 0) speed_move.X = 0; }
            if (key == BindKeys.cam_scale_up) { speed_scale -= -0.1f; if (speed_scale != 0) speed_scale = 0; }
            else if (key == BindKeys.cam_scale_down) { speed_scale -= 0.1f; if (speed_scale != 0) speed_scale  = 0; }
        }

        public void Scaling()
        {
            if (scale >= 0.1 && scale <= 30) 
            scale += speed_scale;
            if (scale < 0.1) scale = 0.1f;
            else if (scale > 30) scale = 30;
        }

        public void Moving()
        {
            pos.X += speed_move.X * scale * 5;
            pos.Y += speed_move.Y * scale * 5;
        }

        public float Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
            }
        }

        public PointF Pos
        {
            get
            {
                return pos;
            }
        }
    }
}
