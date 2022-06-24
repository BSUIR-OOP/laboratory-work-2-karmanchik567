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
    public class Triangle : BaseFigure
    {
        private int x1, y1;
        private int x2, y2;
        private int x3, y3;

        public int p_x1 { get { return x1; } set { x1 = value; } }
        public int p_x2 { get { return x2; } set { x2 = value; } }
        public int p_x3 { get { return x3; } set { x3 = value; } }
        public int p_y1 { get { return y1; } set { y1 = value; } }
        public int p_y2 { get { return y2; } set { y2 = value; } }
        public int p_y3 { get { return y3; } set { y3 = value; } }

        public Triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public Triangle(Point point1, Point point2) :
       this(
           (int)(point1.X),
           (int)(point1.Y),
           (int)(point2.X),
           (int)(point2.Y),
           (int)(point1.X - (point1.X - point2.X) / 2),
           (int)(point1.Y)
         )
        { }
        public override void drawCanvas(Canvas canvas)
        {
            var myLine = drawLine(x1, x2, y1, y2);
            canvas.Children.Add(myLine);
            myLine = drawLine(x2, x3, y2, y3);
            canvas.Children.Add(myLine);
            myLine = drawLine(x1, x3, y1, y3);
            canvas.Children.Add(myLine);
        }
    }
}

