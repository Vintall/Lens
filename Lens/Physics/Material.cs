using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lens
{
    public class Material
    {
        float transparency = 0.3f; //Пропускаемость   
        float reflection = 0.2f;   //Отражение
        float absorption = 0.5f;   //Поглощение
        float n = 1.2f;
        public Color first_color = Color.Green;
        public Color color;
        
        public void InitMaterialColor()
        {
            float a, r, g, b;
            a = 255 * (1 - transparency);
            r = first_color.R / 255f;
            g = first_color.G / 255f;
            b = first_color.B / 255f;

            r += reflection * (1 - r) - absorption * r;
            g += reflection * (1 - g) - absorption * g;
            b += reflection * (1 - b) - absorption * b;
            
            r *= 255f;
            g *= 255f;
            b *= 255f;

            if (a >= 0 && a <= 255 && r >= 0 && r <= 255 && g >= 0 && g <= 255 && b >= 0 && b <= 255)
                color = Color.FromArgb((int)a, (int)r, (int)g, (int)b);
            
        }
        public float N_koef
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
            }
        }
        public float Transparency
        {
            get
            {
                return transparency;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    reflection += (reflection / (reflection + absorption)) * (transparency - value);
                    absorption += (absorption / (reflection + absorption)) * (transparency - value);
                    transparency = value;

                    transparency = (float)Math.Round(transparency, 2);
                    reflection = (float)Math.Round(reflection, 2);
                    absorption = (float)Math.Round(absorption, 2);

                    if (transparency + absorption + reflection != 1) 
                        transparency += 1 - (transparency + absorption + reflection);


                    InitMaterialColor();
                }
            }
        }
        public float Reflection
        {
            get
            {
                return reflection;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    transparency += (transparency / (transparency + absorption)) * (reflection - value);
                    absorption += (absorption / (transparency + absorption)) * (reflection - value);
                    reflection = value;

                    transparency = (float)Math.Round(transparency, 2);
                    reflection = (float)Math.Round(reflection, 2);
                    absorption = (float)Math.Round(absorption, 2);

                    if (transparency + absorption + reflection != 1)
                       reflection += 1 - (transparency + absorption + reflection);

                    InitMaterialColor();
                }
            }
        }
        public float Absorption
        {
            get
            {
                return absorption;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    transparency += (transparency / (transparency + reflection)) * (absorption - value);
                    reflection += (reflection / (transparency + reflection)) * (absorption - value);
                    absorption = value;

                    transparency = (float)Math.Round(transparency, 2);
                    reflection = (float)Math.Round(reflection, 2);
                    absorption = (float)Math.Round(absorption, 2);

                    if (transparency + absorption + reflection != 1)
                        absorption += 1 - (transparency + absorption + reflection);

                        InitMaterialColor();
                }
            }
        }
    }
}
