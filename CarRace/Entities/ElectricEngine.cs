using CarRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRace.Enums;

namespace CarRace.Entities
{
    public class ElectricEngine : IEngine
    {
        
        public string EngineName { get; } = "Electric Engine";

        public bool IsFilled { get; set; } = false;

        public bool Fill(FuelType fuel)
        {
            switch (fuel)
            {
                case FuelType.Electricity:
                    IsFilled = true;
                    return true;
                case FuelType.Petrol:
                default:
                    return false;
            }
        }
    }
}
