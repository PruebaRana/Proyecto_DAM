using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("ResultadoSeccion", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class ResultadoSeccion : IDisposable, IEquatable<ResultadoSeccion>
    {
        #region Propiedades
        private bool disposed = false; // to detect redundant calls

        private List<ResultadoBloque> _Bloque;
        [XmlElement("Bloque", Order = 0, IsNullable = false)]
        public List<ResultadoBloque> Bloque
        {
            get { return _Bloque; }
            set { _Bloque = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public ResultadoSeccion()
        {
            this._Bloque = new List<ResultadoBloque>();
        }
        public ResultadoSeccion(ResultadoSeccion aItem)
        {
            this._Bloque = aItem._Bloque;
        }
        public ResultadoSeccion(List<ResultadoBloque> aBloques)
        {
            this._Bloque = aBloques;
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
                    this._Bloque.Clear();
                    this._Bloque = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~ResultadoSeccion()
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
        public ResultadoSeccion Clone()
        {
            ResultadoSeccion lItem = new ResultadoSeccion();

            foreach (ResultadoBloque lItemLista in this._Bloque)
            {
                lItem._Bloque.Add(lItemLista.Clone());
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
            ResultadoSeccion p = obj as ResultadoSeccion;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._Bloque.Count == p._Bloque.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Bloque.Count; i++)
                {
                    lswIdentico = (this._Bloque[i] != p._Bloque[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }

            // Return true if the fields match:
            return (lswIdentico);
        }

        public bool Equals(ResultadoSeccion p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._Bloque.Count == p._Bloque.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._Bloque.Count; i++)
                {
                    lswIdentico = (this._Bloque[i] != p._Bloque[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }

            // Return true if the fields match:
            return (lswIdentico);
        }

        public static bool operator ==(ResultadoSeccion a, ResultadoSeccion b)
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

            if (a._Bloque.Count == b._Bloque.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < a._Bloque.Count; i++)
                {
                    lswIdentico = (a._Bloque[i] != b._Bloque[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }

            // Return true if the fields match:
            return (lswIdentico);
        }

        public static bool operator !=(ResultadoSeccion a, ResultadoSeccion b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    }
}
