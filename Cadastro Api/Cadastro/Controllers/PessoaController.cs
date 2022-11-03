using Cadastro.Models;
using Cadastro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pessoa>> GetPessoa()
        {
            return await _pessoaRepository.Get();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            return await _pessoaRepository.Get(id);

        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa([FromBody] Pessoa pessoa)
        {
            var addPessoa = await _pessoaRepository.Create(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new {id = addPessoa.Id}, addPessoa);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Delete(int id)
        {
            var delPEssoa = await _pessoaRepository.Get(id);

            if (delPEssoa == null)
                return NotFound();
            
            await _pessoaRepository.Delete(delPEssoa.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult<Pessoa>> PutPessoa(int id, [FromBody] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return BadRequest();

                await _pessoaRepository.Update(pessoa);
            }
            return NoContent();
        }
    }
}
