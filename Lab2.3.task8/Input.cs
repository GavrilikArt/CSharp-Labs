using System;
using System.Globalization;

namespace Lab2._3.task8
{
    public class Input
    {
        public static CultureInfo ReadCulture()
        {
            CultureInfo culture;
            Console.WriteLine("Enter nationality(e.g. en, ru, fr etc.):");
            while (true)
            {
                string inputCulture = Console.ReadLine();
                try
                {
                    culture = CultureInfo.CreateSpecificCulture(inputCulture);
                    return culture;
                }
                catch (CultureNotFoundException)
                {
                    Console.WriteLine("Wrong format, look up the needed format.");
                }
            }
        }
    }
}
