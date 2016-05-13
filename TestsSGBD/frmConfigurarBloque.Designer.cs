namespace TestsSGBD
{
    partial class frmConfigurarBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarBloque));
            this.label2 = new System.Windows.Forms.Label();
            this.txtSentencias = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.udHilosStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.udHilosFin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.udHilosInicio = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSentencia = new System.Windows.Forms.CheckBox();
            this.chkHilo = new System.Windows.Forms.CheckBox();
            this.chkBloque = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAsistente = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosFin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosInicio)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre del bloque";
            // 
            // txtSentencias
            // 
            this.txtSentencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSentencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSentencias.Location = new System.Drawing.Point(15, 83);
            this.txtSentencias.Multiline = true;
            this.txtSentencias.Name = "txtSentencias";
            this.txtSentencias.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSentencias.Size = new System.Drawing.Size(429, 204);
            this.txtSentencias.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Listado de sentencias SQL";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(15, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(561, 23);
            this.txtNombre.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.udHilosStep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.udHilosFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.udHilosInicio);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(457, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 99);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repeticion / hilos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.Location = new System.Drawing.Point(15, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pasos";
            // 
            // udHilosStep
            // 
            this.udHilosStep.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.udHilosStep.Location = new System.Drawing.Point(59, 68);
            this.udHilosStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHilosStep.Name = "udHilosStep";
            this.udHilosStep.Size = new System.Drawing.Size(43, 22);
            this.udHilosStep.TabIndex = 4;
            this.udHilosStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udHilosStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label4.Location = new System.Drawing.Point(15, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fin";
            // 
            // udHilosFin
            // 
            this.udHilosFin.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.udHilosFin.Location = new System.Drawing.Point(59, 45);
            this.udHilosFin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHilosFin.Name = "udHilosFin";
            this.udHilosFin.Size = new System.Drawing.Size(43, 22);
            this.udHilosFin.TabIndex = 2;
            this.udHilosFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udHilosFin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label3.Location = new System.Drawing.Point(15, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Inicio";
            // 
            // udHilosInicio
            // 
            this.udHilosInicio.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.udHilosInicio.Location = new System.Drawing.Point(59, 22);
            this.udHilosInicio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHilosInicio.Name = "udHilosInicio";
            this.udHilosInicio.Size = new System.Drawing.Size(43, 22);
            this.udHilosInicio.TabIndex = 0;
            this.udHilosInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udHilosInicio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkSentencia);
            this.groupBox2.Controls.Add(this.chkHilo);
            this.groupBox2.Controls.Add(this.chkBloque);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(457, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 100);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexiones";
            // 
            // chkSentencia
            // 
            this.chkSentencia.AutoSize = true;
            this.chkSentencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkSentencia.Location = new System.Drawing.Point(19, 70);
            this.chkSentencia.Name = "chkSentencia";
            this.chkSentencia.Size = new System.Drawing.Size(77, 19);
            this.chkSentencia.TabIndex = 2;
            this.chkSentencia.Text = "Sentencia";
            this.chkSentencia.UseVisualStyleBackColor = true;
            // 
            // chkHilo
            // 
            this.chkHilo.AutoSize = true;
            this.chkHilo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkHilo.Location = new System.Drawing.Point(19, 47);
            this.chkHilo.Name = "chkHilo";
            this.chkHilo.Size = new System.Drawing.Size(48, 19);
            this.chkHilo.TabIndex = 1;
            this.chkHilo.Text = "Hilo";
            this.chkHilo.UseVisualStyleBackColor = true;
            // 
            // chkBloque
            // 
            this.chkBloque.AutoSize = true;
            this.chkBloque.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBloque.Location = new System.Drawing.Point(19, 24);
            this.chkBloque.Name = "chkBloque";
            this.chkBloque.Size = new System.Drawing.Size(63, 19);
            this.chkBloque.TabIndex = 0;
            this.chkBloque.Text = "Bloque";
            this.chkBloque.UseVisualStyleBackColor = true;
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
            this.btnAceptar.Location = new System.Drawing.Point(383, 301);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(89, 34);
            this.btnAceptar.TabIndex = 19;
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
            this.btnCancelar.Location = new System.Drawing.Point(487, 301);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 34);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnAsistente
            // 
            this.btnAsistente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAsistente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAsistente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsistente.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAsistente.Enabled = false;
            this.btnAsistente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsistente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsistente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAsistente.Location = new System.Drawing.Point(227, 301);
            this.btnAsistente.Name = "btnAsistente";
            this.btnAsistente.Size = new System.Drawing.Size(89, 34);
            this.btnAsistente.TabIndex = 20;
            this.btnAsistente.Text = "Asistente";
            this.btnAsistente.UseVisualStyleBackColor = false;
            this.btnAsistente.Visible = false;
            this.btnAsistente.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAsistente.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // frmConfigurarBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(589, 347);
            this.Controls.Add(this.btnAsistente);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtSentencias);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(605, 386);
            this.Name = "frmConfigurarBloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Bloque";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosFin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHilosInicio)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSentencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown udHilosStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown udHilosFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udHilosInicio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSentencia;
        private System.Windows.Forms.CheckBox chkHilo;
        private System.Windows.Forms.CheckBox chkBloque;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAsistente;
    }
}