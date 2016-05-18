namespace TestsSGBD
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.PanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.lblSep1 = new System.Windows.Forms.Label();
            this.btnTests = new System.Windows.Forms.Button();
            this.lblSep2 = new System.Windows.Forms.Label();
            this.btnInformes = new System.Windows.Forms.Button();
            this.lblSep3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbLabelMemoria = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelEstadoTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlCentral = new System.Windows.Forms.Panel();
            this.pnlTests = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTest = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvConectoresTest = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.lblTests = new System.Windows.Forms.Label();
            this.pnlConfiguracion = new System.Windows.Forms.Panel();
            this.tabConfiguracion = new System.Windows.Forms.TabControl();
            this.tabConectores = new System.Windows.Forms.TabPage();
            this.btnDelConector = new System.Windows.Forms.Button();
            this.btnUpdConector = new System.Windows.Forms.Button();
            this.btnAddConector = new System.Windows.Forms.Button();
            this.lvConectores = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabTests = new System.Windows.Forms.TabPage();
            this.btnDelTest = new System.Windows.Forms.Button();
            this.btnUpdTest = new System.Windows.Forms.Button();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.lvTests = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblConfiguracion = new System.Windows.Forms.Label();
            this.pnlInformes = new System.Windows.Forms.Panel();
            this.lblInformes = new System.Windows.Forms.Label();
            this.sysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerRefresco = new System.Windows.Forms.Timer(this.components);
            this.PanelMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlCentral.SuspendLayout();
            this.pnlTests.SuspendLayout();
            this.pnlConfiguracion.SuspendLayout();
            this.tabConfiguracion.SuspendLayout();
            this.tabConectores.SuspendLayout();
            this.tabTests.SuspendLayout();
            this.pnlInformes.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PanelMenu.Controls.Add(this.btnConfiguracion);
            this.PanelMenu.Controls.Add(this.lblSep1);
            this.PanelMenu.Controls.Add(this.btnTests);
            this.PanelMenu.Controls.Add(this.lblSep2);
            this.PanelMenu.Controls.Add(this.btnInformes);
            this.PanelMenu.Controls.Add(this.lblSep3);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(150, 334);
            this.PanelMenu.TabIndex = 2;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Silver;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(150, 90);
            this.btnConfiguracion.TabIndex = 0;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnSeccion_Click);
            this.btnConfiguracion.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnConfiguracion.MouseLeave += new System.EventHandler(this.btnSeccion_MouseLeave);
            // 
            // lblSep1
            // 
            this.lblSep1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblSep1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSep1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSep1.Location = new System.Drawing.Point(6, 90);
            this.lblSep1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.Size = new System.Drawing.Size(138, 2);
            this.lblSep1.TabIndex = 10;
            // 
            // btnTests
            // 
            this.btnTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTests.FlatAppearance.BorderSize = 0;
            this.btnTests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTests.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTests.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnTests.Location = new System.Drawing.Point(0, 92);
            this.btnTests.Margin = new System.Windows.Forms.Padding(0);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(150, 90);
            this.btnTests.TabIndex = 1;
            this.btnTests.Text = "Tests";
            this.btnTests.UseVisualStyleBackColor = true;
            this.btnTests.Click += new System.EventHandler(this.btnSeccion_Click);
            this.btnTests.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnTests.MouseLeave += new System.EventHandler(this.btnSeccion_MouseLeave);
            // 
            // lblSep2
            // 
            this.lblSep2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblSep2.Location = new System.Drawing.Point(6, 182);
            this.lblSep2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSep2.Name = "lblSep2";
            this.lblSep2.Size = new System.Drawing.Size(138, 2);
            this.lblSep2.TabIndex = 4;
            // 
            // btnInformes
            // 
            this.btnInformes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInformes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformes.FlatAppearance.BorderSize = 0;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnInformes.Location = new System.Drawing.Point(0, 184);
            this.btnInformes.Margin = new System.Windows.Forms.Padding(0);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(150, 90);
            this.btnInformes.TabIndex = 2;
            this.btnInformes.Text = "Informes";
            this.btnInformes.UseVisualStyleBackColor = true;
            this.btnInformes.Click += new System.EventHandler(this.btnSeccion_Click);
            this.btnInformes.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnInformes.MouseLeave += new System.EventHandler(this.btnSeccion_MouseLeave);
            // 
            // lblSep3
            // 
            this.lblSep3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lblSep3.Location = new System.Drawing.Point(6, 274);
            this.lblSep3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSep3.Name = "lblSep3";
            this.lblSep3.Size = new System.Drawing.Size(138, 2);
            this.lblSep3.TabIndex = 8;
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabelMemoria,
            this.sbInfo,
            this.sbLabelEstadoTest});
            this.statusStrip1.Location = new System.Drawing.Point(150, 312);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(534, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbLabelMemoria
            // 
            this.sbLabelMemoria.AutoSize = false;
            this.sbLabelMemoria.BackColor = System.Drawing.SystemColors.Control;
            this.sbLabelMemoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbLabelMemoria.Name = "sbLabelMemoria";
            this.sbLabelMemoria.Size = new System.Drawing.Size(80, 17);
            this.sbLabelMemoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sbInfo
            // 
            this.sbInfo.AutoSize = false;
            this.sbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.sbInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.sbInfo.Name = "sbInfo";
            this.sbInfo.Size = new System.Drawing.Size(60, 17);
            // 
            // sbLabelEstadoTest
            // 
            this.sbLabelEstadoTest.AutoSize = false;
            this.sbLabelEstadoTest.BackColor = System.Drawing.SystemColors.Control;
            this.sbLabelEstadoTest.Name = "sbLabelEstadoTest";
            this.sbLabelEstadoTest.Size = new System.Drawing.Size(300, 17);
            this.sbLabelEstadoTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCentral
            // 
            this.pnlCentral.Controls.Add(this.pnlTests);
            this.pnlCentral.Controls.Add(this.pnlConfiguracion);
            this.pnlCentral.Controls.Add(this.pnlInformes);
            this.pnlCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentral.Location = new System.Drawing.Point(150, 0);
            this.pnlCentral.Name = "pnlCentral";
            this.pnlCentral.Size = new System.Drawing.Size(534, 312);
            this.pnlCentral.TabIndex = 15;
            // 
            // pnlTests
            // 
            this.pnlTests.Controls.Add(this.label2);
            this.pnlTests.Controls.Add(this.cbTest);
            this.pnlTests.Controls.Add(this.label1);
            this.pnlTests.Controls.Add(this.lvConectoresTest);
            this.pnlTests.Controls.Add(this.btnCancelar);
            this.pnlTests.Controls.Add(this.btnEjecutar);
            this.pnlTests.Controls.Add(this.lblTests);
            this.pnlTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTests.Location = new System.Drawing.Point(0, 0);
            this.pnlTests.Name = "pnlTests";
            this.pnlTests.Size = new System.Drawing.Size(534, 312);
            this.pnlTests.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(13, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Seleccione el test que desea ejecutar";
            // 
            // cbTest
            // 
            this.cbTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTest.FormattingEnabled = true;
            this.cbTest.Location = new System.Drawing.Point(12, 246);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(506, 21);
            this.cbTest.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Seleccione los conectores que desea usar para realizar el test";
            // 
            // lvConectoresTest
            // 
            this.lvConectoresTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConectoresTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvConectoresTest.FullRowSelect = true;
            this.lvConectoresTest.GridLines = true;
            this.lvConectoresTest.Location = new System.Drawing.Point(12, 112);
            this.lvConectoresTest.Name = "lvConectoresTest";
            this.lvConectoresTest.ShowGroups = false;
            this.lvConectoresTest.Size = new System.Drawing.Size(506, 109);
            this.lvConectoresTest.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvConectoresTest.TabIndex = 16;
            this.lvConectoresTest.Tag = "501";
            this.lvConectoresTest.UseCompatibleStateImageBehavior = false;
            this.lvConectoresTest.View = System.Windows.Forms.View.Details;
            this.lvConectoresTest.Resize += new System.EventHandler(this.lvConectoresTest_Resize);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nombre";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tipo";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Cadena";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(348, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEjecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjecutar.Location = new System.Drawing.Point(443, 277);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 23);
            this.btnEjecutar.TabIndex = 13;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // lblTests
            // 
            this.lblTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblTests.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTests.Location = new System.Drawing.Point(0, 20);
            this.lblTests.Name = "lblTests";
            this.lblTests.Padding = new System.Windows.Forms.Padding(25, 0, 0, 5);
            this.lblTests.Size = new System.Drawing.Size(534, 60);
            this.lblTests.TabIndex = 0;
            this.lblTests.Text = "Tests";
            this.lblTests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlConfiguracion
            // 
            this.pnlConfiguracion.Controls.Add(this.tabConfiguracion);
            this.pnlConfiguracion.Controls.Add(this.lblConfiguracion);
            this.pnlConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguracion.Location = new System.Drawing.Point(0, 0);
            this.pnlConfiguracion.Name = "pnlConfiguracion";
            this.pnlConfiguracion.Size = new System.Drawing.Size(534, 312);
            this.pnlConfiguracion.TabIndex = 13;
            // 
            // tabConfiguracion
            // 
            this.tabConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConfiguracion.Controls.Add(this.tabConectores);
            this.tabConfiguracion.Controls.Add(this.tabTests);
            this.tabConfiguracion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabConfiguracion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConfiguracion.ItemSize = new System.Drawing.Size(175, 28);
            this.tabConfiguracion.Location = new System.Drawing.Point(3, 89);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.Padding = new System.Drawing.Point(24, 3);
            this.tabConfiguracion.SelectedIndex = 0;
            this.tabConfiguracion.ShowToolTips = true;
            this.tabConfiguracion.Size = new System.Drawing.Size(528, 218);
            this.tabConfiguracion.TabIndex = 13;
            this.tabConfiguracion.SelectedIndexChanged += new System.EventHandler(this.tabConfiguracion_SelectedIndexChanged);
            // 
            // tabConectores
            // 
            this.tabConectores.Controls.Add(this.btnDelConector);
            this.tabConectores.Controls.Add(this.btnUpdConector);
            this.tabConectores.Controls.Add(this.btnAddConector);
            this.tabConectores.Controls.Add(this.lvConectores);
            this.tabConectores.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabConectores.Location = new System.Drawing.Point(4, 32);
            this.tabConectores.Margin = new System.Windows.Forms.Padding(30);
            this.tabConectores.Name = "tabConectores";
            this.tabConectores.Padding = new System.Windows.Forms.Padding(30);
            this.tabConectores.Size = new System.Drawing.Size(520, 182);
            this.tabConectores.TabIndex = 0;
            this.tabConectores.Text = "Conectores";
            this.tabConectores.ToolTipText = "Lista de conectores de Bases de datos";
            this.tabConectores.UseVisualStyleBackColor = true;
            // 
            // btnDelConector
            // 
            this.btnDelConector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelConector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelConector.Enabled = false;
            this.btnDelConector.Location = new System.Drawing.Point(438, 67);
            this.btnDelConector.Name = "btnDelConector";
            this.btnDelConector.Size = new System.Drawing.Size(75, 23);
            this.btnDelConector.TabIndex = 14;
            this.btnDelConector.Text = "Eliminar";
            this.btnDelConector.UseVisualStyleBackColor = true;
            this.btnDelConector.Click += new System.EventHandler(this.btnDelConector_Click);
            // 
            // btnUpdConector
            // 
            this.btnUpdConector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdConector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdConector.Enabled = false;
            this.btnUpdConector.Location = new System.Drawing.Point(438, 40);
            this.btnUpdConector.Name = "btnUpdConector";
            this.btnUpdConector.Size = new System.Drawing.Size(75, 23);
            this.btnUpdConector.TabIndex = 13;
            this.btnUpdConector.Text = "Modificar";
            this.btnUpdConector.UseVisualStyleBackColor = true;
            this.btnUpdConector.Click += new System.EventHandler(this.btnUpdConector_Click);
            // 
            // btnAddConector
            // 
            this.btnAddConector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddConector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddConector.Location = new System.Drawing.Point(438, 6);
            this.btnAddConector.Name = "btnAddConector";
            this.btnAddConector.Size = new System.Drawing.Size(75, 23);
            this.btnAddConector.TabIndex = 12;
            this.btnAddConector.Text = "Añadir";
            this.btnAddConector.UseVisualStyleBackColor = true;
            this.btnAddConector.Click += new System.EventHandler(this.btnAddConector_Click);
            // 
            // lvConectores
            // 
            this.lvConectores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConectores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvConectores.FullRowSelect = true;
            this.lvConectores.GridLines = true;
            this.lvConectores.Location = new System.Drawing.Point(3, 6);
            this.lvConectores.MultiSelect = false;
            this.lvConectores.Name = "lvConectores";
            this.lvConectores.ShowGroups = false;
            this.lvConectores.Size = new System.Drawing.Size(427, 167);
            this.lvConectores.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvConectores.TabIndex = 11;
            this.lvConectores.Tag = "435";
            this.lvConectores.UseCompatibleStateImageBehavior = false;
            this.lvConectores.View = System.Windows.Forms.View.Details;
            this.lvConectores.SelectedIndexChanged += new System.EventHandler(this.lvConectores_SelectedIndexChanged);
            this.lvConectores.Resize += new System.EventHandler(this.lvConectores_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cadena";
            // 
            // tabTests
            // 
            this.tabTests.Controls.Add(this.btnDelTest);
            this.tabTests.Controls.Add(this.btnUpdTest);
            this.tabTests.Controls.Add(this.btnAddTest);
            this.tabTests.Controls.Add(this.lvTests);
            this.tabTests.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabTests.Location = new System.Drawing.Point(4, 32);
            this.tabTests.Name = "tabTests";
            this.tabTests.Padding = new System.Windows.Forms.Padding(3);
            this.tabTests.Size = new System.Drawing.Size(520, 182);
            this.tabTests.TabIndex = 1;
            this.tabTests.Text = "Tests";
            this.tabTests.ToolTipText = "Lista de Test disponibles";
            this.tabTests.UseVisualStyleBackColor = true;
            // 
            // btnDelTest
            // 
            this.btnDelTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelTest.Enabled = false;
            this.btnDelTest.Location = new System.Drawing.Point(438, 67);
            this.btnDelTest.Name = "btnDelTest";
            this.btnDelTest.Size = new System.Drawing.Size(75, 23);
            this.btnDelTest.TabIndex = 18;
            this.btnDelTest.Text = "Eliminar";
            this.btnDelTest.UseVisualStyleBackColor = true;
            this.btnDelTest.Click += new System.EventHandler(this.btnDelTest_Click);
            // 
            // btnUpdTest
            // 
            this.btnUpdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdTest.Enabled = false;
            this.btnUpdTest.Location = new System.Drawing.Point(438, 40);
            this.btnUpdTest.Name = "btnUpdTest";
            this.btnUpdTest.Size = new System.Drawing.Size(75, 23);
            this.btnUpdTest.TabIndex = 17;
            this.btnUpdTest.Text = "Modificar";
            this.btnUpdTest.UseVisualStyleBackColor = true;
            this.btnUpdTest.Click += new System.EventHandler(this.btnUpdTest_Click);
            // 
            // btnAddTest
            // 
            this.btnAddTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTest.Location = new System.Drawing.Point(438, 6);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(75, 23);
            this.btnAddTest.TabIndex = 16;
            this.btnAddTest.Text = "Añadir";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // lvTests
            // 
            this.lvTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lvTests.FullRowSelect = true;
            this.lvTests.GridLines = true;
            this.lvTests.Location = new System.Drawing.Point(3, 6);
            this.lvTests.MultiSelect = false;
            this.lvTests.Name = "lvTests";
            this.lvTests.ShowGroups = false;
            this.lvTests.Size = new System.Drawing.Size(427, 167);
            this.lvTests.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvTests.TabIndex = 15;
            this.lvTests.Tag = "435";
            this.lvTests.UseCompatibleStateImageBehavior = false;
            this.lvTests.View = System.Windows.Forms.View.Details;
            this.lvTests.SelectedIndexChanged += new System.EventHandler(this.lvTests_SelectedIndexChanged);
            this.lvTests.Resize += new System.EventHandler(this.lvTests_Resize);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nombre";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ruta";
            this.columnHeader5.Width = 130;
            // 
            // lblConfiguracion
            // 
            this.lblConfiguracion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfiguracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblConfiguracion.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfiguracion.Location = new System.Drawing.Point(0, 20);
            this.lblConfiguracion.Name = "lblConfiguracion";
            this.lblConfiguracion.Padding = new System.Windows.Forms.Padding(25, 0, 0, 5);
            this.lblConfiguracion.Size = new System.Drawing.Size(534, 60);
            this.lblConfiguracion.TabIndex = 12;
            this.lblConfiguracion.Text = "Configuración";
            this.lblConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInformes
            // 
            this.pnlInformes.Controls.Add(this.lblInformes);
            this.pnlInformes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInformes.Location = new System.Drawing.Point(0, 0);
            this.pnlInformes.Name = "pnlInformes";
            this.pnlInformes.Size = new System.Drawing.Size(534, 312);
            this.pnlInformes.TabIndex = 15;
            // 
            // lblInformes
            // 
            this.lblInformes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInformes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblInformes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInformes.Location = new System.Drawing.Point(0, 20);
            this.lblInformes.Name = "lblInformes";
            this.lblInformes.Padding = new System.Windows.Forms.Padding(25, 0, 0, 5);
            this.lblInformes.Size = new System.Drawing.Size(534, 60);
            this.lblInformes.TabIndex = 14;
            this.lblInformes.Text = "Informes";
            this.lblInformes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sysTrayIcon
            // 
            this.sysTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.sysTrayIcon.BalloonTipText = "Prueba";
            this.sysTrayIcon.BalloonTipTitle = "ELOOOOOO";
            this.sysTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTrayIcon.Icon")));
            this.sysTrayIcon.Text = "Test SGBD";
            this.sysTrayIcon.Click += new System.EventHandler(this.sysTrayIcon_Click);
            // 
            // timerRefresco
            // 
            this.timerRefresco.Enabled = true;
            this.timerRefresco.Interval = 1000;
            this.timerRefresco.Tick += new System.EventHandler(this.timerRefresco_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 334);
            this.Controls.Add(this.pnlCentral);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 320);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test SGBD by Jaime Aguila";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.Resize += new System.EventHandler(this.frmPrincipal_Resize);
            this.PanelMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlCentral.ResumeLayout(false);
            this.pnlTests.ResumeLayout(false);
            this.pnlTests.PerformLayout();
            this.pnlConfiguracion.ResumeLayout(false);
            this.tabConfiguracion.ResumeLayout(false);
            this.tabConectores.ResumeLayout(false);
            this.tabTests.ResumeLayout(false);
            this.pnlInformes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelMenu;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Label lblSep1;
        private System.Windows.Forms.Button btnTests;
        private System.Windows.Forms.Label lblSep2;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Label lblSep3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelMemoria;
        private System.Windows.Forms.Panel pnlCentral;
        private System.Windows.Forms.Panel pnlConfiguracion;
        private System.Windows.Forms.Label lblConfiguracion;
        private System.Windows.Forms.Panel pnlInformes;
        private System.Windows.Forms.Label lblInformes;
        private System.Windows.Forms.Panel pnlTests;
        private System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.NotifyIcon sysTrayIcon;
        private System.Windows.Forms.TabControl tabConfiguracion;
        private System.Windows.Forms.TabPage tabConectores;
        private System.Windows.Forms.TabPage tabTests;
        private System.Windows.Forms.Button btnDelConector;
        private System.Windows.Forms.Button btnUpdConector;
        private System.Windows.Forms.Button btnAddConector;
        private System.Windows.Forms.ListView lvConectores;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnDelTest;
        private System.Windows.Forms.Button btnUpdTest;
        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.ListView lvTests;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Timer timerRefresco;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelEstadoTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvConectoresTest;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripStatusLabel sbInfo;
    }
}

