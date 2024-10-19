using System;
namespace Method_Overloading_2_
{
    class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Source source = new Source();
            Console.WriteLine(source.Add(10, 20, 30));
            Console.WriteLine(source.Add(1.5, 2.5, 1.5));
        }
    }

}

