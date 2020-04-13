using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lens
{
    public class ActiveCircle                   // Круг позволяет перемещать, поворачивать объекты
    {
        PointF pos;                             //Позиция круга
        PointF[] circle_vec = new PointF[] { new PointF(0, 0) };
        static float[] radius = { 100, 25 };    //Радиус
        double angle;                           //Угол поворота
        static Pen pen;                         //Цвет отрисовки
        string activity;                        //Текущая активность круга (неактивно, движение, вращение) при активности + номер элемента, вызвавшего круг (Пример: Move 1)

        public ActiveCircle() //Первая (Пустая) инициализация
        {
            DeInitCircle();
        }

        public string Activity
        {
            get
            {
                return activity;
            }
        }

        public PointF Pos
        {
            get
            {
                return pos;
            }
        }

        public PointF CircleVec
        {
            get
            {
                return circle_vec[0];
            }
        }

        public double Angle
        {
            get
            {
                return angle;
            }
        }

        public float[] Radius
        {
            get
            {
                return radius;
            }
        }

        public Pen Pen
        {
            get
            {
                return pen;
            }
        }

        public void InitCircle(Object obj)
        {
            activity = "Active " + obj.Num;
            pen = new Pen(Color.Red, 5);
            angle = obj.Angle;
            pos = obj.Pos;
            RotateCircle();
        }

        public void DeInitCircle()
        {
            activity = "None Active";
            pen = new Pen(Color.Red, 5);
            angle = 0;
        }

        public void RotateCircle()
        {
            circle_vec[0] = new PointF(radius[0], 0);
            Operations.RotateVector(circle_vec, angle);
        }

        public void RotateCircle(double angle, ref Object obj)
        {
            this.angle = angle;
            circle_vec[0] = new PointF(radius[0], 0);
            Operations.RotateVector(circle_vec, angle);
            obj.Rotate(angle);
        }
        public void MoveCircle(PointF delta, ref Object obj)
        {
            pos = delta;
            obj.Move(delta);
        }

        public void GetActivity(string activity, int num)
        {
            this.activity = activity + " " + num.ToString();
        }
    }
}
