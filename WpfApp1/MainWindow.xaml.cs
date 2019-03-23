using System;
using System.Collections;
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

namespace WpfApp1
{
    /// <summary>
    /// doubleeraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Object3D> list;
        Object3D one;
        Object3D two;
        Object3D three;
        Object3D four;
        double fov = 256;

        public MainWindow()
        {
            InitializeComponent();
            InitObjects3D();
            Draw3Dto2D();
        }

        public void InitObjects3D()
        {
            list = new List<Object3D>();
            double[][] obj1 = new double[8][] { new double[3] {-200, 200, 200}, new double[3] { -400, 200, 200 }, new double[3] { -400, 400, 200 }, new double[3] { -200, 400, 200 }, new double[3] { -200, 200, 400 }, new double[3] { -400, 200, 400 }, new double[3] { -400, 400, 400 }, new double[3] { -200, 400, 400 } };
            one = new Object3D(obj1);
            list.Add(one);
            double[][] obj2 = new double[8][] { new double[3] { 200, 200, 200 }, new double[3] { 400, 200, 200 }, new double[3] { 400, 400, 200 }, new double[3] { 200, 400, 200 }, new double[3] { 200, 200, 300 }, new double[3] { 400, 200, 300 }, new double[3] { 400, 400, 300 }, new double[3] { 200, 400, 300 } };
            two = new Object3D(obj2);
            list.Add(two);
            double[][] obj3 = new double[8][] { new double[3] { 300, 300, 400 }, new double[3] { 400, 300, 400 }, new double[3] { 400, 400, 400 }, new double[3] { 300, 400, 400 }, new double[3] { 300, 300, 500 }, new double[3] { 400, 300, 500 }, new double[3] { 400, 400, 500 }, new double[3] { 300, 400, 500 } };
            three = new Object3D(obj3);
            list.Add(three);
            double[][] obj4 = new double[8][] { new double[3] { -200, 200, 850 }, new double[3] { -400, 200, 850 }, new double[3] { -400, 400, 850 }, new double[3] { -200, 400, 850 }, new double[3] { -200, 200, 950 }, new double[3] { -400, 200, 950 }, new double[3] { -400, 400, 950 }, new double[3] { -200, 400, 950 } };
            four = new Object3D(obj4);
            list.Add(four);
        }

        void WindowKeyHandler(object sender, System.Windows.Input.KeyEventArgs ev)
        {
            switch (ev.Key)
            {
                case Key.Right:
                    foreach(Object3D obj in list)
                    {
                        obj.move(-3,0,0);
                    }
                    Draw3Dto2D();
                    break;

                case Key.Left:
                    foreach (Object3D obj in list)
                    {
                        obj.move(3,0,0);
                    }
                    Draw3Dto2D();
                    break;

                case Key.Up:
                    foreach (Object3D obj in list)
                    {
                        obj.move(0,3,0);
                    }
                    Draw3Dto2D();
                    break;

                case Key.Down:
                    foreach (Object3D obj in list)
                    {
                        obj.move(0,-3,0);
                    }
                    Draw3Dto2D();
                    break;

                case Key.Q:
                    foreach (Object3D obj in list)
                    {
                        obj.move(0,0,-3);
                    }
                    Draw3Dto2D();
                    break;

                case Key.A:
                    foreach (Object3D obj in list)
                    {
                        obj.move(0,0,3);
                    }
                    Draw3Dto2D();
                    break;

                case Key.W:
                    foreach (Object3D obj in list)
                    {
                        obj.scale(1.25, 1.25, 1.25);
                    }
                    Draw3Dto2D();
                    break;

                case Key.S:
                    foreach (Object3D obj in list)
                    {
                        obj.scale(0.75, 0.75, 0.75);
                    }
                    Draw3Dto2D();
                    break;

                case Key.E:
                    fov += 5;
                    Draw3Dto2D();
                    break;

                case Key.D:
                    fov += -5;
                    Draw3Dto2D();
                    break;

                case Key.R:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateY(-10);
                    }
                    Draw3Dto2D();
                    break;

                case Key.F:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateY(10);
                    }
                    Draw3Dto2D();
                    break;
                case Key.T:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateX(10);
                    }
                    Draw3Dto2D();
                    break;

                case Key.G:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateX(-10);
                    }
                    Draw3Dto2D();
                    break;
                case Key.Y:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateZ(10);
                    }
                    Draw3Dto2D();
                    break;

                case Key.H:
                    foreach (Object3D obj in list)
                    {
                        obj.RotateZ(-10);
                    }
                    Draw3Dto2D();
                    break;
            }
           
        }

        public void Draw3Dto2D()
        {
            Dictionary<double, double[]> podoubles2d = new Dictionary<double, double[]>();
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Black;
            DrawingPanel.Children.Clear();
            double d = 100;
            double widthoffset = 500; 
            double heigthoffset = 100; 
            double i = 1;
            foreach (Object3D obj in list)
            {
                foreach (double[] podouble in obj.GetPoints())
                {
                    double conv = fov / (d + podouble[2]);
                    double x = podouble[0] * conv + widthoffset;
                    double y = podouble[1] * conv + heigthoffset;
                    double[] tmp = {x, y};
                    podoubles2d.Add(i,tmp);
                    i++;
                }
                for (double a = 1; a <= 5; a+=4) {
                    Line line12 = new Line();
                    line12.StrokeThickness = 1;
                    line12.Stroke = redBrush;
                    line12.X1 = podoubles2d[a][0];
                    line12.Y1 = podoubles2d[a][1];
                    line12.X2 = podoubles2d[a+1][0];
                    line12.Y2 = podoubles2d[a+1][1];
                    DrawingPanel.Children.Add(line12);
                    Line line23 = new Line();
                    line23.StrokeThickness = 1;
                    line23.Stroke = redBrush;
                    line23.X1 = podoubles2d[a + 1][0];
                    line23.Y1 = podoubles2d[a + 1][1];
                    line23.X2 = podoubles2d[a + 2][0];
                    line23.Y2 = podoubles2d[a + 2][1];
                    DrawingPanel.Children.Add(line23);
                    Line line34 = new Line();
                    line34.StrokeThickness = 1;
                    line34.Stroke = redBrush;
                    line34.X1 = podoubles2d[a+2][0];
                    line34.Y1 = podoubles2d[a+2][1];
                    line34.X2 = podoubles2d[a + 3][0];
                    line34.Y2 = podoubles2d[a + 3][1];
                    DrawingPanel.Children.Add(line34);
                    Line line41 = new Line();
                    line41.StrokeThickness = 1;
                    line41.Stroke = redBrush;
                    line41.X1 = podoubles2d[a+3][0];
                    line41.Y1 = podoubles2d[a+3][1];
                    line41.X2 = podoubles2d[a][0];
                    line41.Y2 = podoubles2d[a][1];
                    DrawingPanel.Children.Add(line41);
                }
                Line line15 = new Line();
                line15.StrokeThickness = 1;
                line15.Stroke = redBrush;
                line15.X1 = podoubles2d[1][0];
                line15.Y1 = podoubles2d[1][1];
                line15.X2 = podoubles2d[5][0];
                line15.Y2 = podoubles2d[5][1];
                DrawingPanel.Children.Add(line15);
                Line line26 = new Line();
                line26.StrokeThickness = 1;
                line26.Stroke = redBrush;
                line26.X1 = podoubles2d[2][0];
                line26.Y1 = podoubles2d[2][1];
                line26.X2 = podoubles2d[6][0];
                line26.Y2 = podoubles2d[6][1];
                DrawingPanel.Children.Add(line26);
                Line line37 = new Line();
                line37.StrokeThickness = 1;
                line37.Stroke = redBrush;
                line37.X1 = podoubles2d[3][0];
                line37.Y1 = podoubles2d[3][1];
                line37.X2 = podoubles2d[7][0];
                line37.Y2 = podoubles2d[7][1];
                DrawingPanel.Children.Add(line37);
                Line line48 = new Line();
                line48.StrokeThickness = 1;
                line48.Stroke = redBrush;
                line48.X1 = podoubles2d[4][0];
                line48.Y1 = podoubles2d[4][1];
                line48.X2 = podoubles2d[8][0];
                line48.Y2 = podoubles2d[8][1];
                DrawingPanel.Children.Add(line48);
                podoubles2d.Clear();
                i = 1;
            }
            
        }

    }
}
