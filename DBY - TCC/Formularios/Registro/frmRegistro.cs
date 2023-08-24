using DBY___TCC.Formularios.Login;
using System;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Registro
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
