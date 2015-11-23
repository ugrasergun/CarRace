using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.CustomEventArgs
{
    public class VehicleStartedEventArgs: EventArgs
    {
        public VehicleStartedEventArgs(string driverName, string carMake, string carModel)
        {
            DriverName = driverName;
            CarMake = carMake;
            CarModel = carModel;
        }
        public string DriverName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
    }

    
}
