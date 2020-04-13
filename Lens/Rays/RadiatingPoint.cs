using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lens
{
    public class RadiatingPoint
    {
        PointF pos;
        Ray[] rays;
        Color color;
        

        public RadiatingPoint(PointF pos, int count, Color color) 
        {
            this.pos = pos;
            rays = new Ray[count];
            this.color = color;
            for (int i = 0; i < count; i++)
            {
                rays[i] = new Ray(pos, (float)(i * 360f / count), color, 1f);
            }
        }
        public RadiatingPoint(PointF pos, float angle) //Один луч
        {
            this.pos = pos;
            rays = new Ray[1];
            rays[0] = new Ray(pos, angle);
        }
        public RadiatingPoint(PointF pos) //Пустая точка
        {
            this.pos = pos;
            rays = new Ray[0];
        }
        public void InitRaysColor()
        {
            foreach(Ray ray in rays)
            {
                ray.Color = Color;
            }
        }
        public Ray[] Rays
        {
            get
            {
                return rays;
            }
        }
        public RadiatingPoint(PointF pos, float first_angle, float last_angle, int count) //count лучей в промежутке углов 
        {
            this.pos = pos;
            rays = new Ray[count];
            for (int i = 0; i < count; i++)
            {
                rays[i] = new Ray(pos, (float)(first_angle + Math.Abs(first_angle-last_angle) * i / count), Color.Red, 1f);
            }
        }
        public void AddRay(float angle, Color color, float transparency)
        {
            Array.Resize(ref rays, rays.Length + 1);
            rays[rays.Length - 1] = new Ray(pos, angle, color, transparency);
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
                foreach (Ray ray in rays)
                    ray.Color = color;
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
                //for (int i = 0; i < rays.Length; i++)
                //    rays[i].Pos = Operations.PointsOperations(Operations.PointsOperations(rays[i].Pos, pos, '-'), value, '+');
                pos = value;
            }
        }
    }
}
