namespace Figures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Square o = new Square(35, 10);
            o.GetFigureAbstract();
            Triangle o1 = new Triangle(5, 10);
            o1.GetFigureAbstract();
            Circle o2 = new Circle(5);
            o2.GetFigureAbstract();
        }
    }
}