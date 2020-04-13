using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lens
{
    public class Ray
    {
        PointF pos;
        PointF vec;
        PointF last_pos;
        public Pen pen = new Pen(Color.Orange);
        Color color;
        bool init = false;
        float transparency = 1f;


        public Ray(PointF pos, double angle)
        {
            this.pos = pos;
            PointF[] a = { new PointF(1000, 0) };
            Operations.RotateVector(a, angle);
            vec = a[0];
        }
        public Ray(PointF pos, double angle, Color color, float transper)
        {
            this.pos = pos;
            this.vec = new PointF(1000, 0);
            PointF[] a = { vec };
            Operations.RotateVector(a, angle);
            vec = a[0];
            transparency *= transper;
            this.color = Color.FromArgb((int)(transparency*255), color.R, color.G, color.B);
            pen = new Pen(this.color);
            //this.pos = Operations.PointsOperations(this.pos, new PointF(vec.X / 10000, vec.Y / 10000), '+');
        }
        public void InitLastPos(PointF pos)
        {
            last_pos = pos;
        }

        public float Transparence
        {
            get
            {
                return transparency;
            }
        }
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public PointF Vector
        {
            get
            {
                return vec;
            }
        }
        public bool RayInit
        {
            get
            {
                return init;
            }
            set
            {
                init = value;
            }
        }
        public PointF Pos
        {
            get
            {
                return pos;
            }

            set
            {
                
                pos = value;
            }
        }
        public PointF EndPos
        {
            get
            {
                return last_pos;
            }
        }
    }
}
