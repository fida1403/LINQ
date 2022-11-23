using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public abstract class FilterBase
    {
        public int pageNo { get; set; }
        public int itemsPerPage { get; set; }
        public string sortBy { get; set; }
        public bool IsAscending { get; set; }
    }
}
