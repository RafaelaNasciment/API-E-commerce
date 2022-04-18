using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.Models
{
    public class Pedido
    {
        [BsonId]
        public int Id { get; set; }

        public int Id_produto { get; set; }

        public int Id_cliente { get; set; }

        public decimal ValorTotal { get; set; }


    }
}
