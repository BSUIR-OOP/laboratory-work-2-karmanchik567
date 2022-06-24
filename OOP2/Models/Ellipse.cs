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
    public class Ellipse: BaseFigure
    {
        private protected int mainAxis, additionalAxis;
        private protected int x, y;
        public virtual int mainAx { get { return mainAxis; } set { mainAxis = value; } }
        public virtual int additionalAx { get { return additionalAxis; } set { additionalAxis = value; } }
        public int p_x { get { return x; } set { x = value; } }
        public int p_y { get { return y; } set { y = value; } }

        public Ellipse(int x1,int y1, int axis1,int axis2)
        {
            mainAxis = axis1;
            additionalAxis = axis2;
            x = x1;
            y = y1;
        }
        public Ellipse(Point point1, Point point2) :
        this(
            (int)point1.X,
            (int)point1.Y,
            (int)Math.Abs(point1.X - point2.X),
            (int)Math.Abs(point1.Y - point2.Y)
        )
        { }

        public override void drawCanvas(Canvas canvas)
        {
            System.Windows.Shapes.Ellipse circl = new System.Windows.Shapes.Ellipse();
            circl.Width = 2 * mainAxis;
            circl.Height = 2 * additionalAxis;
            
            Canvas.SetTop(circl, y - additionalAxis);
            Canvas.SetLeft(circl, x - mainAxis);
            circl.Stroke = System.Windows.Media.Brushes.Black;
            circl.StrokeThickness = 3;
            canvas.Children.Add(circl);
        }
       
    }
}
