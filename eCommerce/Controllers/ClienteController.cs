using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerce.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Get() =>
            _clienteService.Get();

        [HttpGet("{id}", Name = "GetCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
           _clienteService.Create(cliente);
            return CreatedAtRoute("GetCliente", new {id = cliente.Id.ToString()}, cliente);
        }

        [HttpPut("id")]

        public IActionResult Update(int id, Cliente clienteIn)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Não encontrado!");
            }
            _clienteService.Update(id, clienteIn);

            return NoContent();
        }
        
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Não encontrado!");
            }

            _clienteService.Remove(id);

            return NoContent();
        }
    }
}
