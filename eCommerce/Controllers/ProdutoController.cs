using eCommerce.Models;
using eCommerce.RequestApi.ClienteController;
using eCommerce.RequestApi.PedidoController;
using eCommerce.RequestApi.ProdutoController;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerce.Controllers
{
    [Route("api/Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get() =>
            _produtoService.Get();
       
        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Produto> Get(string id) 
        { 
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create([FromBody] CadastroProdutoRequestApi cadastroProduto)
        {
            Produto produto = new Produto(cadastroProduto.Nome, cadastroProduto.Descricao, 
                cadastroProduto.Preco,cadastroProduto.Ativo);

            var result = _produtoService.Create(produto);
            if (result == null)
            {
                return BadRequest("Favor preencher os dados de maneira correta!");
            }
            return Ok(produto);
        }

        [HttpPut("id")]
        public IActionResult Update([FromBody]AtualizarProdutoRequestApi atualizarProduto)
        {
            var produto = _produtoService.Get(atualizarProduto.Id);

            if(produto == null)
            {
                return NotFound("Não encontrado!");
            }
            produto.Nome = atualizarProduto.Nome;
            produto.Descricao = atualizarProduto.Descricao;
            produto.Preco = atualizarProduto.Preco;
            produto.Ativo = atualizarProduto.Ativo;

            var result = _produtoService.Update(atualizarProduto.Id, produto);
            if(result == null)
            {
                return BadRequest("Favor preencher os dados de maneira correta!");
            }

            return Ok(produto);
        }

        [HttpDelete("id")]
        public IActionResult Delete(string id)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound("Não encontrado");
            }

            _produtoService.Remove(id);

            return NoContent();
        }              
    }
}
