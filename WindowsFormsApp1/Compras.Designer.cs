namespace WindowsFormsApp1
{
    partial class Compras
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.dataGridViewCompradoClientes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewCalefactores = new System.Windows.Forms.DataGridView();
            this.dataGridViewCarrito = new System.Windows.Forms.DataGridView();
            this.radioButtonElect = new System.Windows.Forms.RadioButton();
            this.radioButtonGas = new System.Windows.Forms.RadioButton();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompradoClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalefactores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COMPRAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CLIENTES";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(43, 55);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(279, 150);
            this.dataGridViewClientes.TabIndex = 2;
            // 
            // dataGridViewCompradoClientes
            // 
            this.dataGridViewCompradoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompradoClientes.Location = new System.Drawing.Point(436, 55);
            this.dataGridViewCompradoClientes.Name = "dataGridViewCompradoClientes";
            this.dataGridViewCompradoClientes.Size = new System.Drawing.Size(334, 150);
            this.dataGridViewCompradoClientes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CALEFACTORES COMPRADOS POR EL CLIENTE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "CALEFACTORES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(437, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "CARRITO";
            // 
            // dataGridViewCalefactores
            // 
            this.dataGridViewCalefactores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalefactores.Location = new System.Drawing.Point(43, 240);
            this.dataGridViewCalefactores.Name = "dataGridViewCalefactores";
            this.dataGridViewCalefactores.Size = new System.Drawing.Size(279, 150);
            this.dataGridViewCalefactores.TabIndex = 7;
            // 
            // dataGridViewCarrito
            // 
            this.dataGridViewCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCarrito.Location = new System.Drawing.Point(436, 240);
            this.dataGridViewCarrito.Name = "dataGridViewCarrito";
            this.dataGridViewCarrito.Size = new System.Drawing.Size(334, 150);
            this.dataGridViewCarrito.TabIndex = 8;
            // 
            // radioButtonElect
            // 
            this.radioButtonElect.AutoSize = true;
            this.radioButtonElect.Location = new System.Drawing.Point(153, 222);
            this.radioButtonElect.Name = "radioButtonElect";
            this.radioButtonElect.Size = new System.Drawing.Size(66, 17);
            this.radioButtonElect.TabIndex = 9;
            this.radioButtonElect.TabStop = true;
            this.radioButtonElect.Text = "Electrico";
            this.radioButtonElect.UseVisualStyleBackColor = true;
            this.radioButtonElect.CheckedChanged += new System.EventHandler(this.radioButtonElect_CheckedChanged);
            // 
            // radioButtonGas
            // 
            this.radioButtonGas.AutoSize = true;
            this.radioButtonGas.Location = new System.Drawing.Point(241, 222);
            this.radioButtonGas.Name = "radioButtonGas";
            this.radioButtonGas.Size = new System.Drawing.Size(44, 17);
            this.radioButtonGas.TabIndex = 10;
            this.radioButtonGas.TabStop = true;
            this.radioButtonGas.Text = "Gas";
            this.radioButtonGas.UseVisualStyleBackColor = true;
            this.radioButtonGas.CheckedChanged += new System.EventHandler(this.radioButtonGas_CheckedChanged);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(43, 406);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(131, 23);
            this.buttonAgregar.TabIndex = 11;
            this.buttonAgregar.Text = "Agregar al Carro";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(436, 406);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(124, 23);
            this.buttonConfirmar.TabIndex = 12;
            this.buttonConfirmar.Text = "Confirmar Compra";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cantidad";
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Location = new System.Drawing.Point(235, 408);
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(87, 20);
            this.textBoxCantidad.TabIndex = 15;
            // 
            // Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonConfirmar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.radioButtonGas);
            this.Controls.Add(this.radioButtonElect);
            this.Controls.Add(this.dataGridViewCarrito);
            this.Controls.Add(this.dataGridViewCalefactores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewCompradoClientes);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Compras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.Compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompradoClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalefactores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.DataGridView dataGridViewCompradoClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewCalefactores;
        private System.Windows.Forms.DataGridView dataGridViewCarrito;
        private System.Windows.Forms.RadioButton radioButtonElect;
        private System.Windows.Forms.RadioButton radioButtonGas;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCantidad;
    }
}