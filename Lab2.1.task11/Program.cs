using System;

namespace Lab2.1.task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string[] words = Console.ReadLine().Split(' ');
            foreach (string word in words)
            {
                if (Char.IsPunctuation(word[word.Length - 1]))
                {
                    Console.Write(word[word.Length - 1]);
                }
                Console.Write("{0} ", word);
            }
            Console.Write("\nDone");
        }
    }
}




