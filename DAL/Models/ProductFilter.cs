using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class ProductFilter : FilterBase
    {
        public string productNumber { get; set; }
        public string color { get; set; }
        public decimal listPrice { get; set; }
        public string size { get; set; }
        public string productLineStartsWith { get; set; }
    }
}
