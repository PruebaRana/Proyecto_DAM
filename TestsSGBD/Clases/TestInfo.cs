using System;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("TestInfo", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class TestInfo : IEquatable<TestInfo>
    {
        #region Propiedades
        private string _Nombre;
        [XmlAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _File;
        [XmlAttribute("File")]
        public string File
        {
            get { return _File; }
            set { _File = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public TestInfo()
        {
        }
        public TestInfo(TestInfo aItem)
        {
            this._Nombre = aItem._Nombre;
            this._File = aItem._File;
        }
        public TestInfo(string asNombre, string asFile)
        {
            this._Nombre = asNombre;
            this._File = asFile;
        }
        #endregion

        #region Clone
        public TestInfo Clone()
        {
            return new TestInfo(this._Nombre, this._File);
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
            TestInfo p = obj as TestInfo;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._File == p._File);
        }

        public bool Equals(TestInfo p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._File == p._File);
        }

        public static bool operator ==(TestInfo a, TestInfo b)
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
            return (a._Nombre == b._Nombre && a._File == b._File);
        }

        public static bool operator !=(TestInfo a, TestInfo b)
        {
            return !(a == b);
        }
        #endregion
        #endregion

    }
}
