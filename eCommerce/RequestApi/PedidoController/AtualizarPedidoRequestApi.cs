namespace eCommerce.RequestApi.PedidoController
{
    public class AtualizarPedidoRequestApi
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
    }
}
