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
        public frmCadProduto(string connectionString)
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaMarca_Click(object sender, EventArgs e)
        {
            frmCadMarca cadastroMarca = new frmCadMarca();
            cadastroMarca.Show();
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            frmCadCategoria cadastroCategoria = new frmCadCategoria();
            cadastroCategoria.Show();
        }
    }
}
