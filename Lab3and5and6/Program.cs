using System;
using System.Collections.Generic;

namespace VehicleProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IFormula1 formula = new Formula1(power: 5, material: "iron", age: 2, priceInDollars: 100000, maxSpeed: 280,
                transmission: "manual", color: "red", model: "camry", countryOfManufacturing: "Germany", brand: "Mercedes");
            
            Car car = new Car(power: 5, material: "iron", age: 2, priceInDollars: 5, maxSpeed: 10,
                transmission: "manual", color: "red");
            Truck truck = new Truck(power: 5, material: "iron", age: 2, priceInDollars: 5, maxSpeed: 10,
                transmission: "manual", color: "red", maxWeight: 100, currentWeight: 200);
            Car toyota = new Formula1(power: 5, material: "iron", age: 2, priceInDollars: 100, maxSpeed: 290,
                transmission: "manual", color: "dark", model: "camry", countryOfManufacturing: "Japan", brand: "Toyota");
            Car audi = new Formula1(power: 5, material: "steel", age: 2, priceInDollars: 90000, maxSpeed: 300,
                transmission: "manual", color: "red", model: "camry", countryOfManufacturing: "Germany", brand: "Audi");
            Car mercedes = new Formula1(power: 5, material: "iron", age: 2, priceInDollars: 100000, maxSpeed: 280,
                transmission: "manual", color: "red", model: "camry", countryOfManufacturing: "Germany", brand: "Mercedes");
            string a = ((Formula1) toyota).ToString();
            Console.WriteLine(a);
            List<Car> formula1s = new List<Car>();
            formula1s.Add(toyota);
            formula1s.Add(audi);
            formula1s.Add(mercedes);
            formula1s[0].ChangeSpeed(SpeedChange.Increase, 20);
            formula1s.Sort();
            foreach (Formula1 formula1 in formula1s)
            {
                Console.WriteLine(formula1);
            }
        }
    }
}
