using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lens
{
    public class Line
    {
        private PointF[] pos = { new PointF(0, 0), new PointF(0, 0) };
        public Line()
        {
           
        }
        public Line(PointF p1, PointF p2)
        {
            InitLine(p1, p2);

        }
        public void InitLine(PointF p1, PointF p2)
        {
            pos[0] = p1;
            pos[2] = p2;
        }
        public PointF[] Pos
        {
            get
            {
                return pos;
            }
        }
    }
}
