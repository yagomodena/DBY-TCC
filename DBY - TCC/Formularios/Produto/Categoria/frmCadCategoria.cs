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

namespace DBY___TCC.Formularios.Produto.Categoria
{
    public partial class frmCadCategoria : Form
    {
        public frmCadCategoria()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadCategoria_Load(object sender, EventArgs e)
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();

                // Obtenha o ID da marca selecionada na ComboBox
                //int marcaID = ((Marcas)cmbMarca.SelectedItem).MarcaID;
                int marcaID = (int)cmbMarca.SelectedValue;

                // SQL para inserir a categoria com a marca associada
                string query = "INSERT INTO Categorias (Nome, Id) VALUES (@NomeCategoria, @MarcaID)";

                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@NomeCategoria", txtNomeCategoria.Text);
                    cmd.Parameters.AddWithValue("@MarcaID", marcaID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
