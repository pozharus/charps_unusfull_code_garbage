using System;

namespace Figures
{
    public class Circle: Figure
    {
        public double radius;

        public Circle(int _radius) => (radius) = (_radius);

        public override void GetFigureAbstract()
        {
            double square = Math.Pow(radius, 2) * 3.14;
            Console.WriteLine("The area of circle is {0}", square);
        }
    }
}