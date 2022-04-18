using eCommerce.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace eCommerce.Services
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;

        public ClienteService(IProdutoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientes = database.GetCollection<Cliente>(settings.ClienteCollectionName);
        }

        //Vendo todos clientes
        public List<Cliente> Get() =>
            _clientes.Find(cliente => true).ToList();

        public Cliente Get(int id) =>
            _clientes.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();

        //Criando um novo cliente
        public Cliente Create(Cliente cliente)
        {
            _clientes.InsertOne(cliente);
            return cliente;
        }

        //Atualizando um cliente

        public void Update(int id, Cliente clienteIn) =>
            _clientes.ReplaceOne(cliente => cliente.Id == id, clienteIn);

        //Deletando um cliente
        public void Remove(Produto clienteIn) =>
            _clientes.DeleteOne(cliente => cliente.Id == clienteIn.Id);

        public void Remove(int id) =>
            _clientes.DeleteOne(cliente => cliente.Id == id);
    }
}
