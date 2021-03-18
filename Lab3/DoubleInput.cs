using System;

namespace Lab3
{
    public class DoubleInput
    {
        public static double ReadDouble()
        {
            double number;
            while (!Double.TryParse(Console.ReadLine(), out number) || number == 0)
            {
                Console.Write("Wrong format, enter the correct number.\n");
            }
            return number;
        }
    }
}
