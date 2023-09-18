using System;

namespace DBY___TCC.Classes
{
    public  class Categoria
    {
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public virtual Marcas Marca { get; set; }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}
