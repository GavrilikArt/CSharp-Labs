using System;

namespace Lab3
{
    public class Vehicle
    {
        public int Age { get; private set; }
        private int NumOfWheels { get; set; }

        public string Material { get; private set; }

        public string Color { get ; private set; }
        
        public int Id { get; private set; }

        public void GetMinimunInfo()
        {
            Console.WriteLine($"Your vehicle has {NumOfWheels} wheel(s), it is {Color} and it is made of {Material}");
        }
        
        private static int _identifierFactory = 0;

        private static int GetUniqueId()
        {
            Vehicle._identifierFactory += 1;
            return Vehicle._identifierFactory;
        }

        void ChangeColor(string color)
        {
            this.Color = color;
        }

        public Vehicle()
        {
            Id = GetUniqueId();
            NumOfWheels = 4;
            Material = "steel";
            Color = "orange";
            Age = 0;
        }

        public Vehicle(int numOfWheels, string material, string color, int age)
        {
            if (numOfWheels > 0)
            {
                this.NumOfWheels = numOfWheels;
            }
            else
            {
                Console.WriteLine("Number of wheels cannot be negative, setting it to 0");
                this.NumOfWheels = numOfWheels;
            }
            this.NumOfWheels = numOfWheels;
            this.Material = material;
            this.Color = color;
            this.Id = GetUniqueId();
            if (age > 0)
            {
                this.Age = age;
            }
            else
            {
                Console.WriteLine("Age cannot be negative, setting it to 0");
                this.Age = age;
            }
        }

        public void Upgrade(string material, int numOfWheels, string color)
        {
            this.Material = material;
            this.NumOfWheels = numOfWheels;
            this.Color = color;
        }

        public void Upgrade(string material, int numOfWheels)
        {
            this.Material = material;
            this.NumOfWheels = numOfWheels;
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

        public static Vehicle operator +(Vehicle lhs, Vehicle rhs) => new Vehicle(
            numOfWheels: lhs.NumOfWheels + rhs.NumOfWheels, 
            material: lhs.Material,
            color: rhs.Color,
            age: lhs.Age + rhs.Age
            );
        public void ChangeCarMaterial(string material)
        {
            Material = material;
        }

        public void SetAge(int age)
        {
            Age = age;
        }

        public void SetNumOfWheels(int numOfWheels)
        {
            NumOfWheels = numOfWheels;
        }

        public void WriteAge()
        {
            Console.WriteLine($"Your vehicle is {Age} years of old");
        }

        public override string ToString() => $"Your vehicle has {NumOfWheels} wheel(s), it is {Color} and it is made of {Material}";
    }
}
