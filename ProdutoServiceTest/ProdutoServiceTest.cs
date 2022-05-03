using eCommerce.Models;
using eCommerce.Services;
using System;
using Xunit;

namespace ProdutoServiceTest
{
    public class ProdutoServiceTest : ProdutoService
    {
        private readonly NomeAleatorio _nomeAleatorio;
        private readonly DescriçãoAleatoria _descriçãoAleatoria;
        string id = Guid.NewGuid().ToString();
        public ProdutoServiceTest()
        {
            _nomeAleatorio = new NomeAleatorio();
            _descriçãoAleatoria = new DescriçãoAleatoria();
        }

        #region Testando método Create
        [Fact(DisplayName = "CREATE: Nome Nulo")]
        public void TestandoNomeNulo()
        {
            var produto = new Produto("", "123456", 12.5m, true);
            var result = Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Limite de caracteres Nome")]
        public void TestandoLimiteCaracteresNome()
        {
            var produto = new Produto(_nomeAleatorio.nomeAleatorio(), "123456", 12.5m, true);

            var result = Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Descrição Nula")]
        public void TestandoDescricaoNulo()
        {
            var produto = new Produto("Rafaela","", 12.5m, true);
            var result = Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Limite de caracteres descrição")]
        public void LimiteCaracteresDescricao()
        {
            var produto = new Produto("Rafaela", _descriçãoAleatoria.descricao(), 12.5m, true);
            var result = Create(produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Preço maior que zero")]
        public void TestandoPrecoZero()
        {
            var produto = new Produto("Rafaela", "1234", 0m, true);

            var result = Create(produto);

            Assert.Null(result);
        }

        #endregion

        #region Testando método Update

        [Fact(DisplayName = "UPDATE: ID Vazio")]
        public void TestandoIdVazio()
        {
            var produto = new Produto("Rafa", "Teste", 15m, true);

            var result = Update(null, produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Nome Nulo")]
        public void TestandoNomeNuloUpdate()
        {
            var produto = new Produto(null, "123", 5m, false);

            var result = Update(id, produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Limite caracteres Nome")]
        public void TestandoLimiteCaracteresNomeUpdate()
        {
            var produto = new Produto(_nomeAleatorio.nomeAleatorio(), "123", 5m, false);

            var result = Update(id, produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Descrição nula")]
        public void TestandoDescricaoNulaUpdate()
        {
            var produto = new Produto("Rafaela", "", 5m, false);

            var result = Update(id, produto);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Limite caracteres Descricao")]
        public void TestandoLimiteCaractersDescricaoUpdate()
        {
            var produto = new Produto("Rafaela", _descriçãoAleatoria.descricao(), 51m, false);

            var result = Update(id, produto);

            Assert.Null(result);
        }
        
        [Fact(DisplayName = "UPDATE: Preco maior que zero")]
        public void testandoPrecoUpdate()
        {
            var produto = new Produto("Rafa", "Teste", 0m, true);

            var result = Update(id, produto);

            Assert.Null(result);           
        }

        #endregion

        #region Testando método Delete
        [Fact(DisplayName = "DELETE: ID Vazio")]
        public void TestandoIdVazioDelete()
        {
            var produto = new Produto("Rafa", "Teste", 15m, true);

            var result = Remove(null);

            Assert.Null(result);
        }
        #endregion
    }
}
