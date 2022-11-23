using Linq.Models;
using System.Collections;

namespace DAL
{
    public class LocationRepository: ILocationRepository
    {
        private readonly AdventureWorks2019Context context;
        public LocationRepository(AdventureWorks2019Context context)
        {
            this.context = context;
        }


        public async Task<IEnumerable> GetTotalQuantity()
        {
            var query = (from p in context.Locations
                         join pi in context.ProductInventories on p.LocationId equals pi.LocationId into grp
                         select new
                         {
                             LocationName = p.Name,
                             TotalQuantity = grp.Sum(p => p.Quantity)
                         }).ToList();
            return query;
        }
    }
}
