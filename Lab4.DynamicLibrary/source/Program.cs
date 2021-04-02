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
        
        [DllImport("physics.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double OhmLaw(double amperage, double resistance);

        [DllImport("physics.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GetWeight(double mass);
        
        static void Main(string[] args)
        {
            double a = GetKinematicEnergy(2.0, 2.1);
            Console.WriteLine(a);
            Console.Write($"{GetWeight(10)}");
            Console.Write($"{OhmLaw(10, 10)}");
            Console.Write($"{GetAcceleration(10, 10)}");
            Console.Write($"{GetPotentialEnergy(10, 12)}");
        }
    }
}