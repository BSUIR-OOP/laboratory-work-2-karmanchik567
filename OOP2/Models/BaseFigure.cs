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
    public abstract class BaseFigure
    {
        public abstract void drawCanvas(Canvas canvas);

        public static System.Windows.Shapes.Line drawLine(int x1, int x2, int y1, int y2)
        {
            var Line = new System.Windows.Shapes.Line();
            Line.Stroke = System.Windows.Media.Brushes.Black;
            Line.X1 = x1;
            Line.X2 = x2;
            Line.Y1 = y1;
            Line.Y2 = y2;
            Line.HorizontalAlignment = HorizontalAlignment.Left;
            Line.VerticalAlignment = VerticalAlignment.Center;
            Line.StrokeThickness = 3;
            return Line;
        }

    }
}
