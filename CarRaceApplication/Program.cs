using CarRace.Entities;
using CarRace.Enums;
using CarRace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRaceApplication
{
    class Program
    {
        static IVehicle BMW1, BMW2, Audi1, Audi2, Mercedes, Volvo, Peugot;
        static List<string> resultList = new List<string>();
        static void Main(string[] args)
        {
            InitializeCars();
            StartAllCars();
            DoRace();
            foreach (string result in resultList)
            {
                Console.WriteLine(result);
            }
        }

        private static void DoRace()
        {
            Thread.Sleep(10000);
            BMW1.Stop(1000);
            Thread.Sleep(500);
            Audi1.Stop(1000);
            Thread.Sleep(1000);
            BMW2.Stop(1000);
            Thread.Sleep(1500);
            Volvo.Stop(1000);
            Audi2.Stop(1000);
            Mercedes.Stop(1000);
            Peugot.Stop(1000);
        }

        private static void InitializeCars()
        {
            BMW1 = new Car(new HybridEngine(), "BMW", "Model1", "Driver1"); BMW1.Engine.Fill(FuelType.Electricity);BMW1.VehicleStarted += OnVehicleStarted; BMW1.VehicleStopped += OnVehicleStopped;
            BMW2 = new Car(new ElectricEngine(), "BMW", "Model2", "Driver2"); BMW2.Engine.Fill(FuelType.Electricity); BMW2.VehicleStarted += OnVehicleStarted; BMW2.VehicleStopped += OnVehicleStopped;

            Audi1 = new Car(new ElectricEngine(), "Audi", "Model3", "Driver3"); Audi1.Engine.Fill(FuelType.Electricity); Audi1.VehicleStarted += OnVehicleStarted; Audi1.VehicleStopped += OnVehicleStopped;
            Audi2 = new Car(new ElectricEngine(), "Audi", "Model4", "Driver4"); Audi2.Engine.Fill(FuelType.Electricity); Audi2.VehicleStarted += OnVehicleStarted; Audi2.VehicleStopped += OnVehicleStopped;

            Mercedes = new Car(new PetrolEngine(), "Mercedes", "Model5", "Driver5"); Mercedes.Engine.Fill(FuelType.Petrol); Mercedes.VehicleStarted += OnVehicleStarted; Mercedes.VehicleStopped += OnVehicleStopped;
            Volvo = new Car(new PetrolEngine(), "Volvo", "Model6", "Driver6"); Volvo.Engine.Fill(FuelType.Petrol); Volvo.VehicleStarted += OnVehicleStarted; Volvo.VehicleStopped += OnVehicleStopped;
            Peugot = new Car(new PetrolEngine(), "Peugot", "Model7", "Driver7"); Peugot.Engine.Fill(FuelType.Petrol); Peugot.VehicleStarted += OnVehicleStarted; Peugot.VehicleStopped += OnVehicleStopped;
        }

        private static void OnVehicleStopped(object myObject, CarRace.CustomEventArgs.VehicleStoppedEventArgs myArgs)
        {
            resultList.Add(string.Format("{0} - {1} finished race with average speed of {2} m/s", myArgs.CarMake, myArgs.CarModel, Math.Round(myArgs.AverageSpeed)));
        }

        private static void OnVehicleStarted(object myObject, CarRace.CustomEventArgs.VehicleStartedEventArgs myArgs)
        {
            Console.WriteLine(string.Format("Send Message to Administrator: {0} - {1} has been started by {2}", myArgs.CarMake, myArgs.CarModel, myArgs.DriverName));
        }

        private static void StartAllCars()
        {
            BMW1.Start(0);
            BMW2.Start(0);
            Audi1.Start(0);
            Audi2.Start(0);
            Mercedes.Start(0);
            Volvo.Start(0);
            Peugot.Start(0);
        }
    }
}
