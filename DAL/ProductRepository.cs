using Linq.Models;

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
            if (filter.IsAscending)
            {
                query = filter.sortBy switch
                {
                    "Name" => query.OrderBy(x => x.Name),
                    "ProductNumber" => query.OrderBy(x => x.ProductNumber),
                    "Color" => query.OrderBy(x => x.Color),
                    _ => query.OrderBy(x => x.ProductId),
                };
            }
            else
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
    }
}
