using CarRace.CustomEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Interfaces
{
    public delegate void VehicleStarterdHandler(object myObject, VehicleStartedEventArgs myArgs);
    public delegate void VehicleStoppedHandler(object myObject, VehicleStoppedEventArgs myArgs);
    public interface IVehicle
    {
        IEngine Engine { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        string DriverName { get; set; }
        bool IsStarted { get; }
        void Start(double position);
        void Stop(double position);
        event VehicleStarterdHandler VehicleStarted;
        event VehicleStoppedHandler VehicleStopped;

    }
}
