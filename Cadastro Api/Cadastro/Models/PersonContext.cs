using Microsoft.EntityFrameworkCore;

namespace Cadastro.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Person> Person { get; set; }
    }
}
