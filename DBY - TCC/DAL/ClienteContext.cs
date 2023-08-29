using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.DAL
{
    public class ClienteContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }

        public ClienteContext(string connectionString) : base(connectionString) { }
    }
}
