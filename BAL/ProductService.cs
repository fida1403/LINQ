using DAL;
using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

