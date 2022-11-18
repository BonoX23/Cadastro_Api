using Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly PersonContext _context;
        public PersonRepository(PersonContext context)
        {
            _context = context;
        }
        public async Task<Person> Create(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task Delete(int id)
        {
            var personToDelete = await _context.Person.FindAsync(id);
            _context.Person.Remove(personToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> Get(int id)
        {
            return await _context.Person.FindAsync(id);
        }
        public async Task<IEnumerable<Person>> Get(string name)
        {
            return await _context.Person.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
