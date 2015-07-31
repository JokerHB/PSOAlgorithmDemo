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

namespace PSO_MAX_VALUE.PSO
{
    public class Globle
    {
        public static int MAX_CHANGE { get; set; }
        public static int MAX_PARTICLE { get; set; }
        public static int MAX_DIM { get; set; }
        public static double GlobleBestFitness { get; set; }
        public static List<double> GlobleBestPostion { get; set; }
        //public static List<Partical> partical { get; set; }
        public static List<double> MaxSpeed { get; set; }
        public static List<double> MaxPostion { get; set; }
        public static List<Polyline> Lines { get; set; }
        public static double Up { get; set; }
        public static double Bottom { get; set; }

        public static double w =  0.825;
        public static double c1 = 2.0;
        public static double c2 = 2.0;
        public static double RandowNumber()
        {
            Random ra = new Random();
            double ans = ra.Next(0,1000);

            return ans / 1000;
        }
    }
}
