using eCommerce.Models;
using eCommerce.Services;
using System;
using Xunit;

namespace ClienteControllerTest
{
    public class ClienteTest : ClienteService 
    {
        private NomeAleatorio _nomeAleatorio;
        private string id = Guid.NewGuid().ToString();
        public ClienteTest()
        {
            _nomeAleatorio = new NomeAleatorio();
        }

        #region Teste Método Create

        [Fact(DisplayName = "CREATE: Nome nulo")]
        public void TestandoNomeNulo()
        {
            var cliente = new Cliente("", true);

            var expected = Create(cliente);
            
            Assert.Null(expected);
        }

        [Fact(DisplayName = "CREATE: Limite de caracteres Nome")]
        public void TestandoLimiteCaracteresNome()
        {
            var cliente = new Cliente(_nomeAleatorio.nomeAleatorio(), true);

            var result = Create(cliente);

            Assert.Null(result);
        }
        #endregion

        #region Testando Método Update
        [Fact(DisplayName = "UPDATE: Nome nulo")]
        public void TestandoNomeNuloUpdate()
        {
            var cliente = new Cliente("", true);
            var result = Create(cliente);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Limite de caracteres Nome")]
        public void TestandoLimiteCaracteresNomeUpdate()
        {
            var cliente = new Cliente(_nomeAleatorio.nomeAleatorio(), true);
            var result = Update(Convert.ToString(id), cliente);

            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Testando Id vazio")]
        public void TestandoIdVazio()
        {
            var cliente = new Cliente("Rafaela", true);
            var result = Update(null, cliente);

            Assert.Null(result);
        }
        #endregion

        #region Testando Método Delete

        [Fact(DisplayName = "DELETE: ID vazio")]
        public void TestandoIdVazioDelete()
        {
            var result = Remove(null);

            Assert.Null(result);
        }
        #endregion
    }
}
