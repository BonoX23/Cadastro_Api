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
        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _pessoaRepository.Get();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetById(int id)
        {
            return await _pessoaRepository.Get(id);

        }
        [HttpGet("byname/{nome}")]
        public async Task<IEnumerable<Pessoa>> GetByName(string nome)
        {
            return await _pessoaRepository.Get(nome);

        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa([FromBody] Pessoa pessoa)
        {
            var addPessoa = await _pessoaRepository.Create(pessoa);
            return CreatedAtAction(nameof(GetById), new {id = addPessoa.Id}, addPessoa);

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
        public async Task<ActionResult<Pessoa>> PutPessoa([FromBody] Pessoa pessoa)
        {
            var pessoaExistente = await _pessoaRepository.Get(pessoa.Id);
            if (pessoaExistente == null)
            {
                return BadRequest("Este ID de pessoa não existe");
            }

            pessoaExistente.UpdatePessoa(pessoa);

            await _pessoaRepository.Update(pessoaExistente);


            return Ok(pessoaExistente);
        }
    }
}
