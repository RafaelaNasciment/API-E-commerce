using eCommerce.Models;
using MongoDB.Driver;

namespace eCommerce.Services
{
    public class PedidoService
    {
        private readonly IMongoCollection<Pedido> _pedidos;

        public PedidoService(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pedidos = database.GetCollection<Pedido>(settings.PedidoCollectionName);
        }
        public PedidoService()
        {
        }

        public Pedido Get(string id) =>
            _pedidos.Find<Pedido>(pedido => pedido.Id == id).FirstOrDefault();
    
        public Pedido Create(Pedido pedido)
        {
            if (string.IsNullOrEmpty(pedido.IdProduto) || string.IsNullOrEmpty(pedido.IdCliente))
            {
                return null;
            }
            if(pedido.ValorTotal <= 0)
            {
                return null;
            }
            _pedidos.InsertOne(pedido);
            return pedido;                               
        }
    }
}
