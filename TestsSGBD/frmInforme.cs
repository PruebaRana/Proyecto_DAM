using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TestsSGBD.Clases;
using TestsSGBD.Informes;

namespace TestsSGBD
{
    public partial class frmInforme : Form
    {
        #region Propiedades
        private string _RutaResultado;
        private DSResultado _DSResultado;
        #endregion

        public frmInforme()
        {
            InitializeComponent();
        }
        private void frmInforme_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        #region Metodos Accesibles desde fuera
        public void CargarResultado(string aRutaResultado)
        {
            this._RutaResultado = aRutaResultado;

            if (this._RutaResultado != null)
            {
                // Cargar el report
                CargarResultado();
            }
        }
        #endregion

        #region CargaInforme
        private void CargarResultado()
        {
            ResultadoTest lRT = new ResultadoTest();
            lRT.LoadXML(this._RutaResultado);

            this._DSResultado = new TestsSGBD.Informes.DSResultado();

            int liId = 1;
            DataRow lTablaTest = this._DSResultado.Tables["Test"].NewRow();
            lTablaTest["Nombre"] = lRT.Nombre;
            lTablaTest["Fecha"] = lRT.Fecha;
            lTablaTest["Tipo"] = lRT.Conector.Tipo;
            lTablaTest["Id"] = liId;
            this._DSResultado.Tables["Test"].Rows.Add(lTablaTest);
            int liIdBloque = 0;
            int liIdHilos = 0;

            AddBloque("Insercion", lRT.Insercion, liId, ref liIdBloque, ref liIdHilos);
            AddBloque("Consulta", lRT.Consulta, liId, ref liIdBloque, ref liIdHilos);
            AddBloque("Borrado", lRT.Borrado, liId, ref liIdBloque, ref liIdHilos);
            
            this.reportViewer1.LocalReport.DataSources[0].Value = this._DSResultado.Test;
            this.reportViewer1.LocalReport.DataSources[1].Value = this._DSResultado.Bloques;
            this.reportViewer1.LocalReport.DataSources[2].Value = this._DSResultado.Hilos;
            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);

            this.reportViewer1.RefreshReport();
        }
        private void AddBloque(string asSeccion, ResultadoSeccion aRS, int aiId, ref int aiIdBloque, ref int aiIdHilos)
        {
            foreach (ResultadoBloque lBloque in aRS.Bloque)
            {
                string lsNombreBloque = lBloque.Nombre;
                int liNumeroSentencias = lBloque.NumeroSentencias;

                aiIdBloque++;
                DataRow lTablaBloques = this._DSResultado.Tables["Bloques"].NewRow();
                lTablaBloques["Id"] = aiIdBloque;
                lTablaBloques["IdTest"] = aiId;
                lTablaBloques["NombreSeccion"] = asSeccion;
                
                lTablaBloques["NombreBloque"] = lsNombreBloque;
                lTablaBloques["NumeroSentencias"] = liNumeroSentencias;

                this._DSResultado.Tables["Bloques"].Rows.Add(lTablaBloques);
                foreach (ResultadoConexion lResConexion in lBloque.Conexiones)
                {
                    string lsTipoConexion = lResConexion.Tipo.ToString();

                    foreach (ResultadoHilo lResHilo in lResConexion.Hilos)
                    {
                        int liCantidadHilos = lResHilo.Cantidad;
                        long liTiempo = lResHilo.Tiempo;
                        int liErrores = lResHilo.Errores;

                        aiIdHilos++;
                        DataRow lTablaHilos = this._DSResultado.Tables["Hilos"].NewRow();
                        //lMiTableHilos["Id"] = liIdHilos;
                        lTablaHilos["IdBloque"] = aiIdBloque;

                        lTablaHilos["TipoConexion"] = lsTipoConexion;

                        lTablaHilos["CantidadHilos"] = liCantidadHilos;
                        lTablaHilos["Tiempo"] = liTiempo;
                        lTablaHilos["Errores"] = liErrores;

                        this._DSResultado.Tables["Hilos"].Rows.Add(lTablaHilos);
                    }
                }
            }
        }

        private void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DSHilos", (DataTable)this._DSResultado.Hilos));
        }
        #endregion
    }
}
