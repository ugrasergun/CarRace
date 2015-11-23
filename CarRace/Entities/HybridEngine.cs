using CarRace.Enums;
using CarRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Entities
{
    public class HybridEngine:IEngine
    {
        public string EngineName { get; } = "Hybrid Engine";

        public bool IsFilled { get; set; } = false;

        public bool Fill(FuelType fuel)
        {
            switch (fuel)
            {
                case FuelType.Electricity:
                case FuelType.Petrol:
                    IsFilled = true;
                    return true;
                default:
                    return false;
            }
        }
    }
}
