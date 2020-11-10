using System;

namespace RemoveDublicateWords
{
    internal class Program
    {
        private static string RemoveDublicateWords(string text)
        {
            string[] array = text.Split('.', ',', '!', '?', '-', ':', ';', ' ');

            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                    {
                        array[j] = null;
                    }
                }

            text ="";

            foreach (string item in array)
            {
                text += item + " ";
            }

            return text;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Input text");
            string text = RemoveDublicateWords(Console.ReadLine());
            Console.WriteLine("Text without dublicate: " + text);
            Console.ReadKey();
        }
    }
}
