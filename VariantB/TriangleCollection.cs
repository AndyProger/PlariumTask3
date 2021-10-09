using System;
using System.Collections.Generic;

namespace VariantB
{
    class TriangleCollection
    {
        public List<Triangle> Triangles { get; set; } = new List<Triangle>();

        private delegate bool Method(Triangle triangle);

        public TriangleCollection(params Triangle[] triangles)
        {
            foreach(Triangle triangle in triangles)
            {
                Triangles.Add(triangle);
            }
        }

        private List<Triangle> Find(Method method)
        {
            List<Triangle> resultList = new List<Triangle>();

            foreach(Triangle triangle in Triangles)
            {
                if (method(triangle))
                {
                    resultList.Add(triangle);
                }
            }

            return resultList;
        }

        public List<Triangle> FindIsosceles() => Find(Triangle.IsIsosceles);
        public List<Triangle> FindEquilateral() => Find(Triangle.IsEquilateral);
        public List<Triangle> FindRectangular() => Find(Triangle.IsRectangular);
        public List<Triangle> FindObtuseLargerSpecifiedArea(double area)
        {
            List<Triangle> resultList = new List<Triangle>();

            foreach (Triangle triangle in Triangles)
            {
                if (Triangle.IsObtuseLargerSpecifiedArea(triangle, area))
                {
                    resultList.Add(triangle);
                }
            }

            return resultList;
        }
    }
}
