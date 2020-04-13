using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Lens
{
    public class Object : Material
    {
        PointF pos; //Позиция объекта
        double angle; //Угол поворота объекта
        SolidBrush brush; //Цвет (Зависит от параметров)
        Pen pen; //Цвет обводки
        PointF[] vertex; //Вектора точек объекта в зависимости от центра
        PointF[] start_vertex; //Старторые вектора (Берутся за основу к обычным векторам для антидеформации объекта при поворотах)
        RadiatingPoint[] rad_poins;
        int num; //Номер объекта

        public Object() 
        {

        }

        public Object(PointF pos, double angle, PointF[] start_vertex, int num)
        {
            this.pos = pos;
            this.angle = angle;
            vertex = new PointF[0];
            this.start_vertex = new PointF[0];
            rad_poins = new RadiatingPoint[0];
            Array.Resize(ref this.start_vertex, start_vertex.Length);
            Array.Copy(start_vertex, this.start_vertex, start_vertex.Length);
            Array.Resize(ref this.vertex, start_vertex.Length);
            Array.Copy(start_vertex, vertex, start_vertex.Length);
            brush = new SolidBrush(color);
            pen = new Pen(Color.Black);
            InitMaterialColor();
        }

        public Object(PointF pos, int num) //Новый объект по камере (шестиугольник)
        {
            InitMaterialColor();
            this.num = num;
            this.pos = pos;

            rad_poins = new RadiatingPoint[0];
            angle = 0;
            brush = new SolidBrush(color);
            pen = new Pen(Color.Black);
            start_vertex = new PointF[6];
            start_vertex[0] = new PointF(100, 50);
            start_vertex[1] = new PointF(100, -50);
            start_vertex[2] = new PointF(0, -112);
            start_vertex[3] = new PointF(-100, -50);
            start_vertex[4] = new PointF(-100, 50);
            start_vertex[5] = new PointF(0, 112);
            vertex = new PointF[start_vertex.Length];
            Array.Copy(start_vertex, vertex, vertex.Length);
        }

        public Object(PointF pos, Object obj)
        {
            InitMaterialColor();
            start_vertex = new PointF[obj.start_vertex.Length];
            vertex = new PointF[obj.vertex.Length];

            Array.Copy(obj.start_vertex, start_vertex, obj.start_vertex.Length);
            Array.Copy(obj.vertex, vertex, vertex.Length);

            this.pos = pos;
            brush = obj.brush;
            pen = obj.pen;
            angle = obj.angle;
            rad_poins = obj.rad_poins;
        }
        public Object(PointF pos, Object obj, int num)
        {
            InitMaterialColor();
            start_vertex = new PointF[obj.start_vertex.Length];
            vertex = new PointF[obj.vertex.Length];
            
            Array.Copy(obj.start_vertex, start_vertex, obj.start_vertex.Length);
            Array.Copy(obj.vertex, vertex, vertex.Length);

            this.pos = pos;
            this.num = num;
            brush = obj.brush;
            pen = obj.pen;
            angle = obj.angle;
            rad_poins = obj.rad_poins;
        }

        public Object(Object obj)
        {
            InitMaterialColor();
            start_vertex = new PointF[obj.start_vertex.Length];
            vertex = new PointF[obj.vertex.Length];

            Array.Copy(obj.start_vertex, start_vertex, obj.start_vertex.Length);
            Array.Copy(obj.vertex, vertex, vertex.Length);

            pos = obj.pos;
            brush = obj.brush;
            pen = obj.pen;
            angle = obj.angle;
            rad_poins = obj.rad_poins;
        }

        public Object(Object obj, int num)
        {
            InitMaterialColor();
            start_vertex = new PointF[obj.start_vertex.Length];
            vertex = new PointF[obj.vertex.Length];

            Array.Copy(obj.start_vertex, start_vertex, obj.start_vertex.Length);
            Array.Copy(obj.vertex, vertex, vertex.Length);

            pos = obj.pos;
            brush = obj.brush;
            pen = obj.pen;
            angle = obj.angle;
            this.num = num;
            rad_poins = obj.rad_poins;
        }
        public void InitColor()
        {
            brush = new SolidBrush(color);
            foreach (RadiatingPoint rad_point in rad_poins)
                rad_point.Color = color;
        }

        public RadiatingPoint[] RadPoints
        {
            get
            {
                return rad_poins;
            }
            
        }
        public int Num
        {
            get
            {
                return num;
            }
        }

        public PointF[] StartVertex
        {
            get
            {
                return start_vertex;
            }
        }

        public double Angle
        {
            get { return angle; }
        }

        public PointF Pos
        {
            get { return pos; }
        }

        public PointF[] Vertex
        {
            get { return vertex; }
        }

        public SolidBrush Brush
        {
            get { return brush; }
        }

        public Pen Pen
        {
            get { return pen; }
        }

        public void Rotate(double angle) //Поворот фигуры
        {
            this.angle = angle;
            vertex = new PointF[start_vertex.Length];
            Array.Copy(start_vertex, vertex, vertex.Length);
            Operations.RotateVector(vertex, angle);
        }

        public void InitDrawVertex()
        {
            vertex = new PointF[start_vertex.Length];
            Array.Copy(start_vertex, vertex, start_vertex.Length);
        }

        public void Move(PointF delta) //Перемещение фигуры
        {
            for (int i = 0; i < rad_poins.Length; i++)
                rad_poins[i].Pos = Operations.PointsOperations(Operations.PointsOperations(rad_poins[i].Pos, pos, '-'), delta, '+');
            pos = delta;

        }

        public void ChangeVertex(PointF new_vec, int num)
        {
            if (num >= 0 && num < start_vertex.Length)
            {
                start_vertex[num] = new_vec;
                InitDrawVertex();
            }
        }

        public void RemoveVertex(int num)
        {
            if (num >= 0 && num < start_vertex.Length)
            {
                for (int i = num; i < start_vertex.Length - 1; i++)
                    start_vertex[i] = start_vertex[i + 1];

                Array.Resize(ref start_vertex, start_vertex.Length - 1);
                InitDrawVertex();
            }
        }

        public void RemoveRadPoint(int num)
        {
            if (num >= 0 && num < rad_poins.Length)
            {
                for (int i = num; i < rad_poins.Length - 1; i++)
                    rad_poins[i] = rad_poins[i + 1];

                Array.Resize(ref rad_poins, rad_poins.Length - 1);
            }
        }

        public void AddVertex(PointF pos, int num)
        {
            if (num >= 0 && num <= start_vertex.Length)
            {
                Array.Resize(ref start_vertex, start_vertex.Length + 1);
                for (int i = start_vertex.Length - 1; i > num; i--)
                    start_vertex[i] = start_vertex[i - 1];
                start_vertex[num] = pos;
                InitDrawVertex();
            }
        }

        public void AddRadiationPoint(PointF pos)
        {
            Array.Resize(ref rad_poins, rad_poins.Length + 1);
            Random rnd = new Random();
            rad_poins[rad_poins.Length - 1] = new RadiatingPoint(pos, 1000, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)));
            //Random rnd = new Random();
            //rad_poins[rad_poins.Length - 1].Color = );//color;
        }
    }
}