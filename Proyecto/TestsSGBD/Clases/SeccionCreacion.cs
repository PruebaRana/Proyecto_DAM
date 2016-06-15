using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Seccion", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class SeccionCreacion : Seccion, IEquatable<SeccionCreacion>
    {
        #region Propiedades
        private bool _MantenerEsquema;
        [XmlAttribute("MantenerEsquema")]
        public bool MantenerEsquema
        {
            get { return _MantenerEsquema; }
            set { _MantenerEsquema = value; }
        }
        #endregion
        
        #region Constructores, comparadores, clone
        #region Constructores
        public SeccionCreacion()
        {
            this._MantenerEsquema = false;
        }
        public SeccionCreacion(SeccionCreacion aItem) : base((Seccion)aItem)
        {
            this._MantenerEsquema = aItem._MantenerEsquema;
        }
        public SeccionCreacion(bool aswMantenerEsquema, List<Bloque> aBloques) : base(aBloques)
        {
            this._MantenerEsquema = aswMantenerEsquema;
        }
        #endregion

        #region Clone
        public SeccionCreacion Clone()
        {
            SeccionCreacion lItem = new SeccionCreacion();

            lItem._MantenerEsquema = this._MantenerEsquema;
            foreach (Bloque lItemLista in this.Bloque)
            {
                lItem.Bloque.Add(lItemLista.Clone());
            }

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
            SeccionCreacion p = obj as SeccionCreacion;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._MantenerEsquema == p._MantenerEsquema && (Seccion)this == (Seccion)p);
        }

        public bool Equals(SeccionCreacion p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._MantenerEsquema == p._MantenerEsquema && (Seccion)this == (Seccion)p);
        }

        public static bool operator ==(SeccionCreacion a, SeccionCreacion b)
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
            return (a._MantenerEsquema == b._MantenerEsquema && (Seccion)a == (Seccion)b);
        }

        public static bool operator !=(SeccionCreacion a, SeccionCreacion b)
        {
            return !(a == b);
        }
        #endregion
        
        #endregion
    }
}
