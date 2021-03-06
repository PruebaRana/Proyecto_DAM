﻿using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using TestsSGBD.MisCS;

namespace TestsSGBD.Clases
{
    public class EjecucionTest : IDisposable
    {
        #region Eventos y Delegados
        public delegate void MyEventHandler(object m, MyEventArgs e);
        // Evento para mandar mensajes hacia arriba            
        public event MyEventHandler NotificarAccion;
        #endregion

        #region Propiedades
        #region Patron Singleton
        private static volatile EjecucionTest instance;
        private static object syncRoot = new Object();
        #endregion

        private bool disposed = false;

        private List<Conector> _Conectores;
        public List<Conector> Conectores
        {
            get { return _Conectores; }
            set { _Conectores = value; }
        }

        private Test _Test;
        public Test Test
        {
            get { return _Test; }
            set { _Test = value; }
        }

        private List<ResultadoTest> _Resultados;
        public List<ResultadoTest> Resultados
        {
            get { return _Resultados; }
            set { _Resultados = value; }
        }

        private bool _EnProceso;
        public bool EnProceso
        {
            get { return _EnProceso; }
        }

        private CancellationTokenSource _TokenSource;
        private int _PasosTotales;
        public int PasosTotales
        {
            get { return _PasosTotales; }
        }
        private int _PasosActual;
        public int PasosActual
        {
            get { return _PasosActual; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        private EjecucionTest(List<Conector> aConectores, Test aTest)
        {
            this.asignarConectoresYTest(aConectores, aTest);
        }

        //Metodo estático que devuelve una única instancia de "EjecucionTest" patron singleton
        public static EjecucionTest GetInstance(List<Conector> aConectores, Test aTest)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new EjecucionTest(aConectores, aTest);
                    }
                }
            }
            else
            {
                instance.asignarConectoresYTest(aConectores, aTest);
            }

            return instance;
        }

        private void asignarConectoresYTest(List<Conector> aConectores, Test aTest)
        {
            this._Conectores = aConectores;
            this._Test = aTest;
            this._Resultados = new List<ResultadoTest>();

            this._PasosActual = 0;
            this._PasosTotales = this.ContarRepeticiones() * this._Conectores.Count;
        }
        private int ContarRepeticiones()
        {
            int liCantidad = 0;
            liCantidad += ContarRepeticionesListaBloques(this._Test.Creacion);
            liCantidad += ContarRepeticionesListaBloques(this._Test.Insercion);
            liCantidad += ContarRepeticionesListaBloques(this._Test.Consulta);
            liCantidad += ContarRepeticionesListaBloques(this._Test.Borrado);

            return liCantidad;
        }
        private int ContarRepeticionesListaBloques(Seccion aLista)
        {
            int liCantidad = 0;
            foreach (Bloque lItem in aLista.Bloque)
            {
                liCantidad += ContarRepeticionesBloque(lItem);
            }
            return liCantidad;
        }
        private int ContarRepeticionesBloque(Bloque aBloque)
        {
            int liCantidad = 0 + (aBloque.Conexion.HasFlag(Bloque.TipoConexion.BLOQUE) ? 1 : 0) + (aBloque.Conexion.HasFlag(Bloque.TipoConexion.HILO) ? 1 : 0) + (aBloque.Conexion.HasFlag(Bloque.TipoConexion.SENTENCIA) ? 1 : 0);
            int liRepeticones = ( ( (aBloque.Hilos_Fin - aBloque.Hilos_Inicio) / aBloque.Hilos_Step) + 1 ) * liCantidad;

            return liRepeticones;
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
                    this._Conectores.Clear();
                    this._Conectores = null;
                    this._Test.Dispose();
                    this._Test = null;
                    this._Resultados.Clear();
                    this._Resultados = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~EjecucionTest()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion

        #region Ejecutar / Cancelar proceso
        public void Ejecutar()
        {
            this._PasosActual = 0;

            this._TokenSource = new CancellationTokenSource();
            Task lTaskTest = new Task(ProcesarTest);
            lTaskTest.Start();
            
            // Registrar la llamada a Dispose si alguien activa el token de cancelar.            
            //this._CT.Register(() => { this.Dispose(); });
        }
        public void CancelarEjecucion()
        {
            this._TokenSource.Cancel();
        }

        private void ProcesarTest()
        {
            try
            {
                this._EnProceso = true;
                foreach (Conector lConector in this._Conectores)
                {
                    ResultadoTest lNuevoResultadoTest = new ResultadoTest();
                    lNuevoResultadoTest.Conector = lConector;
                    lNuevoResultadoTest.Fecha = DateTime.Now;
                    lNuevoResultadoTest.Nombre = "Resultado_" + this._Test.Nombre + "_" + lNuevoResultadoTest.Fecha.ToString("yyyyMMdd_HHmmss");

                    // Comenzamos por la seccion de Creacion.
                    this.MandaAccion("Seccion Creacion");
                    foreach (Bloque lBloqueCreacion in this._Test.Creacion.Bloque)
                    {
                        ResultadoConexion lResultadoConexion = new ResultadoConexion();
                        lResultadoConexion.Tipo = ResultadoConexion.TipoApertura.BLOQUE;
                        LanzarBloque(lBloqueCreacion, lResultadoConexion, lConector);
                    }

                    // Insercion
                    lNuevoResultadoTest.Insercion = new ResultadoSeccion();
                    lNuevoResultadoTest.Insercion.Bloque = this.procesaSeccion(lConector, this._Test.Insercion);
                    // Consulta
                    lNuevoResultadoTest.Consulta = new ResultadoSeccion();
                    lNuevoResultadoTest.Consulta.Bloque = this.procesaSeccion(lConector, this._Test.Consulta);
                    // Insercion
                    lNuevoResultadoTest.Borrado = new ResultadoSeccion();
                    lNuevoResultadoTest.Borrado.Bloque = this.procesaSeccion(lConector, this._Test.Borrado);

                    lNuevoResultadoTest.SaveXML();
                }
                
            }
            catch (Exception ex)
            {

                string ll = ex.Message;

            }
            finally
            {
                this.MandaAccion("Finaliza el test");
                GC.GetTotalMemory(true);
                this._EnProceso = false;
            }
        }
        private List<ResultadoBloque> procesaSeccion(Conector aConector, Seccion aSeccion)
        {
            List<ResultadoBloque> lResultadosBloques = new List<ResultadoBloque>();
            // Recorro los bloques
            foreach (Bloque lBloque in aSeccion.Bloque)
            {
                //
                ResultadoBloque lResultadoBloque = new ResultadoBloque();
                lResultadoBloque.Nombre = lBloque.Nombre;
                lResultadoBloque.NumeroSentencias = lBloque.Sentencias.Count;
                Log.EscribeLog("Bloque: " + lBloque.Nombre + "[" + lBloque.Sentencias.Count + "]", "EjecucionTest.procesaSeccion", Log.Tipo.ERROR);

                if ((lBloque.Conexion & Bloque.TipoConexion.BLOQUE) == Bloque.TipoConexion.BLOQUE)
                {
                    ResultadoConexion lResultadoConexion = new ResultadoConexion();
                    lResultadoConexion.Tipo = ResultadoConexion.TipoApertura.BLOQUE;
                    LanzarBloque(lBloque, lResultadoConexion, aConector);
                    lResultadoBloque.Conexiones.Add(lResultadoConexion);
                }

                if ((lBloque.Conexion & Bloque.TipoConexion.HILO) == Bloque.TipoConexion.HILO)
                {
                    ResultadoConexion lResultadoConexion = new ResultadoConexion();
                    lResultadoConexion.Tipo = ResultadoConexion.TipoApertura.HILO;
                    LanzarBloque(lBloque, lResultadoConexion, aConector);
                    lResultadoBloque.Conexiones.Add(lResultadoConexion);
                    
                    Log.EscribeLog("4", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);
                }

                if ((lBloque.Conexion & Bloque.TipoConexion.SENTENCIA) == Bloque.TipoConexion.SENTENCIA)
                {
                    ResultadoConexion lResultadoConexion = new ResultadoConexion();
                    lResultadoConexion.Tipo = ResultadoConexion.TipoApertura.SENTENCIA;
                    LanzarBloque(lBloque, lResultadoConexion, aConector);
                    lResultadoBloque.Conexiones.Add(lResultadoConexion);
                }

                lResultadosBloques.Add(lResultadoBloque);

                Log.EscribeLog("5", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);
            }
            return lResultadosBloques;
        }
        
        
        private void LanzarBloque(Bloque aBloque, ResultadoConexion aResultadoConexion, Conector aConector)
        {
            for (int i = aBloque.Hilos_Inicio; i <= aBloque.Hilos_Fin; i += aBloque.Hilos_Step)
            {
                if (this._TokenSource.IsCancellationRequested)
                {
                    // Alguien ha cancelado la ejecucion salir
                    this.Dispose();
                    this._TokenSource.Token.ThrowIfCancellationRequested();
                }

                Log.EscribeLog("LanzarBloque. [b=" + aBloque.Nombre + "] [h=" + i + "] [p=" + aResultadoConexion.Tipo + "]", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);
                LanzarInformacionComienzoBloque("Bloque: " + aBloque.Nombre + ", hilos: " + i + " por " + aResultadoConexion.Tipo);
                Thread.Sleep(20);

                ResultadoHilo lResultadoHilo = new ResultadoHilo();
                lResultadoHilo.Cantidad = i;

                Log.EscribeLog("1", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);
                
                LanzarSentencias(aBloque.Sentencias, lResultadoHilo, aResultadoConexion.Tipo, aConector);

                Log.EscribeLog("2", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);

                aResultadoConexion.Hilos.Add(lResultadoHilo);

                Log.EscribeLog("3", "EjecucionTest.LanzarBloque", Log.Tipo.ERROR);
            }
            GC.GetTotalMemory(true);
        }

        private void LanzarSentencias(List<Sentencia> aSentencias, ResultadoHilo aResultadoHilo, ResultadoConexion.TipoApertura aTipo, Conector aConector)
        {
            Stopwatch lCrono = new Stopwatch();
            lCrono.Start();
            int lsCantidadHilos = aResultadoHilo.Cantidad;
            Task[] lTask = new Task[lsCantidadHilos];
            List<Sentencia>[] lSentencias = new List<Sentencia>[lsCantidadHilos];
            TareaSentencias[] lListaTareas = new TareaSentencias[lsCantidadHilos];

            Log.EscribeLog("1 - h:" + lsCantidadHilos, "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
            // Cargar las sentencias
            int j = 0;
            for (int i = 0; i < lsCantidadHilos; i++)
            {
                lSentencias[i] = new List<Sentencia>();
            }
            Log.EscribeLog("2 - n:" + aSentencias.Count, "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
            for (int i = 0; i < aSentencias.Count; i++)
            {
                lSentencias[j].Add(new Sentencia(aSentencias[i].SQL));
                j++;
                if (j > lsCantidadHilos - 1)
                {
                    j = 0;
                }
            }

            Log.EscribeLog("3 - c:" + aConector.Tipo, "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
            DatosBase lDBGenerico = DatosBaseFactory.CreateInstance(aConector);
            for (int i = 0; i < lsCantidadHilos; i++)
            {
                Log.EscribeLog("3-1 h:" + i + " T: " + aTipo + " - c:" + aConector.Tipo, "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
                DatosBase lDB;
                if ((aTipo & ResultadoConexion.TipoApertura.BLOQUE) == ResultadoConexion.TipoApertura.BLOQUE)
                {
                    lDB = lDBGenerico;
                }
                else
                {
                    lDB = DatosBaseFactory.CreateInstance(aConector);
                }
                //DatosBase lDB = DatosBaseFactory.CreateInstance(aConector);
                lListaTareas[i] = new TareaSentencias(lSentencias[i], aTipo, lDB, aConector, this._TokenSource.Token);

                Log.EscribeLog("3-1 h:" + i + " Se crea la tarea y se llama", "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);

                Task lTarea = new Task(lListaTareas[i].LanzarConsultas);
                lListaTareas[i].Task = lTarea;
                lTask[i] = lTarea;
                lTarea.Start();
            }

            Task.WaitAll(lTask);

            Log.EscribeLog("4 - c:" + aConector.Tipo, "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
            //Liberar recursos
            int liNumeroErrores = 0;
            foreach (TareaSentencias lItem in lListaTareas)
            {
                liNumeroErrores += lItem.NumeroErrores;
                lItem.Dispose();
            }
            if ((aTipo & ResultadoConexion.TipoApertura.BLOQUE) == ResultadoConexion.TipoApertura.BLOQUE)
            {
                lDBGenerico.Close();
            }
            
            lCrono.Stop();
            aResultadoHilo.Tiempo = lCrono.ElapsedMilliseconds;
            aResultadoHilo.Errores = liNumeroErrores;
            Log.EscribeLog("EjecucionTest. [T=" + lCrono.ElapsedMilliseconds + "] [E=" + liNumeroErrores + "]", "EjecucionTest.LanzarSentencias", Log.Tipo.ERROR);
            GC.Collect();
            GC.GetTotalMemory(true);
        }
        #endregion


        private void LanzarInformacionComienzoBloque(string asTexto)
        {
            this._PasosActual++;
            MandaAccion(asTexto);
        }
        private void MandaAccion(string asTexto)
        {
            if (this.NotificarAccion != null)
            {
                this.NotificarAccion(this, new MyEventArgs(asTexto));
            }
        }
    }
}
