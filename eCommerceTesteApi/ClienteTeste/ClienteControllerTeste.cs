using eCommerceTesteApi.ProdutoTeste;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceTesteApi.ClienteTeste
{
    internal class ClienteControllerTeste : ControllerBase
    {

        [HttpPost]
        public ActionResult<ClienteModelTest> Create([FromBody] ClienteTest cadastroCliente)
        {
            ClienteModelTest cliente = new ClienteModelTest(cadastroCliente.Nome, cadastroCliente.Ativo);

            if (cliente.Nome == null || cliente.Nome == "")
            {
                return BadRequest("Favor informar um nome de cliente!");
            }

            //_clienteService.Create(cliente);
            return Ok(cliente);
        }


        /* [HttpPut]
         public IActionResult Update([FromBody] AtualizarClienteRequestApi atualizarCliente)
         {
             var cliente = _clienteService.Get(atualizarCliente.Id);

             if (cliente == null)
             {
                 return NotFound("Não encontrado!");
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

             if (cliente == null)
             {
                 return NotFound("Não encontrado!");
             }

             _clienteService.Remove(id);

             return Ok();*/
    }
    }
}
