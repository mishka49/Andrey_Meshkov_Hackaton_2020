using System;

namespace Remove_dublicate_words
{
    class Program
    {
        static string RemoveDublicateWords(string text)
        {
            string[] array = text.Split('.', ',', '!', '?', '-', ':', ';', ' ');

            for (int j = 0; j < array.Length; j++)
                for (int i = j + 1; i < array.Length; i++)
                {
                    if (array[j] == array[i])
                    {
                        array[i] = null;
                    }
                }

            text = null;

            foreach (string item in array)
            {
                text += item + " ";
            }

            return text;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input text");
            string text = RemoveDublicateWords(Console.ReadLine());
            Console.WriteLine("Text without dublicate: " + text);
            Console.ReadKey();
        }
    }
}
