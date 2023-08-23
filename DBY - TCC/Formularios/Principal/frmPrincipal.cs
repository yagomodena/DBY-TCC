using DBY___TCC.Formularios.Configurações;
using DBY___TCC.Formularios.Login;
using DBY___TCC.Formularios.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Principal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnEncerrarAcesso_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            frmConfiguracoes configuracoes = new frmConfiguracoes();
            configuracoes.Show();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            frmConfiguracoes configuracoes = new frmConfiguracoes();
            configuracoes.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmConfiguracoes configuracoes = new frmConfiguracoes();
            configuracoes.Show();
        }
    }
}
