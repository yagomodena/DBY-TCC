using System;
using System.Collections.Generic;

namespace DBY___TCC.Classes
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Marca(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
