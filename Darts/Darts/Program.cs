using System;
using static System.Math;

namespace Darts
{
    class Program
    {
        static double InputValue()
        {
            double value;
            while(!double.TryParse(Console.ReadLine(),out value))
            {
                Console.WriteLine("Error. Try again");
            }
            return value;
        }
        static int GetScore(double x, double y)
        {
            if (Abs(x) > 10 || Abs(y) > 10)
            {
                return 0;
            }
            else if (Abs(x) <= 10 && Abs(x) > 5 || Abs(x) <= 10 && Abs(x) > 5)
            {
                return 1;
            }
            else if (Abs(x) <= 5 && Abs(x) > 1 || Abs(x) <= 5 && Abs(x) > 1)
            {
                return 5;
            }
            else
            {
                return 10;
            }
        }
        static void Main(string[] args)
        {
            int score = 0;
            for(int i=0;i<3;i++)
            {
                Console.WriteLine("Enter x");
                double x = InputValue();
                Console.WriteLine("Enter y");
                double y = InputValue();
                score += GetScore(x, y);
            }
            Console.WriteLine("Your score:"+score);
            Console.ReadKey();
        }
    }
}
