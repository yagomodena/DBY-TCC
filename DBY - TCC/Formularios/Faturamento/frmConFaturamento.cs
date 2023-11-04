using DBY___TCC.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Faturamento
{
    public partial class frmConFaturamento : Form
    {
        public frmConFaturamento()
        {
            InitializeComponent();

            dateTimePickerInicial.Format = DateTimePickerFormat.Custom;
            dateTimePickerInicial.CustomFormat = "dd/MM/yyyy";

            dateTimePickerFinal.Format = DateTimePickerFormat.Custom;
            dateTimePickerFinal.CustomFormat = "dd/MM/yyyy";
        }

        private void frmConFaturamento_Load(object sender, EventArgs e)
        {
            LoadTheme();

            dateTimePickerInicial.Value = DateTime.Today;
            dateTimePickerFinal.Value = DateTime.Today;

            FiltrarVendasPorData();

            decimal somaTotalReceber = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Total a Receber"].Value != null &&
                    decimal.TryParse(row.Cells["Total a Receber"].Value.ToString(), out decimal totalReceber))
                {
                    somaTotalReceber += totalReceber;
                }
            }

            labelSomaTotalReceber.Text = $"Soma Total a Receber: R$ {somaTotalReceber:F2}";
        }

        private void FiltrarVendasPorData()
        {
            DateTime dataInicial = dateTimePickerInicial.Value;
            DateTime dataFinal = dateTimePickerFinal.Value;

            string query = "SELECT VendaID, ClienteID, [Nome do Cliente], ProdutoID, [Nome do Produto], [Marca do Produto], [Categoria do Produto], " +
                "[Valor do Produto], [Quantidade de Produto], [Total a Receber], [Total Pago], Troco, [Data da Venda] " +
                "FROM Vendas WHERE [Data da Venda] BETWEEN @DataInicial AND @DataFinal";

            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
                    cmd.Parameters.AddWithValue("@DataFinal", dataFinal);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;
                    }
                }
            }
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime dataInicial = dateTimePickerInicial.Value;
            DateTime dataFinal = dateTimePickerFinal.Value;

            if (dataFinal < dataInicial)
            {
                MessageBox.Show("A data final não pode ser anterior à data inicial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT VendaID, ClienteID, [Nome do Cliente], ProdutoID, [Nome do Produto], [Marca do Produto], [Categoria do Produto]," +
                "[Valor do Produto], [Quantidade de Produto], [Total a Receber], [Total Pago], Troco, [Data da Venda] " +
                "FROM Vendas WHERE [Data da Venda] >= @DataInicial AND [Data da Venda] <= @DataFinal";

            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();

                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@DataInicial", dataInicial);
                    cmd.Parameters.AddWithValue("@DataFinal", dataFinal);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;
                    }
                }
            }

            decimal somaTotalReceber = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Total a Receber"].Value != null &&
                    decimal.TryParse(row.Cells["Total a Receber"].Value.ToString(), out decimal totalReceber))
                {
                    somaTotalReceber += totalReceber;
                }
            }

            labelSomaTotalReceber.Text = $"Faturamento Total: R$ {somaTotalReceber:F2}";
        }
    }
}
