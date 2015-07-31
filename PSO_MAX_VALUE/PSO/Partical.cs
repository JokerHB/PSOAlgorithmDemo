using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_MAX_VALUE.PSO
{
    class Partical
    {
        public  int MAX_DIM { get;private set; }
        public double BestFitness { get; set; }
        public double PreviousFitness { get; set; }
        public List<double> Position { get; set; }
        public List<double> PreviousBest { get; set; }
        public List<double> Speed { get; set; }

        private static Random ra = new Random();

        public delegate double DelegateFitness(Partical partical);

        public DelegateFitness myFunciotn = new DelegateFitness(Algorithm.Function);
        public Partical(int dim = 2,int bottom = -100,int up = 100)
        {
            this.MAX_DIM = dim;

            this.PreviousFitness = 0;
            //this.BestFitness = 0;
            this.Position = new List<double>(this.MAX_DIM);
            this.PreviousBest = new List<double>(this.MAX_DIM);
            this.Speed = new List<double>(this.MAX_DIM);

            for (int i = 0; i < MAX_DIM; i++)
            {
                double tmp = ra.Next(bottom,up);
                this.Position.Add(tmp);
                this.PreviousBest.Add(tmp);
                this.Speed.Add(0);
            }
            //this.CalFitness();
        }
        public bool CalFitness()
        {
            this.BestFitness = this.myFunciotn(this);

            if (this.BestFitness > this.PreviousFitness)
            {
                for (int i = 0; i < this.MAX_DIM; i++)
                {
                    this.PreviousBest[i] = this.Position[i];
                }
                this.PreviousFitness = this.BestFitness;
            }

            if (this.PreviousFitness > Globle.GlobleBestFitness)
            {
                for (int i = 0; i < this.MAX_DIM; i++)
                {
                   Globle.GlobleBestPostion[i] = this.PreviousBest[i];
                }
                Globle.GlobleBestFitness = this.PreviousFitness;
            }
            return true;
        }
        public bool UpdeSpeed()
        {
            for (int i = 0; i < this.MAX_DIM; i++)
            {
                this.Speed[i] = Globle.w * this.Speed[i] + Globle.c1 * Globle.RandowNumber() * (this.PreviousBest[i] - this.Position[i])
                    + Globle.c2 * Globle.RandowNumber() * (Globle.GlobleBestPostion[i] - this.Position[i]);

                if (this.Speed[i] >= Globle.MaxSpeed[i])
                {
                    this.Speed[i] = Globle.MaxSpeed[i];
                }
            }
                return true;
        }
        public bool UptePosition()
        {
            for (int i = 0; i < this.MAX_DIM; i++)
            {
                this.Position[i] = this.Position[i] + this.Speed[i];

                if (this.Position[i] > Globle.MaxPostion[i])
                {
                    this.Position[i] = Globle.MaxPostion[i];
                }
            }

            return true;
        }
    }
}