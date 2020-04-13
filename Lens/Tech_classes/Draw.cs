using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Lens
{
    public class Draw
    {
        Graphics gr;   //Графика
        Bitmap bm;     //Второй буфер
        readonly PictureBox pb; //Полотно
        DrawingObject[] drawing_objects;
        readonly Map map;
        readonly Window window;
        Identifiers identif;

        public Identifiers Identif
        {
            get
            {
                return identif;
            }
        }

        public Draw(ref PictureBox pb, ref Map map, ref Window window, string type)
        {
            gr = pb.CreateGraphics();
            this.pb = pb;
            InitGraphics(new Point(pb.Size.Width, pb.Size.Height));
            drawing_objects = new DrawingObject[0];
            this.map = map;
            this.window = window;
            identif = new Identifiers(type);
        }

        public class Identifiers
        {
            bool draw_obj;
            bool draw_vertex_normal;
            bool draw_vertex;
            bool draw_normal;
            bool draw_verge;
            bool draw_active_circle;
            bool draw_radiation_points;
            SolidBrush vertex_brush;

            public Identifiers(string type)
            {
                draw_obj = true;
                draw_vertex_normal = false;
                draw_vertex = false;
                draw_normal = false;
                draw_verge = true;
                draw_radiation_points = false;

                draw_active_circle = true;
                vertex_brush = new SolidBrush(Color.Red);
            }

            public bool DrawRadPoints
            {
                get
                {
                    return draw_radiation_points;
                }
                set
                {
                    draw_radiation_points = value;
                }
            }

            public SolidBrush VertexBrush
            {
                get
                {
                    return vertex_brush;
                }
                set
                {
                    vertex_brush = value;
                }
            }
            public bool DrawObj
            {
                get
                {
                    return draw_obj;
                }
                set
                {
                    draw_obj = value;
                }
            }
            public bool DrawVertexNormal
            {
                get
                {
                    return draw_vertex_normal;
                }
                set
                {
                    draw_vertex_normal = value;
                }
            }
            public bool DrawVertex
            {
                get
                {
                    return draw_vertex;
                }
                set
                {
                    draw_vertex = value;
                }
            }
            public bool DrawNormals
            {
                get
                {
                    return draw_normal;
                }
                set
                {
                    draw_normal = value;
                }
            }
            public bool DrawVerge
            {
                get
                {
                    return draw_verge;
                }
                set
                {
                    draw_verge = value;
                }
            }
            public bool DrawActiveCircle
            {
                get
                {
                    return draw_active_circle;
                }
                set
                {
                    draw_active_circle = value;
                }
            }
        }

        class DrawingObject 
        {
            PointF[] drawing_points;
            PointF[] drawing_rad_points;
            RadiatingPoint[] rad_points;
            SolidBrush brush;
            Pen pen;
            PointF pos;

            

            public RadiatingPoint[] RadPoints
            {
                get
                {
                    return rad_points;
                }
            }

            public PointF[] DrawingPoints
            {
                get
                {
                    return drawing_points;
                }
                set
                {
                    drawing_points = value;
                }
            }

            public PointF[] DrawingRadPoints
            {
                get
                {
                    return drawing_rad_points;
                }
                set
                {
                    drawing_rad_points = value;
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
            public SolidBrush Brush
            {
                get
                {
                    return brush;
                }
                set
                {
                    brush = value;
                }
            }
            public Pen Pen
            {
                get
                {
                    return pen;
                }
                set
                {
                    pen = value;
                }
            }
            public DrawingObject(PointF[] points, RadiatingPoint[] rad_points, PointF pos, SolidBrush brush, Pen pen)
            {
                this.rad_points = new RadiatingPoint[rad_points.Length];
                drawing_points = new PointF[points.Length];
                this.rad_points = rad_points;
                Array.Copy(points, drawing_points, points.Length);
                this.brush = brush;
                this.pen = pen;
                this.pos = pos;
            }
        }


        public void InitGraphics(Point pb_size) //Создание буфера графики
        {
            bm = new Bitmap(pb_size.X, pb_size.Y);
            gr = Graphics.FromImage(bm);
            pb.Image = bm;
        }

        public void InitGraphics() //Изменение буфера графики
        {
            try
            {
                bm = new Bitmap(pb.Size.Width, pb.Size.Height);
                gr = Graphics.FromImage(bm);
                pb.Image = bm;
            } catch
            {
            }
        }

        public void DrawAll() //Ведущая графическая функция
        {
            gr.Clear(Color.Black);
            DrawObjects();
            DrawActiveCircle();




            DrawRays();
            //Refresh();
        }

        public void Refresh()
        {
            pb.Refresh();
        }

        public void InitScreenPoints()
        {
            int obj_length = map.Objects.Length;
            Object[] objects = new Object[obj_length];
            Array.Copy(map.Objects, objects, obj_length);
            drawing_objects = new DrawingObject[obj_length];
            for (int i = 0; i < obj_length; i++)
            {
                drawing_objects[i] = new DrawingObject(objects[i].Vertex, objects[i].RadPoints, objects[i].Pos, objects[i].Brush, objects[i].Pen);
                drawing_objects[i].DrawingPoints = map.GetScreenPosition(drawing_objects[i].DrawingPoints, drawing_objects[i].Pos);

                drawing_objects[i].DrawingRadPoints = new PointF[drawing_objects[i].RadPoints.Length];
                for (int j = 0; j < drawing_objects[i].RadPoints.Length; j++) 
                drawing_objects[i].DrawingRadPoints[j] = map.GetScreenPosition(drawing_objects[i].RadPoints[j].Pos);


                drawing_objects[i].Pos = map.GetScreenPosition(drawing_objects[i].Pos);
            }
        }
        public void DrawRays()
        {
            if (map.Rays != null) 
            foreach(Ray ray in map.Rays)
                gr.DrawLine(ray.pen, map.GetScreenPosition(ray.Pos), map.GetScreenPosition(ray.EndPos));
            
        }

        void DrawObjects()
        {
            DrawingObject obj;

            int cursor_object_crossing = MouseEvents.CursorOnObject;
            if (cursor_object_crossing >= 0 && cursor_object_crossing < drawing_objects.Length) 
                DrawPolygon(new Pen(Color.Red, 3), drawing_objects[cursor_object_crossing].DrawingPoints);
            if (map.ActiveCircle.Activity != "None Active")
                DrawPolygon(new Pen(Color.Blue, 3), drawing_objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].DrawingPoints);

            for (int i = 0; i < drawing_objects.Length; i++) // Перебор объектов
            {
                obj = drawing_objects[i]; // Текущий объект

                if (identif.DrawObj) 
                DrawObject(obj);
                if (identif.DrawVerge) 
                DrawObjectVerge(obj);
                if (identif.DrawVertex) 
                DrawVertex(obj);
                if (identif.DrawRadPoints)
                DrawRadPoints(obj);
            }
        }

        void DrawPolygon(Pen pen, PointF[] polygon) //Отрисовка периметра
        {
            gr.DrawPolygon(pen, polygon);
        }

        void DrawPolygon(SolidBrush brush, PointF[] polygon) //Зарисовка площади
        {
            gr.FillPolygon(brush, polygon);
        }

        void DrawObject(DrawingObject obj)
        {
            DrawPolygon(obj.Brush, obj.DrawingPoints);
        }

        void DrawObjectVerge(DrawingObject obj)
        {
            DrawPolygon(obj.Pen, obj.DrawingPoints);
        }

        void DrawVertex(DrawingObject obj)
        {
            for (int i = 0; i < obj.DrawingPoints.Length; i++)
                DrawCircle(identif.VertexBrush, obj.DrawingPoints[i], 5);
        }

        void DrawRadPoints(DrawingObject obj)
        {
            for (int i = 0; i < obj.DrawingRadPoints.Length; i++)
                DrawCircle(new SolidBrush(Color.Violet), obj.DrawingRadPoints[i], 5);
        }

        public void DrawCircle(Pen pen, PointF pos, float r)
        {
            gr.DrawEllipse(pen, new RectangleF(pos.X - r, pos.Y - r, r * 2, r * 2));
        }

        public void DrawCircle(SolidBrush brush, PointF pos, float r)
        {
            gr.FillEllipse(brush, new RectangleF(pos.X - r, pos.Y - r, r * 2, r * 2));
        }

        void DrawActiveCircle()
        {
            if (map.ActiveCircle.Activity != "None Active" && identif.DrawActiveCircle)
            {
                PointF circle_pos = map.GetScreenPosition(map.ActiveCircle.Pos);
                DrawCircle(map.ActiveCircle.Pen, circle_pos, map.ActiveCircle.Radius[0]);
                DrawCircle(map.ActiveCircle.Pen, Operations.PointsOperations(circle_pos, map.ActiveCircle.CircleVec, '+'), map.ActiveCircle.Radius[1]);
            }
        }

        public void DrawLine(Color color, PointF p1, PointF p2)
        {
            gr.DrawLine(new Pen(color), p1, p2);
        }
    }
}
