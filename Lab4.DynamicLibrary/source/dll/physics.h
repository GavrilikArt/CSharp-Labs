#pragma once

#ifdef PHYSICSDLL_EXPORTS
#define DLLIMPORT_EXPORT __declspec(dllexport)
#else
#define DLLIMPORT_EXPORT __declspec(dllimport)
#endif

extern "C" {
DLLIMPORT_EXPORT double _stdcall GetPotentialEnergy(double mass, double height);
DLLIMPORT_EXPORT double _stdcall GetKinematicEnergy(double mass, double velocity);
DLLIMPORT_EXPORT double _stdcall GetXCoordinate(double x_0, double time, double speed);
DLLIMPORT_EXPORT double _stdcall GetAcceleration(double velocity, double time);
DLLIMPORT_EXPORT double _stdcall GetFallingSpeed(double time);
DLLIMPORT_EXPORT double _stdcall SecondNewtonsLaw(double force, double mass);
DLLIMPORT_EXPORT double _stdcall Joule_Lenz_Law(double amperage, double time, double resistance);
DLLIMPORT_EXPORT double _stdcall OhmLaw(double amperage, double resistance);
DLLIMPORT_EXPORT double _stdcall GetWeight(double mass);
DLLIMPORT_EXPORT double _stdcall Get_g();
}