using Linq.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductRepository
    {
        public List<Product> GetAllProduct(ProductFilter filter);
        public Task<IEnumerable> GetAllPerson(PersonFilter filter);
    }
}
