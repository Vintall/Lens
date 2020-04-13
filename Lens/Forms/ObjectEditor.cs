using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lens
{
    public partial class ObjectEditor : Form
    {
        Window window;
        public Map map;

        public string editor_status;
        public int obj_num;
        public static class EditorClass
        {
            public static int adding_point_num = -1;
            public static int active_point_num = -1;
            public static int chose_point_num = -1;
            public static int chose_rad_point_num = -1;
            public static int active_rad_point_num = -1;
            public static int radius = 5;
            public static PointF adding_point;

            public static Object obj;

            public static void InitObj(ref Object obj_)
            {
                obj = obj_;
            }
        }

        public ObjectEditor(double scale)
        {
            InitializeComponent();
            window = new Window(Size, Screen.PrimaryScreen.Bounds.Size); // Узнаём размер экрана
            map = new Map(ref window, "Editor");
            map.InitDrawing(ref pictureBox1, ref map);

            map.Cam.Scale = (float)scale;
            map.CreateNewObject(map.Cam.Pos);

            map.Drawing.Identif.DrawVertex = true;
            map.Drawing.Identif.DrawRadPoints = true;

            pictureBox1.Size = window.ResizePB();
            pictureBox1.Location = window.ReposPB();

            KeyPreview = true;
            
            EditorClass.InitObj(ref map.Objects[0]);
            
            timer1.Interval = 16; //60 fps  1000 / 16 ~~ 60 fps
            timer1.Start();
        }

        public ObjectEditor(double scale, Object obj)
        {
            InitializeComponent();
            window = new Window(Size, Screen.PrimaryScreen.Bounds.Size); // Узнаём размер экрана
            map = new Map(ref window, "Editor");
            map.InitDrawing(ref pictureBox1, ref map);
            map.Cam.Scale = (float)scale;
            obj_num = obj.Num;
            map.CreateNewObject();
            map.Objects[0] = new Object(map.Cam.Pos, obj);
            map.Objects[0].Rotate(0);


            map.Drawing.Identif.DrawVertex = true;
            map.Drawing.Identif.DrawRadPoints = true;

            pictureBox1.Size = window.ResizePB();
            pictureBox1.Location = window.ReposPB();

            KeyPreview = true;

            EditorClass.InitObj(ref map.Objects[0]);

            timer1.Interval = 16; //60 fps  1000 / 16 ~~ 60 fps
            timer1.Start();
        }
        //------------------------------------------------------------------
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            map.MouseDownEvents(e.Location);

            if (EditorClass.chose_point_num >= 0) 
            {
                EditorClass.active_point_num = EditorClass.chose_point_num;
                EditorClass.chose_point_num = -1;
            }
            if(EditorClass.chose_rad_point_num >= 0)
            {
                EditorClass.active_rad_point_num = EditorClass.chose_rad_point_num;
                EditorClass.chose_rad_point_num = -1;
            }
            if (EditorClass.adding_point_num >= 0 && e.Button == MouseButtons.Right)
            {
                if (radioButton1.Checked == true)
                {
                    map.Objects[0].AddVertex(Operations.PointsOperations(EditorClass.adding_point, map.Objects[0].Pos, '-'), EditorClass.adding_point_num);
                } else if (radioButton2.Checked == true)
                {
                    map.Objects[0].AddRadiationPoint(EditorClass.adding_point);
                }
            }
        }
        
        

        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            map.MouseMoveEvents(e.Location);
            EditorClass.adding_point_num = -1;
            EditorClass.chose_point_num = -1;
            EditorClass.chose_rad_point_num = -1;

            Object obj = EditorClass.obj;

            if (EditorClass.active_point_num < 0 && EditorClass.active_rad_point_num < 0)
            {
                for (int i = obj.StartVertex.Length - 1; i >= 0; i--) 
                    if (Operations.IsPointInCircle(map.GetScreenPosition(Operations.PointsOperations(obj.Vertex[i], obj.Pos, '+')), EditorClass.radius, e.Location))
                    {
                        EditorClass.chose_point_num = i;
                        break;
                    }
                if (EditorClass.chose_point_num < 0)
                {

                    for (int i = obj.RadPoints.Length - 1; i >= 0; i--)
                    {
                        if (Operations.IsPointInCircle(map.GetScreenPosition(Operations.PointsOperations(obj.RadPoints[i].Pos, obj.Pos, '+')), EditorClass.radius, e.Location))
                        {
                            EditorClass.chose_rad_point_num = i;
                            break;
                        }
                    }

                    if (EditorClass.chose_rad_point_num < 0)
                    {
                        Operations.BoolPointF bpf;
                        for (int i = 1; i < obj.Vertex.Length; i++)
                        {
                            bpf = Operations.IsPointInRadiusLine(Operations.PointsOperations(obj.Vertex[i - 1], obj.Pos, '+'), Operations.PointsOperations(map.Objects[0].Vertex[i], obj.Pos, '+'), map.GetMapPosition(e.Location), EditorClass.radius * map.Cam.Scale);
                            if (bpf.type == "Point")
                            {
                                label1.Text = Operations.GetStringFromPoint(map.GetScreenPosition(bpf.point_));
                                EditorClass.adding_point_num = i;
                                EditorClass.adding_point = bpf.point_;
                                break;
                            }
                        }

                        if (EditorClass.adding_point_num < 0)
                        {
                            bpf = Operations.IsPointInRadiusLine(Operations.PointsOperations(obj.Vertex[obj.Vertex.Length - 1], obj.Pos, '+'), Operations.PointsOperations(obj.Vertex[0], obj.Pos, '+'), map.GetMapPosition(e.Location), EditorClass.radius * map.Cam.Scale);
                            if (bpf.type == "Point")
                            {
                                label1.Text = Operations.GetStringFromPoint(map.GetScreenPosition(bpf.point_));
                                EditorClass.adding_point_num = 0;
                                EditorClass.adding_point = bpf.point_;
                            }
                        }
                    }
                }
            }
            else
                obj.ChangeVertex(Operations.PointsOperations(map.GetMapPosition(e.Location), obj.Pos, '-'), EditorClass.active_point_num);
        }
        //--------------------------------------------------------------------------
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            map.MouseUpEvents(e.Location);
            EditorClass.active_point_num = -1;
            EditorClass.active_rad_point_num = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            map.Drawing.InitScreenPoints();
            map.Events();
            map.Drawing.DrawAll();
            if (EditorClass.adding_point_num >= 0)
                map.Drawing.DrawCircle(new SolidBrush(Color.Black), map.GetScreenPosition(EditorClass.adding_point), EditorClass.radius);

            //for (int i = 0; i < EditorClass.obj.RadPoints.Length; i++)
            //{
            //    for (int j = 0; j < EditorClass.obj.RadPoints[i].Rays.Length; j++)
            //    {
            //        map.Drawing.DrawLine(Color.Red, map.GetScreenPosition(Operations.PointsOperations(map.Objects[0].Pos, EditorClass.obj.RadPoints[i].Pos, '+')), Operations.PointsOperations(map.GetScreenPosition(Operations.PointsOperations(map.Objects[0].Pos, EditorClass.obj.RadPoints[i].Pos, '+')), EditorClass.obj.RadPoints[i].Rays[j].Vector, '+'));
            //    }
            //}
            

            map.Drawing.Refresh();
        }
       
        private void ObjectEditor_KeyDown(object sender, KeyEventArgs e)
        {
            map.Cam.ChangeSpeed(e.KeyCode);
            map.Cam.ChangeScaleSpeed(e.KeyCode);

            if (e.KeyCode == BindKeys.delete) 
            {
                if (EditorClass.active_point_num >= 0 && map.Objects[0].StartVertex.Length > 3)
                {
                    map.Objects[0].RemoveVertex(EditorClass.active_point_num);
                    EditorClass.active_point_num = -1;
                    EditorClass.chose_point_num = -1;
                }
                if(EditorClass.active_rad_point_num>=0)
                {
                    map.Objects[0].RemoveRadPoint(EditorClass.active_rad_point_num);
                    EditorClass.active_rad_point_num = -1;
                }
            }
            if (e.KeyCode == Keys.R) window.ChangeSettingsVisibility(ref groupBox1);
        }

        private void ObjectEditor_KeyUp(object sender, KeyEventArgs e)
        {
            map.Cam.AnulateSpeed(e.KeyCode);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            PointF o = new PointF(0, 0);
            for (int i = 0; i < EditorClass.obj.StartVertex.Length; i++)
            {
                o = Operations.PointsOperations(o, EditorClass.obj.StartVertex[i], '+');
            }
            o = Operations.PointsOperations(o, new PointF(EditorClass.obj.StartVertex.Length, EditorClass.obj.StartVertex.Length), '/');
            for(int i = 0; i < EditorClass.obj.StartVertex.Length; i++)
            {
                EditorClass.obj.AddVertex(Operations.PointsOperations(EditorClass.obj.StartVertex[i], o, '-'), i);
                EditorClass.obj.RemoveVertex(i + 1);
            }
            editor_status = "Confirm";
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            editor_status = "Cancel";
            Close();
        }

        private void checkDrawVertex_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawVertex = checkDrawVertex.Checked;
        }

        private void checkDrawNormal_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawNormals = checkDrawNormal.Checked;
        }

        private void checkDrawVertexNormal_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawVertexNormal = checkDrawVertexNormal.Checked;
        }

        private void paramButton_Click(object sender, EventArgs e)
        {
            window.ChangeSettingsVisibility(ref groupBox1);
        }

        private void ObjectEditor_SizeChanged(object sender, EventArgs e)
        {
            window.WindowSize = new Point(Size.Width, Size.Height);
            pictureBox1.Size = window.ResizePB();
            pictureBox1.Location = window.ReposPB();

            PointTypeBox.Location = new Point(Width - PointTypeBox.Width - 25, 25);

            map.Drawing.InitGraphics();
        }

        private void fullScreen_CheckedChanged(object sender, EventArgs e)
        {
            window.ChangeFullScreenMode(this);
        }
    }
}