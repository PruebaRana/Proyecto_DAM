namespace TestsSGBD
{
    partial class frmInforme
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.testBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSResultado = new TestsSGBD.Informes.DSResultado();
            this.bloquesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hilosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSResultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloquesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hilosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DSTest";
            reportDataSource1.Value = this.testBindingSource;
            reportDataSource2.Name = "DSBloques";
            reportDataSource2.Value = this.bloquesBindingSource;
            reportDataSource3.Name = "DSHilos";
            reportDataSource3.Value = this.hilosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TestsSGBD.Informes.InformeResultado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(818, 423);
            this.reportViewer1.TabIndex = 0;
            // 
            // testBindingSource
            // 
            this.testBindingSource.DataMember = "Test";
            this.testBindingSource.DataSource = this.dSResultado;
            // 
            // dSResultado
            // 
            this.dSResultado.DataSetName = "DSResultado";
            this.dSResultado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bloquesBindingSource
            // 
            this.bloquesBindingSource.DataMember = "Bloques";
            this.bloquesBindingSource.DataSource = this.dSResultado;
            // 
            // hilosBindingSource
            // 
            this.hilosBindingSource.DataMember = "Hilos";
            this.hilosBindingSource.DataSource = this.dSResultado;
            // 
            // frmInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 447);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInforme";
            this.Text = "frmInforme";
            this.Load += new System.EventHandler(this.frmInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSResultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloquesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hilosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource testBindingSource;
        private Informes.DSResultado dSResultado;
        private System.Windows.Forms.BindingSource bloquesBindingSource;
        private System.Windows.Forms.BindingSource hilosBindingSource;
    }
}