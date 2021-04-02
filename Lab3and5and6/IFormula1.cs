using System;

namespace VehicleProject
{
    public interface IFormula1 : IComparable<IFormula1>
    {
        double ActualSpeed { get; set; }
        string PilotName { get; set; }
        void CheckSpeed();
    }
}
