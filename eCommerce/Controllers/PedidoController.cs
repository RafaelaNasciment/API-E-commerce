using eCommerce.Models;
using eCommerce.RequestApi.ClienteController;
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
        private readonly ClienteService _clienteService;
        private readonly ProdutoService _produtoService;

        public PedidoController(PedidoService pedidoService, ClienteService clienteService, ProdutoService produtoService)
        {
            _pedidoService = pedidoService;
            _clienteService = clienteService;
            _produtoService = produtoService;

        }


        [HttpGet("{id}", Name = "GetPedido")]
        public ActionResult<Pedido> Get(string id)
        {
            var pedido = _pedidoService.Get(id);

            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult<Pedido> Create([FromBody] CadastroPedidoRequestApi cadastroPedido)
        {
            var produto = _produtoService.Get(cadastroPedido.IdProduto); ;
            var cliente = _clienteService.Get(cadastroPedido.IdCliente);

            if(produto == null || cliente == null)
            {
                return BadRequest("Favor preencher todas informações!");
            }
            if (produto.Ativo == true && cliente.Ativo == true)
            {
                Pedido pedido = new Pedido(cadastroPedido.IdProduto, cadastroPedido.IdCliente, produto.Preco);
                _pedidoService.Create(pedido);
                return Ok(pedido);
            }
            return BadRequest("Produto ou cliente inativo na base!");
        }
    }
}