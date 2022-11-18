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
        public string firstName { get; set; }
    }
}
