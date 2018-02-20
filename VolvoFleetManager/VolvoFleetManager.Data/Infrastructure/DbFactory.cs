using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvoFleetManager.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        FleetContext dbContext;

        public FleetContext Init()
        {
            return dbContext ?? (dbContext = new FleetContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
