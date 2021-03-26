using System;
using System.Runtime.InteropServices;

namespace Lab4.DynamicLibrary
{
    class Program
    {
        [DllImport("physics.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern double GetKinematicEnergy(double mass, double velocity);

        [DllImport("physics.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern double GetPotentialEnergy(double mass, double height);
        
        [DllImport("physics.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern double GetAcceleration(double velocity, double time);
        
        [DllImport("physics.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern double GetXCoordinate(double velocity, double time);

        
        static void Main(string[] args)
        {
            double a = GetKinematicEnergy(2.0, 2.1);
            Console.WriteLine(a);
            Console.Write($"{GetAcceleration(4.2, 2.1)}");
        }
    }
}