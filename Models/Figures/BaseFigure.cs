using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace OOP_LR2_V2.FiguresLR1
{
    public abstract class BaseFigure
    {
        public abstract string FigureName();
        public abstract void ShowFigure();
        public abstract void drawCanvas(Canvas canvas);

        public static System.Windows.Shapes.Line drawLine(int x1, int x2, int y1, int y2)
        {
            var myLine = new System.Windows.Shapes.Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 3;
            return myLine;
        }

    }
}
