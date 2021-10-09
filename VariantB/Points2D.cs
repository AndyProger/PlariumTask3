using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariantB
{
    class Points2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Points2D()
        {
            X = 0;
            Y = 0;
        }

        public Points2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Points2D(Points2D other)
        {
            X = other.X;
            Y = other.Y;
        }

        public static double FindSide(Points2D a, Points2D b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2.0) + Math.Pow(b.Y - a.Y, 2.0));
        }
    }
}
