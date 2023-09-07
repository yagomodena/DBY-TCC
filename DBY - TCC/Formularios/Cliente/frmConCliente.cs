using DBY___TCC.Classes;
using DBY___TCC.Service;
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

        frmCadCliente form;

        public frmConCliente()
        {
            InitializeComponent();
            LoadTheme();
            //DBCliente.MostrarClientes("SELECT * FROM Clientes", dataGridView);
            form = new frmCadCliente(this);
        }

        public void Mostrar()
        {
            DBCliente.MostrarClientes("SELECT * FROM Clientes", dataGridView);
        }

        private void frmConCliente_Load(object sender, EventArgs e)
        {
            LoadTheme();
            SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString);
            DBCliente.MostrarClientes("SELECT * FROM Clientes", dataGridView);

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
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", conexao);
            ////faz a ponte entre o objeto dataset e a fonte de dados - cria um adapter para preencer um dataset
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            ////define um objeto dataset que guardará na memória os dados obtidos da fonte de dados
            //DataSet ds = new DataSet();
            ////estrutura um objeto dataset que guardará na memória os dados obtidos da fonte de dados
            //DataTable clientes = new DataTable();
            ////recupera os dados da fonte de dados usando a instrução sql
            //da.Fill(clientes);
            ////obter ou define a fonte de dados que será exibida no datagridview
            //dataGridView.DataSource = clientes;
            //configuraDataGridView();
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
            form.LimparCampos();
            form.ShowDialog();
        }

        //public void configuraDataGridView()
        //{
        //    //Nome das colunas
        //    dataGridView.Columns[0].HeaderText = "ID";
        //    dataGridView.Columns[1].HeaderText = "Nome";
        //    dataGridView.Columns[2].HeaderText = "CPF";
        //    dataGridView.Columns[3].HeaderText = "Data Nascimento";
        //    dataGridView.Columns[4].HeaderText = "Sexo";
        //    dataGridView.Columns[5].HeaderText = "Tel. Residencial";
        //    dataGridView.Columns[6].HeaderText = "Celular";
        //    dataGridView.Columns[7].HeaderText = "Email";
        //    dataGridView.Columns[8].HeaderText = "CEP";
        //    dataGridView.Columns[9].HeaderText = "Rua";
        //    dataGridView.Columns[10].HeaderText = "Numero";
        //    dataGridView.Columns[11].HeaderText = "Complemento";
        //    dataGridView.Columns[12].HeaderText = "Bairro";
        //    dataGridView.Columns[13].HeaderText = "Referencia";
        //    dataGridView.Columns[14].HeaderText = "Cidade";
        //    dataGridView.Columns[15].HeaderText = "UF";

        //    //Tamanho das colunas
        //    dataGridView.Columns[0].Width = 50;
        //    dataGridView.Columns[1].Width = 250;
        //    dataGridView.Columns[2].Width = 100;
        //    dataGridView.Columns[3].Width = 100;
        //    dataGridView.Columns[4].Width = 70;
        //    dataGridView.Columns[5].Width = 100;
        //    dataGridView.Columns[6].Width = 100;
        //    dataGridView.Columns[7].Width = 200;
        //    dataGridView.Columns[8].Width = 80;
        //    dataGridView.Columns[9].Width = 150;
        //    dataGridView.Columns[10].Width = 80;
        //    dataGridView.Columns[11].Width = 80;
        //    dataGridView.Columns[12].Width = 100;
        //    dataGridView.Columns[13].Width = 100;
        //    dataGridView.Columns[14].Width = 100;
        //    dataGridView.Columns[15].Width = 40;
        //}

        private void txtPesquisa_TextChanged_1(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisa.Text.Trim();

            ((DataTable)dataGridView.DataSource).DefaultView.RowFilter = string.Format("Nome LIKE '%{0}%'", termoPesquisa);
        }

        private void frmConCliente_Shown(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                form.LimparCampos();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.nome = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.CPF = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.DataNascimento = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.Sexo = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.TelefoneResidencial = dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                form.TelefoneCelular = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                form.Email = dataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                form.CEP = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                form.Rua = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                form.Numero = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
                form.Complemento = dataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
                form.Bairro = dataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();
                form.Referencia = dataGridView.Rows[e.RowIndex].Cells[15].Value.ToString();
                form.Cidade = dataGridView.Rows[e.RowIndex].Cells[16].Value.ToString();
                form.UF = dataGridView.Rows[e.RowIndex].Cells[17].Value.ToString();
                form.EditarCliente();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                if(MessageBox.Show("Realmente deseja excluir este cliente?", "Informação", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DBCliente.DeletarCliente(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Mostrar();
                }
                return;
            }
        }
    }
}
