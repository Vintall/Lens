using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Lens
{
    public class Map
    {
        PointF size; //Размер карты
        Cam cam;
        Object[] objects;
        ActiveCircle activeCircle;
        Window window;
        string map_state;
        Draw drawing;
        Ray[] rays_container;

        public Ray[] Rays
        {
            get
            {
                return rays_container;
            }
        }
        
        public Map(ref Window window, string map_state)
        {
            size = new Point(60000, 40000);
            cam = new Cam(new PointF(size.X / 2, size.Y / 2));
            objects = new Object[0];
            activeCircle = new ActiveCircle(); 
            this.window = window;
            this.map_state = map_state;
        }

        public void InitDrawing(ref PictureBox pb, ref Map map)
        {
            drawing = new Draw(ref pb, ref map, ref window, map_state);
        }

        public Object[] Objects
        {
            get
            {
                return objects;
            }
        }

        public void InitRays()
        {
            void Ray_Obj_Crossing_Min(Ray ray, ref PointF min_dot_crossing, ref int obj_crossing_index, ref PointF _a, ref PointF _b)
            {
                PointF a; //1 vertex
                PointF b; //2 Vertex
                PointF dot_cross; //Crossing dot (ray - obj line) 
                min_dot_crossing = new PointF(0, 0);
                _a = new PointF(0, 0);
                _b = new PointF(0, 0);

                obj_crossing_index = -1;
                PointF ray_pos = Operations.PointsOperations(ray.Pos, new PointF(ray.Vector.X / 8500, ray.Vector.Y / 8500), '+');

                foreach (Object obj in objects)
                {
                    for (int i = 1; i <= obj.Vertex.Length; i++)
                    {
                        int k = i - 1;
                        int l = i;
                        if (l == obj.Vertex.Length) l = 0;
                        a = Operations.PointsOperations(obj.Pos, obj.Vertex[k], '+');
                        b = Operations.PointsOperations(obj.Pos, obj.Vertex[l], '+');
                        dot_cross = Operations.CrossingStraight(ray_pos, Operations.PointsOperations(ray.Pos, ray.Vector, '+'), a, b);

                        if ((ray.Vector.X > 0 && dot_cross.X - ray_pos.X > 0) || (ray.Vector.X < 0 && dot_cross.X - ray_pos.X < 0) || (ray.Vector.Y < 0 && dot_cross.Y - ray_pos.Y < 0) || (ray.Vector.Y > 0 && dot_cross.Y - ray_pos.Y > 0))
                            if (a.Y != b.Y)
                            {
                                if (Operations.Interval(a.Y, b.Y, dot_cross.Y))
                                    if (obj_crossing_index != -1)
                                    {
                                        if (Operations.GetLength(ray_pos, dot_cross) < Operations.GetLength(ray_pos, min_dot_crossing))
                                        {
                                            min_dot_crossing = dot_cross;
                                            _a = a;
                                            _b = b;
                                            obj_crossing_index = obj.Num;
                                        }
                                    }
                                    else
                                    {
                                        min_dot_crossing = dot_cross;
                                        _a = a;
                                        _b = b;
                                        obj_crossing_index = obj.Num;
                                    }
                            }
                            else
                            {
                                if (Operations.Interval(a.X, b.X, dot_cross.X))
                                {
                                    if (obj_crossing_index != -1)
                                    {
                                        if (Operations.GetLength(ray_pos, dot_cross) < Operations.GetLength(ray_pos, min_dot_crossing))
                                        {
                                            min_dot_crossing = dot_cross;
                                            _a = a;
                                            _b = b;
                                            obj_crossing_index = obj.Num;
                                        }
                                    }
                                    else
                                    {
                                        min_dot_crossing = dot_cross;
                                        _a = a;
                                        _b = b;
                                        obj_crossing_index = obj.Num;
                                    }
                                }
                            }
                    }
                }
                if (obj_crossing_index != -1)
                {
                    ray.InitLastPos(min_dot_crossing);
                    ray.RayInit = true;
                }
                else  //Сделать пересечения с границами карты!!!-----------------------------------------------------------------------------------------------------
                {
                    ray.InitLastPos(Operations.PointsOperations(ray.Pos, new PointF(ray.Vector.X * 1000, ray.Vector.Y * 1000), '+'));
                    ray.RayInit = true;
                }

            }
            Random rnd = new Random();
            rays_container = new Ray[0];
            Ray[] empty_rays = new Ray[0];
            RadiatingPoint[] rad_points = new RadiatingPoint[0];
            
            for (int i = 0; i < objects.Length; i++)
            {
                Array.Resize(ref rad_points, rad_points.Length + objects[i].RadPoints.Length);
                for (int j = 0; j < objects[i].RadPoints.Length; j++)
                    rad_points[rad_points.Length - objects[i].RadPoints.Length + j] = objects[i].RadPoints[j];
            }
            for (int i = 0; i < rad_points.Length; i++)
            {
                Array.Resize(ref empty_rays, empty_rays.Length + rad_points[i].Rays.Length);
                for (int j = 0; j < rad_points[i].Rays.Length; j++)
                    empty_rays[empty_rays.Length - rad_points[i].Rays.Length + j] = rad_points[i].Rays[j];
            }

            PointF dot_cross_point = new PointF(0, 0);
            PointF a_dot = new PointF(0, 0);
            PointF b_dot = new PointF(0, 0);
            int obj_index = -1;
            rad_points = new RadiatingPoint[0];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < rad_points.Length; j++)
                {
                    Array.Resize(ref empty_rays, empty_rays.Length + rad_points[j].Rays.Length);
                    for (int q = 0; q < rad_points[j].Rays.Length; q++)
                        empty_rays[empty_rays.Length - rad_points[j].Rays.Length + q] = rad_points[j].Rays[q];
                }
                foreach (Ray ray in empty_rays)
                {
                    obj_index = -1;
                    dot_cross_point = new PointF(0, 0);
                    a_dot = new PointF(0, 0);
                    b_dot = new PointF(0, 0); 
                    Ray_Obj_Crossing_Min(ray, ref dot_cross_point, ref obj_index, ref a_dot, ref b_dot);
                    if (obj_index != -1)
                    {
                        double angle = (Operations.GetAngle(b_dot, a_dot));
                        double ray_angle = (Operations.GetAngle(ray.EndPos, ray.Pos));

                        if (ray_angle <= angle) angle -= 90f;
                        else angle += 90f;

                        if (objects[obj_index].Transparency == 1) { } 
                        else  if (objects[obj_index].Absorption != 1 && objects[obj_index].Reflection != 1)
                        {
                            Array.Resize(ref rad_points, rad_points.Length+1);
                            Color obj_col = objects[obj_index].first_color;
                            int r_p_l = rad_points.Length - 1;
                            rad_points[r_p_l] = new RadiatingPoint(dot_cross_point);
                            rad_points[r_p_l].AddRay((float)(2*angle-ray_angle ), ray.Color, 0.5f/*objects[obj_index].Reflection*/);
                            //rad_points[r_p_l].AddRay((float)(0), Color.Blue, 0.8f/*objects[obj_index].Reflection*/);
                            //rad_points[r_p_l].AddRay((float)(Math.Asin(Math.Sin(angle-ray_angle)*objects[obj_index].N_koef) * (180/Math.PI) + angle - 180), /*obj_col*/Color.Blue, 1f /*objects[obj_index].Transparency*/);
                        }
                        else if (objects[obj_index].Absorption == 1)
                        {

                        }
                        else if(objects[obj_index].Absorption == 1)
                        {

                        }
                    }
                }
                Array.Resize(ref rays_container, rays_container.Length + empty_rays.Length);
                for (int q = rays_container.Length - empty_rays.Length; q < rays_container.Length; q++)
                    rays_container[q] = empty_rays[q - rays_container.Length + empty_rays.Length];
                empty_rays = new Ray[0];

                for (int j = 0; j < rad_points.Length; j++)
                {
                    Array.Resize(ref empty_rays, empty_rays.Length + rad_points[j].Rays.Length);
                    for (int q = 0; q < rad_points[j].Rays.Length; q++)
                        empty_rays[empty_rays.Length - rad_points[j].Rays.Length + q] = rad_points[j].Rays[q];
                }

                rad_points = new RadiatingPoint[0];
            }

        }

        public Draw Drawing
        {
            get
            {
                return drawing;
            }
        }

        public Cam Cam
        {
            get
            {
                return cam;
            }
        }

        public PointF Size
        {
            get
            {
                return size;
            }
        }

        

        public void ReInitMap(Point size, Cam cam, Object[] objects)
        {
            this.size = size;
            this.cam = new Cam(cam);
            this.objects = new Object[objects.Length];
            Array.Copy(objects, this.objects, objects.Length);
            activeCircle = new ActiveCircle();
        }

        public void CreateNewObject(PointF pos)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = new Object(pos, objects.Length - 1);
        }

        public void CreateNewObject(Object obj)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = new Object(obj, objects.Length - 1);
            activeCircle.InitCircle(Objects[Objects.Length - 1]);
        }
        public void CreateNewObject(Object obj, PointF pos)
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = new Object(pos, obj, objects.Length - 1);
            activeCircle.InitCircle(Objects[Objects.Length - 1]);
        }

        public void CreateNewObject()
        {
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = new Object();
        }

        public void Events()
        {
            cam.Moving();
            cam.Scaling();
        }

        public void MouseDownEvents(PointF mouse_down) //Событие мыши
        {
            MouseEvents.MouseDown = mouse_down;
            
            if (map_state == "Main")
            {
                int num = CursorObjectCrossing(MouseEvents.MouseDown);

                if (activeCircle.Activity != "None Active")//Отслеживание нажатия на круг
                {
                    if (Operations.IsPointInCircle(Operations.PointsOperations(activeCircle.CircleVec, GetScreenPosition(activeCircle.Pos), '+'), activeCircle.Radius[1] + 5, mouse_down))
                    {
                        activeCircle.GetActivity("Rotate", int.Parse(activeCircle.Activity.Split(' ')[1]));
                    }
                    else if (Operations.IsPointInCircle(GetScreenPosition(activeCircle.Pos), activeCircle.Radius[0] + 5, mouse_down))
                    {
                        activeCircle.GetActivity("Move", int.Parse(activeCircle.Activity.Split(' ')[1]));
                    }
                    else if (num < 0)
                        activeCircle.DeInitCircle();
                }
                else
                {
                    if (num >= 0)
                        activeCircle.InitCircle(objects[num]);
                }
            }
        }

        public void MouseUpEvents(PointF mouse_up) //Событие мыши
        {
            MouseEvents.MouseUp = mouse_up;
            if (map_state == "Main")
            {
                if (activeCircle.Activity.Split(' ')[0] == "Move" || activeCircle.Activity.Split(' ')[0] == "Rotate")
                    activeCircle.GetActivity("Active", int.Parse(activeCircle.Activity.Split(' ')[1]));
            }
        } 

        public void MouseMoveEvents(PointF mouse_move) //Событие мыши
        {
            MouseEvents.MouseMove = mouse_move;

            if (map_state == "Main")
            {
                int num = CursorObjectCrossing(MouseEvents.MouseMove);
                    MouseEvents.CursorOnObject = num;

                if (activeCircle.Activity.Split(' ')[0] == "Rotate")
                    activeCircle.RotateCircle(Operations.GetAngle(GetScreenPosition(activeCircle.Pos), mouse_move), ref objects[int.Parse(activeCircle.Activity.Split(' ')[1])]);
                else if (activeCircle.Activity.Split(' ')[0] == "Move")
                    activeCircle.MoveCircle(GetMapPosition(mouse_move), ref Objects[int.Parse(activeCircle.Activity.Split(' ')[1])]);
            }
        }

        int CursorObjectCrossing(PointF cursor) 
        {
            for (int i = objects.Length - 1; i >= 0; i--) 
            {
                PointF[] points = new PointF[objects[i].Vertex.Length];
                Array.Copy(objects[i].Vertex, points, objects[i].Vertex.Length);
                for (int j = 0; j < objects[i].Vertex.Length; j++)
                    points[j] = new PointF(objects[i].Vertex[j].X + objects[i].Pos.X, objects[i].Vertex[j].Y + objects[i].Pos.Y);
                
                if (Operations.IsPointInPolygon(GetMapPosition(cursor), points))
                    return i;
            }
            return -1;
        }

        public ActiveCircle ActiveCircle 
        {
            get
            {
                return activeCircle;
            }
        }

        public PointF[] GetScreenPosition(PointF[] vertex, PointF object_pos)
        {
            PointF[] screen_points = new PointF[vertex.Length];
            for (int i = 0; i < vertex.Length; i++)
                screen_points[i] = new PointF((vertex[i].X + object_pos.X - cam.Pos.X) / cam.Scale + window.Pb_size.X / 2,
                                    (vertex[i].Y + object_pos.Y - cam.Pos.Y) / cam.Scale + window.Pb_size.Y / 2);
            return screen_points;
        }

        public PointF GetScreenPosition(PointF object_pos)
        {
                object_pos = new PointF((object_pos.X - cam.Pos.X) / cam.Scale + window.Pb_size.X / 2, (object_pos.Y - cam.Pos.Y) / cam.Scale + window.Pb_size.Y / 2);
            return object_pos;
        }

        public PointF[] GetMapPosition(PointF[] vertex, PointF object_pos) //-------------------------
        {
            PointF[] map_points = new PointF[vertex.Length];
            for (int i = 0; i < vertex.Length; i++)
                map_points[i] = new PointF((cam.Pos.X + (object_pos.X + vertex[i].X - window.Pb_size.X / 2) * cam.Scale), (cam.Pos.Y + (object_pos.Y + vertex[i].Y - window.Pb_size.Y / 2) * cam.Scale));
            return map_points;
        }

        public PointF GetMapPosition(PointF object_pos) //-------------------------
        {
            object_pos = new PointF((cam.Pos.X + (object_pos.X - window.Pb_size.X / 2) * cam.Scale), (cam.Pos.Y + (object_pos.Y - window.Pb_size.Y / 2) * cam.Scale));
            return object_pos;
        }
    }
}