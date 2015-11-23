using CarRace.Enums;
using CarRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Entities
{
    public class PetrolEngine:IEngine
    {
        public string EngineName { get; } = "Petrol Engine";

        public bool IsFilled { get; set; } = false;

        public bool Fill(FuelType fuel)
        {
            switch (fuel)
            {
                case FuelType.Petrol:
                    IsFilled = true;
                    return true;
                case FuelType.Electricity:
                default:
                    return false;
            }
        }
    }
}
