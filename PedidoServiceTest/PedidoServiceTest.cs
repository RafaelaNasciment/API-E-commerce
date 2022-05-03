using eCommerce.Models;
using eCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PedidoServiceTest
{
    #region Testando método Creatw
    public class PedidoServiceTest : PedidoService
    {
        [Fact(DisplayName = "CREATE: Testando IdProduto nulo")]
        public void TestandoIdProdutoNulo()
        {
            var pedido = new Pedido(null, "123", 15m);
            var pedidoService = Create(pedido);

            Assert.Null(pedidoService);
        }

        [Fact(DisplayName = "CREATE: IdCliente nulo")]
        public void TestandoIdClienteNulo()
        {
            var pedido = new Pedido("123", null, 15m);
            var pedidoService = Create(pedido);

            Assert.Null(pedidoService);
        }

        [Fact(DisplayName = "CREATE: Valor zerado")]
        public void TestandoValorZerado()
        {
            var pedido = new Pedido("123", "123", 0m);
            var pedidoService = Create(pedido);

            Assert.Null(pedidoService);
        }
    }

    #endregion
}
