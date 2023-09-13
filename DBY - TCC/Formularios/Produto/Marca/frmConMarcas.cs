using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto.Marca
{
    public partial class frmConMarcas : Form
    {
        private readonly frmCadProduto _cadProdutos;

        public frmConMarcas(frmCadProduto conProdutos)
        {
            InitializeComponent();
            _cadProdutos = conProdutos;
        }

        public void Mostrar()
        {
            DBMarca.MostrarMarcas("SELECT * FROM Marcas", dgvMarcas);
        }

        private void frmConMarcas_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            Mostrar();

            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha de acesso ao banco de dados.");
                return;
            }
        }

        private void frmConMarcas_Shown(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
