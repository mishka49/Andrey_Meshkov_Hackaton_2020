using System;

namespace Task1
{
    class Program
    {
<<<<<<< Updated upstream
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
=======
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
>>>>>>> Stashed changes
            else
            {
                Console.WriteLine("This triangle cannot exist");
                return false;
<<<<<<< Updated upstream
            }
               
        }
        static void DefiningType(double a, double b, double c)
=======
            }        
        }
        static void DetermineType(double a, double b, double c)
>>>>>>> Stashed changes
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Equilateral triangle");
            }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            else if (a == b || b == c || a == c)
            {
                Console.WriteLine("Isosceles triangle");
            }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            else
            {
                Console.WriteLine("Versatile triangle");
            }
        }
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
            double a, b, c;
            CheckingInput(out a, out b, out c);
            if (CheckingExistence(a, b, c))
            {
                DefiningType(a, b, c);
=======
            Console.WriteLine("enter the first side");
            CheckInput(out double FirstSide);
            Console.WriteLine("Enter the second side");
            CheckInput(out double SecondSide);
            Console.WriteLine("Enter the third side");
            CheckInput(out double ThirdSide);
            if (CheckExistence(FirstSide, SecondSide, ThirdSide))
            {
                DetermineType(FirstSide, SecondSide, ThirdSide);
>>>>>>> Stashed changes
            } 
            Console.ReadKey();
        }
    }
}
