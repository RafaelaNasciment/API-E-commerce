using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerce.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        private readonly ProdutoService _produtoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService; 
        }

        //[HttpGet]
        //public ActionResult<List<Pedido>> Get() =>
        //    _pedidoService.Get(); 

        [HttpGet("{id}", Name = "GetPedido")]
        public ActionResult<Pedido> Get(int id, bool ativo)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null) 
            {
                return NotFound(); 
            }
            return pedido;
        }

        [HttpPost]
        public ActionResult<Pedido> Create(Pedido pedido)
        {
            _pedidoService.Create(pedido);
            return CreatedAtRoute("GetPedido", new { id = pedido.Id.ToString() }, pedido);
            
        }
    }
}
