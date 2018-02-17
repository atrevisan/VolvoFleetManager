using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoFleetManager.Data.Infrastructure;
using VolvoFleetManager.Data.Repositories;
using VolvoFleetManager.Entities;
using VolvoFleetManager.Entities.Enumerations;

namespace VolvoFleetManager.Presentation
{
    public class InputProcessor
    {
        private readonly EntityBaseRepository<Vehicle> _vehicleRepository;

        public InputProcessor()
        {
            _vehicleRepository = new EntityBaseRepository<Vehicle>(new DbFactory());
        }

        public void ProcessInput(int input)
        {

            switch (input)
            {
                case 1:
                    InsertNewVehicle();
                    break;

                case 2:
                    EditVehicle();
                    break;

                case 3:
                    DeleteVehicle();
                    break;

                case 4:
                    ShowAllVehicles();
                    break;

                case 5:
                    FindVehicle();
                    break;
            }
        }

        private void InsertNewVehicle()
        {
            Console.Write("Enter chassisID ");
            string chassisIdInput = Console.ReadLine();

            Console.Write("Enter vehicle type (0, 1, 2 for Bus, truck and car) ");
            string vehicleTypeInput = Console.ReadLine();

            Console.Write("Enter vehicle color ");
            string vehicleColorInput = Console.ReadLine();
            
            int vehicleType = 0;
            if (!Int32.TryParse(vehicleTypeInput, out vehicleType))
            {
                Console.WriteLine("Vehicle type invalid");
                return;
            }

            if (_vehicleRepository.
                    FindBy(v => v.ChassisId == chassisIdInput).Any())
            {
                Console.WriteLine("Already exist a vehicle with this chassis");
                return;
            }

            Vehicle vehicle = new Vehicle
            {
                ChassisId = chassisIdInput,
                Type = (VehicleType)vehicleType,
                Color = vehicleColorInput
            };

            _vehicleRepository.Add(vehicle);
        }

        private void EditVehicle()
        {
            Console.Write("Enter chassisID ");
            string chassisIdInput = Console.ReadLine();

            Vehicle vehicle = _vehicleRepository
                .FindBy(v => v.ChassisId == chassisIdInput)
                .SingleOrDefault();

            if (vehicle == null)
            {
                Console.WriteLine("No vehicle found");
                return;
            }

            Console.Write("Enter vehicle color ");
            string vehicleColorInput = Console.ReadLine();
            
            vehicle.Color = vehicleColorInput;
            _vehicleRepository.Edit(vehicle);
        }

        private void DeleteVehicle()
        {
            Console.Write("Enter chassisID ");
            string chassisIdInput = Console.ReadLine();

            Vehicle vehicle = _vehicleRepository
                .FindBy(v => v.ChassisId == chassisIdInput)
                .SingleOrDefault();

            if (vehicle == null)
            {
                Console.WriteLine("No vehicle found");
                return;
            }
            
            _vehicleRepository.Delete(vehicle);
        }

        private void ShowAllVehicles()
        {
            var vehicles = _vehicleRepository.All.ToList();

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(string.Format("Chassi {0}, Color {1} Type {2} Passenger {3}", vehicle.ChassisId, vehicle.Color, vehicle.Type, vehicle.NumberOfPassemgers));
            }
        }

        private void FindVehicle()
        {
            Console.Write("Enter chassisID ");
            string chassisIdInput = Console.ReadLine();

            Vehicle vehicle = _vehicleRepository
                .FindBy(v => v.ChassisId == chassisIdInput)
                .SingleOrDefault();

            if (vehicle == null)
            {
                Console.WriteLine("No vehicle found");
                return;
            }

            Console.WriteLine(string.Format("Chassi {0}, Color {1} Type {2} Passenger {3}", vehicle.ChassisId, vehicle.Color, vehicle.Type, vehicle.NumberOfPassemgers));
        }
    }
}
