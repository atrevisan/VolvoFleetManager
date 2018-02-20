using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoFleetManager.Entities;
using VolvoFleetManager.Entities.Enumerations;

namespace VolvoFleetManager.Data.Infrastructure
{
    public class FleetContext : DbContext
    {
        public FleetContext()
            : base("VolvoFleetManager")
        {
        }

        #region Entity Sets
        public IDbSet<Vehicle> VehicleSet { get; set; }
        public IDbSet<Fleet> FleetSet { get; set; }
        
        #endregion

     
    }
}
