using System;

namespace Task1
{
    class Program
    {
        static double CheckInput()
        {
            double value;
            while(!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Error. Try again");
            }
            return value;
        }
        static bool CheckExistence(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide)
            {
                return true;
            }
            else
            {
                Console.WriteLine("This triangle cannot exist");
                return false;
            }        
        }
        static void DetermineType(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide == secondSide && secondSide == thirdSide)
            {
                Console.WriteLine("Equilateral triangle");
            }
            else if (firstSide == secondSide || secondSide ==thirdSide || firstSide == thirdSide)
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
            double firstSide = CheckInput();
            Console.WriteLine("Enter the second side");
            double secondSide = CheckInput();
            Console.WriteLine("Enter the third side");
            double thirdSide = CheckInput();
            if (CheckExistence(firstSide, secondSide, thirdSide))
            {
                DetermineType(firstSide, secondSide, thirdSide);
            } 
            Console.ReadKey();
        }
    }
}
