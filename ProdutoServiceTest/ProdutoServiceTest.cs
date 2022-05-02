using eCommerce.Models;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProdutoServiceTest
{
    public class ProdutoServiceTest
    {
        #region Testando método Create
        [Fact(DisplayName = "CREATE: Testando nome Nulo está passando")]
        public void testandoNomeNulo()
        {
            var produto = new Produto("", "123456", 12.5m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Testando limite de caracteres do Nome")]
        public void limiteCaracteresNome()
        {
            var nome = new NomeAleatorio().nomeAleatorio();
            var produto = new Produto(nome, "123456", 12.5m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Testando descrição nula está passando")]
        public void testandoDescricaoNulo()
        {
            var produto = new Produto("Rafaela", "", 12.5m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Testando limite de caracteres descrição")]
        public void limiteCaracteresDescricao()
        {
            var descricao = new DescriçãoAleatoria().descricao();
            var produto = new Produto("Rafaela", descricao, 12.5m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Testando se o preço é maior que zero")]
        public void testandoPrecoZero()
        {
            var descricao = new DescriçãoAleatoria().descricao();
            var produto = new Produto("Rafaela", "1234", 0m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Create(produto);

            Assert.Null(result);
        }

        #endregion

        #region Testando método Update
        [Fact(DisplayName = "UPDATE: Verificando se o ID está vazio")]
        public void idVazio()
        {
            var produto = new Produto("Rafa", "Teste", 15m, true);
            var produtoService = new ProdutoService();
            produtoService.Update(null, produto);
        }

        [Fact(DisplayName = "UPDATE: Testando se o nome está nulo")]
        public void testandoNomeNuloUpdate()
        {
            var id = Guid.NewGuid();
            var produto = new Produto(null, "123", 5m, false);
            var produtoService = new ProdutoService();
            var result = produtoService.Update(id.ToString(), produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Testando Limite de caracteres Nome")]
        public void testandoLimiteCaractersNomeUpdate()
        {
            var id = Guid.NewGuid();
            var nome = new NomeAleatorio().nomeAleatorio();
            var produto = new Produto(nome, "123", 5m, false);
            var produtoService = new ProdutoService();
            var result = produtoService.Update(id.ToString(), produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Testando Descrição nula")]
        public void testandoDescricaoNulaUpdate()
        {
            var id = Guid.NewGuid();
            var produto = new Produto("Rafaela", "", 5m, false);
            var produtoService = new ProdutoService();
            var result = produtoService.Update(id.ToString(), produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Testando Limite de caracteres Descricao")]
        public void testandoLimiteCaractersDescricaoUpdate()
        {
            var id = Guid.NewGuid();
            var descricao = new DescriçãoAleatoria().descricao();
            var produto = new Produto("Rafaela", descricao, 51m, false);
            var produtoService = new ProdutoService();
            var result = produtoService.Update(id.ToString(), produto);

            Assert.Null(result);
        }
        
        [Fact(DisplayName = "UPDATE: Testando Preco está maior que zero")]
        public void testandoPrecoUpdate()
        {
            var id = Guid.NewGuid().ToString();
            var produto = new Produto("Rafa", "Teste", 0m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Update(id, produto);

            Assert.Null(result);           
        }

        #endregion

        #region Testando método Delete
        [Fact(DisplayName = "DELETE: Testando ID Vazio")]
        public void idVazioDelete()
        {
            var produto = new Produto("Rafa", "Teste", 15m, true);
            var produtoService = new ProdutoService();
            var result = produtoService.Remove(null);

            Assert.Null(result);
        }
        #endregion
    }
}
