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

        public Pedido Get(string id) =>
            _pedidos.Find<Pedido>(pedido => pedido.Id == id).FirstOrDefault();
    
        //Criando um novo pedido
        public Pedido Create(Pedido pedido)
        {
            _pedidos.InsertOne(pedido);
            return pedido;                               
        }
    }
}
