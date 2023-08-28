using DBY___TCC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBY___TCC.Formularios.Cliente
{
    public partial class frmConCliente : Form
    {
        public frmConCliente()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void frmConCliente_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = CorTema.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = CorTema.SecondaryColor;
                }
            }
            //label1.ForeColor = CorTema.SecondaryColor;
            //label2.ForeColor = CorTema.PrimaryColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCadCliente cadastroCliente = new frmCadCliente();
            cadastroCliente.Show();
        }
    }
}
