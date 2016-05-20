using System;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Conector", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Conector
    {
        #region Propiedades
        private string _Nombre;
        [XmlAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Tipo;
        [XmlElement("Tipo", Order = 2, IsNullable = false)]
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        private string _CadenaConexion;
        [XmlElement("Cadena", Order = 3, IsNullable = false)]
        public string CadenaConexion
        {
            get { return _CadenaConexion; }
            set { _CadenaConexion = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public Conector()
        {
            this._Nombre = string.Empty;
            this._Tipo = "ODBC";
            this._CadenaConexion = string.Empty;
        }
        public Conector(Conector aItem)
        {
            this._Nombre = aItem._Nombre;
            this._Tipo = aItem._Tipo;
            this._CadenaConexion = aItem._CadenaConexion;
        }
        public Conector(string asNombre, string asTipo, string asCadenaConexion)
        {
            this._Nombre = asNombre;
            this._Tipo = asTipo;
            this._CadenaConexion = asCadenaConexion;
        }
        #endregion

        #region Clone
        public Conector Clone()
        {
            Conector lItem = new Conector(this._Nombre, this._Tipo, this._CadenaConexion);
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
            Conector p = obj as Conector;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._Tipo == p._Tipo && this._CadenaConexion == p._CadenaConexion);
        }

        public bool Equals(Conector p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._Tipo == p._Tipo && this._CadenaConexion == p._CadenaConexion);
        }

        public static bool operator ==(Conector a, Conector b)
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
            return (a._Nombre == b._Nombre && a._Tipo == b._Tipo && a._CadenaConexion == b._CadenaConexion);
        }

        public static bool operator !=(Conector a, Conector b)
        {
            return !(a == b);
        }
        #endregion
        #endregion

        public bool Validar()
        {
            bool lRes = true;

            if (string.IsNullOrEmpty(this._Nombre) || string.IsNullOrEmpty(this._Tipo) || string.IsNullOrEmpty(this._CadenaConexion))
            {
                lRes = false;
            }

            return lRes;
        }
    }
}
