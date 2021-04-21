using System;

namespace VehicleProject
{
    public interface ITruck : IComparable<ITruck>
    { 
        double MaxWeight { get; set; }
        double CurrentWeight { get; set; }
        void ChangeCurrentWeight(double amount, bool up);
    }
}
