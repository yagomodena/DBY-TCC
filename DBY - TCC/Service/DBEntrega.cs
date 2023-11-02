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
    public class DBEntrega
    {
        public static void MostrarEntregas(string query, DataGridView dgv)
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

        public void AtualizarStatusEntrega(int vendaID, string novoStatus)
        {
            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();

                string query = "UPDATE Vendas SET Entrega = @NovoStatus WHERE VendaID = @VendaID";

                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@NovoStatus", novoStatus);
                    cmd.Parameters.AddWithValue("@VendaID", vendaID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
