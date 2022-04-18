using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.Models
{
    public class Produto
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; } 

        [BsonElement("Name")]
        public string Nome { get; set; } 

        public string Descricao { get; set; } 

        public decimal Preco { get; set; } 

        public bool Ativo { get; set; } 
    }
}
