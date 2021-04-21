using System;

namespace VehicleProject
{
    public enum SpeedChange
    {
        Increase,
        Decrease,
        BreakEngine
    }
    public class Car : Vehicle, IComparable<Car>
    {
        public delegate void CustomUpgade(ref double maxSpeed, ref double priceInDollars, ref double power);
        public CarDoc CarInfo { get; }
        public double Power { get; set; }
        public string Transmission { get; private set; }
        public double MaxSpeed { get; protected set; }
        public double PriceInDollars { get; private set; }

        public Car()
        {
            Transmission = "manual";
            Power = 0;
            MaxSpeed = 10;
            PriceInDollars = 1;
            CarInfo = new CarDoc(1, 10, "manual", "blue", "steel");
        }
        
        public int CompareTo(Car obj)
        {
            if (this.PriceInDollars > obj.PriceInDollars)
                return 1;
            if (this.PriceInDollars < obj.PriceInDollars)
                return -1;
            else
                return 0;
        }

        public virtual void ChangeSpeed(SpeedChange operation, double value)
        {
            switch (operation)
            {
                case SpeedChange.Increase:
                    MaxSpeed += value;
                    break;
                case SpeedChange.Decrease:
                    if (MaxSpeed > value)
                    {
                        MaxSpeed -= value;
                    }
                    break;
                case SpeedChange.BreakEngine:
                    MaxSpeed = 0;
                    break;
            }
        }
        public Car(double power, double maxSpeed,double priceInDollars ,string transmission, string material, string color, int age) : base(numOfWheels: 4,
            material: material, color: color, age: age)
        {
            CarInfo = new CarDoc(priceInDollars, maxSpeed, transmission, color, material);
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

        public override void GetMinimumInfo()
        {
            Console.WriteLine($"Your vehicle has 4 wheel(s), it is {Color} and it is made of {Material}. Also it's max speed is {MaxSpeed} and it will cost you {PriceInDollars}");
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

        public void Upgrage(CustomUpgade function)
        {
            if (MaxSpeed == 0)
            {
                throw new InvalidOperationException("This car is broken");
            }
            double power = Power;
            double speed = MaxSpeed;
            double price = PriceInDollars;
            function.Invoke(ref speed, ref price, ref power);
            (Power, MaxSpeed, PriceInDollars) = (power, speed, price);
        }
        public override double Upgrade()
        {
            Console.Write("Enter a coefficient to multiply all the characteristics(Has to be between 0 and 2): ");
            double k = DoubleInput.ReadDouble();
            if (k <= 2.0 && k > 1.0)
            {
                this.Power *= k;
                this.MaxSpeed *= k;
                this.PriceInDollars *= k * 1.1;
                Console.WriteLine($"Wow, All the char's are multiplied by {k}!");
                return k;
            }
            else
            {
                Console.WriteLine("k does not fit the requirements of being less then 2 and bigger than 0");
                Upgrade();
            }
            return k;
        }

        public void MakeSound()
        {
            Console.WriteLine("\a");
        }
    }

    public struct CarDoc
    {
        public double Price;
        public double Speed;
        public string Transmission;
        public string Color;
        public string Material;

        public CarDoc(double price, double speed, string transmission, string color, string material)
        {
            Price = price;
            Speed = speed;
            Transmission = transmission;
            Color = color;
            Material = material;
        }

        public void Help()
        {
            Console.WriteLine("Hello, it is CarHelper, what info you wanna get:\n1: Price\n2: Speed\n3: transmission\n4: color\n5: material\nChoose one of the following options");
            string choice = Console.ReadLine();
            switch (choice) 
            {
                case "1":
                    if (Price > 30000)
                    {
                        Console.WriteLine($"Nice car! But expensive:(. It costs {Price}$");
                    }
                    else
                    {
                        Console.WriteLine($"Good car! Nice option for the money, it's price is {Price}$");
                    }
                    break;
                case "2":
                    if (Speed > 200)
                    {
                        Console.WriteLine($"Nice car! Do you have lambo? It's speed is {Speed}");
                    }
                    else
                    {
                        Console.WriteLine($"A little bit slow, but it is alright, speed it {Speed}");
                    }
                    break;
                case "3":
                    if (Transmission.ToLower() == "manual")
                    {
                        Console.WriteLine("You got manual transmission, old school!");
                    }
                    else
                    {
                        Console.WriteLine("Keeping it modern. Automatic transmission");
                    }
                    break;
                case "4": 
                    Console.WriteLine($"The color of your car is {Color}");
                    break;
                case "5":
                    Console.WriteLine($"Your car is made of {Material}. Good choice, I guess!");
                    break;
                default:
                    Console.WriteLine("Choose a digit between 1 and 5!");
                    Help();
                    break;
            }
        }
    }
}
