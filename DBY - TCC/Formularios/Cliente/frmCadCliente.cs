using DBY___TCC.Classes;
using System;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmCadCliente : Form
    {

        public frmCadCliente(string connectionString)
        {
            InitializeComponent();
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
                DataNascimento = dataNascimentoPiker.Value,
                Sexo = cmbSexo.SelectedItem.ToString(),
                TelefoneResidencial = mskTelRel.Text,
                TelefoneCelular = mskTelCel.Text,
                Email = txtEmail.Text,
                Rua = txtRua.Text,
                Bairro = txtBairro.Text,
                CEP = txtCEP.Text,
                Cidade = txtCidade.Text,
                Complemento = txtComplemento.Text,
                Numero = txtNumero.Text,
                Referencia = txtReferencia.Text,
                UF = txtEstado.Text
            };
        }        

        private void LimparCamposEndereco()
        {
            txtRua.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }
    }
}
