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

        private void button1_Click(object sender, EventArgs e)
        {
            Relatorios.frmRelClientes form = new Relatorios.frmRelClientes();
            form.Show();
        }
    }
}
