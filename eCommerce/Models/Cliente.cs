using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.Models
{
    public class Cliente
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("Name")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
