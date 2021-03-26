#include "physics.h"
#include <math.h>

const double g = 9.8;
double GetPotentialEnergy(double mass, double height) {
  return g * mass * height;
}
double GetKinematicEnergy(double mass, double velocity) {
  return (mass * (pow(velocity, 2))) / 2;
}
double GetXCoordinate(double x_0, double time, double speed) {
  return x_0 + time * speed;
}
double GetAcceleration(double velocity, double time) {
  return velocity / time;
}
double GetFallingSpeed(double time) {
  return g * time;
}
double SecondNewtonsLaw(double force, double mass) {
  return force / mass;
}
double Joule_Lenz_Law(double amperage, double time, double resistance) {
  return pow(amperage, 2) * time * resistance;
}
double OhmLaw(double amperage, double resistance) {
  return amperage * resistance;
}
double GetWeight(double mass) {
  return mass * g;
}
double Get_g() {
  return g;
}
