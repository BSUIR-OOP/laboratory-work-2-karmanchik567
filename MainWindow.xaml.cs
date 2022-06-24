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
using OOP_LR2_V2.FiguresLR1;
using OOP_LR2_V2.Factory;


namespace OOP_LR2_V2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button _activeBtn;
        private Point _rigthPoint;
        private Point _leftPoint;

        public MainWindow()
        {
            InitializeComponent();
            var figuresList = new List<BaseFigure>(); //список фигур
            IEnumerable<Type> shapesTypes = typeof(BaseFigure).Assembly.ExportedTypes.Where(t => typeof(BaseFigure).IsAssignableFrom(t) && t != typeof(BaseFigure));
            //переменная которая хранит в себе все подклассы BaseFigure но без него 

            foreach (var item in shapesTypes) 
            {
                Button btn = new Button() // создаем кнопку для каждого класса
                {
                    Margin = new Thickness(2),
                    Content = item.Name,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 150,
                    Height = 20,
                    Tag = item // отвечает за нажата ли кнопка или нет
                };
                btn.Click += SelectFigure; //cоздание новой кнопки
                DockPanel.SetDock(btn, Dock.Top);
                toolPanel.Children.Add(btn);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var relativeMouseCoordinates = e.GetPosition(this.DrawFieldCanvas);
            if (_activeBtn == null)// если кнопка не нажата
                return;
            else if (_leftPoint.X == 0)//есл нажата и нет точки
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
            Button button = (Button)sender; // определяется нажатая кнопка

            if (_activeBtn != null) _activeBtn.IsEnabled = true;
            
            _activeBtn = button;
            _activeBtn.IsEnabled = false;
        }
    }
}
