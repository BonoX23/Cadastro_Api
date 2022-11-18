using Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> Get();
        Task<Person> Get(int id);
        Task<IEnumerable<Person>> Get(string name);
        Task<Person> Create(Person person);
        Task Update(Person person);
        Task Delete(int id);
        
    }
}
