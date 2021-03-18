using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.children_classes;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            List<Toyota> list = new List<Toyota>();
            Car what = new Car(color: "green", material: "iron", transmission: "manual", power: 12,
                maxSpeed: 12, priceInDollars: 1222, age: 12);
            Toyota shit = new Toyota();
            Toyota damn = new Toyota(color: "green", material: "iron", transmission: "manual", model: "shit", power: 13,
                maxSpeed: 12, countryOfManufacturing: "Nikita", priceInDollars: 1222, age: 5);
            Toyota toyota = new Toyota(color: "green", material: "iron", transmission: "manual", model: "shit", power: 13,
                maxSpeed: 12, countryOfManufacturing: "Nikita", priceInDollars: 1222, age: 11);
            Toyota fu = new Toyota(color: "green", material: "iron", transmission: "manual", model: "shit", power: 13,
                maxSpeed: 12, countryOfManufacturing: "Nikita", priceInDollars: 1222, age: 10);
            Console.WriteLine($"{fu.Age}");
            list.Add(fu);
            list.Add(toyota);
            list.Add(damn);
            Console.WriteLine($"{list.Count}");
            list.Sort((Toyota a, Toyota b) => a.Age - b.Age);
            shit = fu;
            what++;
            Console.WriteLine($"{fu.Id}");
            Console.WriteLine(fu);
            Console.WriteLine(what);
            shit.GetMinimunInfo();
            foreach (var i in list)
            {
                Console.WriteLine($"age is {i.Id}");
            }
            */
            Vehicle vehicle = new Vehicle(numOfWheels: 1, material: "steel", age: 2, color: "blue");
        }
    }
}
