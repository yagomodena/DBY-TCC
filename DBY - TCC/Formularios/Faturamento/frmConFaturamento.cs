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

            // Defina as datas dos DateTimePickers para o dia atual
            dateTimePickerInicial.Value = DateTime.Today;
            dateTimePickerFinal.Value = DateTime.Today;

            // Chame o método de filtragem para carregar as vendas do dia atual
            FiltrarVendasPorData();
        }

        private void FiltrarVendasPorData()
        {
            // Recupere as datas selecionadas nos DateTimePickers
            DateTime dataInicial = dateTimePickerInicial.Value;
            DateTime dataFinal = dateTimePickerFinal.Value;

            // Consulta SQL para buscar vendas no intervalo de datas
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

                        // Preencha o DataGridView com os resultados da consulta
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

            // Certifique-se de que a data final seja maior ou igual à data inicial
            if (dataFinal < dataInicial)
            {
                MessageBox.Show("A data final não pode ser anterior à data inicial.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agora você pode usar as datas dataInicial e dataFinal para filtrar as vendas no banco de dados
            // Consulte o banco de dados e exiba as vendas no seu controle (por exemplo, uma DataGridView)

            // Exemplo de consulta SQL (substitua pelo seu próprio banco de dados):
            string query = "SELECT * FROM Vendas WHERE [Data da Venda] >= @DataInicial AND [Data da Venda] <= @DataFinal";

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

                        // Preencha o DataGridView com os resultados da consulta
                        dataGridView.DataSource = dt;
                    }
                }
            }
        }
    }
}
