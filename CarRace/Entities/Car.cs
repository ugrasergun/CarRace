using CarRace.CustomEventArgs;
using CarRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace.Entities
{
    public class Car : IVehicle
    {
        public Car(IEngine engine, string make, string model, string driverName)
        {
            Engine = engine;
            Make = make;
            Model = model;
            DriverName = driverName;
        }
        
        public event VehicleStarterdHandler VehicleStarted;
        public event VehicleStoppedHandler VehicleStopped;
        
        public IEngine Engine { get; set; }
        private DateTime StartTime;
        private double StartPosition;
        private double StopPosition;
        private DateTime EndTime;

        public string Make { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
        public bool IsStarted { get; private set; } = false;

        public void Start(double position)
        {
            if (Engine?.IsFilled ?? false && !IsStarted)
            {
                StartPosition = position;
                StartTime = DateTime.Now;
                IsStarted = true;
                VehicleStartedEventArgs myArgs = new VehicleStartedEventArgs(DriverName, Make, Model);
                if (VehicleStarted != null)
                {
                    VehicleStarted(this, myArgs);
                }
            }
        }

        public void Stop(double position)
        {
            if (IsStarted)
            {
                StopPosition = position;
                EndTime = DateTime.Now;
                TimeSpan time = EndTime - StartTime;
                double averageSpeed = position / time.TotalSeconds;
                IsStarted = false;
                VehicleStoppedEventArgs myArgs = new VehicleStoppedEventArgs(Make, Model, averageSpeed);
                if (VehicleStopped != null)
                {
                    VehicleStopped(this, myArgs);
                }
            }
        }
    }
}
