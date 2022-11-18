using Azure;
using DAL;
using Linq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IProductService
    {
        List<Product> GetAllProduct(ProductFilter filter);
        Task<IEnumerable> GetAllPerson(PersonFilter filter);
    }
    public class ProductService : IProductService
    {
        public List<Product> GetAllProduct(ProductFilter filter)
        {
            var result = repository.GetAllProduct(filter);
            return result;
        }

        public Task<IEnumerable> GetAllPerson(PersonFilter filter)
        {
            var result = repository.GetAllPerson(filter);
            return result;
        }

       
        private IProductRepository repository;
        public ProductService(IProductRepository repo)
        {
            repository = repo;
        }
    }
}

