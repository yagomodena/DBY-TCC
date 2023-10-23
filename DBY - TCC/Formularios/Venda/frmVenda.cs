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

namespace DBY___TCC.Formularios.Venda
{
    public partial class frmVenda : Form
    {
        public frmVenda()
        {
            InitializeComponent();
            LoadTheme();

            // Adicione as colunas ao DataGridView
            dataGridViewPedido.Columns.Add("ClienteID", "Cliente ID");
            dataGridViewPedido.Columns.Add("NomeDoCliente", "Nome do Cliente");
            dataGridViewPedido.Columns.Add("ProdutoID", "Produto ID");
            dataGridViewPedido.Columns.Add("NomeDoProduto", "Nome do Produto");
            dataGridViewPedido.Columns.Add("Marca", "Marca");
            dataGridViewPedido.Columns.Add("Categoria", "Categoria");
            dataGridViewPedido.Columns.Add("ValorUnitario", "ValorUnitario");
            dataGridViewPedido.Columns.Add("ValorTotal", "ValorTotal");
            dataGridViewPedido.Columns.Add("Quantidade", "Quantidade");
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
            // Obtenha o Cliente ID fornecido pelo usuário
            int clienteID;
            if (int.TryParse(txtClienteID.Text, out clienteID))
            {
                // Realize a consulta no banco de dados para obter o nome do cliente
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
            string nomeDoCliente = ""; // Inicialize com uma string vazia

            // Conecte-se ao banco de dados e execute uma consulta para obter o nome do cliente
            // Substitua isso com a lógica real para acessar seu banco de dados

            // Exemplo fictício:
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
            // Obtenha o Produto ID fornecido pelo usuário
            int produtoID;
            if (int.TryParse(txtProdutoID.Text, out produtoID))
            {
                // Realize a consulta no banco de dados para obter informações do produto
                ProdutoInfo produto = ObterInformacoesDoProduto(produtoID);

                if (produto != null)
                {
                    // Preencha os campos de texto com as informações do produto
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
            ProdutoInfo produto = null; // Inicialize com um valor nulo

            // Conecte-se ao banco de dados e execute uma consulta para obter informações do produto
            // Substitua isso com a lógica real para acessar seu banco de dados

            // Exemplo fictício:
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

        private List<PedidoItem> listaPedido = new List<PedidoItem>(); // Lista para armazenar os produtos no pedido

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            // Obtenha a quantidade de produtos do controle NumericUpDown
            int quantidadeProduto = (int)numericQuantidadeProdutos.Value;


            if (quantidadeProduto > 0)
            {
                // Obtenha as informações do produto (substitua com a lógica real)
                int clienteID = Convert.ToInt32(txtClienteID.Text);
                string nomeDoCliente = txtNomeCliente.Text;
                int produtoID = Convert.ToInt32(txtProdutoID.Text);
                string nomeDoProduto = txtNomeProduto.Text;
                string marca = txtMarca.Text;
                string categoria = txtCategoria.Text;

                decimal valor = Convert.ToDecimal(txtValorProduto.Text);
                // Obtenha a quantidade de produtos do controle NumericUpDown
                int quantidade = (int)numericQuantidadeProdutos.Value;

                decimal valorTotal = valor * quantidade;

                PedidoItem pedidoItem = new PedidoItem
                {
                    ClienteID = clienteID,
                    NomeDoCliente = nomeDoCliente,
                    ProdutoID = produtoID,
                    NomeDoProduto = nomeDoProduto,
                    Marca = marca,
                    Categoria = categoria,
                    Valor = valor, //Valor Unitário
                    ValorTotal = valorTotal, //Valor Total
                    Quantidade = quantidade
                };

                listaPedido.Add(pedidoItem);

                AtualizarDataGridViewPedido();

                AtualizarValorTotalCompra();

                LimparCampos();
            }
            else
            {
                MessageBox.Show("Informe uma quantidade válida para o produto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Obtenha o valor total a receber da compra (já calculado)
            decimal valorTotalAReceber = CalcularValorTotalDaVenda();
        }

        private decimal CalcularValorTotalDaVenda()
        {
            decimal valorTotalCompra = 0.0m;

            // Percorra as linhas da DataGridView e some os valores totais de cada item
            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                decimal valorTotalItem = Convert.ToDecimal(row.Cells["ValorTotal"].Value);
                valorTotalCompra += valorTotalItem;
            }

            return valorTotalCompra;
        }

        private void AtualizarDataGridViewPedido()
        {
            // Limpe as linhas existentes no DataGridView
            dataGridViewPedido.Rows.Clear();

            // Adicione os produtos do pedido como novas linhas no DataGridView
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

        private void LimparCampos()
        {
            // Limpe os campos ou redefina-os conforme necessário
            txtProdutoID.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            numericQuantidadeProdutos.Value = 0; // Defina o valor padrão
        }

        private void AtualizarValorTotalCompra()
        {
            decimal valorTotalCompra = 0.0m;

            // Percorra as linhas da DataGridView e some os valores totais de cada item
            foreach (DataGridViewRow row in dataGridViewPedido.Rows)
            {
                decimal valorTotalItem = Convert.ToDecimal(row.Cells["ValorTotal"].Value);
                valorTotalCompra += valorTotalItem;
            }

            // Atualize a Label com o valor total da compra
            txtTotalReceber.Text = "R$ " + valorTotalCompra.ToString();
        }

        private void txtTotalPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Calcula o troco quando a tecla "Enter" é pressionada
                CalcularTroco();
            }
        }

        private void CalcularTroco()
        {
            // Obtenha o valor total a receber da compra (já calculado)
            decimal valorTotalAReceber = CalcularValorTotalDaVenda();

            if (decimal.TryParse(txtTotalPago.Text, out decimal valorPago))
            {

                txtTotalReceber.Text = $" {valorTotalAReceber:C}"; // Formate como moeda com "R$"
                txtTotalPago.Text = $" {valorPago:C}"; // Formate como moeda com "R$"

                // Calcule o troco
                decimal troco = valorPago - valorTotalAReceber;

                if (troco >= 0)
                {
                    // Exiba o troco na TextBox de troco
                    txtTroco.Text = troco.ToString("C"); // Formatando como moeda
                }
            }
            else
            {
                txtTroco.Text = string.Empty; // Limpe o TextBox de troco se o valor pago for inválido
            }
        }

        private void dataGridViewPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            for (int i = 0; i < dataGridViewPedido.Columns.Count; i++)
            {
                if (i != 8) // Índice 8 é a coluna da quantidade, que é editável
                {
                    dataGridViewPedido.Columns[i].ReadOnly = true;
                }
            }
            // Certifique-se de que a coluna editada seja a coluna da quantidade de produto
            if (e.ColumnIndex == 8)
            {
                // Obtenha a quantidade editada da célula
                int novaQuantidade;
                if (int.TryParse(dataGridViewPedido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out novaQuantidade))
                {
                    // Faça o cálculo do novo valor total (preço unitário * nova quantidade)
                    decimal precoUnitario = Convert.ToDecimal(dataGridViewPedido.Rows[e.RowIndex].Cells[6].Value);
                    decimal novoValorTotal = precoUnitario * novaQuantidade;

                    // Atualize a célula do valor total com o novo valor formatado como moeda
                    dataGridViewPedido.Rows[e.RowIndex].Cells[7].Value = $"{novoValorTotal:C}";

                    // Atualize a célula da quantidade com a nova quantidade
                    dataGridViewPedido.Rows[e.RowIndex].Cells[8].Value = novaQuantidade;
                }
                else
                {
                    // Se a edição da quantidade for inválida, exiba uma mensagem de erro
                    MessageBox.Show("Quantidade inválida. Digite um valor numérico inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewPedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) // Supondo que a coluna da quantidade seja a coluna de índice 8
            {
                decimal valorTotalCompra = 0;

                foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                {
                    int quantidade = Convert.ToInt32(row.Cells[8].Value); // Supondo que a coluna da quantidade seja a coluna de índice 8
                    decimal valorUnitario = Convert.ToDecimal(row.Cells[6].Value); // Supondo que a coluna do valor unitário seja a coluna de índice 6
                    decimal valorTotal = valorUnitario * quantidade;
                    valorTotalCompra += valorTotal;
                }

                // Atualize a TextBox do Total a Receber com o novo valor total da compra
                txtTotalReceber.Text = $"{valorTotalCompra:C}";
            }
        }
    }
}
