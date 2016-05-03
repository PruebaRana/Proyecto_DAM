using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("ResultadoBloque", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class ResultadoBloque : IDisposable, IEquatable<ResultadoBloque>
    {
        #region Propiedades
        private bool disposed = false; 
        private string _Nombre;
        [XmlAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private int _NumeroSentencias;
        [XmlAttribute("NumeroSentencias")]
        public int NumeroSentencias
        {
            get { return _NumeroSentencias; }
            set { _NumeroSentencias = value; }
        }

        private List<ResultadoConexion> _Conexiones;
        [XmlElement("Conexion", Order = 0, IsNullable = false)]
        public List<ResultadoConexion> Conexiones
        {
            get { return _Conexiones; }
            set { _Conexiones = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public ResultadoBloque()
        {
            this._Conexiones = new List<ResultadoConexion>();
        }
        public ResultadoBloque(ResultadoBloque aItem)
        {
            this._Nombre = aItem._Nombre;
            this._NumeroSentencias = aItem._NumeroSentencias;
            this._Conexiones = aItem._Conexiones;
        }
        public ResultadoBloque(string asNombre, int aiNumeroSentencias, List<ResultadoConexion> aConexiones)
        {
            this._Nombre = asNombre;
            this._NumeroSentencias = aiNumeroSentencias;
            this._Conexiones = aConexiones;
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
                    this._Conexiones.Clear();
                    this._Conexiones = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~ResultadoBloque()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Clone
        public ResultadoBloque Clone()
        {
            ResultadoBloque lItem = new ResultadoBloque();

            lItem._Nombre = this._Nombre;
            lItem._NumeroSentencias = this._NumeroSentencias;
            lItem._Conexiones = this._Conexiones;
            return lItem;
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
            ResultadoBloque p = obj as ResultadoBloque;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._Conexiones.Count == p._Conexiones.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Conexiones.Count; i++)
                {
                    lswIdentico = (this._Conexiones[i] != p._Conexiones[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._NumeroSentencias == p._NumeroSentencias && lswIdentico);
        }

        public bool Equals(ResultadoBloque p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._Conexiones.Count == p._Conexiones.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Conexiones.Count; i++)
                {
                    lswIdentico = (this._Conexiones[i] != p._Conexiones[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._NumeroSentencias == p._NumeroSentencias && lswIdentico);
        }

        public static bool operator ==(ResultadoBloque a, ResultadoBloque b)
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

            if (a._Conexiones.Count == b._Conexiones.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < a._Conexiones.Count; i++)
                {
                    lswIdentico = (a._Conexiones[i] != b._Conexiones[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (a._Nombre == b._Nombre && a._NumeroSentencias == b._NumeroSentencias && lswIdentico);
        }

        public static bool operator !=(ResultadoBloque a, ResultadoBloque b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    
    }
}
