using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lens
{
    public static class Operations
    {
        static Matrix matrix;

        public struct BoolPointF
        {
            public PointF point_;
            public bool bool_;
            public string type;
            public BoolPointF(PointF point)
            {
                type = "Point";
                bool_ = false;
                this.point_ = point;
            }
            public BoolPointF(bool bool_)
            {
                type = "Bool";
               this.bool_ = false;
                point_ = new PointF(0, 0);
            }
        }

        public static float GetLength(PointF point1, PointF point2) //Длина отрезка из двух точек
        {
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static bool IsPointInPolygon(PointF point, PointF[] polygon) //Проверка вхождения точки в многоугольник
        {
            int count = 0;
            PointF dot;

            for (int i = 1; i < polygon.Length; i++)
            {
                dot = CrossingStraight(point, new PointF(point.X + 100, point.Y), polygon[i - 1], polygon[i]);
                if (dot.X > point.X)
                    if (polygon[i - 1].Y < polygon[i].Y)
                    {
                        if (point.Y > polygon[i - 1].Y && point.Y < polygon[i].Y)
                            count++;
                    }
                    else if (polygon[i - 1].Y > polygon[i].Y)
                    {
                        if (point.Y < polygon[i - 1].Y && point.Y > polygon[i].Y)
                            count++;
                    }
                    else
                    {
                        if (point.Y == polygon[i - 1].Y && point.Y == polygon[i].Y)
                            count++;
                    }
            }
            dot = CrossingStraight(point, new PointF(point.X + 100, point.Y), polygon[polygon.Length - 1], polygon[0]);
            if (dot.X > point.X)
            {
                if (polygon[0].Y < polygon[polygon.Length - 1].Y)
                {
                    if (point.Y > polygon[0].Y && point.Y < polygon[polygon.Length - 1].Y)
                    {
                        count++;
                    }
                }
                else if (polygon[0].Y > polygon[polygon.Length - 1].Y)
                {
                    if (point.Y < polygon[0].Y && point.Y > polygon[polygon.Length - 1].Y)
                    {
                        count++;
                    }
                }
                else
                {
                    if (point.Y == polygon[0].Y && point.Y == polygon[polygon.Length - 1].Y)
                    {
                        count++;
                    }
                }
            }
            if (count % 2 == 0) return false;
            else return true;
        }

        public static PointF CrossingStraight(PointF l1_p1, PointF l1_p2, PointF l2_p1, PointF l2_p2)
        {
            PointF l1_p2_p1 = PointsOperations(l1_p2, l1_p1, '-');
            PointF l2_p2_p1 = PointsOperations(l2_p2, l2_p1, '-');

            if (l1_p2_p1.X != 0 && l2_p2_p1.X != 0)
            {
                double k1 = l1_p2_p1.Y / l1_p2_p1.X;
                double k2 = l2_p2_p1.Y / l2_p2_p1.X;
                double b1 = l1_p1.Y - (l1_p1.X * k1);
                double b2 = l2_p1.Y - (l2_p1.X * k2);
                double x = (b2 - b1) / (k1 - k2);

                return new PointF((float)x, (float)(x * k1 + b1));
            }
            else if(l1_p2_p1.X == 0 && l2_p2_p1.X == 0)
            {
                l1_p2_p1.X = 0.0001f;

                double k1 = l1_p2_p1.Y / l1_p2_p1.X;
                double k2 = l2_p2_p1.Y / l2_p2_p1.X;
                double b1 = l1_p1.Y - (l1_p1.X * k1);
                double b2 = l2_p1.Y - (l2_p1.X * k2);
                double x = (b2 - b1) / (k1 - k2);

                return new PointF((float)x, (float)(x * k1 + b1));
            }
            else if (l1_p2_p1.X == 0)
            {
                double k2 = l2_p2_p1.Y / l2_p2_p1.X;
                double b2 = l2_p1.Y - (l2_p1.X * k2);
                return new PointF(l1_p1.X, (float)(l1_p1.X * k2 + b2));
            }
            else
            {
                double k1 = l1_p2_p1.Y / l1_p2_p1.X;
                double b1 = l1_p1.Y - (l1_p1.X * k1);
                return new PointF(l2_p1.X, (float)(l2_p1.X * k1 + b1));
            }
        }

        public static bool IsPointInCircle(PointF circle_pos, float radius, PointF point) //Проверка вхождения точки в круг
        {
            if (GetLength(circle_pos, point) < radius) return true;
            else return false;
        } 
        public static double GetAngle(PointF a, PointF b, PointF c, PointF d)
        {
            double ab = GetLength(a, b);
            double ad = GetLength(a, d);
            double bd = GetLength(b, d);
            double bc = GetLength(b, c);
            double cd = GetLength(c, d);
            double abd = Math.Acos((ab * ab + bd * bd - ad * ad) / (2 * ab * bd)) / (Math.PI / 180);
            double bdc = Math.Acos((bd * bd + cd * cd - bc * bc) / (2 * bd * cd)) / (Math.PI / 180);
            double angle = abd - bdc;
            if (angle > 180) angle = 180 - angle;
            
            return angle;
        }
        public static double GetAngle(PointF p1, PointF p2) //Получение угла из двух точек (p1, p2)
        {
            if (p1.X != p2.X || p1.Y != p2.Y)
            {
                double angle = Math.Acos(Math.Abs(p1.X - p2.X) / (Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)))); //Считаем угол по косинусу
                angle /= (Math.PI / 180); //Переводим в радианы
                if (p1.X <= p2.X && p1.Y >= p2.Y) { }                              //1 чверть
                else if (p1.X > p2.X && p1.Y >= p2.Y) { angle = 180 - angle; }    //2 чверть
                else if (p1.X > p2.X && p1.Y < p2.Y) { angle = 180 + angle; }    //3 чверть
                else { angle = 360 - angle; }                                    //4 чверть
                return angle;
            } else return 0;
        }

        public static PointF PointsOperations(PointF p1, PointF p2, char asd) //Операции над переменной типа PointF('+','-','*','/')
        {
            switch(asd)
            {
                case '+': return new PointF(p1.X + p2.X, p1.Y + p2.Y);
                case '-': return new PointF(p1.X - p2.X, p1.Y - p2.Y);
                case '*': return new PointF(p1.X * p2.X, p1.Y * p2.Y);
                case '/': return new PointF(p1.X / p2.X, p1.Y / p2.Y);
                default : return new PointF(0, 0);
            }
        }

        public static string GetStringFromPoint(PointF point) //Получение текста из координат точки
        {
            return (point.X.ToString() + ' ' + point.Y.ToString());
        }

        public static string GetStringFromPoint(PointF[] points) //Получения текса из массива точек (последовательная запись)
        {
            string text = "";
            for (int i = 0; i < points.Length; i++) 
            {
                text += GetStringFromPoint(points[i]) + ' ';
            }
            text = text.Remove(text.Length - 1,1);
            return text;
        }

        public static void Swap(ref PointF p1, ref PointF p2)
        {
            PointF q = p1;
            p1 = p2;
            p2 = q;
        }
        public static void Swap(ref Point p1, ref Point p2)
        {
            Point q = p1;
            p1 = p2;
            p2 = q;
        }
        public static void Swap(ref float p1, ref float p2)
        {
            float q = p1;
            p1 = p2;
            p2 = q;
        }
        public static void Swap(ref int p1, ref int p2)
        {
            int q = p1;
            p1 = p2;
            p2 = q;
        }

        public static PointF RotateVector(PointF vec, double angle)
        {
            PointF[] vec2 = { vec };
            matrix = new Matrix();
            matrix.Rotate((float)angle * (-1));
            matrix.TransformPoints(vec2);
            return vec2[0];
        }
        
        public static PointF[] RotateVector(PointF[] vec, double angle)
        {
            matrix = new Matrix();
            matrix.Rotate((float)angle * (-1));
            matrix.TransformPoints(vec);
            matrix.Dispose();
            return vec;
        }

        public static bool Interval(float a,float b, float digit)
        {
            if (a > b) Swap(ref a, ref b);
            if (digit >= a && digit <= b) return true;
            else return false;
        }

        public static BoolPointF IsPointInRadiusLine(PointF a, PointF b, PointF o, double radius)
        {
            double a_b = GetLength(a, b);
            double b_o = GetLength(b, o);
            double a_o = GetLength(a, o);
            double cos_abo = Math.Round((Math.Pow(a_b, 2) + Math.Pow(b_o, 2) - Math.Pow(a_o, 2)) / (2 * a_b * b_o),5);
            double cos_bao = Math.Round((Math.Pow(a_b, 2) + Math.Pow(a_o, 2) - Math.Pow(b_o, 2)) / (2 * a_b * a_o),5);
            double b_l = Math.Abs(b_o * cos_abo);
            PointF k = new PointF(b.X + 100, b.Y);
            double b_k = 100;
            double a_k = GetLength(a, k);
            double cos_abk = Math.Round((Math.Pow(a_b, 2) + Math.Pow(b_k, 2) - Math.Pow(a_k, 2)) / (2 * a_b * b_k), 5);

            double angle_abk = Math.Acos(Math.Abs(cos_abk)) / (Math.PI / 180);

            if (a.X <= b.X && a.Y >= b.Y) angle_abk = 180 - angle_abk;
            else if (a.X <= b.X && a.Y < b.Y) angle_abk += 180;
            else if (a.X > b.X && a.Y < b.Y) angle_abk = 360 - angle_abk;

            PointF[] l = { new PointF((float)b_l, 0) };
            RotateVector(l, (float)angle_abk * -1);
            l[0] = PointsOperations(l[0], b, '+');
            BoolPointF asd;
            if (cos_abo > 0 && cos_bao > 0 && GetLength(o, l[0]) < radius) asd = new BoolPointF(l[0]);
            else asd = new BoolPointF(false);
            return asd;
        }
    }
}