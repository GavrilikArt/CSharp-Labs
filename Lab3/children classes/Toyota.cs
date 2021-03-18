namespace Lab3.children_classes
{
    public class Toyota : Car
    {
        public const string Brand = "Toyota";
        public string Model { get; }
        public int Id { get; }
        public string CountryOfManufacturing { get; }

        private static int _identifierFactory = 0;

        private static int GetUniqueId()
        {
            Toyota._identifierFactory += 1;
            return Toyota._identifierFactory;
        }

        public Toyota() : base()
        {
            this.Id = Toyota.GetUniqueId();
        }

        public Toyota(double power, double maxSpeed, double priceInDollars, string transmission, string material,
            string color, string model, string countryOfManufacturing, int age) : base(power, maxSpeed, priceInDollars,
            transmission, material, color, age)
        {
            Id = GetUniqueId();
            this.Model = model;
            this.CountryOfManufacturing = countryOfManufacturing;
        }

        public static Toyota operator ++(Toyota car)
        {
            car.Power += 100;
            return car;
        }
        public override string ToString() => $"This is {Brand}. {base.ToString()}";
    }
}
