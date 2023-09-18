using System;
using System.Collections.Generic;

namespace DBY___TCC.Classes
{
    public class Marcas
    {
        public int MarcaID { get; set; }
        public string Nome { get; set; }

        public Marcas(string nome)
        {
            Nome = nome;
        }
    }
}
