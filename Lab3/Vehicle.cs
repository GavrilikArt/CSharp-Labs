using System;

namespace Lab3
{
    public class Vehicle
    {
        public int Age { get; set; }
        private int NumOfWheels { get; }
        public string Material { get; private set; }
        public string Color { get; private set; }

        public void GetMinimunInfo()
        {
            Console.WriteLine($"Your vehicle has {NumOfWheels} wheel(s), it is {Color} and it is made of {Material}");
        }

        void ChangeColor(string color)
        {
            this.Color = color;
        }

        public Vehicle()
        {
            NumOfWheels = 4;
            Material = "steel";
            Color = "orange";
            Age = 0;
        }

        public Vehicle(int numOfWheels, string material, string color, int age)
        {
            this.NumOfWheels = numOfWheels;
            this.Material = material;
            this.Color = color;
            this.Age = age;
        }

        public void IsOld()
        {
            if (Age > 10)
            {
                Console.WriteLine("Your car is old");
            }
            else
            {
                Console.WriteLine("Your car is not old");
            }
        }

        public void GetAge()
        {
            Console.WriteLine($"Your car is {Age} years of old");
        }
        
        
        public override string ToString() => $"Your vehicle has {NumOfWheels} wheel(s), it is {Color} and it is made of {Material}";
        
    }
}
