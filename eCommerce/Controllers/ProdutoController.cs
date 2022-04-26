using eCommerce.Models;
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
        public ActionResult<Produto> Create([FromBody]string nome, [FromBody] string descricao, 
            [FromBody]decimal preco, [FromBody] bool ativo)
        {
            Produto produto = new Produto(nome, descricao, preco, ativo);

            _produtoService.Create(produto);

            return Ok(produto);
        }

        [HttpPut("id")]
        public IActionResult Update([FromQuery]string id, [FromBody] string nome, [FromBody] string descricao,
            [FromBody] decimal preco, [FromBody] bool ativo)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound("Não encontrado!");
            }
            produto.Nome = nome;
            produto.Descricao = descricao;
            produto.Preco = preco;
            produto.Ativo = ativo;

            _produtoService.Update(id, produto);

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
