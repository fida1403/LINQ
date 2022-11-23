using System.Collections;

namespace DAL
{
    public interface ILocationRepository
    {
        public Task<IEnumerable> GetTotalQuantity();
    }
}
