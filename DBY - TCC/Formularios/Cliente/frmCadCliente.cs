using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmCadCliente : Form
    {
        private readonly frmConCliente _conCliente;

        public frmCadCliente(frmConCliente conCliente)
        {
            InitializeComponent();
            _conCliente = conCliente;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string CPF = mskCPF.Text;

            //Clientes cliente = new Clientes()
            //{
            //    Nome = txtNome.Text,
            //    CPF = mskCPF.Text,
            //    DataNascimento = dataNascimentoPiker.Value,
            //    Sexo = cmbSexo.SelectedItem.ToString(),
            //    TelefoneResidencial = mskTelRel.Text,
            //    TelefoneCelular = mskTelCel.Text,
            //    Email = txtEmail.Text,
            //    Rua = txtRua.Text,
            //    Bairro = txtBairro.Text,
            //    CEP = txtCEP.Text,
            //    Cidade = txtCidade.Text,
            //    Complemento = txtComplemento.Text,
            //    Numero = txtNumero.Text,
            //    Referencia = txtReferencia.Text,
            //    UF = txtEstado.Text
            //};

            if (ChecarCPF(CPF))
            {
                MessageBox.Show("Já existe um cliente com este CPF!");
            }
            else if (btnCadastrar.Text == "Cadastrar")
            {
                Clientes cliente = new Clientes(txtNome.Text.Trim(),
                    mskCPF.Text.Trim(),
                    DateTime.Parse(dataNascimentoPiker.Text.Trim()),
                    cmbSexo.Text.Trim(),
                    mskTelRel.Text.Trim(),
                    mskTelCel.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtCEP.Text.Trim(),
                    txtRua.Text.Trim(),
                    txtBairro.Text.Trim(),
                    txtComplemento.Text.Trim(),
                    txtCidade.Text.Trim(),
                    txtEstado.Text.Trim(),
                    txtNumero.Text.Trim(),
                    txtReferencia.Text.Trim());

                DBCliente.CadastrarClientes(cliente);

                LimparCampos();
                //Clientes cliente = new Clientes()
                //{
                //    Nome = txtNome.Text,
                //    CPF = mskCPF.Text,
                //    DataNascimento = dataNascimentoPiker.Value,
                //    Sexo = cmbSexo.SelectedItem.ToString(),
                //    TelefoneResidencial = mskTelRel.Text,
                //    TelefoneCelular = mskTelCel.Text,
                //    Email = txtEmail.Text,
                //    Rua = txtRua.Text,
                //    Bairro = txtBairro.Text,
                //    CEP = txtCEP.Text,
                //    Cidade = txtCidade.Text,
                //    Complemento = txtComplemento.Text,
                //    Numero = txtNumero.Text,
                //    Referencia = txtReferencia.Text,
                //    UF = txtEstado.Text
                //};

                //DBCliente.CadastrarClientes(cliente);
                //LimparCampos();

                //using (SqlConnection Conexao = new SqlConnection(ConnectionHelper.ConnectionString))
                //{
                //    Conexao.Open();
                //    string query = @"INSERT INTO tbClientes (Nome, CPF, DataNascimento, Sexo, TelefoneResidencial, TelefoneCelular, Email, CEP, Rua, Numero, Complemento, Bairro, Referencia, Cidade, UF)
                //                 VALUES(@Nome, @CPF, @DataNascimento, @Sexo, @TelRes, @TelCel, @Email, @CEP, @Rua, @Numero, @Complemento, @Bairro, @Referencia, @Cidade, @UF)";

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

                //        int rowsAffected = cmd.ExecuteNonQuery();

                //        if (rowsAffected > 0)
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
            _conCliente.Mostrar();
        }


        private bool ChecarCPF(string CPF)
        {
            using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                conexao.Open();
                string query = "SELECT COUNT(*) FROM Clientes WHERE CPF = @Cpf";
                SqlCommand cmd = new SqlCommand(query, conexao);

                cmd.Parameters.AddWithValue("@Cpf", mskCPF.Text);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = mskCPF.Text = mskTelRel.Text = mskTelCel.Text = txtEmail.Text = txtRua.Text = txtBairro.Text = txtCEP.Text = txtCidade.Text = txtComplemento.Text = txtNumero.Text = txtReferencia.Text = txtEstado.Text = string.Empty;
        }
    }
}
