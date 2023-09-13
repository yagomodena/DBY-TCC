using System;

namespace DBY___TCC.Classes
{
    public  class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get;set; } = DateTime.Now;
        public int MarcaId { get; set; }
        public virtual Marcas Marca { get; set; }
    }
}
