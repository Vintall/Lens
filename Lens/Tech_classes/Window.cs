using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lens
{
    public class Window
    {
        Point window_size; //Размер окна приложения
        Point pb_size; //Размер области отрисовки
        Point monitor_size; //Размер монитора

        float win_attitute = 1.5F;

        bool settings_visibility; //видимость окна с настройками
        bool full_screen_mode = false; //Режим полного экрана
    
        public Window(Size size, Size windows_screen_size)
        {
            window_size = new Point(size.Width, size.Height);
            pb_size = new Point(size.Width - 8, size.Height - 47);
            monitor_size = new Point(windows_screen_size.Width, windows_screen_size.Height);
            win_attitute = (float)monitor_size.X / monitor_size.Y;
        }
        
        public Point Pb_size //Свойство размера полотна
        {   
            get
            {
                return pb_size;
            }
        }

        public void ChangeSettingsVisibility(ref GroupBox gb) //Изменение видимости окна настроек
        {
            if(gb.Visible)
            {
                gb.Visible = false;
            }
            else
            {
                gb.Visible = true;
            }
        }

        public void ChangeFullScreenMode(Form form) //Режим работы "на весь экран"
        {
            if (full_screen_mode)
            {
                full_screen_mode = false;
                form.WindowState = FormWindowState.Normal;
                form.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                full_screen_mode = true;
                form.WindowState = FormWindowState.Maximized;
                form.FormBorderStyle = FormBorderStyle.None;
            }
        }

        public Point WindowSize
        {
            set { window_size = value; }
        }
        
        public Size ResizePB()
        {
            float winAttit = (float)window_size.X / window_size.Y;
            if (winAttit == win_attitute) pb_size = window_size;
            else if (winAttit > win_attitute) pb_size = new Point((int)(window_size.Y * win_attitute), window_size.Y);
            else if (winAttit < win_attitute) pb_size = new Point(window_size.X, (int)(window_size.X / win_attitute));
            if (full_screen_mode) return new Size(pb_size.X, pb_size.Y);
            else return new Size(pb_size.X - 8, pb_size.Y - 37);
        }

        public Point ReposPB()
        {
            return new Point((window_size.X - pb_size.X) / 2, (window_size.Y - pb_size.Y) / 2);
        }
    }
}