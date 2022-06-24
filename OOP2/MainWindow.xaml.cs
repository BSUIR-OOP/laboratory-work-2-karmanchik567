using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab2.Figures;
using lab2.Factory;


namespace lab2
{
    public partial class MainWindow : Window
    {
        private Button _activeBtn;
        private Point _rigthPoint;
        private Point _leftPoint;

        public MainWindow()
        {
            InitializeComponent();
            var figuresList = new List<BaseFigure>();
            IEnumerable<Type> shapesTypes = typeof(BaseFigure).Assembly.ExportedTypes.Where(t => typeof(BaseFigure).IsAssignableFrom(t) && t != typeof(BaseFigure));

            foreach (var item in shapesTypes)
            {
                Button btn = new Button()
                {
                    Margin = new Thickness(2),
                    Content = item.Name,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 200,
                    Height = 50,
                    Tag = item
                    
                };
                btn.FontSize = 25;   
                btn.Click += SelectFigure;
                DockPanel.SetDock(btn, Dock.Top);
                toolPanel.Children.Add(btn);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.DrawFieldCanvas);
            if (_activeBtn == null)
                return;
            else if (_leftPoint.X == 0)
                _leftPoint = new Point((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);
            else
            {
                _rigthPoint = new Point((int)relativeMouseCoordinates.X, (int)relativeMouseCoordinates.Y);

                BaseFigure shape = FigureFactory.Build((Type)_activeBtn.Tag, _rigthPoint, _leftPoint);
                shape.drawCanvas(DrawFieldCanvas);
                
                 _rigthPoint.X = _leftPoint.X = 0;
                _rigthPoint.Y = _leftPoint.Y = 0;
            }
        }

        private void SelectFigure(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (_activeBtn != null) _activeBtn.IsEnabled = true;
            
            _activeBtn = button;
            _activeBtn.IsEnabled = false;
        }
    }
}
