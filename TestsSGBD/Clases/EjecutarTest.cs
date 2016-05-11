using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace TestsSGBD.Clases
{
    public class EjecutarTest
    {
        #region Propiedades
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
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public EjecutarTest()
        {
            this._Conectores = new List<Conector>();
            this._Test = new Test();
            this._Resultados = new List<ResultadoTest>();
        }
        public EjecutarTest(EjecutarTest aItem)
        {
            this._Conectores = aItem._Conectores;
            this._Test = aItem._Test;
            this._Resultados = aItem._Resultados;
        }
        public EjecutarTest(List<Conector> aConectores, Test aTest)
        {
            this._Conectores = aConectores;
            this._Test = aTest;
            this._Resultados = new List<ResultadoTest>();
        }
        #endregion
        #endregion

        public void Ejecutar()
        {
            foreach (Conector lConector in this._Conectores)
            {
                ResultadoTest lNuevoResultadoTest = new ResultadoTest();
                lNuevoResultadoTest.Conector = lConector;
                lNuevoResultadoTest.Fecha = DateTime.Now;
                lNuevoResultadoTest.Nombre = "Resultado_" + this._Test.Nombre + "_" + lNuevoResultadoTest.Fecha.ToString("yyyyMMdd_HHmmss");

                // Comenzamos por la seccion de Creacion.
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
                GC.GetTotalMemory(true);
            }
        }

        private void LanzarBloque(Bloque aBloque, ResultadoConexion aResultadoConexion, Conector aConector)
        {
            for (int i = aBloque.Hilos_Inicio; i <= aBloque.Hilos_Fin; i += aBloque.Hilos_Step)
            {
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
                lListaTareas[i] = new TareaSentencias(lSentencias[i], aTipo, lDB, aConector);
                
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

    }
}
