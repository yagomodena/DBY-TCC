namespace DBY___TCC.Classes
{
    public class Pedido
    {
        public int ClienteID { get; set; }
        public string NomeDoCliente { get; set; }
        public int ProdutoID { get; set; }
        public string NomeDoProduto { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public int Quantidade { get; set; }
    }
}
