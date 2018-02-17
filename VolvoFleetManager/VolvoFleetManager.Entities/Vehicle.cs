using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoFleetManager.Entities.Enumerations;

namespace VolvoFleetManager.Entities
{
    public class Vehicle : IEntityBase
    {

        public int ID { get; set; }

        public string ChassisId { get; set; }

        public VehicleType Type { get; set; }

        public byte NumberOfPassemgers
        {
            get
            {
                switch (Type)
                {
                    case VehicleType.Bus:
                        return 42;
                    case VehicleType.Truck:
                        return 1;
                    case VehicleType.Car:
                        return 4;
                    default:
                        return 0;
                }
            }
        }

        public string Color { get; set; }
    }
}
