using DBY___TCC.Classes;
using DBY___TCC.DAL;
using DBY___TCC.Formularios.Login;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Registro
{
    public partial class frmRegistro : Form
    {
        private readonly UsuarioContext _context;

        public frmRegistro()
        {
            InitializeComponent();
            txtLogin.Select();
            _context = new UsuarioContext();
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
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            string confirmaSenha = txtConfirmarSenha.Text;

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmaSenha))
            {
                MessageBox.Show("Informe todos os campos!");
                txtLogin.Select();
            }

            if (senha != confirmaSenha)
            {
                MessageBox.Show("As senhas não coincidem. Por favor, verifique.");
                return;
            }

            bool usuarioJaExistente = _context.tbUsuarios.Any(u => u.Nome == login);

            if (usuarioJaExistente)
            {
                MessageBox.Show("O nome de usuário já está em uso. Por favor, escolha outro.");
                return;
            }

            // Cria um novo usuário e armazena a senha criptografada
            var novoUsuario = new Usuario
            {
                Nome = login,
                Senha = BCrypt.Net.BCrypt.HashPassword(senha), // Criptografa a senha
                DataCadastro = DateTime.Now
            };

            _context.tbUsuarios.Add(novoUsuario);
            
            _context.SaveChanges();

            MessageBox.Show("Usuário registrado com sucesso!");

            // Limpa os campos de entrada após o registro
            txtLogin.Clear();
            txtSenha.Clear();
            txtConfirmarSenha.Clear();

            //else if (ChecarUsuario(login))
            //{
            //    MessageBox.Show("Nome de usuário já existe. Por favor informe outro!");
            //}
            //else
            //{
            //    if (senha == confirmaSenha)
            //    {
            //        if (RegistrarUsuario(login, senha))
            //        {
            //            MessageBox.Show("Usuário cadastrado com sucesso!");
            //            frmLogin login = new frmLogin();
            //            this.Close();
            //            login.Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ocorreu um erro durante o registro!");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("As senhas não coincidem");
            //        txtSenha.Text = "";
            //        txtConfirmarSenha.Text = "";
            //        txtSenha.Select();
            //    }
            //}
        }

        //private bool ChecarUsuario(string usuario)
        //{
        //    using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
        //    {
        //        conexao.Open();
        //        string query = "SELECT COUNT(*) FROM tbUsuarios WHERE USUARIO = @Usuario";
        //        SqlCommand cmd = new SqlCommand(query, conexao);

        //        cmd.Parameters.AddWithValue("@Usuario", usuario);
        //        int count = (int)cmd.ExecuteScalar();
        //        return count > 0;
        //    }
        //}

        //private bool RegistrarUsuario(string usuario, string senha)
        //{
        //    using (SqlConnection conexao = new SqlConnection(ConnectionHelper.ConnectionString))
        //    {
        //        conexao.Open();
        //        string query = "INSERT INTO tbUsuarios (USUARIO, SENHA) VALUES (@Usuario, @Senha)";
        //        SqlCommand cmd = new SqlCommand(query, conexao);
        //        cmd.Parameters.AddWithValue("@Usuario", usuario);
        //        cmd.Parameters.AddWithValue("@Senha", senha);
        //        int linhasAfetadas = cmd.ExecuteNonQuery();
        //        return linhasAfetadas > 0;
        //    }
        //}
    }
}
