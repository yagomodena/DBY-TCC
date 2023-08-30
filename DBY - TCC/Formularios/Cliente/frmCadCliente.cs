using DBY___TCC.Classes;
using DBY___TCC.Service;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmCadCliente : Form
    {
        private readonly ClienteService _clienteService;
        private readonly CepService _cepService = new CepService();

        public frmCadCliente(string connectionString)
        {
            InitializeComponent();
            _clienteService = new ClienteService(connectionString);
            txtCEP.KeyDown += txtCEP_KeyDown;
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
                Situacao = "Ativo",
                SaldoPontos = 0,
                DataCadastro = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now,
                DataUltimaCompra = DateTime.Now
            };

            Endereco endereco = new Endereco()
            {
                Rua = txtRua.Text,
                Bairro = txtBairro.Text,
                CEP = txtCEP.Text,
                Cidade = txtCidade.Text,
                Complemento = txtComplemento.Text,
                Numero = txtNumero.Text,
                Referencia = txtReferencia.Text,
                UF = txtEstado.Text
            };

            if (_clienteService.CadastrarCliente(cliente, endereco))
            {
                MessageBox.Show("Cadastro de cliente realizado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar o cliente!");
            }
        }        

        private void LimparCamposEndereco()
        {
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }

        private async void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string cep = txtCEP.Text.Replace("-", "");

                if (cep.Length >= 1)
                {
                    try
                    {
                        string responseJson = await _cepService.ConsultarCepAsync(cep);
                        var cepResponse = JsonConvert.DeserializeObject<Endereco>(responseJson);

                        if (cepResponse != null)
                        {
                            txtRua.Text = cepResponse.Rua;
                            txtBairro.Text = cepResponse.Bairro;
                            txtCidade.Text = cepResponse.Cidade;
                            txtEstado.Text = cepResponse.UF;
                        }
                        else
                        {
                            LimparCamposEndereco();
                        }
                    }
                    catch (Exception ex)
                    {
                        LimparCamposEndereco();
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
