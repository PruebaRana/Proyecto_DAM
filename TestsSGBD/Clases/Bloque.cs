using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Bloque", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Bloque : IDisposable, IEquatable<Bloque>
    {
        [Flags]
        public enum TipoConexion
        {
            BLOQUE = 1,
            HILO = 2,
            SENTENCIA = 4
        };

        #region Propiedades
        private bool disposed = false; // to detect redundant calls

        private string _Nombre;
        [XmlAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private int _Hilos_Inicio;
        [XmlAttribute("Hilos_Inicio")]
        public int Hilos_Inicio
        {
            get { return _Hilos_Inicio; }
            set { _Hilos_Inicio = value; }
        }

        private int _Hilos_Fin;
        [XmlAttribute("Hilos_Fin")]
        public int Hilos_Fin
        {
            get { return _Hilos_Fin; }
            set { _Hilos_Fin = value; }
        }

        private int _Hilos_Step;
        [XmlAttribute("Hilos_Step")]
        public int Hilos_Step
        {
            get { return _Hilos_Step; }
            set { _Hilos_Step = value; }
        }

        private TipoConexion _Conexion;
        [XmlAttribute("Conexion")]
        public TipoConexion Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private List<Sentencia> _Sentencias;
        [XmlElement("Sentencia", Order = 0, IsNullable = false)]
        public List<Sentencia> Sentencias
        {
            get { return _Sentencias; }
            set { _Sentencias = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public Bloque()
        {
            this._Hilos_Inicio = 1;
            this._Hilos_Fin = 1;
            this._Hilos_Step = 1;
            this._Conexion = TipoConexion.BLOQUE;
            this._Sentencias = new List<Sentencia>();
        }
        public Bloque(Bloque aItem)
        {
            this._Hilos_Inicio = aItem._Hilos_Inicio;
            this._Hilos_Fin = aItem._Hilos_Fin;
            this._Hilos_Step = aItem._Hilos_Step;
            this._Conexion = aItem._Conexion;
            this._Nombre = aItem._Nombre;
            this._Sentencias = aItem._Sentencias;
        }
        public Bloque(string asNombre, List<Sentencia> aSentencias, int aiHilos_Inicio, int aiHilos_Fin, int aiHilos_Step, TipoConexion aConexion)
        {
            this._Hilos_Inicio = aiHilos_Inicio;
            this._Hilos_Fin = aiHilos_Fin;
            this._Hilos_Step = aiHilos_Step;
            this._Conexion = aConexion;
            this._Nombre = asNombre;
            this._Sentencias = aSentencias;
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
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~Bloque()
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
        public Bloque Clone()
        {
            Bloque lItem = new Bloque();

            lItem._Nombre = this._Nombre;
            lItem._Hilos_Inicio = this._Hilos_Inicio;
            lItem._Hilos_Fin = this._Hilos_Fin;
            lItem._Hilos_Step = this._Hilos_Step;
            lItem._Conexion = this._Conexion;
            foreach (Sentencia lItemList in this._Sentencias)
            {
                lItem._Sentencias.Add(lItemList.Clone());
            }

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
            Bloque p = obj as Bloque;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._Sentencias.Count == p._Sentencias.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Sentencias.Count; i++)
                {
                    lswIdentico = (this._Sentencias[i] != p._Sentencias[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Nombre == p._Nombre && lswIdentico && this._Hilos_Inicio == p._Hilos_Inicio && this._Hilos_Fin == p._Hilos_Fin && this._Hilos_Step == p._Hilos_Step && this._Conexion == p._Conexion);
        }

        public bool Equals(Bloque p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._Sentencias.Count == p._Sentencias.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Sentencias.Count; i++)
                {
                    lswIdentico = (this._Sentencias[i] != p._Sentencias[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._Nombre == p._Nombre && lswIdentico && this._Hilos_Inicio == p._Hilos_Inicio && this._Hilos_Fin == p._Hilos_Fin && this._Hilos_Step == p._Hilos_Step && this._Conexion == p._Conexion);
        }

        public static bool operator ==(Bloque a, Bloque b)
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

            if (a._Sentencias.Count == b._Sentencias.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < a._Sentencias.Count; i++)
                {
                    lswIdentico = (a._Sentencias[i] != b._Sentencias[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (a._Nombre == b._Nombre && lswIdentico && a._Hilos_Inicio == b._Hilos_Inicio && a._Hilos_Fin == b._Hilos_Fin && a._Hilos_Step == b._Hilos_Step && a._Conexion == b._Conexion);
        }

        public static bool operator !=(Bloque a, Bloque b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    
        public string SentenciasToString()
        {
            StringBuilder lSentencias = new StringBuilder();

            foreach (Sentencia lItem in Sentencias)
            {
                lSentencias.Append(lItem.SQL).Append(Environment.NewLine);
            }
            
            return lSentencias.ToString();
        }

        public bool Validar()
        {
            bool lRes = true;

            if (string.IsNullOrEmpty(this.Nombre) || this.Sentencias.Count < 1 || this.Hilos_Inicio < 1 || (this.Hilos_Fin < 1 || this.Hilos_Fin < this.Hilos_Fin) || this.Hilos_Step < 1)
            {
                lRes = false;
            }
            if (this.Conexion == 0)
            {
                lRes = false;
            }

            return lRes;
        }

    }
}
