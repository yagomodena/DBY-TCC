using DBY___TCC.Classes;
using DBY___TCC.Service;
using System;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto.Marca
{
    public partial class frmCadMarca : Form
    {
        private readonly frmConMarcas _conMarcas;
        public string Id, Nome;

        public frmCadMarca(frmConMarcas conMarcas)
        {
            InitializeComponent();
            _conMarcas = conMarcas;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (btnCadastrar.Text == "Cadastrar")
            {
                Marcas marca = new Marcas(txtNomeMarca.Text.Trim());

                DBMarca.CadastrarMarca(marca);
                this.Close();
            }
            else if (btnCadastrar.Text == "Atualizar")
            {
                Marcas marca = new Marcas(txtNomeMarca.Text.Trim());

                DBMarca.EditarMarca(marca, Id);

                this.Close();
            }
            _conMarcas.Mostrar();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        public void EditarMarca()
        {
            label1.Text = "Edição de Cliente";
            btnCadastrar.Text = "Atualizar";

            txtNomeMarca.Text = Nome;
        }
    }
}
