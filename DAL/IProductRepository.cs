using Linq.Models;

namespace DAL
{
    public interface IProductRepository
    {
        public List<Product> GetAllProduct(ProductFilter filter);
    }
}
