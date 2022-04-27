namespace eCommerce
{
    public interface IEcommerceDatabaseSettings
    {
        string ProdutoCollectionName { get; set; }

        string ClienteCollectionName { get; set; }

        string PedidoCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
