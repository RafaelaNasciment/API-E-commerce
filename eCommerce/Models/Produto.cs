using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace eCommerce.Models
{
    public class Produto
    {
        public Produto(string nome, string descricao, decimal preco, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
        [BsonId]        
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public bool Ativo { get; set; }
    }
}
