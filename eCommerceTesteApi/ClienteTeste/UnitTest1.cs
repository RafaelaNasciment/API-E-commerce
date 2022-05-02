using Xunit;
using eCommerce.RequestApi.ClienteController;
using eCommerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using eCommerceTesteApi.ClienteTeste;
using eCommerceTesteApi.ProdutoTeste;
using System.Collections.Generic;

namespace eCommerceTesteApi
{
    public class UnitTest1
    {
        [Fact(DisplayName = "Testando se nome Nulo está passando")]
        public void TesteSeNomeNuloEstaPassando()
        {
            //Arrange
            var controlerClienteTeste = new ClienteControllerTeste();
            var cadastroCliente = User;
            var response = controlerClienteTeste.Create(("/api/people", new
            {
                Name = "John Doe",
                ativo = true
            });

            //Act
            var expected = "Favor informar um nome de cliente!";
            var okResult = controlerClienteTeste.Create(cadastroCliente);
            Assert.IsType<BadRequestResult>(okResult);
            Assert.Equal(400, okResult);
            
        }
        public IEnumerable<object> User => new[]
        {
        new[] { new ClienteTest ("Rafaela",  true)},
        new[] { new ClienteTest("Rafaela", true)},
        new[] { new ClienteTest ("Rafaela",  true)},
        new[] { new ClienteTest("Rafaela", true) },
        new[] { new ClienteTest("Rafaela", true) }
        };

    }
}
