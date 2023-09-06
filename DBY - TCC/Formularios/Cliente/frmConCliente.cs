using DBY___TCC.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmConCliente : Form
    {
        public frmConCliente()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void frmConCliente_Load(object sender, EventArgs e)
        {
            LoadTheme();
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);

            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha de acesso ao banco de dados.");
                return;
            }
            //define comandos sql
            SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", conexao);
            //faz a ponte entre o objeto dataset e a fonte de dados - cria um adapter para preencer um dataset
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //define um objeto dataset que guardará na memória os dados obtidos da fonte de dados
            DataSet ds = new DataSet();
            //estrutura um objeto dataset que guardará na memória os dados obtidos da fonte de dados
            DataTable clientes = new DataTable();
            //recupera os dados da fonte de dados usando a instrução sql
            da.Fill(clientes);
            //obter ou define a fonte de dados que será exibida no datagridview
            dataGridView.DataSource = clientes;
            configuraDataGridView();
            //atualizaDataGridView("SELECT * FROM Clientes ORDER BY Nome");
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

        private void button7_Click(object sender, EventArgs e)
        {
            frmCadCliente cadastroCliente = new frmCadCliente(this);
            cadastroCliente.Show();
        }

        public void configuraDataGridView()
        {
            //Nome das colunas
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Nome";
            dataGridView.Columns[2].HeaderText = "CPF";
            dataGridView.Columns[3].HeaderText = "Data Nascimento";
            dataGridView.Columns[4].HeaderText = "Sexo";
            dataGridView.Columns[5].HeaderText = "Tel. Residencial";
            dataGridView.Columns[6].HeaderText = "Celular";
            dataGridView.Columns[7].HeaderText = "Email";
            dataGridView.Columns[8].HeaderText = "CEP";
            dataGridView.Columns[9].HeaderText = "Rua";
            dataGridView.Columns[10].HeaderText = "Numero";
            dataGridView.Columns[11].HeaderText = "Complemento";
            dataGridView.Columns[12].HeaderText = "Bairro";
            dataGridView.Columns[13].HeaderText = "Referencia";
            dataGridView.Columns[14].HeaderText = "Cidade";
            dataGridView.Columns[15].HeaderText = "UF";

            //Tamanho das colunas
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 250;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 70;
            dataGridView.Columns[5].Width = 100;
            dataGridView.Columns[6].Width = 100;
            dataGridView.Columns[7].Width = 200;
            dataGridView.Columns[8].Width = 80;
            dataGridView.Columns[9].Width = 150;
            dataGridView.Columns[10].Width = 80;
            dataGridView.Columns[11].Width = 80;
            dataGridView.Columns[12].Width = 100;
            dataGridView.Columns[13].Width = 100;
            dataGridView.Columns[14].Width = 100;
            dataGridView.Columns[15].Width = 40;
        }

        private void txtPesquisa_TextChanged_1(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisa.Text.Trim();

            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Nome LIKE '%{0}%'", termoPesquisa);
        }
    }
}
