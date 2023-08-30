using System;
using System.Collections.Generic;

namespace DBY___TCC.Classes
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
