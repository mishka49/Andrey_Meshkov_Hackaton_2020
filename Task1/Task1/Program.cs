﻿using System;

namespace Task1
{
    internal class Program
    {
        private static double EnterDoubleValue()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Error. Try again");
            }
            return value;
        }

        private static bool CheckExistTriangle(double firstSide, double secondSide, double thirdSide)
        {
            return firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide ? true : false;
        }

        private static void DefineType(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide == secondSide && secondSide == thirdSide)
            {
                Console.WriteLine("Equilateral triangle");
            }
            else if (firstSide == secondSide || secondSide == thirdSide || firstSide == thirdSide)
            {
                Console.WriteLine("Isosceles triangle");
            }
            else
            {
                Console.WriteLine("Versatile triangle");
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("enter the first side");
            double firstSide = EnterDoubleValue();
            Console.WriteLine("Enter the second side");
            double secondSide = EnterDoubleValue();
            Console.WriteLine("Enter the third side");
            double thirdSide = EnterDoubleValue();

            if (CheckExistTriangle(firstSide, secondSide, thirdSide))
            {
                DefineType(firstSide, secondSide, thirdSide);
            }
            else
            {
                Console.WriteLine("This triangle cannot exist");
            }

            Console.ReadKey();
        }
    }
}
