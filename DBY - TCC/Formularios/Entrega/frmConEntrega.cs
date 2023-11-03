using DBY___TCC.Classes;
using DBY___TCC.Relatorios;
using DBY___TCC.Relatorios.Entrega;
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

namespace DBY___TCC.Formularios.Entrega
{
    public partial class frmConEntrega : Form
    {
        public frmConEntrega()
        {
            InitializeComponent();
        }

        private void frmConEntrega_Load(object sender, EventArgs e)
        {
            LoadTheme();
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

        private void Mostrar()
        {
            DBEntrega.MostrarEntregas("SELECT * FROM Vendas WHERE Entrega = 'SIM'", dataGridView);
        }

        private void frmConEntrega_Shown(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void chcJaEntregues_CheckStateChanged(object sender, EventArgs e)
        {
            if (chcJaEntregues.Checked)
            {
                DBEntrega.MostrarEntregas("SELECT * FROM Vendas WHERE Entrega = 'JÁ ENTREGUE'", dataGridView);
            }
            else
            {
                DBEntrega.MostrarEntregas("SELECT * FROM Vendas WHERE Entrega = 'SIM'", dataGridView);
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex >= 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[rowIndex].Selected = true;

                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    ToolStripMenuItem opcao1 = new ToolStripMenuItem("Já entregue!");
                    opcao1.Click += Opcao1_Click;
                    contextMenu.Items.Add(opcao1);

                    ToolStripMenuItem opcao2 = new ToolStripMenuItem("Excluir da entrega!");
                    opcao2.Click += Opcao2_Click;
                    contextMenu.Items.Add(opcao2);

                    contextMenu.Show(dataGridView, e.Location);
                }
            }
        }

        private void Opcao1_Click(object sender, EventArgs e)
        {
            string cliente = string.Empty;

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                if (selectedRow.Cells["NomeDoCliente"].Value != null)
                {
                    cliente = selectedRow.Cells["NomeDoCliente"].Value.ToString();
                }

                int vendaID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["VendaID"].Value);

                PedidoEntregue(vendaID, "Já Entregue");

                dataGridView.SelectedRows[0].Cells["Entrega"].Value = "Já Entregue";

                MessageBox.Show($"O pedido do {cliente}, nº de pedido: {vendaID}, foi entregue!", "Entrega realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar();
            }
        }

        private void PedidoEntregue(int vendaID, string novoStatus)
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

        private void Opcao2_Click(object sender, EventArgs e)
        {
            if(dataGridView.SelectedRows.Count > 0)
            {
                string cliente = string.Empty;

                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                if (selectedRow.Cells["NomeDoCliente"].Value != null)
                {
                    cliente = selectedRow.Cells["NomeDoCliente"].Value.ToString();
                }

                int vendaID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["VendaID"].Value);

                DialogResult result = MessageBox.Show($"O pedido:{vendaID} do cliente {cliente} realmente não vai ser mais entregue?", "Cancelamento de Entregua", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    EntregaRemovida(vendaID, "NÃO");

                    dataGridView.SelectedRows[0].Cells["Entrega"].Value = "NÃO";

                    MessageBox.Show($"A entrega do {cliente} nº de pedido:{vendaID} não vai ser mais entregue!", "Entrega cancelada!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Mostrar();
                }
            }
        }

        private void EntregaRemovida(int vendaID, string novoStatus)
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

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            var dt = GerarDadosRelatorio();
            using (var frm = new frmRelEntregas(dt))
            {
                frm.ShowDialog();
            }
        }

        private DataTable GerarDadosRelatorio()
        {
            var dt = new DataTable();
            dt.Columns.Add("Venda ID");
            dt.Columns.Add("Nome do Cliente");
            dt.Columns.Add("Produto");
            dt.Columns.Add("Entrega");
            dt.Columns.Add("Valor");

            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                dt.Rows.Add(item.Cells[0].Value.ToString(),
                    item.Cells[2].Value.ToString(),
                    item.Cells[4].Value.ToString(),
                    item.Cells[9].Value.ToString(),
                    item.Cells[10].Value.ToString());
            }

            return dt;
        }
    }
}
