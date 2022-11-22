using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPersonRepository
    {
        public Task<IEnumerable> GetAllPerson(PersonFilter filter);
        public Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter);
        public Task<IEnumerable> GetAllPersonSqlQuery(PersonFilter filter);
    }
}
