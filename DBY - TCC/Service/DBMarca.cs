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
    public class DBMarca
    {
        public static void CadastrarMarca(Marcas marca)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = @"INSERT INTO Marcas (Nome) VALUES (@Nome)";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = marca.Nome;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca cadastrada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Marca não cadastrada. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void EditarMarca(Marcas marca, string id)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = @"UPDATE Marcas SET Nome = @Nome WHERE ID = @ID";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@Nome", System.Data.SqlDbType.VarChar).Value = marca.Nome;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca editada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Marca não editada. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void DeletarMarca(string id)
        {
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            conexao.Open();

            string query = "DELETE FROM Marcas WHERE ID = @ID";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Marca excluída com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Marca não excluída. \n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }

        public static void MostrarMarcas(string query, DataGridView dgv)
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
