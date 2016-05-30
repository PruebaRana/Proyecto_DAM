namespace TestsSGBD
{
    partial class frmConfigurarConector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarConector));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.hpConector = new System.Windows.Forms.HelpProvider();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hpConector.SetHelpString(this.btnAceptar, "Pulse Aceptar, para guardar los datos y salir");
            this.btnAceptar.Location = new System.Drawing.Point(301, 209);
            this.btnAceptar.Name = "btnAceptar";
            this.hpConector.SetShowHelp(this.btnAceptar, true);
            this.btnAceptar.Size = new System.Drawing.Size(89, 34);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAceptar.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hpConector.SetHelpString(this.btnCancelar, "Pulse cancelar para cerrar la ventana sin guardar");
            this.btnCancelar.Location = new System.Drawing.Point(406, 209);
            this.btnCancelar.Name = "btnCancelar";
            this.hpConector.SetShowHelp(this.btnCancelar, true);
            this.btnCancelar.Size = new System.Drawing.Size(89, 34);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hpConector.SetHelpString(this.txtNombre, "Nombre descriptivo para identificar al conector.");
            this.txtNombre.Location = new System.Drawing.Point(15, 33);
            this.txtNombre.Name = "txtNombre";
            this.hpConector.SetShowHelp(this.txtNombre, true);
            this.txtNombre.Size = new System.Drawing.Size(480, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre del conector";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tipo";
            // 
            // txtCadena
            // 
            this.txtCadena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCadena.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hpConector.SetHelpString(this.txtCadena, "La cadena de conexion a la Base de Datos.");
            this.txtCadena.Location = new System.Drawing.Point(15, 143);
            this.txtCadena.Multiline = true;
            this.txtCadena.Name = "txtCadena";
            this.hpConector.SetShowHelp(this.txtCadena, true);
            this.txtCadena.Size = new System.Drawing.Size(480, 52);
            this.txtCadena.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cadena de conexion";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTipo.FormattingEnabled = true;
            this.hpConector.SetHelpString(this.cmbTipo, "Como se realizara la conexion con la base de datos, por ODBC o MySQL");
            this.cmbTipo.Items.AddRange(new object[] {
            "Conector ODBC",
            "Nativo MySQL"});
            this.cmbTipo.Location = new System.Drawing.Point(15, 85);
            this.cmbTipo.Name = "cmbTipo";
            this.hpConector.SetShowHelp(this.cmbTipo, true);
            this.cmbTipo.Size = new System.Drawing.Size(142, 23);
            this.cmbTipo.TabIndex = 14;
            // 
            // btnComprobar
            // 
            this.btnComprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnComprobar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComprobar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnComprobar.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.hpConector.SetHelpString(this.btnComprobar, "Servira para comprobar si se tiene acceso a la BD con dicha cadena de conexion");
            this.btnComprobar.Location = new System.Drawing.Point(149, 209);
            this.btnComprobar.Name = "btnComprobar";
            this.hpConector.SetShowHelp(this.btnComprobar, true);
            this.btnComprobar.Size = new System.Drawing.Size(89, 34);
            this.btnComprobar.TabIndex = 15;
            this.btnComprobar.Text = "Comprobar";
            this.btnComprobar.UseVisualStyleBackColor = false;
            this.btnComprobar.Click += new System.EventHandler(this.btnComprobar_Click);
            // 
            // frmConfigurarConector
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(508, 255);
            this.Controls.Add(this.btnComprobar);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(514, 284);
            this.Name = "frmConfigurarConector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Conector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.HelpProvider hpConector;
        private System.Windows.Forms.Button btnComprobar;
    }
}