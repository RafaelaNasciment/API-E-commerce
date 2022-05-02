using eCommerce.Models;
using eCommerce.Services;
using System;
using Xunit;

namespace ClienteControllerTest
{
    public class ClienteTest
    {
        #region Teste Método Create

        [Fact(DisplayName = "CREATE: Testando se o Nome é nulo")]
        public void TestandoNomeNulo()
        {
            var novoCliente = new Cliente("", true);

            var clienteCreate = new ClienteService();
            var result = clienteCreate.Create(novoCliente);
            
            Assert.Null(result);
        }

        [Fact(DisplayName = "CREATE: Lista de limite de caracteres")]
        public void TestandoLimiteCaracteres()
        {
            var nomeLimite = new NomeAleatorio().nomeAleatorio();
            var clienteNome = new Cliente(nomeLimite, true);
            var clienteService = new ClienteService();

            var result = clienteService.Create(clienteNome);

            Assert.Null(result);
        }
        #endregion

        #region Testando Método Update
        [Fact(DisplayName = "UPDATE: Testando se o nome é nulo ao atualizar")]
        public void testandoNomeNulo()
        {
            var cliente = new Cliente("", true);
            var clienteService = new ClienteService();

            var result = clienteService.Create(cliente);

            Assert.Null(result);
        }
        [Fact(DisplayName = "UPDATE: Testando limite de caracteres ao atualizar um nome")]
        public void testandoLimiteCaracteresNome()
        {
            var id = Guid.NewGuid();
            var nome = new NomeAleatorio().nomeAleatorio();
            var cliente = new Cliente(nome, true);
            var clienteService = new ClienteService();

            var result = clienteService.Update(Convert.ToString(id), cliente);
            Assert.Null(result);
        }

        [Fact(DisplayName = "UPDATE: Testando Id vazio")]
        public void testandoIdVazio()
        {
            var cliente = new Cliente("Rafaela", true);
            var clienteService = new ClienteService();
            var result = clienteService.Update(null, cliente);

            Assert.Null(result);
        }
        #endregion

        #region Testando Método Delete
        [Fact(DisplayName = "DELETE: Verificando se o ID está vazio")]
        public void testandoIdVazioDelete()
        {
            var clienteService = new ClienteService();
            var result = clienteService.Remove(null);

            Assert.Null(result);
        }
        #endregion
    }
}
