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
    public class Parallelogram: Quadrangle
    {
        public Parallelogram(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) : base(x1, y1, x2, y2, x3, y3, x4,y4)
        {
        }
        public Parallelogram(Point point1, Point point2) :
             this
            (
                 (int)(point1.X),
                 (int)(point1.Y),
                 (int)(point2.X - (point2.X - point1.X)/2),
                 (int)(point2.Y),
                 (int)(point2.X),
                 (int)(point2.Y),
                 (int)(point2.X - (point2.X - point1.X) / 2),
                 (int)(point1.Y)
             )
        { }
     
    }
}
