using System;
using System.Runtime.CompilerServices;


namespace Lab3.children_classes
{
    public class Car : Vehicle
    {
        public double Power { get; set; }
        public string Transmission { get; private set; }
        public double MaxSpeed { get; private set; }
        public double PriceInDollars { get; private set; }

        public Car()
        {
            Transmission = "manual";
            Power = 0;
            MaxSpeed = 10;
            PriceInDollars = 1;
        }

        public Car(double power, double maxSpeed,double priceInDollars ,string transmission, string material, string color, int age) : base(numOfWheels: 4,
            material: material, color: color, age: age)
        {
            this.Power = power;
            this.MaxSpeed = maxSpeed;
            this.PriceInDollars = priceInDollars;
            if (transmission.ToLower() == "manual" || transmission.ToLower() == "automatic")
            {
                this.Transmission = transmission;
            }
            else
            {
                Console.WriteLine("This transmission doesn't exist, choose either manual or automatic. You will be provided with an opportunity to choose it right now");
                this.ChooseTransmission();
            }
        }

        public void ChooseTransmission()
        {
            Console.WriteLine("Type 1 if u want manual and 2 if you want automatic");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": 
                    this.Transmission = "manual";
                    break;
                case "2": 
                    this.Transmission = "automatic";
                    break;
                default:
                    Console.WriteLine("Please type in 1 or 2, nothing else");
                    this.ChooseTransmission();
                    break;
            }
        }

        public override string ToString() => $"Your car's power is {Power} hp, it has {Transmission} transmission, it's max speed is {MaxSpeed} mph. That's why it costs {PriceInDollars}$";

        public static Car operator ++(Car car)
        {
            car.Power += 100;
            return car;
        }
        public void Upgrade()
        {
            Console.Write("Enter a coefficient to multiply all the characteristics(Has to be between 0 and 2): ");
            double k = DoubleInput.ReadDouble();
            if (k <= 2.0 && k > 1.0)
            {
                this.Power *= k;
                this.MaxSpeed *= k;
                this.PriceInDollars *= k * 1.1;
                Console.WriteLine($"Wow, All the char's are multiplied by {k}!");
            }
            else
            {
                Console.WriteLine("k does not fit the requirements of being less then 2 and bigger than 0");
                Upgrade();
            }
        }
        
        public void MakeSound()
        {
            Console.WriteLine("\a");
        }
    }
}
