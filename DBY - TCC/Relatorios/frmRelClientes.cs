using DBY___TCC.Classes;
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

namespace DBY___TCC.Relatorios
{
    public partial class frmRelClientes : Form
    {
        public frmRelClientes()
        {
            InitializeComponent();
        }

        private void frmRelProdutos_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
        }
    }
}
