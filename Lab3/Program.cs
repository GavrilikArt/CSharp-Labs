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
            Toyota toyota = new Toyota(color: "green", material: "iron", transmission: "manual", model: "camry", power: 13,
                maxSpeed: 12, countryOfManufacturing: "Japan", priceInDollars: 1222, age: 11);
            Vehicle vehicle = new Vehicle(numOfWheels: 1, material: "steel", age: 2, color: "blue");
        }
    }
}
