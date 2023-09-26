using DBY___TCC.Classes;
using DBY___TCC.Formularios.Produto.Categoria;
using DBY___TCC.Formularios.Produto.Marca;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto
{
    public partial class frmCadProduto : Form
    {

        public frmCadProduto(string connectionString)
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaMarca_Click(object sender, EventArgs e)
        {
            frmCadMarca frmMarca = new frmCadMarca();
            frmMarca.ShowDialog();
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            frmCadCategoria cadastroCategoria = new frmCadCategoria();
            cadastroCategoria.ShowDialog();
        }

        private void frmCadProduto_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT Nome FROM Marcas";

            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand(consulta, conexao);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nome = reader["Nome"].ToString();
                    cmbMarca.Items.Add(nome);
                }
                conexao.Close();
            }
        }
    }
}
