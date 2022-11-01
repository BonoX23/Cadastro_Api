using Microsoft.EntityFrameworkCore;

namespace Cadastro.Models
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}
