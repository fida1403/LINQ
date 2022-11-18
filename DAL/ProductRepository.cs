using Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdventureWorks2019Context context;
        public ProductRepository(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        public List<Product> GetAllProduct(ProductFilter filter)
        {
            var query = this.context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(filter.productNumber))
            {
                query = query.Where(x => x.ProductNumber == filter.productNumber);
            }
            if (!string.IsNullOrEmpty(filter.color))
            {
                query = query.Where(x => x.Color == filter.color);
            }
            if (filter.listPrice != null)
            {
                query = query.Where(x => x.ListPrice == filter.listPrice);
            }
            if (filter.size != null)
            {
                query = query.Where(x => x.Size == filter.size);
            }
            if (filter.sortByAscendingOrDescending == "Ascending")
            {
                switch (filter.sortBy)
                {
                    case "Name":
                        query = query.OrderBy(x => x.Name);
                        break;
                    case "ProductNumber":
                        query = query.OrderBy(x => x.ProductNumber);
                        break;
                    case "Color":
                        query = query.OrderBy(x => x.Color);
                        break;
                    default:
                        query = query.OrderBy(x => x.ProductId);
                        break;
                }
            }
            if (filter.sortByAscendingOrDescending == "Descending")
            {
                switch (filter.sortBy)
                {
                    case "Name":
                        query = query.OrderByDescending(x => x.Name);
                        break;
                    case "ProductNumber":
                        query = query.OrderByDescending(x => x.ProductNumber);
                        break;
                    case "Color":
                        query = query.OrderByDescending(x => x.Color);
                        break;
                    default:
                        query = query.OrderByDescending(x => x.ProductId);
                        break;
                }
            }
            return query.Skip((filter.pageNo - 1) * filter.itemsPerPage).Take(filter.itemsPerPage).Where(x => x.SellStartDate != null).Where(x => x.ProductLine == filter.productLineStartsWith).ToList();
        }

        public async Task<IEnumerable> GetAllPerson(PersonFilter filter)
        {
            var query = await context.People.Where(x => x.FirstName == filter.firstName).Skip((filter.pageNo - 1) * filter.itemsPerPage).Take(filter.itemsPerPage).Join(context.PersonPhones, p => p.BusinessEntityId, pp => pp.BusinessEntityId, (p, pp) => new { p, pp }).Select(result => new
            {
                BusinessEntityId = result.p.BusinessEntityId,
                PersonType = result.p.PersonType,
                NameStyle = result.p.NameStyle,
                Title = result.p.Title,
                FirstName = result.p.FirstName,
                MiddleName = result.p.MiddleName,
                LastName = result.p.LastName,
                Suffix = result.p.Suffix,
                EmailPromotion = result.p.EmailPromotion,
                AdditionalContactInfo = result.p.AdditionalContactInfo,
                Demographics = result.p.Demographics,
                rowguid = result.p.Rowguid,
                ModifiedDate = result.p.ModifiedDate,
                PhoneNumber = result.pp.PhoneNumber
            }).ToListAsync();
            return query;
        }
    }
}
