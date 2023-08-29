using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmCadCliente : Form
    {
        private readonly ClienteService _clienteService;

        public frmCadCliente(string connectionString)
        {
            InitializeComponent();
            _clienteService = new ClienteService(connectionString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes()
            {
                Nome = txtNome.Text,
                CPF = mskCPF.Text,
                ClienteFidelidade = cmbFidelidade.SelectedItem.ToString(),
                DataNascimento = dataNascimentoPiker.Value,
                Sexo = cmbSexo.SelectedItem.ToString(),
                TelefoneResidencial = mskTelRel.Text,
                TelefoneCelular = mskTelCel.Text,
                Email = txtEmail.Text,
                CEP = txtCEP.Text,
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Referencia = txtReferencia.Text,
                Cidade = txtCidade.Text,
                UF = "SP", /*cmbUF.SelectedItem.ToString(),*/
                Situacao = "Ativo",
                SaldoPontos = 0,
                DataCadastro = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now,
                DataUltimaCompra = DateTime.Now
            };

            if (_clienteService.CadastrarCliente(cliente))
            {
                MessageBox.Show("Cadastro de cliente realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar o cliente!");
            }

            //using (SqlConnection Conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            //{
            //    Conexao.Open();
            //    string query = @"INSERT INTO tbClientes (Nome, CPF, ClienteFidelidade, DataNascimento, Sexo, TelefoneResidencial, TelefoneCelular, Email, CEP, Rua, Numero, Complemento, Bairro, Referencia, Cidade, UF, Situacao, SaldoPontos, DataCadastro, DataAtualizacao, DataUltimaCompra)
            //                     VALUES(@Nome, @CPF, @ClienteFidelidade, @DataNascimento, @Sexo, @TelRes, @TelCel, @Email, @CEP, @Rua, @Numero, @Complemento, @Bairro, @Referencia, @Cidade, @UF, @Situacao, @SaldoPontos, @DataCadastro, @DataAtualizacao, DataUltimaCompra)";

            //    using (SqlCommand cmd = new SqlCommand(query, Conexao))
            //    {
            //        cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            //        cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
            //        cmd.Parameters.AddWithValue("@ClienteFidelidade", cliente.ClienteFidelidade);
            //        cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
            //        cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
            //        cmd.Parameters.AddWithValue("@TelRes", cliente.TelefoneResidencial);
            //        cmd.Parameters.AddWithValue("@TelCel", cliente.TelefoneCelular);
            //        cmd.Parameters.AddWithValue("@Email", cliente.Email);
            //        cmd.Parameters.AddWithValue("@CEP", cliente.CEP);
            //        cmd.Parameters.AddWithValue("@Rua", cliente.Rua);
            //        cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
            //        cmd.Parameters.AddWithValue("@Complemento", cliente.Complemento);
            //        cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
            //        cmd.Parameters.AddWithValue("@Referencia", cliente.Referencia);
            //        cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            //        cmd.Parameters.AddWithValue("@UF", cliente.UF);
            //        cmd.Parameters.AddWithValue("@Situacao", cliente.Situacao);
            //        cmd.Parameters.AddWithValue("@SaldoPontos", cliente.SaldoPontos);
            //        cmd.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
            //        cmd.Parameters.AddWithValue("@DataAtualizacao", cliente.DataUltimaAtualizacao);
            //        cmd.Parameters.AddWithValue("@DataUltimaCompra", cliente.DataUltimaCompra);

            //        int rowsAffected = cmd.ExecuteNonQuery();

            //        if(rowsAffected > 0)
            //        {
            //            MessageBox.Show("Cadastro de cliente realizado com sucesso!");
            //        }
            //        else
            //        {
            //            MessageBox.Show("Erro ao cadastrar o cliente.");
            //        }
            //    }
            //}


        }
    }
}
