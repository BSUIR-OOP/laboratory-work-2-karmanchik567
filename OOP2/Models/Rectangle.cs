using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace lab2.Figures
{
    public class Rectangle : Parallelogram
    {
        public override int p_x3 { get { return x3; } }
        public override int p_x4 { get { return x4; } }
        public override int p_y3 { get { return y3; } }
        public override int p_y4 { get { return y4; } }
        public Rectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x1, y2, x2, y2, x2, y1)
        {

        }
        public Rectangle(Point point1, Point point2) :
              this(
                  (int)(point1.X),
                  (int)(point1.Y),
                  (int)(point2.X),
                  (int)(point2.Y)
              )
        { }
    }
}

