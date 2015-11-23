using CarRace.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Interfaces
{
    public interface IEngine
    {
        string EngineName { get; }
        bool Fill(FuelType fuel);
        bool IsFilled { get; set; }
    }
}
