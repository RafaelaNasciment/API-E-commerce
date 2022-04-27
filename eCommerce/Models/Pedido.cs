using MongoDB.Bson.Serialization.Attributes;
using System;

namespace eCommerce.Models
{
    public class Pedido
    {
        public Pedido(string idProduto, string idCliente, decimal valorTotal)
        {
            Id = Guid.NewGuid().ToString();
            IdProduto = idProduto;
            IdCliente = idCliente;
            ValorTotal = valorTotal;
        }

        [BsonId]
        public string Id { get; set; }

        public string IdProduto { get; set; }

        public string IdCliente { get; set; }

        public decimal ValorTotal { get; set; }      
    }
}
