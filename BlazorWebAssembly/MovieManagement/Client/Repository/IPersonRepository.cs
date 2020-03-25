using MovieManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Repository
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
        Task<List<Person>> GetPeople();
    }
}
