using eCommerce.Models;
using eCommerce.RequestApi.ClienteController;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("id")]
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
        public ActionResult<Cliente> Create([FromBody] CadastroClienteRequestApi cadastroCliente)
        {
            Cliente cliente = new Cliente(cadastroCliente.Nome, cadastroCliente.Ativo);
            var result = _clienteService.Create(cliente);
            if (result == null)
            {
                return BadRequest("Favor preencher as informações de maneira correta!");                
            }
            return Ok(cliente);
        }
       
        [HttpPut]
        public IActionResult Update([FromBody] AtualizarClienteRequestApi atualizarCliente)
        {
            var cliente = _clienteService.Get(atualizarCliente.Id);
           
            if(cliente == null)
            {
                return NotFound("Favor preencher as informações de maneira correta!");
            }

            cliente.Nome = atualizarCliente.Nome;
            cliente.Ativo = atualizarCliente.Ativo;

            _clienteService.Update(atualizarCliente.Id, cliente);

            return Ok();
        }
        
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var cliente = _clienteService.Get(id);

            if(cliente == null)
            {
                return NotFound("Favor preencher as informações de maneira correta!");
            }
            _clienteService.Remove(id);
            return Ok();
        }
    }
}
