using System.Collections.Generic;
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
        public EjecucionTest(List<Conector> aConectores, Test aTest)
        {
            this._Conectores = aConectores;
            this._Test = aTest;
            this._Resultados = new List<ResultadoTest>();

            this._PasosTotales = this.ContarRepeticionesTest() * this._Conectores.Count;
            this._PasosActual = 0;
        }

        private int ContarRepeticionesTest()
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

        public void Ejecutar()
        {
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
                        foreach (Sentencia lSentencia in lBloqueCreacion.Sentencias)
                        {

                        }
                    }

                    // Insercion
                    lNuevoResultadoTest.Insercion = new ResultadoSeccion();
                    foreach (Bloque lBloque in this._Test.Insercion.Bloque)
                    {
                        //
                        ResultadoBloque lResultadoBloque = new ResultadoBloque();
                        lResultadoBloque.Nombre = lBloque.Nombre;
                        lResultadoBloque.NumeroSentencias = lBloque.Sentencias.Count;

                        if ((lBloque.Conexion & Bloque.TipoConexion.BLOQUE) == Bloque.TipoConexion.BLOQUE)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.BLOQUE;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.HILO) == Bloque.TipoConexion.HILO)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.HILO;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.SENTENCIA) == Bloque.TipoConexion.SENTENCIA)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.SENTENCIA;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        lNuevoResultadoTest.Insercion.Bloque.Add(lResultadoBloque);
                    }

                    // Consulta
                    lNuevoResultadoTest.Consulta = new ResultadoSeccion();
                    foreach (Bloque lBloque in this._Test.Consulta.Bloque)
                    {
                        //
                        ResultadoBloque lResultadoBloque = new ResultadoBloque();
                        lResultadoBloque.Nombre = lBloque.Nombre;
                        lResultadoBloque.NumeroSentencias = lBloque.Sentencias.Count;

                        if ((lBloque.Conexion & Bloque.TipoConexion.BLOQUE) == Bloque.TipoConexion.BLOQUE)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.BLOQUE;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.HILO) == Bloque.TipoConexion.HILO)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.HILO;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.SENTENCIA) == Bloque.TipoConexion.SENTENCIA)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.SENTENCIA;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        lNuevoResultadoTest.Consulta.Bloque.Add(lResultadoBloque);
                    }

                    // Borrado
                    lNuevoResultadoTest.Borrado = new ResultadoSeccion();
                    foreach (Bloque lBloque in this._Test.Borrado.Bloque)
                    {
                        //
                        ResultadoBloque lResultadoBloque = new ResultadoBloque();
                        lResultadoBloque.Nombre = lBloque.Nombre;
                        lResultadoBloque.NumeroSentencias = lBloque.Sentencias.Count;

                        if ((lBloque.Conexion & Bloque.TipoConexion.BLOQUE) == Bloque.TipoConexion.BLOQUE)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.BLOQUE;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.HILO) == Bloque.TipoConexion.HILO)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.HILO;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        if ((lBloque.Conexion & Bloque.TipoConexion.SENTENCIA) == Bloque.TipoConexion.SENTENCIA)
                        {
                            ResultadoConexion lResultadoConexion = new ResultadoConexion();
                            lResultadoConexion.Tipo = ResultadoConexion.TipoConexion.SENTENCIA;
                            LanzarBloque(lBloque, lResultadoConexion, lConector);
                            lResultadoBloque.Conexiones.Add(lResultadoConexion);
                        }

                        lNuevoResultadoTest.Borrado.Bloque.Add(lResultadoBloque);
                    }

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

                LanzarInformacionComienzoBloque("Bloque: " + aBloque.Nombre + ", hilos: " + i + " por " + aResultadoConexion.Tipo);
                Thread.Sleep(200);

                ResultadoHilo lResultadoHilo = new ResultadoHilo();
                lResultadoHilo.Cantidad = i;

                //DatosBase lDatos = DatosBaseFactory.CreateInstance(aConector);
                //lDatos.Open();

                LanzarSentencias(aBloque.Sentencias, lResultadoHilo, aResultadoConexion.Tipo, aConector);

                //lDatos.Close();

                aResultadoConexion.Hilos.Add(lResultadoHilo);
            }
            GC.GetTotalMemory(true);
        }

        private void LanzarSentencias(List<Sentencia> aSentencias, ResultadoHilo aResultadoHilo, ResultadoConexion.TipoConexion aTipo, Conector aConector)
        {
            Stopwatch lCrono = new Stopwatch();
            lCrono.Start();
            int lsCantidadHilos = aResultadoHilo.Cantidad;
            Task[] lTask = new Task[lsCantidadHilos];
            List<Sentencia>[] lSentencias = new List<Sentencia>[lsCantidadHilos];
            TareaSentencias[] lListaTareas = new TareaSentencias[lsCantidadHilos];

            // Cargar las sentencias
            int j = 0;
            for (int i = 0; i < lsCantidadHilos; i++)
            {
                lSentencias[i] = new List<Sentencia>();
            }
            for (int i = 0; i < aSentencias.Count; i++)
            {
                lSentencias[j].Add(new Sentencia(aSentencias[i].SQL));
                j++;
                if (j > lsCantidadHilos - 1)
                {
                    j = 0;
                }
            }

            DatosBase lDBGenerico = DatosBaseFactory.CreateInstance(aConector);
            for (int i = 0; i < lsCantidadHilos; i++)
            {
                DatosBase lDB;
                if ((aTipo & ResultadoConexion.TipoConexion.BLOQUE) == ResultadoConexion.TipoConexion.BLOQUE)
                {
                    lDB = lDBGenerico;
                }
                else
                {
                    lDB = DatosBaseFactory.CreateInstance(aConector);
                }
                //DatosBase lDB = DatosBaseFactory.CreateInstance(aConector);
                lListaTareas[i] = new TareaSentencias(lSentencias[i], aTipo, lDB, aConector, this._TokenSource.Token);
                
                Task lTarea = new Task(lListaTareas[i].LanzarConsultas);
                lListaTareas[i].Task = lTarea;
                lTask[i] = lTarea;
                lTarea.Start();
            }

            Task.WaitAll(lTask);

            //Liberar recursos
            int liNumeroErrores = 0;
            foreach (TareaSentencias lItem in lListaTareas)
            {
                liNumeroErrores += lItem.NumeroErrores;
                lItem.Dispose();
            }
            if ((aTipo & ResultadoConexion.TipoConexion.BLOQUE) == ResultadoConexion.TipoConexion.BLOQUE)
            {
                lDBGenerico.Close();
            }
            
            lCrono.Stop();
            aResultadoHilo.Tiempo = lCrono.ElapsedMilliseconds;
            aResultadoHilo.Errores = liNumeroErrores;
            GC.Collect();
            GC.GetTotalMemory(true);
        }

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
