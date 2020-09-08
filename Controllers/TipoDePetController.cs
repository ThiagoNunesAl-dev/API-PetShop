using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_PetShop.Repositories;
using API_PetShop.Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        TipoDePetRepository rep = new TipoDePetRepository();


        // GET: api/<TipoDePetController>
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return rep.LerTodos();
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return rep.BuscarPorId(id);
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet t)
        {
            return rep.Cadastrar(t);
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet t)
        {
            return rep.Alterar(id, t);
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Excluir(id);
        }
    }
}
