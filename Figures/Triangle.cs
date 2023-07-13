using System;

namespace Figures
{
    public class Triangle: Figure
    {
        public int triangleBase;
        public int height;

        public Triangle(int _triangleBase, int _height) => (triangleBase, height) = (_triangleBase, _height);

        public override void GetFigureAbstract()
        {
            double square = (triangleBase * height) * 0.5;
            Console.WriteLine("The area of triangle is {0}", square);
        }
    }
}