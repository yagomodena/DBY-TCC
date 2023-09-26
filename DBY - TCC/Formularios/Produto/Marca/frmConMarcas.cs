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
        frmCadMarca form;

        public frmConMarcas()
        {
            InitializeComponent();
            //form = new frmCadMarca(this);
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

        private void dgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.ID = dgvMarcas.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.Nome = dgvMarcas.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Realmente deseja excluir este cliente?", "Informação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBMarca.DeletarMarca(dgvMarcas.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Mostrar();
                }
                return;
            }
        }
    }
}
