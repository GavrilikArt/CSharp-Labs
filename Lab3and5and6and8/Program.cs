using System;
using System.Collections.Generic;

namespace VehicleProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Formula1 toyota = new Formula1(power: 5, material: "iron", age: 2, priceInDollars: 100, maxSpeed: 290,
                transmission: "manual", color: "dark", model: "camry", countryOfManufacturing: "Japan", brand: "Toyota");
            Formula1 mercedes = new Formula1(power: 5, material: "steel", age: 1, priceInDollars: 1000000, maxSpeed: 300,
                transmission: "automatic", color: "blue", model: "S", countryOfManufacturing: "Japan", brand: "Mercedes");
            string a = ((Formula1) toyota).ToString();
            Console.WriteLine(toyota.MaxSpeed);
            toyota.ChangeSpeed(SpeedChange.BreakEngine, 1);
            Console.WriteLine("_______________\n");
            Console.WriteLine("Handling exceptions");
            try
            {
                toyota.Upgrage(Upgrade);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("_______________");
            Console.WriteLine("Testing delegates");
            toyota.PrintInformation(x => Console.WriteLine(x));
            mercedes.Upgrage(Upgrade);
            mercedes.PrintInformation(x => Console.WriteLine(x));
            Console.WriteLine("\n\n");
            Console.WriteLine("_______________");
            Console.WriteLine("Testing Events");
            toyota.Complement += (message) => Console.WriteLine(message);
            toyota.Criticize += (message) => Console.WriteLine(message);
            mercedes.Complement += delegate(string message) { Console.WriteLine(message); };
            mercedes.Criticize += delegate(string message) { Console.WriteLine(message); };
            toyota.GirlsReaction("Stas");
            mercedes.GirlsReaction("Stas");
        }

        public static void Upgrade(ref double speed, ref double price, ref double power)
        {
            speed *= 2;
            power *= 3;
            price *= 2;
        }
    }
}
