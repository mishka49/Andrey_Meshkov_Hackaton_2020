using System;

namespace Task1
{
    class Program
    {
        static void CheckInput(out double a)
        {
            string s;
            bool result;
            while(true)
            {
                s = Console.ReadLine();
                result = double.TryParse(s, out a);
                if(result)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Error. Try again");
                }
            }
        }
        static bool CheckExistence(double a, double b, double c)
        {
            if (a + b > c && a+c>b && b+c>a)
            {
                return true;
            }
            else
            {
                Console.WriteLine("This triangle cannot exist");
                return false;
            }        
        }
        static void DetermineType(double a, double b, double c)
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
            Console.WriteLine("enter the first side");
            CheckInput(out double FirstSide);
            Console.WriteLine("Enter the second side");
            CheckInput(out double SecondSide);
            Console.WriteLine("Enter the third side");
            CheckInput(out double ThirdSide);
            if (CheckExistence(FirstSide, SecondSide, ThirdSide))
            {
                DetermineType(FirstSide, SecondSide, ThirdSide);
            } 
            Console.ReadKey();
        }
    }
}
