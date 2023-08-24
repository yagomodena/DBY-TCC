using DBY___TCC.Classes;
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
using System.Xml.Serialization;

namespace DBY___TCC.Formularios.Principal
{
    public partial class frmPrincipal : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        public frmPrincipal()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(CorTema.ColorList.Count);
           
            while(tempIndex == index)
            {
               index =  random.Next(CorTema.ColorList.Count);
            }
            tempIndex = index;
            string color = CorTema.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = CorTema.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Venda.frmVenda(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Entrega.frmConEntrega(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Produto.frmConProduto(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Cliente.frmConCliente(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Faturamento.frmConFaturamento(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Estoque.frmConEstoque(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Configurações.frmConfiguracoes(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Formularios.Login.frmLogin(), sender);
        }
    }
}
