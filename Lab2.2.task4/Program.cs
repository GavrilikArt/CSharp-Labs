using System;

namespace Task4
{
    class Program
    {
        static ulong PowersBeforeTheNum(ulong number)
        {
            ulong amount = 0;
            ulong pow = 2;
            for (int i = 1; i < 64; i++)
            {
                amount += number / pow;
                pow *= 2;
                if (number == 0)
                {
                    break;
                }
            }
            return amount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first natural number:");
            ulong a = Input.ReadUlong();
            Console.WriteLine("Enter second natural number:");
            ulong b = Input.ReadUlong();
            while (b < a)
            {
                Console.WriteLine("The first number must be less than the second!");
                b = Input.ReadUlong();
            }
            Console.WriteLine("Answer is: {0}", PowersBeforeTheNum(b) - PowersBeforeTheNum(a - 1));
        }
    }
}
