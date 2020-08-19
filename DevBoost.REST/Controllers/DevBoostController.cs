using DevBoost.REST.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DevBoost.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevBoostController : ControllerBase
    {
        private List<Pessoa> Pessoas
        {
            get
            {
                List<Pessoa> pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Fulano de alguma coisa"
                },
                    new Pessoa
                    {
                        Id = 2,
                    Nome = "Beltrano de alguma coisa"
                }
            };
                return pessoas;
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Pessoas);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }


        [HttpPost]
        public IActionResult Post(Pessoa pessoa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Pessoas.Add(pessoa);

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pessoa pessoaNova)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa == null)
                return NotFound();

            pessoa.Nome = pessoaNova.Nome;

            return Ok(pessoa);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            if (pessoa == null)
                return NotFound();

            Pessoas.Remove(pessoa);

            return NoContent();
        }
    }
}