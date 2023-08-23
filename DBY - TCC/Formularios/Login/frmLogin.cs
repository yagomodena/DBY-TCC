using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DBY___TCC.Formularios.Principal;
using DBY___TCC.Formularios.Registro;

namespace DBY___TCC.Formularios.Login
{
    public partial class frmLogin : Form
    {

        SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-59265J7\SQLEXPRESS; Initial Catalog=DBYTCC; Integrated Security=true");

        public frmLogin()
        {
            InitializeComponent();
            txtLogin.Select();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.Open();

            string query = "SELECT * FROM tbUsuarios WHERE USUARIO = '" + txtLogin.Text + "' AND SENHA = '" + txtSenha.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                frmPrincipal principal = new frmPrincipal();
                this.Hide();
                principal.Show();
                Conexao.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha incorreto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Select();
                Conexao.Close();
            }
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            this.Hide();
            registro.Show();
        }
    }
}
