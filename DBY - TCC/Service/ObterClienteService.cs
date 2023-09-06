using DBY___TCC.Classes;
using DBY___TCC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Service
{
    public class ObterClienteService
    {
        private readonly ClienteContext _context;

        public ObterClienteService(string connectionString)
        {
            _context = new ClienteContext(connectionString);
        }

        public List<Clientes> ObterClientes()
        {
            return _context.Clientes.ToList();
        }
    }
}
