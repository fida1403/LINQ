using DAL;
using Linq.Models;

namespace BAL
{
    public interface IProductService
    {
        List<Product> GetAllProduct(ProductFilter filter);
    }


    public class ProductService : IProductService
    {
        public List<Product> GetAllProduct(ProductFilter filter)
        {
            var result = repository.GetAllProduct(filter);
            return result;
        }


        private IProductRepository repository;
        public ProductService(IProductRepository repo)
        {
            repository = repo;
        }
    }
}

