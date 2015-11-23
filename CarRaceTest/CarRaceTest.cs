using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRace.Interfaces;
using CarRace.Entities;
using CarRace.Enums;
using CarRace.CustomEventArgs;
using System.Threading;

namespace CarRaceTest
{
    [TestClass]
    public class CarRaceTest
    {
        [TestMethod]
        public void TestElectricEngine()
        {
            IEngine engine = new ElectricEngine();
            Assert.IsTrue(engine.EngineName == "Electric Engine");
            Assert.IsFalse(engine.IsFilled);
            bool fillResult = engine.Fill(FuelType.Electricity);
            Assert.IsTrue(fillResult);
            Assert.IsTrue(engine.IsFilled);
            engine.IsFilled = false;
            fillResult = engine.Fill(FuelType.Petrol);
            Assert.IsFalse(fillResult);
            Assert.IsFalse(engine.IsFilled);
            fillResult = engine.Fill((FuelType)9);
            Assert.IsFalse(fillResult);
            Assert.IsFalse(engine.IsFilled);
        }

        [TestMethod]
        public void TestPetrolEngine()
        {
            IEngine engine = new PetrolEngine();
            Assert.IsTrue(engine.EngineName == "Petrol Engine");
            Assert.IsFalse(engine.IsFilled);
            bool fillResult = engine.Fill(FuelType.Petrol);
            Assert.IsTrue(fillResult);
            Assert.IsTrue(engine.IsFilled);
            engine.IsFilled = false;
            fillResult = engine.Fill(FuelType.Electricity);
            Assert.IsFalse(fillResult);
            Assert.IsFalse(engine.IsFilled);
            fillResult = engine.Fill((FuelType)9);
            Assert.IsFalse(fillResult);
            Assert.IsFalse(engine.IsFilled);
        }

        [TestMethod]
        public void TestHybridEngine()
        {
            IEngine engine = new HybridEngine();
            Assert.IsTrue(engine.EngineName == "Hybrid Engine");
            Assert.IsFalse(engine.IsFilled);
            bool fillResult = engine.Fill(FuelType.Petrol);
            Assert.IsTrue(fillResult);
            Assert.IsTrue(engine.IsFilled);
            engine.IsFilled = false;
            fillResult = engine.Fill(FuelType.Electricity);
            Assert.IsTrue(fillResult);
            Assert.IsTrue(engine.IsFilled);
            engine.IsFilled = false;
            fillResult = engine.Fill((FuelType)9);
            Assert.IsFalse(fillResult);
            Assert.IsFalse(engine.IsFilled);
        }

        [TestMethod]
        public void TestCarStart()
        {
            IVehicle raceCar = new Car(new PetrolEngine(), "Mercedes", "McLaren", "Mika Hakkinen");
            bool isFired = false;
            VehicleStartedEventArgs args = null;
            raceCar.VehicleStarted += delegate (object o, VehicleStartedEventArgs e) { isFired = true;args = e;  };
            Assert.IsFalse(isFired);
            raceCar.Start(0);
            Assert.IsFalse(isFired);
            raceCar.Engine.Fill(FuelType.Petrol);
            raceCar.Start(0);
            Assert.IsTrue(isFired);
            Assert.IsTrue(args.CarMake == "Mercedes");
            Assert.IsTrue(args.CarModel == "McLaren");
            Assert.IsTrue(args.DriverName == "Mika Hakkinen");
        }
        [TestMethod]
        public void TestCarStop()
        {
            IVehicle raceCar = new Car(new PetrolEngine(), "Mercedes", "McLaren", "Mika Hakkinen");
            bool isFired = false;
            VehicleStoppedEventArgs args = null;
            raceCar.VehicleStopped += delegate (object o, VehicleStoppedEventArgs e) { isFired = true; args = e; };
            Assert.IsFalse(isFired);
            raceCar.Stop(1000);
            Assert.IsFalse(isFired);
            raceCar.Engine.Fill(FuelType.Petrol);
            raceCar.Start(0);
            Thread.Sleep(20000);
            raceCar.Stop(1000);
            Assert.IsTrue(isFired);
            Assert.IsTrue(Math.Round(args.AverageSpeed) == 50);
            Assert.IsTrue(args.CarMake == "Mercedes");
            Assert.IsTrue(args.CarModel == "McLaren");
        }
    }
}
