﻿using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmCadCliente : Form
    {
        private readonly frmConCliente _conCliente;
        public string id, nome, CPF, DataNascimento, Sexo, TelefoneResidencial, TelefoneCelular, Email, Rua, Bairro, CEP, Cidade, Complemento, Numero, Referencia, UF;

        public frmCadCliente(frmConCliente conCliente)
        {
            InitializeComponent();
            _conCliente = conCliente;
        }

        public void EditarCliente()
        {
            label1.Text = "Edição de Cliente";
            btnCadastrar.Text = "Atualizar";

            txtNome.Text = nome;
            mskCPF.Text = CPF;
            dataNascimentoPiker.Text = DataNascimento;
            cmbSexo.ValueMember = Sexo;
            mskTelRel.Text = TelefoneResidencial;
            mskTelCel.Text = TelefoneCelular;
            txtEmail.Text = Email;
            txtRua.Text = Rua;
            txtBairro.Text = Bairro;
            txtCEP.Text = CEP;
            txtCidade.Text = Cidade;
            txtComplemento.Text = Complemento;
            txtNumero.Text = Numero;
            txtReferencia.Text = Referencia;
            txtEstado.Text = UF;
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
            }
            else if (btnCadastrar.Text == "Atualizar")
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

                DBCliente.EditarClientes(cliente, id);

                LimparCampos();
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

        public void LimparCampos()
        {
            txtNome.Text = mskCPF.Text = mskTelRel.Text = mskTelCel.Text = txtEmail.Text = txtRua.Text = txtBairro.Text = txtCEP.Text = txtCidade.Text = txtComplemento.Text = txtNumero.Text = txtReferencia.Text = txtEstado.Text = string.Empty;
        }
    }
}
