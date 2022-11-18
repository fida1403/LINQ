using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IPersonService
    {
        Task<IEnumerable> GetAllPerson(PersonFilter filter);
        Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter);
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


        private IPersonRepository repository;
        public PersonService(IPersonRepository repo)
        {
            repository = repo;
        }
    }
}
