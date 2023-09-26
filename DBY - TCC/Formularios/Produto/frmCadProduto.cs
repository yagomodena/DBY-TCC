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
