using System;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("ResultadoHilo", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class ResultadoHilo : IEquatable<ResultadoHilo>
    {
        #region Propiedades
        private int _Cantidad;
        [XmlAttribute("Cantidad")]
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        private long _Tiempo;
        [XmlAttribute("Tiempo")]
        public long Tiempo
        {
            get { return _Tiempo; }
            set { _Tiempo = value; }
        }

        private int _Errores;
        [XmlAttribute("Errores")]
        public int Errores
        {
            get { return _Errores; }
            set { _Errores = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public ResultadoHilo()
        {
        }
        public ResultadoHilo(ResultadoHilo aItem)
        {
            this._Cantidad = aItem._Cantidad;
            this._Tiempo = aItem._Tiempo;
            this._Errores = aItem._Errores;
        }
        public ResultadoHilo(int aiCantidad, int aiTiempo, int aiErrores)
        {
            this._Cantidad = aiCantidad;
            this._Tiempo = aiTiempo;
            this._Errores = aiErrores;
        }
        #endregion

        #region Clone
        public ResultadoHilo Clone()
        {
            ResultadoHilo lItem = new ResultadoHilo();
            lItem._Cantidad = this._Cantidad;
            lItem._Tiempo = this._Tiempo;
            lItem._Errores = this._Errores;
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
            ResultadoHilo p = obj as ResultadoHilo;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Cantidad == p._Cantidad && this._Tiempo == p._Tiempo && this._Errores == p._Errores);
        }

        public bool Equals(ResultadoHilo p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Cantidad == p._Cantidad && this._Tiempo == p._Tiempo && this._Errores == p._Errores);
        }

        public static bool operator ==(ResultadoHilo a, ResultadoHilo b)
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
            return (a._Cantidad == b._Cantidad && a._Tiempo == b._Tiempo && a._Errores == b._Errores);
        }

        public static bool operator !=(ResultadoHilo a, ResultadoHilo b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    }
}
