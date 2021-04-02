using System;

namespace VehicleProject
{
    public class Truck : Car, ITruck
    {
        public Truck(double power, double maxSpeed, double priceInDollars, string transmission, string material,
            string color, int age, double currentWeight, double maxWeight) : base(power, maxSpeed, priceInDollars, transmission, material, color, age)
        {
            Id = GetUniqueId();
            _maxWeight = maxWeight;
            _currentWeight = currentWeight;
            MaxWeight = maxWeight;
            CurrentWeight = currentWeight;
        }
        
        public Truck() : base()
        {
            this.Id = Truck.GetUniqueId();
            _maxWeight = 100;
            _currentWeight = 50;
        }

        public override double Upgrade()
        {
            double k = base.Upgrade();
            _maxWeight *= k;
            return k;
        }

        private double _maxWeight;
        public double MaxWeight {
            get => _maxWeight;
            set {
                if (value < 0)
                    _maxWeight = 0;
                else if (value < _currentWeight)
                {
                    Console.WriteLine($"Too small of a value(MaxWeight({value})). Expanding it to CurrentWeight({_currentWeight}).");
                    _maxWeight = _currentWeight;
                }
            }
        }

        private double _currentWeight;
        public double CurrentWeight {
            get => _currentWeight;
            set {
                if (value < 0)
                {
                    _currentWeight = 0;
                    Console.WriteLine("Weight can't be negative, setting it to 0");
                } else if (value > _maxWeight)
                {
                    Console.WriteLine($"Too much to handle. {value - _maxWeight} will be dropped");
                    _currentWeight = _maxWeight;
                }
            }
        }

        public void ChangeCurrentWeight(double amount, bool up)
        {
            if (up)
            {
                if (_currentWeight + amount <= _maxWeight) 
                    _currentWeight += amount;
                else
                {
                    _currentWeight = _maxWeight;
                    Console.WriteLine($"{MaxWeight - amount} kilos were lost");
                }
            }
            else
            {
                if (_currentWeight - amount >= 0)
                    _currentWeight -= amount;
                else
                {
                    _currentWeight = 0;
                    Console.WriteLine("CurrentWeight is set to 0. Too much to distract");
                }
            }
        }

        public int CompareTo(ITruck other)
        {
            if (this.MaxWeight > other.MaxWeight)
                return 1;
            else if (this.MaxWeight < other.MaxWeight)
                return -1;
            else return 0;
        }

        public int Id { get; }
        private static int _identifierFactory = 0;

        private static int GetUniqueId()
        {
            Truck._identifierFactory += 1;
            return Truck._identifierFactory;
        }
    }
}
