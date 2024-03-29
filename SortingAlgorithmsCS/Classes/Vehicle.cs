﻿using SortingAlgorithmsCS.Interfaces;
using System;

namespace SortingAlgorithmsCS.Classes
{
    public abstract class Vehicle : IVehicle, ICloneable
    {
        public string make { get; set; }
        public string model { get; set; }
        public string registration { get; set; }
        public int currentState { get; set; }

        public Vehicle(string _make, string _model, string _registration)
        {
            make = _make;
            model = _model;
            registration = _registration;
        }

        public Vehicle()
        {

        }

        public abstract void run();

        public abstract void start();

        public abstract void stop();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
