namespace DBY___TCC.Formularios.Venda
{
    partial class frmVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVender = new System.Windows.Forms.Button();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericQuantidadeProdutos = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewPedido = new System.Windows.Forms.DataGridView();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorProduto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.txtTotalPago = new System.Windows.Forms.TextBox();
            this.txtTotalReceber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chcEntregarPedido = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidadeProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedido)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnVender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVender.FlatAppearance.BorderSize = 0;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.ForeColor = System.Drawing.Color.White;
            this.btnVender.Location = new System.Drawing.Point(1234, 503);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(144, 44);
            this.btnVender.TabIndex = 8;
            this.btnVender.Text = "VENDER";
            this.btnVender.UseVisualStyleBackColor = false;
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarCliente.FlatAppearance.BorderSize = 0;
            this.btnPesquisarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCliente.Image = global::DBY___TCC.Properties.Resources.lupa__1_;
            this.btnPesquisarCliente.Location = new System.Drawing.Point(216, 53);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(36, 33);
            this.btnPesquisarCliente.TabIndex = 6;
            this.btnPesquisarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            // 
            // txtClienteID
            // 
            this.txtClienteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteID.Location = new System.Drawing.Point(43, 56);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.Size = new System.Drawing.Size(168, 26);
            this.txtClienteID.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Cliente ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nome do cliente";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.Location = new System.Drawing.Point(268, 56);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(511, 26);
            this.txtNomeCliente.TabIndex = 12;
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdutoID.Location = new System.Drawing.Point(43, 118);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.Size = new System.Drawing.Size(168, 26);
            this.txtProdutoID.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Produto ID";
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarProduto.FlatAppearance.BorderSize = 0;
            this.btnPesquisarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarProduto.Image = global::DBY___TCC.Properties.Resources.lupa__1_;
            this.btnPesquisarProduto.Location = new System.Drawing.Point(216, 115);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(36, 33);
            this.btnPesquisarProduto.TabIndex = 15;
            this.btnPesquisarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(268, 118);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(511, 26);
            this.txtNomeProduto.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(264, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nome do produto";
            // 
            // numericQuantidadeProdutos
            // 
            this.numericQuantidadeProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericQuantidadeProdutos.Location = new System.Drawing.Point(268, 237);
            this.numericQuantidadeProdutos.Name = "numericQuantidadeProdutos";
            this.numericQuantidadeProdutos.Size = new System.Drawing.Size(131, 26);
            this.numericQuantidadeProdutos.TabIndex = 18;
            // 
            // dataGridViewPedido
            // 
            this.dataGridViewPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedido.Location = new System.Drawing.Point(43, 293);
            this.dataGridViewPedido.Name = "dataGridViewPedido";
            this.dataGridViewPedido.RowHeadersWidth = 51;
            this.dataGridViewPedido.RowTemplate.Height = 24;
            this.dataGridViewPedido.Size = new System.Drawing.Size(1333, 204);
            this.dataGridViewPedido.TabIndex = 19;
            this.dataGridViewPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPedido_CellEndEdit);
            this.dataGridViewPedido.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPedido_CellValueChanged);
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdicionarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarProduto.FlatAppearance.BorderSize = 0;
            this.btnAdicionarProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarProduto.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarProduto.Location = new System.Drawing.Point(424, 233);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(118, 34);
            this.btnAdicionarProduto.TabIndex = 20;
            this.btnAdicionarProduto.Text = "Adicionar";
            this.btnAdicionarProduto.UseVisualStyleBackColor = false;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(266, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Qtde. de Produto";
            // 
            // txtValorProduto
            // 
            this.txtValorProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorProduto.Location = new System.Drawing.Point(43, 237);
            this.txtValorProduto.Name = "txtValorProduto";
            this.txtValorProduto.Size = new System.Drawing.Size(209, 26);
            this.txtValorProduto.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Valor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(43, 175);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(358, 26);
            this.txtMarca.TabIndex = 25;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(417, 175);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(362, 26);
            this.txtCategoria.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(413, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Categoria";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.txtTroco);
            this.panel1.Controls.Add(this.txtTotalPago);
            this.panel1.Controls.Add(this.txtTotalReceber);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 617);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 65);
            this.panel1.TabIndex = 31;
            // 
            // txtTroco
            // 
            this.txtTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Location = new System.Drawing.Point(1036, 15);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Size = new System.Drawing.Size(266, 36);
            this.txtTroco.TabIndex = 36;
            // 
            // txtTotalPago
            // 
            this.txtTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPago.Location = new System.Drawing.Point(661, 15);
            this.txtTotalPago.Name = "txtTotalPago";
            this.txtTotalPago.Size = new System.Drawing.Size(266, 36);
            this.txtTotalPago.TabIndex = 35;
            this.txtTotalPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTotalPago_KeyDown);
            // 
            // txtTotalReceber
            // 
            this.txtTotalReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReceber.Location = new System.Drawing.Point(228, 15);
            this.txtTotalReceber.Name = "txtTotalReceber";
            this.txtTotalReceber.Size = new System.Drawing.Size(266, 36);
            this.txtTotalReceber.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(943, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 29);
            this.label11.TabIndex = 34;
            this.label11.Text = "Troco";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(510, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 29);
            this.label10.TabIndex = 33;
            this.label10.Text = "Total Pago";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(40, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 29);
            this.label9.TabIndex = 32;
            this.label9.Text = "Total à receber";
            // 
            // chcEntregarPedido
            // 
            this.chcEntregarPedido.AutoSize = true;
            this.chcEntregarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcEntregarPedido.Location = new System.Drawing.Point(558, 238);
            this.chcEntregarPedido.Name = "chcEntregarPedido";
            this.chcEntregarPedido.Size = new System.Drawing.Size(149, 24);
            this.chcEntregarPedido.TabIndex = 32;
            this.chcEntregarPedido.Text = "Entregar pedido";
            this.chcEntregarPedido.UseVisualStyleBackColor = true;
            // 
            // frmVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 682);
            this.Controls.Add(this.chcEntregarPedido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtValorProduto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.dataGridViewPedido);
            this.Controls.Add(this.numericQuantidadeProdutos);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPesquisarProduto);
            this.Controls.Add(this.txtProdutoID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.txtClienteID);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Name = "frmVenda";
            this.Text = "Realizar Venda";
            this.Load += new System.EventHandler(this.frmVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantidadeProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedido)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnPesquisarCliente;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtProdutoID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericQuantidadeProdutos;
        private System.Windows.Forms.DataGridView dataGridViewPedido;
        private System.Windows.Forms.Button btnAdicionarProduto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorProduto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.TextBox txtTotalPago;
        private System.Windows.Forms.TextBox txtTotalReceber;
        private System.Windows.Forms.CheckBox chcEntregarPedido;
    }
}