using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Figures;
using System.Windows;
using System.Reflection;

namespace lab2.Factory
{
    public static class FigureFactory
    {
        public static BaseFigure Build(Type shapeType, Point? point1, Point? point2)
        {
            ConstructorInfo ctor = shapeType.GetConstructor(new[] { typeof(Point), typeof(Point) });
            return (BaseFigure)ctor.Invoke(new object[] { point1, point2 });

        }

    }
}
