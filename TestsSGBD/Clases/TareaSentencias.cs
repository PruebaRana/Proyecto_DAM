using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace TestsSGBD.Clases
{
    class TareaSentencias : IDisposable
    {
        #region Propiedades
        private bool disposed = false;

        private List<Sentencia> _Sentencias;
        public List<Sentencia> Sentencias
        {
            get { return _Sentencias; }
            set { _Sentencias = value; }
        }

        private ResultadoConexion.TipoConexion _Tipo;
        public ResultadoConexion.TipoConexion Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private DatosBase _Datos;
        public DatosBase Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }

        private Task _Task;
        public Task Task
        {
            get { return _Task; }
            set { _Task = value; }
        }
        #endregion

        #region Constructores
        public TareaSentencias(List<Sentencia> aSentencias, ResultadoConexion.TipoConexion aTipo, DatosBase aDatos)
        {
            this._Sentencias = aSentencias;
            this._Tipo = aTipo;
            this._Datos = aDatos;
        }
        #endregion

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose-only, i.e. non-finalizable logic
                    this._Sentencias.Clear();
                    this._Sentencias = null;
                    this._Datos.Close();
                    this._Datos = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~TareaSentencias()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public void LanzarConsultas()
        {
            this._Datos.Open();

            foreach (Sentencia lSentencia in this._Sentencias)
            {
                DataTable lDataTable = this._Datos.ObtenerDataTable(lSentencia.SQL);
                int lCantidadRegistros = lDataTable.Rows.Count;

                if ((this._Tipo & ResultadoConexion.TipoConexion.SENTENCIA) == ResultadoConexion.TipoConexion.SENTENCIA)
                {
                    this._Datos.Close();
                    this._Datos.Open();
                }
            }
            
            this._Datos.Close();
        }
    }
}
