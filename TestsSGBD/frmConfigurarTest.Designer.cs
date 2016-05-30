namespace TestsSGBD
{
    partial class frmConfigurarTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurarTest));
            this.tabTest = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCreacion = new System.Windows.Forms.TabPage();
            this.lvCreacion = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelCreacion = new System.Windows.Forms.Button();
            this.btnUpdCreacion = new System.Windows.Forms.Button();
            this.btnAddCreacion = new System.Windows.Forms.Button();
            this.tabInsercion = new System.Windows.Forms.TabPage();
            this.lvInsercion = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelInsercion = new System.Windows.Forms.Button();
            this.btnUpdInsercion = new System.Windows.Forms.Button();
            this.btnAddInsercion = new System.Windows.Forms.Button();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.btnDelConsulta = new System.Windows.Forms.Button();
            this.btnUpdConsulta = new System.Windows.Forms.Button();
            this.btnAddConsulta = new System.Windows.Forms.Button();
            this.lvConsulta = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabBorrado = new System.Windows.Forms.TabPage();
            this.lvBorrado = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelBorrado = new System.Windows.Forms.Button();
            this.btnUpdBorrado = new System.Windows.Forms.Button();
            this.btnAddBorrado = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tabTest.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabCreacion.SuspendLayout();
            this.tabInsercion.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.tabBorrado.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTest
            // 
            this.tabTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTest.Controls.Add(this.tabGeneral);
            this.tabTest.Controls.Add(this.tabCreacion);
            this.tabTest.Controls.Add(this.tabInsercion);
            this.tabTest.Controls.Add(this.tabConsulta);
            this.tabTest.Controls.Add(this.tabBorrado);
            this.tabTest.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.helpProvider1.SetHelpString(this.tabTest, "Cada una de las secciones de las que se compone un test");
            this.tabTest.ItemSize = new System.Drawing.Size(200, 28);
            this.tabTest.Location = new System.Drawing.Point(12, 12);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Drawing.Point(24, 3);
            this.tabTest.SelectedIndex = 0;
            this.helpProvider1.SetShowHelp(this.tabTest, true);
            this.tabTest.Size = new System.Drawing.Size(509, 151);
            this.tabTest.TabIndex = 8;
            this.tabTest.SelectedIndexChanged += new System.EventHandler(this.tabTest_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtNombre);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabGeneral.Location = new System.Drawing.Point(4, 32);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(501, 115);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.helpProvider1.SetHelpString(this.txtNombre, "Sera un nombre descriptivo para el test");
            this.txtNombre.Location = new System.Drawing.Point(6, 36);
            this.txtNombre.Name = "txtNombre";
            this.helpProvider1.SetShowHelp(this.txtNombre, true);
            this.txtNombre.Size = new System.Drawing.Size(487, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre del test";
            // 
            // tabCreacion
            // 
            this.tabCreacion.Controls.Add(this.lvCreacion);
            this.tabCreacion.Controls.Add(this.btnDelCreacion);
            this.tabCreacion.Controls.Add(this.btnUpdCreacion);
            this.tabCreacion.Controls.Add(this.btnAddCreacion);
            this.tabCreacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabCreacion.Location = new System.Drawing.Point(4, 32);
            this.tabCreacion.Name = "tabCreacion";
            this.tabCreacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreacion.Size = new System.Drawing.Size(501, 115);
            this.tabCreacion.TabIndex = 1;
            this.tabCreacion.Text = "Creacion";
            this.tabCreacion.UseVisualStyleBackColor = true;
            // 
            // lvCreacion
            // 
            this.lvCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCreacion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvCreacion.FullRowSelect = true;
            this.lvCreacion.GridLines = true;
            this.helpProvider1.SetHelpString(this.lvCreacion, "Estos seran los datos de los bloques de la seccion de creacion");
            this.lvCreacion.Location = new System.Drawing.Point(5, 8);
            this.lvCreacion.MultiSelect = false;
            this.lvCreacion.Name = "lvCreacion";
            this.lvCreacion.ShowGroups = false;
            this.helpProvider1.SetShowHelp(this.lvCreacion, true);
            this.lvCreacion.Size = new System.Drawing.Size(408, 100);
            this.lvCreacion.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCreacion.TabIndex = 27;
            this.lvCreacion.Tag = "413";
            this.lvCreacion.UseCompatibleStateImageBehavior = false;
            this.lvCreacion.View = System.Windows.Forms.View.Details;
            this.lvCreacion.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lvCreacion.Resize += new System.EventHandler(this.lv_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SQLs";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Hilos";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Conex.";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Rep.";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 40;
            // 
            // btnDelCreacion
            // 
            this.btnDelCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelCreacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelCreacion.Enabled = false;
            this.btnDelCreacion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnDelCreacion, "Pulse para eliminar el bloque que tenga seleccionado");
            this.btnDelCreacion.Location = new System.Drawing.Point(421, 69);
            this.btnDelCreacion.Name = "btnDelCreacion";
            this.helpProvider1.SetShowHelp(this.btnDelCreacion, true);
            this.btnDelCreacion.Size = new System.Drawing.Size(75, 23);
            this.btnDelCreacion.TabIndex = 26;
            this.btnDelCreacion.Text = "Eliminar";
            this.btnDelCreacion.UseVisualStyleBackColor = true;
            this.btnDelCreacion.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdCreacion
            // 
            this.btnUpdCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdCreacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdCreacion.Enabled = false;
            this.btnUpdCreacion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnUpdCreacion, "Pulse para modificar un bloque que tenga seleccionado");
            this.btnUpdCreacion.Location = new System.Drawing.Point(421, 42);
            this.btnUpdCreacion.Name = "btnUpdCreacion";
            this.helpProvider1.SetShowHelp(this.btnUpdCreacion, true);
            this.btnUpdCreacion.Size = new System.Drawing.Size(75, 23);
            this.btnUpdCreacion.TabIndex = 25;
            this.btnUpdCreacion.Text = "Modificar";
            this.btnUpdCreacion.UseVisualStyleBackColor = true;
            this.btnUpdCreacion.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAddCreacion
            // 
            this.btnAddCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCreacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCreacion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnAddCreacion, "Pulse para añadir un nuevo bloque");
            this.btnAddCreacion.Location = new System.Drawing.Point(421, 8);
            this.btnAddCreacion.Name = "btnAddCreacion";
            this.helpProvider1.SetShowHelp(this.btnAddCreacion, true);
            this.btnAddCreacion.Size = new System.Drawing.Size(75, 23);
            this.btnAddCreacion.TabIndex = 24;
            this.btnAddCreacion.Text = "Añadir";
            this.btnAddCreacion.UseVisualStyleBackColor = true;
            this.btnAddCreacion.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabInsercion
            // 
            this.tabInsercion.Controls.Add(this.lvInsercion);
            this.tabInsercion.Controls.Add(this.btnDelInsercion);
            this.tabInsercion.Controls.Add(this.btnUpdInsercion);
            this.tabInsercion.Controls.Add(this.btnAddInsercion);
            this.tabInsercion.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabInsercion.Location = new System.Drawing.Point(4, 32);
            this.tabInsercion.Name = "tabInsercion";
            this.tabInsercion.Size = new System.Drawing.Size(501, 115);
            this.tabInsercion.TabIndex = 2;
            this.tabInsercion.Text = "Insercion";
            this.tabInsercion.UseVisualStyleBackColor = true;
            // 
            // lvInsercion
            // 
            this.lvInsercion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInsercion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader15});
            this.lvInsercion.FullRowSelect = true;
            this.lvInsercion.GridLines = true;
            this.helpProvider1.SetHelpString(this.lvInsercion, "Estos seran los datos de los bloques de la seccion de insercion");
            this.lvInsercion.Location = new System.Drawing.Point(5, 8);
            this.lvInsercion.MultiSelect = false;
            this.lvInsercion.Name = "lvInsercion";
            this.lvInsercion.ShowGroups = false;
            this.helpProvider1.SetShowHelp(this.lvInsercion, true);
            this.lvInsercion.Size = new System.Drawing.Size(408, 100);
            this.lvInsercion.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvInsercion.TabIndex = 24;
            this.lvInsercion.Tag = "413";
            this.lvInsercion.UseCompatibleStateImageBehavior = false;
            this.lvInsercion.View = System.Windows.Forms.View.Details;
            this.lvInsercion.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lvInsercion.Resize += new System.EventHandler(this.lv_Resize);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nombre";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "SQLs";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Hilos";
            this.columnHeader11.Width = 55;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Conex.";
            this.columnHeader12.Width = 50;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Rep.";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader15.Width = 40;
            // 
            // btnDelInsercion
            // 
            this.btnDelInsercion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelInsercion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelInsercion.Enabled = false;
            this.btnDelInsercion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnDelInsercion, "Pulse para eliminar el bloque que tenga seleccionado");
            this.btnDelInsercion.Location = new System.Drawing.Point(421, 69);
            this.btnDelInsercion.Name = "btnDelInsercion";
            this.helpProvider1.SetShowHelp(this.btnDelInsercion, true);
            this.btnDelInsercion.Size = new System.Drawing.Size(75, 23);
            this.btnDelInsercion.TabIndex = 22;
            this.btnDelInsercion.Text = "Eliminar";
            this.btnDelInsercion.UseVisualStyleBackColor = true;
            this.btnDelInsercion.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdInsercion
            // 
            this.btnUpdInsercion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdInsercion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdInsercion.Enabled = false;
            this.btnUpdInsercion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnUpdInsercion, "Pulse para modificar un bloque que tenga seleccionado");
            this.btnUpdInsercion.Location = new System.Drawing.Point(421, 42);
            this.btnUpdInsercion.Name = "btnUpdInsercion";
            this.helpProvider1.SetShowHelp(this.btnUpdInsercion, true);
            this.btnUpdInsercion.Size = new System.Drawing.Size(75, 23);
            this.btnUpdInsercion.TabIndex = 21;
            this.btnUpdInsercion.Text = "Modificar";
            this.btnUpdInsercion.UseVisualStyleBackColor = true;
            this.btnUpdInsercion.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAddInsercion
            // 
            this.btnAddInsercion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInsercion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddInsercion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnAddInsercion, "Pulse para añadir un nuevo bloque");
            this.btnAddInsercion.Location = new System.Drawing.Point(421, 8);
            this.btnAddInsercion.Name = "btnAddInsercion";
            this.helpProvider1.SetShowHelp(this.btnAddInsercion, true);
            this.btnAddInsercion.Size = new System.Drawing.Size(75, 23);
            this.btnAddInsercion.TabIndex = 20;
            this.btnAddInsercion.Text = "Añadir";
            this.btnAddInsercion.UseVisualStyleBackColor = true;
            this.btnAddInsercion.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.btnDelConsulta);
            this.tabConsulta.Controls.Add(this.btnUpdConsulta);
            this.tabConsulta.Controls.Add(this.btnAddConsulta);
            this.tabConsulta.Controls.Add(this.lvConsulta);
            this.tabConsulta.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabConsulta.Location = new System.Drawing.Point(4, 32);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Size = new System.Drawing.Size(501, 115);
            this.tabConsulta.TabIndex = 3;
            this.tabConsulta.Text = "Consulta";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // btnDelConsulta
            // 
            this.btnDelConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelConsulta.Enabled = false;
            this.btnDelConsulta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnDelConsulta, "Pulse para eliminar el bloque que tenga seleccionado");
            this.btnDelConsulta.Location = new System.Drawing.Point(421, 69);
            this.btnDelConsulta.Name = "btnDelConsulta";
            this.helpProvider1.SetShowHelp(this.btnDelConsulta, true);
            this.btnDelConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnDelConsulta.TabIndex = 26;
            this.btnDelConsulta.Text = "Eliminar";
            this.btnDelConsulta.UseVisualStyleBackColor = true;
            this.btnDelConsulta.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdConsulta
            // 
            this.btnUpdConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdConsulta.Enabled = false;
            this.btnUpdConsulta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnUpdConsulta, "Pulse para modificar un bloque que tenga seleccionado");
            this.btnUpdConsulta.Location = new System.Drawing.Point(421, 42);
            this.btnUpdConsulta.Name = "btnUpdConsulta";
            this.helpProvider1.SetShowHelp(this.btnUpdConsulta, true);
            this.btnUpdConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnUpdConsulta.TabIndex = 25;
            this.btnUpdConsulta.Text = "Modificar";
            this.btnUpdConsulta.UseVisualStyleBackColor = true;
            this.btnUpdConsulta.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAddConsulta
            // 
            this.btnAddConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddConsulta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnAddConsulta, "Pulse para añadir un nuevo bloque");
            this.btnAddConsulta.Location = new System.Drawing.Point(421, 8);
            this.btnAddConsulta.Name = "btnAddConsulta";
            this.helpProvider1.SetShowHelp(this.btnAddConsulta, true);
            this.btnAddConsulta.Size = new System.Drawing.Size(75, 23);
            this.btnAddConsulta.TabIndex = 24;
            this.btnAddConsulta.Text = "Añadir";
            this.btnAddConsulta.UseVisualStyleBackColor = true;
            this.btnAddConsulta.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvConsulta
            // 
            this.lvConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConsulta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader13,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader14});
            this.lvConsulta.FullRowSelect = true;
            this.lvConsulta.GridLines = true;
            this.helpProvider1.SetHelpString(this.lvConsulta, "Estos seran los datos de los bloques de la seccion de consulta");
            this.lvConsulta.Location = new System.Drawing.Point(5, 8);
            this.lvConsulta.MultiSelect = false;
            this.lvConsulta.Name = "lvConsulta";
            this.lvConsulta.ShowGroups = false;
            this.helpProvider1.SetShowHelp(this.lvConsulta, true);
            this.lvConsulta.Size = new System.Drawing.Size(408, 100);
            this.lvConsulta.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvConsulta.TabIndex = 23;
            this.lvConsulta.Tag = "413";
            this.lvConsulta.UseCompatibleStateImageBehavior = false;
            this.lvConsulta.View = System.Windows.Forms.View.Details;
            this.lvConsulta.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lvConsulta.Resize += new System.EventHandler(this.lv_Resize);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Nombre";
            this.columnHeader7.Width = 180;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "SQLs";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Hilos";
            this.columnHeader8.Width = 55;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Conex.";
            this.columnHeader9.Width = 50;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Rep.";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader14.Width = 40;
            // 
            // tabBorrado
            // 
            this.tabBorrado.Controls.Add(this.lvBorrado);
            this.tabBorrado.Controls.Add(this.btnDelBorrado);
            this.tabBorrado.Controls.Add(this.btnUpdBorrado);
            this.tabBorrado.Controls.Add(this.btnAddBorrado);
            this.tabBorrado.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabBorrado.Location = new System.Drawing.Point(4, 32);
            this.tabBorrado.Name = "tabBorrado";
            this.tabBorrado.Size = new System.Drawing.Size(501, 115);
            this.tabBorrado.TabIndex = 4;
            this.tabBorrado.Text = "Borrado";
            this.tabBorrado.UseVisualStyleBackColor = true;
            // 
            // lvBorrado
            // 
            this.lvBorrado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBorrado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvBorrado.FullRowSelect = true;
            this.lvBorrado.GridLines = true;
            this.helpProvider1.SetHelpString(this.lvBorrado, "Estos seran los datos de los bloques de la seccion de borrado");
            this.lvBorrado.Location = new System.Drawing.Point(5, 8);
            this.lvBorrado.MultiSelect = false;
            this.lvBorrado.Name = "lvBorrado";
            this.lvBorrado.ShowGroups = false;
            this.helpProvider1.SetShowHelp(this.lvBorrado, true);
            this.lvBorrado.Size = new System.Drawing.Size(408, 100);
            this.lvBorrado.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvBorrado.TabIndex = 27;
            this.lvBorrado.Tag = "413";
            this.lvBorrado.UseCompatibleStateImageBehavior = false;
            this.lvBorrado.View = System.Windows.Forms.View.Details;
            this.lvBorrado.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            this.lvBorrado.Resize += new System.EventHandler(this.lv_Resize);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Nombre";
            this.columnHeader16.Width = 180;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "SQLs";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Hilos";
            this.columnHeader18.Width = 55;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Conex.";
            this.columnHeader19.Width = 50;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Rep.";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader20.Width = 40;
            // 
            // btnDelBorrado
            // 
            this.btnDelBorrado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelBorrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelBorrado.Enabled = false;
            this.btnDelBorrado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnDelBorrado, "Pulse para eliminar el bloque que tenga seleccionado");
            this.btnDelBorrado.Location = new System.Drawing.Point(421, 69);
            this.btnDelBorrado.Name = "btnDelBorrado";
            this.helpProvider1.SetShowHelp(this.btnDelBorrado, true);
            this.btnDelBorrado.Size = new System.Drawing.Size(75, 23);
            this.btnDelBorrado.TabIndex = 26;
            this.btnDelBorrado.Text = "Eliminar";
            this.btnDelBorrado.UseVisualStyleBackColor = true;
            this.btnDelBorrado.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdBorrado
            // 
            this.btnUpdBorrado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdBorrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdBorrado.Enabled = false;
            this.btnUpdBorrado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnUpdBorrado, "Pulse para modificar un bloque que tenga seleccionado");
            this.btnUpdBorrado.Location = new System.Drawing.Point(421, 42);
            this.btnUpdBorrado.Name = "btnUpdBorrado";
            this.helpProvider1.SetShowHelp(this.btnUpdBorrado, true);
            this.btnUpdBorrado.Size = new System.Drawing.Size(75, 23);
            this.btnUpdBorrado.TabIndex = 25;
            this.btnUpdBorrado.Text = "Modificar";
            this.btnUpdBorrado.UseVisualStyleBackColor = true;
            this.btnUpdBorrado.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnAddBorrado
            // 
            this.btnAddBorrado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBorrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBorrado.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.helpProvider1.SetHelpString(this.btnAddBorrado, "Pulse para añadir un nuevo bloque");
            this.btnAddBorrado.Location = new System.Drawing.Point(421, 8);
            this.btnAddBorrado.Name = "btnAddBorrado";
            this.helpProvider1.SetShowHelp(this.btnAddBorrado, true);
            this.btnAddBorrado.Size = new System.Drawing.Size(75, 23);
            this.btnAddBorrado.TabIndex = 24;
            this.btnAddBorrado.Text = "Añadir";
            this.btnAddBorrado.UseVisualStyleBackColor = true;
            this.btnAddBorrado.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.helpProvider1.SetHelpString(this.btnAceptar, "Pulse Aceptar, para guardar los datos y salir");
            this.btnAceptar.Location = new System.Drawing.Point(327, 175);
            this.btnAceptar.Name = "btnAceptar";
            this.helpProvider1.SetShowHelp(this.btnAceptar, true);
            this.btnAceptar.Size = new System.Drawing.Size(89, 34);
            this.btnAceptar.TabIndex = 10;
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
            this.helpProvider1.SetHelpString(this.btnCancelar, "Pulse cancelar para cerrar la ventana sin guardar");
            this.btnCancelar.Location = new System.Drawing.Point(432, 175);
            this.btnCancelar.Name = "btnCancelar";
            this.helpProvider1.SetShowHelp(this.btnCancelar, true);
            this.btnCancelar.Size = new System.Drawing.Size(89, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // frmConfigurarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(534, 221);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabTest);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 260);
            this.Name = "frmConfigurarTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.tabTest.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabCreacion.ResumeLayout(false);
            this.tabInsercion.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabBorrado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTest;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabCreacion;
        private System.Windows.Forms.TabPage tabInsercion;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.TabPage tabBorrado;
        private System.Windows.Forms.Button btnDelInsercion;
        private System.Windows.Forms.Button btnUpdInsercion;
        private System.Windows.Forms.Button btnAddInsercion;
        private System.Windows.Forms.Button btnDelConsulta;
        private System.Windows.Forms.Button btnUpdConsulta;
        private System.Windows.Forms.Button btnAddConsulta;
        private System.Windows.Forms.ListView lvConsulta;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnDelBorrado;
        private System.Windows.Forms.Button btnUpdBorrado;
        private System.Windows.Forms.Button btnAddBorrado;
        private System.Windows.Forms.Button btnDelCreacion;
        private System.Windows.Forms.Button btnUpdCreacion;
        private System.Windows.Forms.Button btnAddCreacion;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ListView lvCreacion;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvInsercion;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ListView lvBorrado;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}