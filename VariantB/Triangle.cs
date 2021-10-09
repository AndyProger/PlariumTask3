using System;

namespace VariantB
{
    class Triangle
    {
        // кортеж
        private (Points2D pointA, Points2D pointB, Points2D pointC) TupleOfPoints;
        public double SideA { get => Points2D.FindSide(TupleOfPoints.pointA, TupleOfPoints.pointB); }
        public double SideB { get => Points2D.FindSide(TupleOfPoints.pointB, TupleOfPoints.pointC); }
        public double SideC { get => Points2D.FindSide(TupleOfPoints.pointA, TupleOfPoints.pointC); }
        private static uint indexCounter = 0; 
        public uint index { get; private set; }
        public double Area
        {
            get
            {
                var p = (SideA + SideB + SideC) / 2.0;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        public Triangle(Points2D a, Points2D b, Points2D c)
        {
            TupleOfPoints.pointA = a;
            TupleOfPoints.pointB = b;
            TupleOfPoints.pointC = c;
            index = ++indexCounter;
        }

        // является ли равнобедренным
        public static bool IsIsosceles(Triangle triangle)
        {
            var A = triangle.SideA;
            var B = triangle.SideB;
            var C = triangle.SideC;

            return A == B || B == C || C == A; 
        }

        // является ли равносторонним
        public static bool IsEquilateral(Triangle triangle)
        {
            var A = triangle.SideA;
            var B = triangle.SideB;
            var C = triangle.SideC;

            return A == B && B == C && C == A;
        }

        // является ли прямоугольным 
        public static bool IsRectangular(Triangle triangle)
        {
            var A = Math.Pow(triangle.SideA,2.0);
            var B = Math.Pow(triangle.SideB, 2.0);
            var C = Math.Pow(triangle.SideC, 2.0);

            return A == B + C || B == A + C || C == A + B;
        }

        // является ли тупоугольным с площадью больше заданной
        public static bool IsObtuseLargerSpecifiedArea(Triangle triangle, double specAre)
        {
            var A = Math.Pow(triangle.SideA, 2.0);
            var B = Math.Pow(triangle.SideB, 2.0);
            var C = Math.Pow(triangle.SideC, 2.0);

            return (A > B + C || B > A + C || C > A + B) && triangle.Area > specAre;
        }

        public override string ToString()
        {
            return $"Triange #{ index}";
        }
    }
}
