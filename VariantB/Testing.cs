using System;

namespace VariantB
{
    class Testing
    {
        static void Main(string[] args)
        {
            // Triangle #1 прямоугольный
            Triangle a = new Triangle(new Points2D(-3, -2), new Points2D(0, -1), new Points2D(-2, 5));
            // Triangle #2 равнобедренный
            Triangle b = new Triangle(new Points2D(0, 3), new Points2D(-2, -3), new Points2D(-6, 1));
            // Triangle #3 равносторонний
            Triangle c = new Triangle(new Points2D(-2, 0), new Points2D(4, 0), new Points2D(1.0, 3.0*Math.Sqrt(3.0)));
            // Triangle #4 тупоугольный
            Triangle d = new Triangle(new Points2D(2, 3), new Points2D(6, 7), new Points2D(-7, 2));

            TriangleCollection collection = new TriangleCollection(a,b,c,d);

            //----------------------------------------------------
            var tmp = collection.FindRectangular();

            foreach(Triangle triangle in tmp)
                Console.WriteLine(triangle);

            Console.WriteLine(new string('-',25));

            //----------------------------------------------------
            tmp = collection.FindIsosceles();

            foreach (Triangle triangle in tmp)
                Console.WriteLine(triangle);

            Console.WriteLine(new string('-', 25));

            //----------------------------------------------------
            tmp = collection.FindEquilateral();

            foreach (Triangle triangle in tmp)
                Console.WriteLine(triangle);

            Console.WriteLine(new string('-', 25));

            //----------------------------------------------------
            tmp = collection.FindObtuseLargerSpecifiedArea(-100);

            foreach (Triangle triangle in tmp)
                Console.WriteLine(triangle);

        }
    }
}
