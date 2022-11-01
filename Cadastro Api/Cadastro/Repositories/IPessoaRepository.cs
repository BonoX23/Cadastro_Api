using Cadastro.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> Get();
        Task<Pessoa> Get(int id);
        Task<Pessoa> Create(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task Delete(int id);
        
    }
}
