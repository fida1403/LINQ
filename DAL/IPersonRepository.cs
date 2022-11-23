using System.Collections;
using DAL.Models;

namespace DAL
{
    public interface IPersonRepository
    {
        public Task<IEnumerable> GetAllPerson(PersonFilter filter);
        public Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter);
        public Task<IEnumerable> GetAllPersonSqlQuery(PersonFilter filter);
    }
}
