using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Venda
{
    public partial class frmVenda : Form
    {
        //Variáveis para rastrear os valores
        private decimal totalAReceber = 0m;
        private decimal totalPago = 0m;

        public frmVenda()
        {
            InitializeComponent();
            LoadTheme();

            //dataGridViewPedido.Columns.Add("ClienteID", "Cliente ID");
            //dataGridViewPedido.Columns.Add("NomeDoCliente", "Nome do Cliente");
            //dataGridViewPedido.Columns.Add("ProdutoID", "Produto ID");
            //dataGridViewPedido.Columns.Add("NomeDoProduto", "Nome do Produto");
            //dataGridViewPedido.Columns.Add("Marca", "Marca");
            //dataGridViewPedido.Columns.Add("Categoria", "Categoria");
            //dataGridViewPedido.Columns.Add("ValorUnitario", "ValorUnitario");
            //dataGridViewPedido.Columns.Add("ValorTotal", "ValorTotal");
            //dataGridViewPedido.Columns.Add("Quantidade", "Quantidade");
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
            // Coluna de entrega como CheckBox
            DataGridViewCheckBoxColumn entregaColumn = new DataGridViewCheckBoxColumn();
            entregaColumn.HeaderText = "Entrega";
            entregaColumn.Name = "Entrega";
            dataGridViewPedido.Columns.Add(entregaColumn);
            dataGridViewPedido.Columns.Add("TotalAReceber", "Total a Receber");
            dataGridViewPedido.Columns.Add("TotalPago", "Total Pago");
            dataGridViewPedido.Columns.Add("Troco", "Troco");
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

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            //// Obtém os valores informados pelo usuário
            //int clienteID = Convert.ToInt32(txtClienteID.Text);
            //string nomeDoCliente = txtNomeCliente.Text;
            //int produtoID = Convert.ToInt32(txtProdutoID.Text);
            //string nomeDoProduto = txtNomeProduto.Text;
            //string marcaDoProduto = txtMarca.Text;
            //string categoriaDoProduto = txtCategoria.Text;
            //decimal valorDoProduto = Convert.ToDecimal(txtValorProduto.Text);
            //int quantidadeDeProduto = (int)numericQuantidadeProdutos.Value;
            //bool entrega = chcEntregarPedido.Checked;

            //// Calcula o valor total deste item
            //decimal valorTotalItem = valorDoProduto * quantidadeDeProduto;

            //// Adiciona o item à DataGridView
            //dataGridViewPedido.Rows.Add(clienteID, nomeDoCliente, produtoID, nomeDoProduto, marcaDoProduto, categoriaDoProduto, valorDoProduto, quantidadeDeProduto, entrega, valorTotalItem);

            //// Atualiza o total a receber
            //totalAReceber += valorTotalItem;

            //// Atualiza o TextBox do total a receber
            //txtTotalReceber.Text = totalAReceber.ToString("C");

            //// Limpa os campos para o próximo item
            //LimparCampos();

            //O DE CIMA ADICIONAR COM O GPT

            //ESSE É O NOVO
            // Obtenha as informações do cliente, produto, entrega, total a receber, total pago e troco
            int vendaId = ObtenhaProximoIDVenda();  // Substitua com a lógica para obter o próximo ID de venda
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
            decimal totalPago = Convert.ToDecimal(txtTotalPago.Text);
            decimal troco = CalcularTroco();

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
                totalPago,
                troco
            );

            // Limpe os campos após adicionar o produto
            LimparCampos();

            // Recalcule o valor total da compra
            AtualizarValorTotalCompra();

            //O DE BAIXO JÁ TAVA

            //int quantidadeProduto = (int)numericQuantidadeProdutos.Value;


            //if (quantidadeProduto > 0)
            //{

            //    int clienteID = Convert.ToInt32(txtClienteID.Text);
            //    string nomeDoCliente = txtNomeCliente.Text;
            //    int produtoID = Convert.ToInt32(txtProdutoID.Text);
            //    string nomeDoProduto = txtNomeProduto.Text;
            //    string marca = txtMarca.Text;
            //    string categoria = txtCategoria.Text;

            //    decimal valor = Convert.ToDecimal(txtValorProduto.Text);

            //    int quantidade = (int)numericQuantidadeProdutos.Value;

            //    decimal valorTotal = valor * quantidade;

            //    PedidoItem pedidoItem = new PedidoItem
            //    {
            //        ClienteID = clienteID,
            //        NomeDoCliente = nomeDoCliente,
            //        ProdutoID = produtoID,
            //        NomeDoProduto = nomeDoProduto,
            //        Marca = marca,
            //        Categoria = categoria,
            //        Valor = valor, //Valor Unitário
            //        ValorTotal = valorTotal, //Valor Total
            //        Quantidade = quantidade
            //    };

            //    listaPedido.Add(pedidoItem);

            //    AtualizarDataGridViewPedido();

            //    AtualizarValorTotalCompra();

            //    LimparCampos();
            //}
            //else
            //{
            //    MessageBox.Show("Informe uma quantidade válida para o produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //decimal valorTotalAReceber = CalcularValorTotalDaVenda();
        }

        private int ObtenhaProximoIDVenda()
        {
            // Suponhamos que você tenha um campo no seu banco de dados que mantém o número de vendas realizadas
            // Você pode consultar esse campo e adicionar 1 para obter o próximo ID
            int numeroDeVendas = ConsultarNumeroDeVendasNoBancoDeDados(); // Implemente a função para consultar o banco de dados

            // Adicione 1 ao número de vendas para obter o próximo ID
            int proximoID = numeroDeVendas + 1;

            return proximoID;
        }

        private decimal CalcularTroco()
        {
            decimal totalAReceber = CalcularValorTotalDaVenda();
            decimal totalPago;

            if (decimal.TryParse(txtTotalPago.Text, out totalPago))
            {
                decimal troco = totalPago - totalAReceber;
                return troco;
            }

            // Se a conversão do valor pago falhar, retorne 0 para o troco
            return 0;
        }

        private int ConsultarNumeroDeVendasNoBancoDeDados()
        {
            int numeroDeVendas = 0;

            // Conecte-se ao banco de dados (substitua a ConnectionString pelo seu caminho)
            using (SqlConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                connection.Open();

                // Consulta SQL para obter o número de vendas realizadas
                string query = "SELECT COUNT(*) FROM Vendas"; // Assumindo que "Vendas" é a tabela de vendas

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute o comando SQL e obtenha o número de vendas
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
                if (row.Cells["ValorTotal"].Value != null &&
                    decimal.TryParse(row.Cells["ValorTotal"].Value.ToString(), out decimal valorTotalItem))
                {
                    valorTotal += valorTotalItem;
                }
            }

            return valorTotal;
        }

        private void LimparCampos()
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


        //private decimal CalcularValorTotalDaVenda()
        //{
        //    decimal valorTotal = 0;

        //    foreach (DataGridViewRow row in dataGridViewPedido.Rows)
        //    {
        //        if (row.Cells["ValorTotal"].Value != null)
        //        {
        //            string valorTotalCellValue = row.Cells["ValorTotal"].Value.ToString();
        //            decimal valorTotalItem;

        //            if (decimal.TryParse(valorTotalCellValue, out valorTotalItem))
        //            {
        //                valorTotal += valorTotalItem;
        //            }
        //            else
        //            {
        //                // Trate o erro de formato de valor total conforme necessário
        //            }
        //        }
        //    }

        //    txtTotalReceber.Text = $"{valorTotal:C}";

        //    return valorTotal;
        //}

        private void AtualizarDataGridViewPedido()
        {
            dataGridViewPedido.Rows.Clear();

            foreach (PedidoItem item in listaPedido)
            {
                dataGridViewPedido.Rows.Add(
                    item.ClienteID,
                    item.NomeDoCliente,
                    item.ProdutoID,
                    item.NomeDoProduto,
                    item.Marca,
                    item.Categoria,
                    item.Valor,
                    item.ValorTotal,
                    item.Quantidade
                );
            }
        }

        private void AtualizarValorTotalCompra()
        {
            decimal valorTotalCompra = 0.0m;

            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                decimal valorTotalItem = Convert.ToDecimal(row.Cells["ValorTotal"].Value);
                valorTotalCompra += valorTotalItem;
            }

            txtTotalReceber.Text = "R$ " + valorTotalCompra.ToString();
        }

        //private void txtTotalPago_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        CalcularTroco();
        //        CalcularValorTotalAReceber();
        //    }
        //}

        private void dataGridViewPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i < dataGridViewPedido.Columns.Count; i++)
            {
                if (i != 8)
                {
                    dataGridViewPedido.Columns[i].ReadOnly = true;
                }
            }

            if (e.ColumnIndex == 8)
            {
                int novaQuantidade;
                if (int.TryParse(dataGridViewPedido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out novaQuantidade))
                {
                    decimal precoUnitario = Convert.ToDecimal(dataGridViewPedido.Rows[e.RowIndex].Cells[6].Value);
                    decimal novoValorTotal = precoUnitario * novaQuantidade;

                    dataGridViewPedido.Rows[e.RowIndex].Cells[7].Value = $"{novoValorTotal:C}";

                    dataGridViewPedido.Rows[e.RowIndex].Cells[8].Value = novaQuantidade;
                }
                else
                {
                    MessageBox.Show("Quantidade inválida. Digite um valor numérico inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularValorTotalAReceber()
        {
            decimal valorTotalCompra = 0;

            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                int quantidade = Convert.ToInt32(row.Cells[8].Value);
                decimal valorUnitario = Convert.ToDecimal(row.Cells[6].Value);
                decimal valorTotal = valorUnitario * quantidade;
                valorTotalCompra += valorTotal;
            }

            txtTotalReceber.Text = $"{valorTotalCompra:C}";
        }

        //private void dataGridViewPedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 8)
        //    {
        //        CalcularValorTotalAReceber();

        //        CalcularTroco();
        //    }
        //}

        private void btnVender_Click(object sender, EventArgs e)
        {
            // Verifica se há itens na DataGridView
            if (dataGridViewPedido.Rows.Count > 0)
            {
                // Obtém o valor total pago informado pelo usuário
                totalPago = Convert.ToDecimal(txtTotalPago.Text);

                // Calcula o troco
                decimal troco = totalPago - totalAReceber;

                // Insere a venda no banco de dados
                using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    conexao.Open();

                    foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                    {
                        int clienteId;

                        if (row.Cells["ClienteID"].Value != null && int.TryParse(row.Cells["ClienteID"].Value.ToString(), out clienteId))
                        {
                            int clienteID = Convert.ToInt32(row.Cells["ClienteID"].Value);
                            string nomeDoCliente = row.Cells["NomeDoCliente"].Value.ToString();
                            int produtoID = Convert.ToInt32(row.Cells["ProdutoID"].Value);
                            string nomeDoProduto = row.Cells["NomeDoProduto"].Value.ToString();
                            string marcaDoProduto = row.Cells["MarcaDoProduto"].Value.ToString();
                            string categoriaDoProduto = row.Cells["CategoriaDoProduto"].Value.ToString();
                            decimal valorDoProduto = Convert.ToDecimal(row.Cells["ValorDoProduto"].Value);
                            int quantidadeDeProduto = Convert.ToInt32(row.Cells["QuantidadeDeProduto"].Value);
                            bool entrega = (bool)row.Cells["Entrega"].Value;

                            string query = "INSERT INTO Vendas (ClienteID, NomeDoCliente, ProdutoID, NomeDoProduto, MarcaDoProduto, CategoriaDoProduto, ValorDoProduto, QuantidadeDeProduto, Entrega, TotalAReceber, TotalPago, Troco) " +
                                "VALUES (@ClienteID, @NomeDoCliente, @ProdutoID, @NomeDoProduto, @MarcaDoProduto, @CategoriaDoProduto, @ValorDoProduto, @QuantidadeDeProduto, @Entrega, @TotalAReceber, @TotalPago, @Troco)";

                            using (SqlCommand cmd = new SqlCommand(query, conexao))
                            {
                                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                                cmd.Parameters.AddWithValue("@NomeDoCliente", nomeDoCliente);
                                cmd.Parameters.AddWithValue("@ProdutoID", produtoID);
                                cmd.Parameters.AddWithValue("@NomeDoProduto", nomeDoProduto);
                                cmd.Parameters.AddWithValue("@MarcaDoProduto", marcaDoProduto);
                                cmd.Parameters.AddWithValue("@CategoriaDoProduto", categoriaDoProduto);
                                cmd.Parameters.AddWithValue("@ValorDoProduto", valorDoProduto);
                                cmd.Parameters.AddWithValue("@QuantidadeDeProduto", quantidadeDeProduto);
                                cmd.Parameters.AddWithValue("@Entrega", entrega);
                                cmd.Parameters.AddWithValue("@TotalAReceber", totalAReceber);
                                cmd.Parameters.AddWithValue("@TotalPago", totalPago);
                                cmd.Parameters.AddWithValue("@Troco", troco);

                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                }

                // Limpa a DataGridView e outros campos
                dataGridViewPedido.Rows.Clear();
                LimparCampos();

                // Limpa as variáveis de rastreamento
                totalAReceber = 0m;
                totalPago = 0m;

                // Atualiza o TextBox do total a receber
                txtTotalReceber.Text = "R$ 0.00";

                // Exibe o troco
                txtTroco.Text = troco.ToString("C");
            }
            else
            {
                MessageBox.Show("Nenhum item na venda. Adicione itens primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
