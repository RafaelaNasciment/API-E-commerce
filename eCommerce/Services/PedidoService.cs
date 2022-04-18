using eCommerce.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace eCommerce.Services
{
    public class PedidoService
    {
        private readonly IMongoCollection<Pedido> _pedidos;

        public PedidoService(IProdutoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pedidos = database.GetCollection<Pedido>(settings.PedidoCollectionName);
        }

        //Visualizando pedido por Id
        public List<Pedido> Get() =>
            _pedidos.Find(pedido => true).ToList();

        public Pedido Get(int id) =>
            _pedidos.Find<Pedido>(pedido => pedido.Id == id).FirstOrDefault();

        //Criando um novo pedido
        public Pedido Create(Pedido pedido)
        {
            _pedidos.InsertOne(pedido);
            return pedido;
        }
    }
}
