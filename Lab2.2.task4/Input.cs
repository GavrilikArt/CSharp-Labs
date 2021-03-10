using System;

namespace Task4
{
    public class Input
    {
        public static ulong ReadUlong()
        {
            ulong number;
            while (!UInt64.TryParse(Console.ReadLine(), out number) || number == 0)
            {
                Console.Write("Wrong format, enter the correct number.\n");
            }
            return number;
        }
    }
}
