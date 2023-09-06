using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.DAL
{
    public class CategoriaContext : DbContext
    {
        public CategoriaContext() : base(ConnectionHelper.ConnectionString) { }


        public DbSet<Categoria> tbCategoria { get; set; }
        public CategoriaContext (string connectionString) : base(connectionString) { }
    }
}
