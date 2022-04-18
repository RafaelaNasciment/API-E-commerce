using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerce.Controllers
{
    [Route("api/controller")]
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

        //GetById
        [HttpGet("{id}", Name = "GetProduto")]
        public ActionResult<Produto> Get(int id) 
        { 
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            _produtoService.Create(produto);

            return CreatedAtRoute("GetProduto", new { id = produto.Id.ToString() }, produto);
        }

        [HttpPut("id")]
        public IActionResult Update(int id, Produto produtoIn)
        {
            var produto = _produtoService.Get(id);

            if(produto == null)
            {
                return NotFound("Não encontrado!");
            }

            _produtoService.Update(id, produtoIn);

            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
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
