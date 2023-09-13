using DBY___TCC.Formularios.Cliente;
using DBY___TCC.Formularios.Produto.Categoria;
using DBY___TCC.Formularios.Produto.Marca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Produto
{
    public partial class frmCadProduto : Form
    {

        frmConMarcas form;

        public frmCadProduto(string connectionString)
        {
            InitializeComponent();
            form = new frmConMarcas(this);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaMarca_Click(object sender, EventArgs e)
        {
            frmCadMarca frmMarca = new frmCadMarca();
            frmMarca.ShowDialog();
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            frmCadCategoria cadastroCategoria = new frmCadCategoria();
            cadastroCategoria.Show();
        }

        private void btnPesquisarMarcas_Click(object sender, EventArgs e)
        {
            form.ShowDialog();
        }
    }
}
