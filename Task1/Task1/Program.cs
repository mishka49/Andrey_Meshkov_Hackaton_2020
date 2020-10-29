using System;

namespace Task1
{
    class Program
    {
        static bool CheckingInput(out double a, out double b, out double c)
        {
            Console.WriteLine("Enter the values of the sides of the triangle");
            try
            {
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                c = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error");
                return CheckingInput(out a, out b, out c);
            }
            return true;

        }
        static bool CheckingExistence(double a, double b, double c)
        {
            if (a + b > c && a+c>b && b+c>a)
                return true;
            else
            {
                Console.WriteLine("This triangle cannot exist");
                return false;
            }
               
        }
        static void DefiningType(double a, double b, double c)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Equilateral triangle");
            }

            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Isosceles triangle");
            }

            else
            {
                Console.WriteLine("Versatile triangle");
            }
        }
        static void Main(string[] args)
        {
            double a, b, c;
            CheckingInput(out a, out b, out c);
            if (CheckingExistence(a, b, c))
            {
                DefiningType(a, b, c);
            } 
            Console.ReadKey();
        }
    }
}
