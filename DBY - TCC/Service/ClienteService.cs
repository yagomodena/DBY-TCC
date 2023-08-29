using DBY___TCC.DAL;
using DBY___TCC.Classes;
using System;
using System.Windows.Forms;

namespace DBY___TCC.Service
{
    public class ClienteService
    {
        private readonly ClienteContext _context;

        public ClienteService(string connectionString)
        {
            _context = new ClienteContext(connectionString);
        }

        public bool CadastrarCliente(Clientes cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o cliente!");
                return false;
            }
        }
    }
}
