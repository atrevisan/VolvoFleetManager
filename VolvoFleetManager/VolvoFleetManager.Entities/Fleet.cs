using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoFleetManager.Entities
{
    public class Fleet : IEntityBase
    {
        public int ID { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
