namespace eCommerce.RequestApi.ProdutoController
{
    public class AtualizarProdutoRequestApi
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
