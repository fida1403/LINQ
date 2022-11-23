using DAL;
using System.Collections;

namespace BAL
{
    public interface ILocationService
    {
        Task<IEnumerable> GetTotalQuantity();
    }


    public class LocationService: ILocationService
    {
        public Task<IEnumerable> GetTotalQuantity()
        {
            var result = repository.GetTotalQuantity();
            return result;
        }

        private ILocationRepository repository;
        public LocationService(ILocationRepository repo)
        {
            repository = repo;
        }
    }
}
