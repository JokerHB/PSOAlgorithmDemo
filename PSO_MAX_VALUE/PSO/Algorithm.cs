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

namespace PSO_MAX_VALUE.PSO
{
    class Algorithm
    {
        public int CurrentTime { get; set; }
        public List<Partical> partical { get; set; }
        public Algorithm(int change = 20, int particle = 20, int dim = 2, int bottom = -100, int up = 100)
        {
            Globle.MAX_CHANGE = change;
            Globle.MAX_DIM = dim;
            Globle.MAX_PARTICLE = particle;
            Globle.GlobleBestFitness = 0;
            Globle.Up = up;
            Globle.Bottom = bottom;
            Globle.Lines = new List<Polyline>(Globle.MAX_PARTICLE);
            Globle.GlobleBestPostion = new List<double>(Globle.MAX_DIM);
            //Globle.partical = new List<Partical>(Globle.MAX_PARTICLE);
            this.partical = new List<Partical>(Globle.MAX_PARTICLE);
            this.CurrentTime = 0;
            Globle.MaxSpeed = new List<double>(Globle.MAX_DIM);
            Globle.MaxPostion = new List<double>(Globle.MAX_DIM);

            for (int i = 0; i < Globle.MAX_DIM; i++)
            {
                Random ra = new Random();

                Globle.MaxPostion.Add(up);
                Globle.MaxSpeed.Add(up / (1.5));
                Globle.GlobleBestPostion.Add(ra.Next(bottom,up));
            }

            Globle.GlobleBestFitness = Globle.GlobleBestPostion[0] + Globle.GlobleBestPostion[1];

            for (int i = 0; i < Globle.MAX_PARTICLE; i++)
            {
                Partical newPartical = new Partical(Globle.MAX_DIM, bottom, up);

                //Globle.partical.Add(newPartical);
                this.partical.Add(newPartical);
            }
        }
        public static double Function(Partical partical)
        {
            double ans = 0;

            for (int i = 0; i < partical.MAX_DIM; i++)
            {
                ans += partical.Position[i];
            }

            return ans;
        }
        public void Running()
        {
            this.CurrentTime++;
            for (int i = 0; i < Globle.MAX_PARTICLE; i++)
            {
                //Globle.partical[i].CalFitness();
                this.partical[i].CalFitness();
            }
            for (int i = 0; i < Globle.MAX_PARTICLE; i++)
            {
                //Globle.partical[i].UpdeSpeed();
                this.partical[i].UptePosition();
            }
            for (int i = 0; i < Globle.MAX_PARTICLE; i++)
            {
                //Globle.partical[i].UptePosition();
                this.partical[i].UptePosition();
            }
            this.Graph();
            //return true;
        }
        public void  Graph()
        {
           // Globle.Lines = new List<Polyline>(Globle.MAX_PARTICLE);
            Globle.Lines.Clear();
            for (int i = 0; i < Globle.MAX_PARTICLE; i++)
            {
                Polyline lineTemp = new Polyline();
                lineTemp.VerticalAlignment = VerticalAlignment.Center;
                lineTemp.Stroke = SystemColors.WindowTextBrush;
                lineTemp.StrokeThickness = 2;

                lineTemp.Points.Add(new Point(this.partical[i].Position[0], this.partical[i].Position[1]));
                lineTemp.Points.Add(new Point(this.partical[i].Position[0] + 1, this.partical[i].Position[1] + 1));

                Globle.Lines.Add(lineTemp);
            }
            //return lines;
        }
    }
}
