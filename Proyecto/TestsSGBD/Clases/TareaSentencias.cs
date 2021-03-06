﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Threading;

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

        private ResultadoConexion.TipoApertura _Tipo;
        public ResultadoConexion.TipoApertura Tipo
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

        private int _NumeroErrores;
        public int NumeroErrores
        {
            get { return _NumeroErrores; }
            set { _NumeroErrores = value; }
        }

        private Conector _Conector;
        private CancellationToken _CT;
        #endregion

        #region Constructores
        public TareaSentencias(List<Sentencia> aSentencias, ResultadoConexion.TipoApertura aTipo, DatosBase aDatos, Conector aConector, CancellationToken aCT)
        {
            this._CT = aCT;
            this._Sentencias = aSentencias;
            this._Tipo = aTipo;
            this._Datos = aDatos;
            this._Conector = aConector;
            // Registrar la llamada a Dispose si alguien activa el token de cancelar.            
            // this._CT.Register(() => { this.Dispose(); });
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
            int liErrores = 0;

            Log.EscribeLog("3-1-a sqls__:" + this._Sentencias.Count, "TareaSentencia.LanzarConsultas", Log.Tipo.ERROR);

            try
            {
                foreach (Sentencia lSentencia in this._Sentencias)
                {
                    try
                    {
                        if (this._CT.IsCancellationRequested)
                        {
                            // Alguien ha cancelado la ejecucion salir
                            this.Dispose();
                            return;
                        }

                        string lTipo = lSentencia.SQL.Substring(0, 6);
                        lTipo = lTipo.ToLower();
                        if (lTipo == "insert")
                        {
                            int liId = this._Datos.EjecutarNonQueryYObtenerLastId(lSentencia.SQL);
                        }
                        else if (lTipo == "update" || lTipo == "delete")
                        {
                            int lCantidadRegistros = this._Datos.EjecutarEscalar(lSentencia.SQL);
                        }
                        else
                        {
                            if (lSentencia.SQL.Contains(" count("))
                            {
                                int lCantidadRegistros = this._Datos.EjecutarCount(lSentencia.SQL);
                            }
                            else
                            {
                                DataTable lDataTable = this._Datos.ObtenerDataTable(lSentencia.SQL);
                                if (lDataTable == null)
                                {
                                    Log.EscribeLog("UPS !!!", "TareaSentencias.LanzarConsultas", Log.Tipo.ERROR);
                                }
                                else
                                {
                                    int lCantidadRegistros = lDataTable.Rows.Count;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.EscribeLog("UPS. Error [" + ex.Message + "]", "TareaSentencias.LanzarConsultas", Log.Tipo.ERROR);
                        liErrores++;
                        // Incrementar contador errores
                    }

                    if ((this._Tipo & ResultadoConexion.TipoApertura.SENTENCIA) == ResultadoConexion.TipoApertura.SENTENCIA)
                    {
                        this._Datos.Close();
                        this._Datos = DatosBaseFactory.CreateInstance(this._Conector);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.EscribeLog("3-1-c Err:" + ex.Message, "TareaSentencia.LanzarConsultas", Log.Tipo.ERROR);
                Log.EscribeLog("3-1-d _sen:" + this._Sentencias.Count, "TareaSentencia.LanzarConsultas", Log.Tipo.ERROR);
            }

            Log.EscribeLog("3-1-b errores:" + liErrores, "TareaSentencia.LanzarConsultas", Log.Tipo.ERROR);
            this._NumeroErrores = liErrores;
            //this._Datos.Close();
        }
    }
}
