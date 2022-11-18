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
    public class PersonRepository : IPersonRepository
    {
        private readonly AdventureWorks2019Context context;
        public PersonRepository(AdventureWorks2019Context context)
        {
            this.context = context;
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

        public async Task<IEnumerable> GetAllPersonQuerySyntax(PersonFilter filter)
        {
            var query = (from p in context.People
                         join pp in context.PersonPhones on p.BusinessEntityId equals pp.BusinessEntityId
                         where p.FirstName == filter.firstName
                         select new
                         {
                             BusinessEntityId = p.BusinessEntityId,
                             PersonType = p.PersonType,
                             NameStyle = p.NameStyle,
                             Title = p.Title,
                             FirstName = p.FirstName,
                             MiddleName = p.MiddleName,
                             LastName = p.LastName,
                             Suffix = p.Suffix,
                             EmailPromotion = p.EmailPromotion,
                             AdditionalContactInfo = p.AdditionalContactInfo,
                             Demographics = p.Demographics,
                             rowguid = p.Rowguid,
                             ModifiedDate = p.ModifiedDate,
                             PhoneNumber = pp.PhoneNumber
                         }).Skip((filter.pageNo - 1) * filter.itemsPerPage).Take(filter.itemsPerPage).ToList();
            return query;
        }
    }
}
