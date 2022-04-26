namespace eCommerce
{
    public class EcommerceDatabaseSettings : IEcommerceDatabaseSettings
    {
        public string ProdutoCollectionName {get; set; } 

        public string ClienteCollectionName { get; set; }

        public string PedidoCollectionName { get; set; }

        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; }
    }
}
