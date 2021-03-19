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
            Vehicle vehicle = new Vehicle(numOfWheels: 1, material: "steel", age: 2, color: "blue");
            Vehicle vehicle1 = new Vehicle(numOfWheels: 3, material: "iron", age: 10, color: "cyan");
            vehicle1.IsOld();
            Vehicles vehicles = new Vehicles();
            vehicles[vehicle.Id] = vehicle;
            vehicles[vehicle1.Id] = vehicle1;
            Console.Write(vehicles[vehicle.Id]);
            vehicle.Upgrade("iron", 12, "blue");
        }
    }
}
