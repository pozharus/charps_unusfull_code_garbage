// See https://aka.ms/new-console-template for more information
namespace Car
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Car car = new Car(6);
            foreach (var detail in car)
            {
                Console.WriteLine(detail);
            }
        }
    }
}