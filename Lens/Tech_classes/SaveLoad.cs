using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Lens
{
    public static class SaveLoad
    {
        static string path = Application.StartupPath + "\\saves\\";
        static string file_name = "save";
        static string file_format = ".gg";
        static Map map;

        public static string FileFormat
        {
            get
            {
                return file_format;
            }
        }
        public static string Path
        {
            get
            {
                return path;
            }
        }
        public static string FileName
        {
            get
            {
                return file_name;
            }
            set
            {
                file_name = value;
            }
        }

        public static void Save()
        {
            CreateFile();
            StreamWriter stw = new StreamWriter(path + file_name + file_format);

            stw.WriteLine(Operations.GetStringFromPoint(map.Size));
            stw.WriteLine(Operations.GetStringFromPoint(map.Cam.Pos) + ' ' + map.Cam.Scale.ToString());
            for (int i = 0; i < map.Objects.Length; i++)
            {
                stw.WriteLine(Operations.GetStringFromPoint(map.Objects[i].Pos) + ' '
                    + map.Objects[i].StartVertex.Length + ' '
                    + Operations.GetStringFromPoint(map.Objects[i].StartVertex) + ' '
                    + map.Objects[i].Angle.ToString() + ' '
                    + map.Objects[i].Brush.Color.A.ToString() + ' '
                    + map.Objects[i].Brush.Color.R.ToString() + ' '
                    + map.Objects[i].Brush.Color.G.ToString() + ' '
                    + map.Objects[i].Brush.Color.B.ToString());
            }
            stw.Close();
        }
        public static void Load()
        {
            try
            {
                string[] saves = File.ReadAllLines(path + file_name + file_format);
                //0 - map
                //1 - cam
                //2-... - objects
                string[] one_line = saves[0].Split(' ');
                Point map_size = new Point(int.Parse(one_line[0]), int.Parse(one_line[1]));
                one_line = saves[1].Split(' ');
                Point cam_pos = new Point(int.Parse(one_line[0]), int.Parse(one_line[1]));
                float scale = float.Parse(one_line[2]);
                Cam cam = new Cam(cam_pos, scale);
                Object[] objects = new Object[0];
                for (int i = 2; i < saves.Length - 1; i++)
                {
                    //for (int j = 0; j < one_line.Length; j++)
                    //    if (one_line[j] == ",") one_line[j] = ".";
                    one_line = saves[i].Split(' ');
                    int line_length = one_line.Length;
                    PointF obj_pos = new PointF(int.Parse(one_line[0]), int.Parse(one_line[1]));
                    PointF[] obj_vertex = new PointF[int.Parse(one_line[2])];
                    for (int j = 0; j < int.Parse(one_line[2]); j++)
                        obj_vertex[j] = new PointF(int.Parse(one_line[3 + j * 2]), int.Parse(one_line[4 + j * 2]));
                    Array.Resize(ref objects, objects.Length + 1);
                    double angle = int.Parse(one_line[3 + (int.Parse(one_line[2]) * 2)]);
                    objects[objects.Length - 1] = new Object(obj_pos, angle, obj_vertex, objects.Length - 1);
                }
                map.ReInitMap(map_size, cam, objects);
            }
            catch
            {
                MessageBox.Show("Loading Error! Try to load else file");
            }
        }
        public static void CreateFile()
        {
            try
            {
                FileStream str = new FileStream(path + file_name + file_format, FileMode.Create);
                str.Close();
            }
            catch
            {
            }
        }
        public static void Init(ref Map map_)
        {
            map = map_;
            Directory.CreateDirectory(path);
        }
    }
}
