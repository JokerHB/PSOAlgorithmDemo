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
using System.Threading;

using PSO_MAX_VALUE.PSO;

namespace PSO_MAX_VALUE
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Thread Calcualte { get; set; }
        //private Thread GraphPoint { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //Graph.ShowGridLines = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(changeNumber.Text);
            int times = Convert.ToInt32(particalNumber.Text);
            Algorithm algorithm = new Algorithm(number, times, 2, -100, 100);
            //Calcualte = new Thread(algorithm.Running);
            //GraphPoint = new Thread(this.Display);

            //Calcualte.Start();
            //GraphPoint.Start();
           // GraphPoint.Suspend();
            //this.GraphBasic();
            while (algorithm.CurrentTime < Globle.MAX_CHANGE)
            {
                algorithm.Running();
                Display(algorithm.CurrentTime);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Display(int curTime)
        {
            this.Times.Content = (curTime).ToString();
            Graph.Children.Clear();
            Graph.Children.Add(Info);
            this.GraphBasic(100);
            this.GraphBasic(0);
            this.GraphBasicBtom(100);
            this.GraphBasicBtom(-100);
            if (Globle.Lines != null && Globle.Lines.Count > 0)
            {
                foreach (Polyline line in Globle.Lines)
                {
                    Graph.Children.Add(line);
                }
            }
            
            BestX1.Content = Globle.GlobleBestPostion[0].ToString();
            BestX2.Content = Globle.GlobleBestPostion[1].ToString();
            BestFitness.Content = Globle.GlobleBestFitness.ToString();
        }

        private void GraphBasic(int value)
        {
            Polyline lineTemp = new Polyline();
            lineTemp.VerticalAlignment = VerticalAlignment.Center;
            lineTemp.Stroke = SystemColors.WindowTextBrush;
            lineTemp.StrokeThickness = 4;

            for (int i = -100; i < (int)(Globle.Up); i++)
            {
                lineTemp.Points.Add(new Point(value, i));
            }
            Graph.Children.Add(lineTemp);
        }
        private void GraphBasicBtom(int value)
        {
            Polyline lineTemp = new Polyline();
            lineTemp.VerticalAlignment = VerticalAlignment.Center;
            lineTemp.Stroke = SystemColors.WindowTextBrush;
            lineTemp.StrokeThickness = 4;

            for (int i = 0; i < (int)(Globle.Up) ; i++)
            {
                lineTemp.Points.Add(new Point(i, value));
            }
            Graph.Children.Add(lineTemp);
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Calcualte.Abort();
            //this.GraphPoint.Abort();
        }
    }
}
