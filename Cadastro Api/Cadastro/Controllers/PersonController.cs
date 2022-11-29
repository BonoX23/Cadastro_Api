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
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _personRepository.Get();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            return await _personRepository.Get(id);

        }
        [HttpGet("byname/{name}")]
        public async Task<IEnumerable<Person>> GetByName(string name)
        {
            return await _personRepository.Get(name);

        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPessoa([FromBody] Person person)
        {
            var addPerson = await _personRepository.Create(person);
            return CreatedAtAction(nameof(GetById), new {id = addPerson.Id}, addPerson);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            var delPerson = await _personRepository.Get(id);

            if (delPerson == null)
                return NotFound();
            
            await _personRepository.Delete(delPerson.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult<Person>> PutPessoa([FromBody] Person person)
        {
            var existingPerson = await _personRepository.Get(person.Id);
            if (existingPerson == null)
            {
                return BadRequest("Este ID de pessoa não existe");
            }

            existingPerson.UpdatePerson(person);

            await _personRepository.Update(existingPerson);


            return Ok(existingPerson);
        }
    }
}
