using MongoDB.Bson.Serialization.Attributes;
using System;

namespace eCommerce.Models
{
    public class Cliente
    {
        public Cliente(string nome, bool ativo)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Ativo = ativo;
        }
        public string Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
