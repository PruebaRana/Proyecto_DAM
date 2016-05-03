using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("ResultadoConexion", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class ResultadoConexion : IDisposable, IEquatable<ResultadoConexion>
    {
        public enum TipoConexion
        {
            BLOQUE = 1,
            HILO = 2,
            SENTENCIA = 4
        };

        #region Propiedades
        private bool disposed = false;
        private TipoConexion _Tipo;
        [XmlAttribute("Tipo")]
        public TipoConexion Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private List<ResultadoHilo> _Hilos;
        [XmlElement("Hilo", Order = 0, IsNullable = false)]
        public List<ResultadoHilo> Hilos
        {
            get { return _Hilos; }
            set { _Hilos = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public ResultadoConexion()
        {
            this._Tipo = TipoConexion.BLOQUE;
            this._Hilos = new List<ResultadoHilo>();
        }
        public ResultadoConexion(ResultadoConexion aItem)
        {
            this._Tipo = aItem._Tipo;
            this._Hilos = aItem._Hilos;
        }
        public ResultadoConexion(TipoConexion aTipo, List<ResultadoHilo> aHilos)
        {
            this._Tipo = aTipo;
            this._Hilos = aHilos;
        }
        #endregion

        #region Clone
        public ResultadoConexion Clone()
        {
            ResultadoConexion lItem = new ResultadoConexion();

            lItem._Tipo = this._Tipo;
            lItem._Hilos = this._Hilos;
            return lItem;
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
                    this._Hilos.Clear();
                    this._Hilos = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~ResultadoConexion()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Equals, == y !=
        public override bool Equals(System.Object obj)
        {
            bool lswIdentico = false;
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            ResultadoConexion p = obj as ResultadoConexion;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._Hilos.Count == p._Hilos.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Hilos.Count; i++)
                {
                    lswIdentico = (this._Hilos[i] != p._Hilos[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Tipo == p._Tipo && lswIdentico);
        }

        public bool Equals(ResultadoConexion p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._Hilos.Count == p._Hilos.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Hilos.Count; i++)
                {
                    lswIdentico = (this._Hilos[i] != p._Hilos[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Tipo == p._Tipo && lswIdentico);
        }

        public static bool operator ==(ResultadoConexion a, ResultadoConexion b)
        {
            bool lswIdentico = false;
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            if (a._Hilos.Count == b._Hilos.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < a._Hilos.Count; i++)
                {
                    lswIdentico = (a._Hilos[i] != b._Hilos[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (a._Tipo == b._Tipo && lswIdentico);
        }

        public static bool operator !=(ResultadoConexion a, ResultadoConexion b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    }
}
