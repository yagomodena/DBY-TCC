using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Classes
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string CategoriaId { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }

    }
}
