using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PetShop.Domains;
using API_PetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        RacaRepository rep = new RacaRepository();


        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return rep.BuscarPorId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca r)
        {
            return rep.Cadastrar(r);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca r)
        {
            return rep.Alterar(id, r);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Excluir(id);
        }
    }
}
