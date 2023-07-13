using System;

namespace Figures
{
    public class Square: Figure
    {
        public int weight;
        public int height;

        public Square(int _weight, int _height) => (weight, height) = (_weight, _height);

        public override void GetFigureAbstract()
        {
            Console.WriteLine("The area of square is {0}", weight * height);
        }
    }
}