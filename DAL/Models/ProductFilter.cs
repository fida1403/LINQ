using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonFilter
    {
        public int pageNo { get; set; }
        public int itemsPerPage { get; set; }
    }


    public abstract class ProductFilter : PersonFilter
    {
        public string productNumber { get; set; }
        public string color { get; set; }
        public decimal listPrice { get; set; }
        public string size { get; set; }
        public string productLineStartsWith { get; set; }
        public string sortByAscendingOrDescending { get; set; }
        public string sortBy { get; set; }
    }
}
