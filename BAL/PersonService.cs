using DAL;
using DAL.Models;
using System.Collections;

namespace BAL
{
    public interface IPersonService
    {
        Task<IEnumerable> GetAllPerson(PersonFilter filter);
        Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter);
        Task<IEnumerable> GetAllPersonSqlQuery(PersonFilter filter);
    }


    public class PersonService : IPersonService
    {
        public Task<IEnumerable> GetAllPerson(PersonFilter filter)
        {
            var result = repository.GetAllPerson(filter);
            return result;
        }

        public Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter)
        {
            var result = repository.GetAllPersonQuerySyntax(filter);
            return result;
        }

        public Task<IEnumerable> GetAllPersonSqlQuery(PersonFilter filter)
        {
            var result = repository.GetAllPersonSqlQuery(filter);
            return result;
        }


        private IPersonRepository repository;
        public PersonService(IPersonRepository repo)
        {
            repository = repo;
        }
    }
}
