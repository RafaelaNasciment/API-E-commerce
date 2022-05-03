using eCommerce.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace eCommerce.Services
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _clientes;
        public ClienteService(IEcommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientes = database.GetCollection<Cliente>(settings.ClienteCollectionName);
        }

        public ClienteService()
        {
        }
       
        public List<Cliente> Get() =>
            _clientes.Find(cliente => true).ToList();

        public Cliente Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var result = _clientes.Find<Cliente>(cliente => cliente.Id == id).FirstOrDefault();
            return result;
        }

        public Cliente Create(Cliente cliente)
        {
            
            if (String.IsNullOrEmpty(cliente.Nome))
            {               
                return null;
            }
            if(cliente.Nome.Length > 50)
            {
                return null;
            }
            _clientes.InsertOne(cliente);
            return cliente;
        }

        public Cliente Update(string id, Cliente clienteIn)
        {
            if (String.IsNullOrEmpty(id))
            {
                return null;
            }

            if (String.IsNullOrEmpty(clienteIn.Nome))
            {
                return null;
            }

            if (clienteIn.Nome.Length > 50)
            {
                return null;
            }
            _clientes.ReplaceOne(cliente => cliente.Id == id, clienteIn);
            return clienteIn;
        }
        public DeleteResult Remove(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return null;
            }
            var delete = _clientes.DeleteOne(cliente => cliente.Id == id);
            return delete;
        }
         
    }
}
