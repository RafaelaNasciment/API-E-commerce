namespace eCommerce.Models
{
    public class ProdutoDatabaseSettings : IProdutoDatabaseSettings
    {
        public string ProdutoCollectionName {get; set; } 

        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; }
    }

    public interface IProdutoDatabaseSettings
    {
        string ProdutoCollectionName { get; set; } 

        string ConnectionString { get; set; } 

        string DatabaseName { get; set; } 
    }
}
