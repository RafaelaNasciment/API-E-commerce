namespace eCommerce.Models
{
    public class ProdutoDatabaseSettings : IProdutoDatabaseSettings
    {
        public string ProdutoCollectionName {get; set; } 

        public string ClienteCollectionName { get; set; }

        public string PedidoCollectionName { get; set; }

        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; }
    }

    public interface IProdutoDatabaseSettings
    {
        string ProdutoCollectionName { get; set; } 

        string ClienteCollectionName { get; set; }

        string PedidoCollectionName { get; set; }

        string ConnectionString { get; set; } 

        string DatabaseName { get; set; } 
    }
}
