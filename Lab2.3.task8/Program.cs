using System;
using System.Globalization;

namespace Lab2._3.task8
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture =  Input.ReadCulture();
            DateTime someDate = new DateTime();
            for (int index = 0; index < 12; index++)
            {
                Console.WriteLine(someDate.AddMonths(index).ToString("MMMM", culture));
            }
        }
    }
}
