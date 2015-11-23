using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.CustomEventArgs
{
    public class VehicleStoppedEventArgs:EventArgs
    {
        public VehicleStoppedEventArgs(string carMake, string carModel, double averageSpeed)
        {
            CarMake = carMake;
            CarModel = carModel;
            AverageSpeed = averageSpeed;
        }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public double AverageSpeed { get; set; }
    }
}
