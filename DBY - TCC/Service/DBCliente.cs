using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Service
{
    public class DBCliente
    {   

        public static void CadastrarClientes(Clientes cliente)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = @"INSERT INTO Clientes (Nome, CPF, DataNascimento, Sexo, TelefoneResidencial, TelefoneCelular, Email, CEP, Rua, Numero, Complemento, Bairro, Referencia, Cidade, UF)
                                 VALUES(@Nome, @CPF, @DataNascimento, @Sexo, @TelRes, @TelCel, @Email, @CEP, @Rua, @Numero, @Complemento, @Bairro, @Referencia, @Cidade, @UF)";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar).Value = cliente.CPF;
            cmd.Parameters.Add("@DataNascimento", System.Data.SqlDbType.VarChar).Value = cliente.DataNascimento;
            cmd.Parameters.Add("@Sexo", System.Data.SqlDbType.VarChar).Value = cliente.Sexo;
            cmd.Parameters.Add("@TelRes", System.Data.SqlDbType.VarChar).Value = cliente.TelefoneResidencial;
            cmd.Parameters.Add("@TelCel", System.Data.SqlDbType.VarChar).Value = cliente.TelefoneCelular;
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = cliente.Email;
            cmd.Parameters.Add("@CEP", System.Data.SqlDbType.VarChar).Value = cliente.CEP;
            cmd.Parameters.Add("@Rua", System.Data.SqlDbType.VarChar).Value = cliente.Rua;
            cmd.Parameters.Add("@Numero", System.Data.SqlDbType.VarChar).Value = cliente.Numero;
            cmd.Parameters.Add("@Complemento", System.Data.SqlDbType.VarChar).Value = cliente.Complemento;
            cmd.Parameters.Add("@Bairro", System.Data.SqlDbType.VarChar).Value = cliente.Bairro;
            cmd.Parameters.Add("@Referencia", System.Data.SqlDbType.VarChar).Value = cliente.Referencia;
            cmd.Parameters.Add("@Cidade", System.Data.SqlDbType.VarChar).Value = cliente.Cidade;
            cmd.Parameters.Add("@UF", System.Data.SqlDbType.VarChar).Value = cliente.UF;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente cadastrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cliente não cadastrado. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void EditarClientes(Clientes cliente, string id)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = @"UPDATE Clientes SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Sexo = @Sexo, TelefoneResidencial = @TelRes, TelefoneCelular = @TelCel, Email = @Email, CEP = @CEP, Rua = @Rua, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Referencia = @Referencia, Cidade = @Cidade, UF = @UF";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@CPF", System.Data.SqlDbType.VarChar).Value = cliente.CPF;
            cmd.Parameters.Add("@DataNascimento", System.Data.SqlDbType.VarChar).Value = cliente.DataNascimento;
            cmd.Parameters.Add("@Sexo", System.Data.SqlDbType.VarChar).Value = cliente.Sexo;
            cmd.Parameters.Add("@TelRes", System.Data.SqlDbType.VarChar).Value = cliente.TelefoneResidencial;
            cmd.Parameters.Add("@TelCel", System.Data.SqlDbType.VarChar).Value = cliente.TelefoneCelular;
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = cliente.Email;
            cmd.Parameters.Add("@CEP", System.Data.SqlDbType.VarChar).Value = cliente.CEP;
            cmd.Parameters.Add("@Rua", System.Data.SqlDbType.VarChar).Value = cliente.Rua;
            cmd.Parameters.Add("@Numero", System.Data.SqlDbType.VarChar).Value = cliente.Numero;
            cmd.Parameters.Add("@Complemento", System.Data.SqlDbType.VarChar).Value = cliente.Complemento;
            cmd.Parameters.Add("@Bairro", System.Data.SqlDbType.VarChar).Value = cliente.Bairro;
            cmd.Parameters.Add("@Referencia", System.Data.SqlDbType.VarChar).Value = cliente.Referencia;
            cmd.Parameters.Add("@Cidade", System.Data.SqlDbType.VarChar).Value = cliente.Cidade;
            cmd.Parameters.Add("@UF", System.Data.SqlDbType.VarChar).Value = cliente.UF;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente editado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cliente não editado. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void DeletarCliente(string id)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = "DELETE FROM Clientes WHERE ID = @ID";    

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cliente não excluído. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void MostrarClientes(string query, DataGridView dgv)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string sql = query;
            SqlCommand cmd = new SqlCommand(sql, conexao);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            conexao.Close();
        }
    }
}
