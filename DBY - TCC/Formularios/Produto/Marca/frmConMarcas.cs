using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto.Marca
{
    public partial class frmConMarcas : Form
    {
        frmCadMarca form;

        public frmConMarcas()
        {
            InitializeComponent();
            LoadTheme();
            //form = new frmCadMarca(this);
        }

        public void Mostrar()
        {
            DBMarca.MostrarMarcas("SELECT * FROM Marcas", dgvMarcas);
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = CorTema.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = CorTema.SecondaryColor;
                }
            }
        }

        private void frmConMarcas_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
                form.Id = dgvMarcas.Rows[e.RowIndex].Cells[1].Value.ToString();
                form.Nome = dgvMarcas.Rows[e.RowIndex].Cells[2].Value.ToString();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string termoPesquisa = textBox1.Text.Trim();

            ((DataTable)dgvMarcas.DataSource).DefaultView.RowFilter = string.Format("Nome LIKE '%{0}%'", termoPesquisa);
        }
    }
}
