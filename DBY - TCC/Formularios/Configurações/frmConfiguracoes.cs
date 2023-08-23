using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Configurações
{
    public partial class frmConfiguracoes : Form
    {
        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        private void cadastrarNovoUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnNovoNivelAcesso_Click(object sender, EventArgs e)
        {
            frmNovoNivelAcesso novoNivel = new frmNovoNivelAcesso();
            novoNivel.Show();
        }
    }
}
