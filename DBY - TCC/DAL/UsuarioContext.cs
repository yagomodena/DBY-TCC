using DBY___TCC.Classes;
using System.Data.Entity;

namespace DBY___TCC.DAL
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> tbUsuarios { get; set; }

        public UsuarioContext() : base(ConnectionHelper.ConnectionString) { }
    }
}
