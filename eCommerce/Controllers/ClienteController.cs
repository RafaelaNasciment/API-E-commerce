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

        [HttpGet]
        public ActionResult<Cliente> Get(string id)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            return cliente;
        }

        [HttpPost]
        public ActionResult<Cliente> Create(string nome, [FromBody]bool ativo)
        {
            Cliente cliente = new Cliente(nome, ativo);

           _clienteService.Create(cliente);
            return Ok(cliente);
        }

        [HttpPut]
        public IActionResult Update([FromQuery]string id, [FromBody] string nome, [FromBody] bool ativo)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Não encontrado!");
            }
            cliente.Nome = nome;
            cliente.Ativo = ativo;

            _clienteService.Update(id, cliente);

            return Ok();
        }
        
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Não encontrado!");
            }

            _clienteService.Remove(id);

            return Ok();
        }
    }
}
