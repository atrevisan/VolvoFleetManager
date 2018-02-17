using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolvoFleetManager.Data.Repositories;
using VolvoFleetManager.Entities;
using VolvoFleetManager.Data.Infrastructure;
using VolvoFleetManager.Entities.Enumerations;
using System.Linq;

namespace VolvoFleetManager.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestAddVehicle()
        {
            EntityBaseRepository<Vehicle> vehiclesRepository = new EntityBaseRepository<Vehicle>(new DbFactory());
            Vehicle vehicle = new Vehicle
            {
                ChassisId = "aaa123",
                Color = "Blue",
                Type = VehicleType.Car
            };

            vehiclesRepository.Add(vehicle);

            Assert.IsTrue(vehiclesRepository.FindBy(v => v.ChassisId == "aaa123").Any());
        }

        [TestMethod]
        public void TestDeleteVehicle()
        {
            EntityBaseRepository<Vehicle> vehiclesRepository = new EntityBaseRepository<Vehicle>(new DbFactory());
            Vehicle vehicle = new Vehicle
            {
                ChassisId = "bbb123",
                Color = "Blue",
                Type = VehicleType.Car
            };
  
            vehiclesRepository.Add(vehicle);

            Vehicle vei = vehiclesRepository.FindBy(v => v.ChassisId == "bbb123").SingleOrDefault();
            vehiclesRepository.Delete(vei);

            Assert.IsTrue(!vehiclesRepository.All.Any());
        }

        [TestMethod]
        public void TestEditVehicle()
        {
            EntityBaseRepository<Vehicle> vehiclesRepository = new EntityBaseRepository<Vehicle>(new DbFactory());
            Vehicle vehicle = new Vehicle
            {
                ChassisId = "bbb123",
                Color = "Blue",
                Type = VehicleType.Car
            };

            vehiclesRepository.Add(vehicle);

            Vehicle vei = vehiclesRepository.FindBy(v => v.ChassisId == "bbb123").SingleOrDefault();
            vei.Color = "red";
            vehiclesRepository.Edit(vei);

            Assert.IsTrue(vehiclesRepository.FindBy(v => v.ChassisId == "bbb123").SingleOrDefault().Color == "red");
        }

        [TestMethod]
        public void TestAddManyVehicles()
        {
            EntityBaseRepository<Vehicle> vehiclesRepository = new EntityBaseRepository<Vehicle>(new DbFactory());
            Vehicle vehicle = new Vehicle
            {
                ChassisId = "aaa123",
                Color = "Blue",
                Type = VehicleType.Car
            };

            Vehicle vehicle2 = new Vehicle
            {
                ChassisId = "bbb123",
                Color = "red",
                Type = VehicleType.Truck
            };

            vehiclesRepository.Add(vehicle);
            vehiclesRepository.Add(vehicle2);

            Assert.IsTrue(vehiclesRepository.All.Count() > 1);
        }
    }

}
