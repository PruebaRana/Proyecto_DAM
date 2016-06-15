using System;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Sentencia", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Sentencia : IEquatable<Sentencia>
    {
        #region Propiedades
        private string _SQL;
        [XmlAttribute("SQL")]
        public string SQL
        {
            get { return _SQL; }
            set { _SQL = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public Sentencia()
        {
        }
        public Sentencia(Sentencia aItem)
        {
            this._SQL = aItem._SQL;
        }
        public Sentencia(string asSQL)
        {
            this._SQL = asSQL;
        }
        #endregion

        #region Clone
        public Sentencia Clone()
        {
            Sentencia lItem = new Sentencia(this._SQL);
            return lItem;
        }
        #endregion

        #region Equals, == y !=
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Sentencia p = obj as Sentencia;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._SQL == p._SQL);
        }

        public bool Equals(Sentencia p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._SQL == p._SQL);
        }

        public static bool operator ==(Sentencia a, Sentencia b)
        {
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

            // Return true if the fields match:
            return (a._SQL == b._SQL);
        }

        public static bool operator !=(Sentencia a, Sentencia b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    }
}
