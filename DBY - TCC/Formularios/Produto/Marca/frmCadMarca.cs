using DBY___TCC.Classes;
using DBY___TCC.Formularios.Cliente;
using DBY___TCC.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto.Marca
{
    public partial class frmCadMarca : Form
    {
        private readonly frmConMarcas _conMarcas;
        public string ID, Nome;

        public frmCadMarca()
        {
            InitializeComponent();
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
        }
    }
}
