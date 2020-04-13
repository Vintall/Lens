using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lens
{
    public partial class MainForm : Form
    {
        Window window;
        public Map map;

        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;

            window = new Window(Size, Screen.PrimaryScreen.Bounds.Size); // Узнаём размер экрана
            map = new Map(ref window, "Main");
            map.InitDrawing(ref pictureBox1, ref map);
            checkDrawObj.Checked = map.Drawing.Identif.DrawObj;
            checkDrawVerge.Checked = map.Drawing.Identif.DrawVerge;
            checkDrawVertex.Checked = map.Drawing.Identif.DrawVertex;
            checkDrawNormal.Checked = map.Drawing.Identif.DrawNormals;
            checkDrawVertexNormal.Checked = map.Drawing.Identif.DrawVertexNormal;

            pictureBox1.Size = window.ResizePB();
            pictureBox1.Location = window.ReposPB();

            SaveLoad.Init(ref map);
            
            timer1.Interval = 16; //60 fps  1000 / 16 ~~ 60 fps
            timer1.Start();
        }

        void DrawAll()
        {
            map.Drawing.InitScreenPoints();
            map.Drawing.DrawAll();
            label1.Text = map.ActiveCircle.Activity + "   " + map.ActiveCircle.Angle.ToString();
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            map.Events();


            map.InitRays();
            map.Drawing.DrawRays();


            DrawAll();
        }

        private void AddObject_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ObjectEditor obj_edit = new ObjectEditor(map.Cam.Scale);
            obj_edit.ShowDialog();
            if (obj_edit.editor_status == "Confirm")
                map.CreateNewObject(obj_edit.map.Objects[0], map.Cam.Pos);
            
            obj_edit.Dispose();
            timer1.Start();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (map.ActiveCircle.Activity != "None Active")
            {
                timer1.Stop();
                ObjectEditor obj_edit = new ObjectEditor(map.Cam.Scale, map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])]);
                obj_edit.ShowDialog();
                if (obj_edit.editor_status == "Confirm")
                {
                    map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])] = new Object(map.ActiveCircle.Pos, obj_edit.map.Objects[0], obj_edit.obj_num);
                    map.ActiveCircle.InitCircle(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])]);
                }
                obj_edit.Dispose();
                timer1.Start();
            }
            
        }

        private void paramButton_Click(object sender, EventArgs e)
        {
            window.ChangeSettingsVisibility(ref groupBox1);
        }

        private void fullScreen_CheckedChanged(object sender, EventArgs e)
        {
            window.ChangeFullScreenMode(this);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            map.MouseUpEvents(e.Location);
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            map.MouseMoveEvents(e.Location);


           
            //DrawAll();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            map.MouseDownEvents(e.Location);

            DrawAll();
        }

        private void FormSizeChanged(object sender, EventArgs e)
        {
            window.WindowSize = new Point(Size.Width, Size.Height);
            pictureBox1.Size = window.ResizePB();
            pictureBox1.Location = window.ReposPB();
            map.Drawing.InitGraphics();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            map.Cam.ChangeSpeed(e.KeyCode);
            map.Cam.ChangeScaleSpeed(e.KeyCode);
            
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            map.Cam.AnulateSpeed(e.KeyCode);
            map.Cam.AnulateSpeed(e.KeyCode);

            if (e.KeyCode == Keys.R) window.ChangeSettingsVisibility(ref groupBox1);


            map.Drawing.DrawRays();
        }

        private void transparencyBar_Scroll(object sender, EventArgs e)
        {

            if (map.ActiveCircle.Activity != "None Active" && transparencyBar.Value <= 100)  
            {
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Transparency = transparencyBar.Value / 100f;
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].InitColor();


                int ab = (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Absorption * 100f);
                int re = (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Reflection * 100f);

                if (re >= 0 && re <= 100)
                    reflectionBar.Value = re;
                if (ab >= 0 && ab <= 100)
                    absorptionBar.Value = ab;
            }
        }
        private void reflectionBar_Scroll(object sender, EventArgs e)
        {
            if (map.ActiveCircle.Activity != "None Active" && reflectionBar.Value <= 100) 
            {
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Reflection = reflectionBar.Value / 100f;
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].InitColor();
                
                int tr= (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Transparency * 100f);
                int ab = (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Absorption * 100f);
                if (tr>=0 && tr<=100)
                    transparencyBar.Value = tr;
                if(ab>=0 && ab <=100)
                absorptionBar.Value = ab;
            }
        }

        private void absorptionBar_Scroll(object sender, EventArgs e)
        {
            if (map.ActiveCircle.Activity != "None Active" && absorptionBar.Value <= 100) 
            {
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Absorption = absorptionBar.Value/100f;
                map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].InitColor();

                int tr = (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Transparency * 100f);
                int re = (int)(map.Objects[int.Parse(map.ActiveCircle.Activity.Split(' ')[1])].Reflection * 100f);

                if (tr >= 0 && tr <= 100)
                    transparencyBar.Value = tr;

                if (re >= 0&&re<=100)
                reflectionBar.Value = re;
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveForm save = new SaveForm();
            save.ShowDialog();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadForm load = new LoadForm();
            load.ShowDialog();
        }

        private void checkDrawObj_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawObj = checkDrawObj.Checked;
        }

        private void checkDrawVerge_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawVerge = checkDrawVerge.Checked;
        }

        private void checkDrawVertex_CheckedChanged(object sender, EventArgs e)
        {
            map.Drawing.Identif.DrawVertex = checkDrawVertex.Checked;
        }

        private void DrawRaysButton_Click(object sender, EventArgs e)
        {
            // map.InitRays();
            // map.Drawing.DrawRays();
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                map.CreateNewObject(new PointF(rnd.Next(15000, 25000), rnd.Next(15000, 25000)));
        }
    }
}
