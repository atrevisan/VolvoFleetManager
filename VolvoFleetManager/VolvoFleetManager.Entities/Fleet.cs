using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoFleetManager.Entities
{
    public class Fleet
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
