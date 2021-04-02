using System;
namespace VehicleProject
{
    public sealed class Formula1 : Car, IFormula1, IComparable<Formula1>
    {
        public string PilotName { get; set; }
        public string Brand { get; set; }
        public double ActualSpeed { get; set; }
        public string Model { get; }
        public int Id { get; }
        public string CountryOfManufacturing { get; }
        public void CheckSpeed()
        {
            if (ActualSpeed < 280)
            {
                Console.WriteLine("Not enough speed for Formula 1, setting MaxSpeed to 280");
                ActualSpeed = 280;
            }
        }

        private static int _identifierFactory = 0;
        private static int GetUniqueId()
        {
            Formula1._identifierFactory += 1;
            return Formula1._identifierFactory;
        }

        public Formula1() : base()
        {
            this.Id = Formula1.GetUniqueId();
        }

        public Formula1(double power, double maxSpeed, double priceInDollars, string transmission, string material,
            string color, string model, string countryOfManufacturing, int age, string brand) : base(power, maxSpeed, priceInDollars,
            transmission, material, color, age)
        {
            Id = GetUniqueId();
            this.Model = model;
            this.CountryOfManufacturing = countryOfManufacturing;
            this.ActualSpeed = maxSpeed;
            this.Brand = brand;
        }

        public override void ChangeSpeed(SpeedChange operation, double value)
        {
            switch (operation)
            {
                case SpeedChange.Increase:
                    MaxSpeed += value;
                    ActualSpeed += value;
                    break;
                case SpeedChange.Decrease:
                    if (MaxSpeed > value)
                    {
                        ActualSpeed -= value;
                        MaxSpeed -= value;
                    }
                    break;
                case SpeedChange.BreakEngine:
                    ActualSpeed = 0;
                    MaxSpeed = 0;
                    break;
            }
        }

        public override void GetMinimumInfo()
        {
            base.GetMinimumInfo();
            Console.WriteLine($"It's Id is {Id} and The Manufacturer is Toyota, it was manufactured in {CountryOfManufacturing}");
        }

        public int CompareTo(IFormula1 other)
        {
            if (this.ActualSpeed > other.ActualSpeed)
                return 1;
            else if (this.ActualSpeed < other.ActualSpeed)
                return -1;
            else return 0;
        }
        
        public int CompareTo(Formula1 other)
        {
            if (this.ActualSpeed > other.ActualSpeed)
                return 1;
            else if (this.ActualSpeed < other.ActualSpeed)
                return -1;
            else return 0;
        }

        public static Formula1 operator ++(Formula1 car)
        {
            car.Power += 100;
            return car;
        }
        public override string ToString() => $"This is {Brand}. {base.ToString()}";
    }
}
