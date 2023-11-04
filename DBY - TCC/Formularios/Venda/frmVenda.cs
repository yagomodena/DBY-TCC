using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Venda
{
    public partial class frmVenda : Form
    {
        private decimal totalAReceber = 0m;
        private decimal totalPago = 0m;
        private int clienteId;
        private string nomeDoCliente;
        int vendaId;

        public frmVenda()
        {
            InitializeComponent();
            LoadTheme();

            // Adicione as colunas à DataGridView
            dataGridViewPedido.Columns.Add("vendaID", "ID da Venda");
            dataGridViewPedido.Columns.Add("ClienteID", "ID do Cliente");
            dataGridViewPedido.Columns.Add("NomeDoCliente", "Nome do Cliente");
            dataGridViewPedido.Columns.Add("ProdutoID", "ID do Produto");
            dataGridViewPedido.Columns.Add("NomeDoProduto", "Nome do Produto");
            dataGridViewPedido.Columns.Add("MarcaDoProduto", "Marca do Produto");
            dataGridViewPedido.Columns.Add("CategoriaDoProduto", "Categoria do Produto");
            dataGridViewPedido.Columns.Add("ValorDoProduto", "Valor do Produto");
            dataGridViewPedido.Columns.Add("Quantidade", "Quantidade");
            dataGridViewPedido.Columns.Add("Entrega", "Entrega"); // Coluna de entrega como CheckBox

            dataGridViewPedido.Columns.Add("TotalAReceber", "Total a Receber");
            dataGridViewPedido.Columns["TotalAReceber"].Visible = false;

            dataGridViewPedido.Columns.Add("TotalPago", "Total Pago");
            dataGridViewPedido.Columns["TotalPago"].Visible = false;

            dataGridViewPedido.Columns.Add("Troco", "Troco");
            dataGridViewPedido.Columns["Troco"].Visible = false;
            dataGridViewPedido.Columns.Add("DataDaVenda", "Data da Venda");
        }

        private void frmVenda_Load(object sender, EventArgs e)
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

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            int vendaId = ObtenhaProximoIDVenda();
            int clienteId = Convert.ToInt32(txtClienteID.Text);
            string nomeDoCliente = txtNomeCliente.Text;
            int produtoId = Convert.ToInt32(txtProdutoID.Text);
            string nomeDoProduto = txtNomeProduto.Text;
            string marcaDoProduto = txtMarca.Text;
            string categoriaDoProduto = txtCategoria.Text;
            decimal valorDoProduto = Convert.ToDecimal(txtValorProduto.Text);
            int quantidade = Convert.ToInt32(numericQuantidadeProdutos.Value);
            bool entrega = chcEntregarPedido.Checked;
            decimal totalAReceber = CalcularValorTotalDaVenda();
            DateTime dateTime = DateTime.Now.Date;

            // Adicione os valores na DataGridView
            dataGridViewPedido.Rows.Add(
                vendaId,
                clienteId,
                nomeDoCliente,
                produtoId,
                nomeDoProduto,
                marcaDoProduto,
                categoriaDoProduto,
                valorDoProduto,
                quantidade,
                entrega,
                totalAReceber,
                dateTime
            );

            AtualizarValorTotalCompra();
            LimparCampos();
        }       

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTotalReceber.Text))
            {
                MessageBox.Show("Calcule o total a receber antes de finalizar a venda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal totalAReceber = decimal.Parse(txtTotalReceber.Text.Trim(), NumberStyles.Currency);
            decimal valorPago = decimal.Parse(txtTotalPago.Text.Trim(), NumberStyles.Currency);
            decimal troco = valorPago - totalAReceber;

            // Verifica se há itens na DataGridView
            if (dataGridViewPedido.Rows.Count > 0)
            {
                // Insere a venda no banco de dados
                using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    conexao.Open();

                    foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                    {
                        if (row.Cells["ClienteID"].Value != null && int.TryParse(row.Cells["ClienteID"].Value.ToString(), out int clienteID))
                        {
                            int produtoID = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                            string nomeDoCliente = row.Cells["NomeDoCliente"].Value.ToString();
                            string nomeDoProduto = row.Cells["NomeDoProduto"].Value.ToString();
                            string marcaDoProduto = row.Cells["MarcaDoProduto"].Value.ToString();
                            string categoriaDoProduto = row.Cells["CategoriaDoProduto"].Value.ToString();
                            decimal valorDoProduto = Convert.ToDecimal(row.Cells["ValorDoProduto"].Value);
                            int quantidadeDeProduto = Convert.ToInt32(row.Cells["Quantidade"].Value);
                            bool entrega = (bool)row.Cells["Entrega"].Value;
                            DateTime dateTime = DateTime.Now.Date;

                            string entregaValue = entrega ? "SIM" : "NÃO"; // Converte a variável entrega em "SIM" ou "NÃO"

                            string query = "INSERT INTO Vendas (ClienteID, [Nome Do Cliente], ProdutoID, [Nome Do Produto], [Marca Do Produto], [Categoria Do Produto], [Valor Do Produto], [Quantidade De Produto], Entrega, [Total a Receber], [Total Pago], Troco, [Data da Venda]) " +
                                "VALUES (@ClienteID, @NomeDoCliente, @ProdutoID, @NomeDoProduto, @MarcaDoProduto, @CategoriaDoProduto, @ValorDoProduto, @QuantidadeDeProduto, @Entrega, @TotalAReceber, @TotalPago, @Troco, @Data)";

                            using (SqlCommand cmd = new SqlCommand(query, conexao))
                            {
                                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                                cmd.Parameters.AddWithValue("@NomeDoCliente", nomeDoCliente); // Adicione a definição do parâmetro
                                cmd.Parameters.AddWithValue("@ProdutoID", produtoID);
                                cmd.Parameters.AddWithValue("@NomeDoProduto", nomeDoProduto);
                                cmd.Parameters.AddWithValue("@MarcaDoProduto", marcaDoProduto);
                                cmd.Parameters.AddWithValue("@CategoriaDoProduto", categoriaDoProduto);
                                cmd.Parameters.AddWithValue("@ValorDoProduto", valorDoProduto);
                                cmd.Parameters.AddWithValue("@QuantidadeDeProduto", quantidadeDeProduto);
                                cmd.Parameters.AddWithValue("@Entrega", entregaValue);
                                cmd.Parameters.AddWithValue("@TotalAReceber", totalAReceber);
                                cmd.Parameters.AddWithValue("@TotalPago", valorPago);
                                cmd.Parameters.AddWithValue("@Troco", troco);
                                cmd.Parameters.AddWithValue("@Data", dateTime);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                // Agora que os valores foram inseridos no banco, você pode atualizar o DataGridView com os valores calculados
                dataGridViewPedido.Columns["TotalAReceber"].Visible = true;
                dataGridViewPedido.Columns["TotalPago"].Visible = true;
                dataGridViewPedido.Columns["Troco"].Visible = true;

                // Preencher as colunas no DataGridView
                dataGridViewPedido.Rows[0].Cells["TotalAReceber"].Value = totalAReceber;
                dataGridViewPedido.Rows[0].Cells["TotalPago"].Value = valorPago;
                dataGridViewPedido.Rows[0].Cells["Troco"].Value = troco;

                // Limpar a DataGridView e outros campos
                dataGridViewPedido.Rows.Clear();
                LimparCamposVenda();

                // Limpar as variáveis de rastreamento
                totalAReceber = 0m;
                totalPago = 0m;

                // Atualizar o TextBox do total a receber
                txtTotalReceber.Text = "R$ 0.00";

                // Exibir o troco
                txtTroco.Text = troco.ToString("C");
            }
            else
            {
                MessageBox.Show("Nenhum item na venda. Adicione itens primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Eventos

        private void LimparCampos()
        {
            // Limpe os campos ou redefina-os conforme necessário
            txtProdutoID.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            numericQuantidadeProdutos.Value = 0; // Defina o valor padrão
            chcEntregarPedido.Checked = false; // Desmarque a caixa de seleção de entrega
            txtTotalPago.Text = string.Empty;
            txtTroco.Text = string.Empty;
        }

        private void LimparCamposVenda()
        {
            // Limpe os campos ou redefina-os conforme necessário
            txtClienteID.Text = string.Empty;
            txtNomeCliente.Text = string.Empty;
            txtProdutoID.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            numericQuantidadeProdutos.Value = 0; // Defina o valor padrão
            chcEntregarPedido.Checked = false; // Desmarque a caixa de seleção de entrega
            txtTotalPago.Text = string.Empty;
            txtTroco.Text = string.Empty;
        }

        #endregion Eventos

        #region Calculos

        private int ObtenhaProximoIDVenda()
        {
            int numeroDeVendas = ConsultarNumeroDeVendasNoBancoDeDados();

            int proximoID = numeroDeVendas + 1;

            return proximoID;
        }

        private int ConsultarNumeroDeVendasNoBancoDeDados()
        {
            int numeroDeVendas = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Vendas";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    numeroDeVendas = (int)command.ExecuteScalar();
                }
            }

            return numeroDeVendas;
        }

        private decimal CalcularValorTotalDaVenda()
        {
            decimal valorTotal = 0;

            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                // Verifique se a célula não é nula e se o valor é um decimal válido
                if (row.Cells["TotalAReceber"].Value != null &&
                    decimal.TryParse(row.Cells["TotalAReceber"].Value.ToString(), out decimal valorTotalItem))
                {
                    valorTotal += valorTotalItem;
                }
            }

            return valorTotal;
        }

        private void btnCalcularTotalPago_Click(object sender, EventArgs e)
        {
            decimal valorTotalCompra = CalcularValorTotalDaVenda();

            if (decimal.TryParse(txtTotalPago.Text, out decimal valorPago))
            {
                if (valorPago >= valorTotalCompra)
                {
                    decimal troco = valorPago - valorTotalCompra;
                    txtTroco.Text = $"R$ {troco:F2}";
                }
                else
                {
                    MessageBox.Show("O valor pago é insuficiente. Verifique o valor pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Informe um valor de pagamento válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizarValorTotalCompra()
        {
            decimal valorTotalCompra = 0.0m;

            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                decimal valorDoProduto = Convert.ToDecimal(row.Cells["ValorDoProduto"].Value);
                int quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                decimal valorTotalItem = valorDoProduto * quantidade;
                row.Cells["TotalAReceber"].Value = valorTotalItem;
                valorTotalCompra += valorTotalItem;
            }

            txtTotalReceber.Text = valorTotalCompra.ToString("C");
        }

        private void dataGridViewPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPedido.Columns["Quantidade"].Index ||
                e.ColumnIndex == dataGridViewPedido.Columns["ValorDoProduto"].Index)
            {
                AtualizarValorTotalCompra();
            }
        }

        #endregion Calculos        

        #region Informações de Cliente/Pedido/Produto
        private class ProdutoInfo
        {
            public string NomeDoProduto { get; set; }
            public decimal PrecoDeCusto { get; set; }
            public decimal PrecoDeVenda { get; set; }
            public string Marca { get; set; }
            public string Categoria { get; set; }
        }

        public class PedidoItem
        {
            public int ClienteID { get; set; }
            public string NomeDoCliente { get; set; }
            public int ProdutoID { get; set; }
            public string NomeDoProduto { get; set; }
            public string Marca { get; set; }
            public string Categoria { get; set; }
            public decimal Valor { get; set; }
            public decimal ValorTotal { get; set; }
            public int Quantidade { get; set; }
        }

        private List<PedidoItem> listaPedido = new List<PedidoItem>();

        private ProdutoInfo ObterInformacoesDoProduto(int produtoID)
        {
            ProdutoInfo produto = null;

            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();
                string query = "SELECT NomeDoProduto, PrecoDeCusto, PrecoDeVenda, Marca, Categoria FROM Produtos WHERE ID = @ProdutoID";
                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@ProdutoID", produtoID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new ProdutoInfo
                            {
                                NomeDoProduto = reader["NomeDoProduto"].ToString(),
                                PrecoDeCusto = (decimal)reader["PrecoDeCusto"],
                                PrecoDeVenda = (decimal)reader["PrecoDeVenda"],
                                Marca = reader["Marca"].ToString(),
                                Categoria = reader["Categoria"].ToString()
                            };
                        }
                    }
                }
            }

            return produto;
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            int produtoID;
            if (int.TryParse(txtProdutoID.Text, out produtoID))
            {
                ProdutoInfo produto = ObterInformacoesDoProduto(produtoID);

                if (produto != null)
                {
                    txtNomeProduto.Text = produto.NomeDoProduto;
                    txtValorProduto.Text = produto.PrecoDeVenda.ToString("0.00");
                    txtMarca.Text = produto.Marca;
                    txtCategoria.Text = produto.Categoria;
                }
                else
                {
                    MessageBox.Show("Produto não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Informe um Produto ID válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ObterNomeDoCliente(int clienteID)
        {
            string nomeDoCliente = "";

            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();
                string query = "SELECT Nome FROM Clientes WHERE ID = @ClienteID";
                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                    nomeDoCliente = (string)cmd.ExecuteScalar();
                }
            }

            return nomeDoCliente;
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            int clienteID;
            if (int.TryParse(txtClienteID.Text, out clienteID))
            {
                string nomeDoCliente = ObterNomeDoCliente(clienteID);

                if (!string.IsNullOrEmpty(nomeDoCliente))
                {
                    txtNomeCliente.Text = nomeDoCliente;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Informe um Cliente ID válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion Informações de Cliente/Pedido/Produto

    }
}
