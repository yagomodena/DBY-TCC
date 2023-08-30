﻿using DBY___TCC.Classes;
using DBY___TCC.Formularios.Cliente;
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
    public partial class frmConProduto : Form
    {
        public frmConProduto()
        {
            InitializeComponent();
        }

        private void frmConProduto_Load(object sender, EventArgs e)
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
        }

        private void btnCadastroProduto_Click(object sender, EventArgs e)
        {
            frmCadProduto cadastroProduto = new frmCadProduto(ConnectionHelper.ConnectionString);
            cadastroProduto.Show();
        }
    }
}
