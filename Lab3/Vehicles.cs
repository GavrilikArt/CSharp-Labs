using System;
using System.Collections.Generic;

namespace Lab3
{
    class Vehicles {
        int numberOfVehicles = 0;
        private Dictionary<int, Vehicle> _vehicles;
        public Vehicles()
        {
            _vehicles = new Dictionary<int, Vehicle>();
        }
        public Vehicle this[int index] {
            get {
                if (index < 0 && index >= numberOfVehicles) {
                    throw new Exception("There is no vehicle with such id\n");
                }
                return _vehicles[index];
            }
            set {
                if (index != value.Id)
                {
                    throw new Exception("There is no vehicle with such id\n");
                }
                _vehicles[value.Id] = value;
                numberOfVehicles++;
            }
        }
    }
}
