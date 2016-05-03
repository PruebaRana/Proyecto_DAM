using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TestsSGBD.MisCS;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Test", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Test : IDisposable, IEquatable<Test>
    {
        #region Propiedades
        private bool disposed = false; // to detect redundant calls
        private string _RutaXML;
        [XmlIgnore]
        public string RutaXML
        {
            get { return this._RutaXML; }
            set { this._RutaXML = value; }
        }

        private string _Nombre;
        [XmlAttribute("Nombre")]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private SeccionCreacion _Creacion;
        [XmlElement("Creacion", Order = 0, IsNullable = false)]
        public SeccionCreacion Creacion
        {
            get { return _Creacion; }
            set { _Creacion = value; }
        }

        private Seccion _Insercion;
        [XmlElement("Insercion", Order = 1, IsNullable = false)]
        public Seccion Insercion
        {
            get { return _Insercion; }
            set { _Insercion = value; }
        }

        private Seccion _Consulta;
        [XmlElement("Consulta", Order = 2, IsNullable = false)]
        public Seccion Consulta
        {
            get { return _Consulta; }
            set { _Consulta = value; }
        }

        private Seccion _Borrado;
        [XmlElement("Borrado", Order = 3, IsNullable = false)]
        public Seccion Borrado
        {
            get { return _Borrado; }
            set { _Borrado = value; }
        }
        #endregion

        #region Constructores, comparadores, clone
        #region Constructores
        public Test()
        {
            this._Creacion = new SeccionCreacion();
            this._Insercion = new Seccion();
            this._Consulta = new Seccion();
            this._Borrado = new Seccion();
        }
        public Test(Test aItem)
        {
            this._Nombre = aItem._Nombre;
            this._Creacion = aItem._Creacion;
            this._Insercion = aItem._Insercion;
            this._Consulta = aItem._Consulta;
            this._Borrado = aItem._Borrado;
        }
        public Test(string asNombre, SeccionCreacion aCreacion, Seccion aInsercion, Seccion aConsulta, Seccion aBorrado)
        {
            this._Nombre = asNombre;
            this._Creacion = aCreacion;
            this._Insercion = aInsercion;
            this._Consulta = aConsulta;
            this._Borrado = aBorrado;
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
                    this._Creacion.Dispose();
                    this._Insercion.Dispose();
                    this._Consulta.Dispose();
                    this._Borrado.Dispose();
                    this._Creacion = null;
                    this._Insercion = null;
                    this._Consulta = null;
                    this._Borrado = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~Test()
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
        public Test Clone()
        {
            Test lItem = new Test();

            lItem._Nombre = this._Nombre;
            lItem._Creacion = this._Creacion.Clone();
            lItem._Insercion = this._Insercion.Clone();
            lItem._Consulta = this._Consulta.Clone();
            lItem._Borrado = this._Borrado.Clone();

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
            Test p = obj as Test;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._Creacion == p._Creacion && this._Insercion == p._Insercion && this._Consulta == p._Consulta && this._Borrado == p._Borrado);
        }

        public bool Equals(Test p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this._Nombre == p._Nombre && this._Creacion == p._Creacion && this._Insercion == p._Insercion && this._Consulta == p._Consulta && this._Borrado == p._Borrado);
        }

        public static bool operator ==(Test a, Test b)
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
            return (a._Nombre == b._Nombre && a._Creacion == b._Creacion && a._Insercion == b._Insercion && a._Consulta == b._Consulta && a._Borrado == b._Borrado);
        }

        public static bool operator !=(Test a, Test b)
        {
            return !(a == b);
        }
        #endregion
        #endregion

        #region Serializacion y Operaciones con XML y Ficheros XML
        /// <summary>Metodo encargado de montar la clase desde un XML</summary>
        public bool LoadXML()
        {
            string lsFile = Path.Combine(Config.RutaConfiguraciones, this.Nombre) + ".XML";
            return this.LoadXML(lsFile);
        }
        public bool LoadXML(string asRutaXML)
        {
            bool lswRespuesta = true;
            try
            {
                if (!File.Exists(asRutaXML))
                {
                    // No existe ese fichero
                    Log.EscribeLog("No existe el XML [" + asRutaXML + "]", "Test.LoadXML", Log.Tipo.INFO);
                    return false;
                }
                Test lItem = StringToObject(File.ReadAllText(asRutaXML, Encoding.Default));
                //Configuraciones lConf = new Configuraciones();
                //Configuracion.StringToObject(File.ReadAllText(asRutaXML), lConf);
                this._RutaXML = asRutaXML;
                this._Nombre = lItem.Nombre;
                this._Creacion = lItem._Creacion;
                this._Insercion = lItem._Insercion;
                this._Consulta = lItem._Consulta;
                this._Borrado = lItem._Borrado;
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se ha podido parsear el fichero al objeto Conectores [" + asRutaXML + "]", "Test.LoadXML", Log.Tipo.ERROR);
                lswRespuesta = false;
            }
            return lswRespuesta;
        }

        /// <summary>Metodo que guardara nuestra clase a un XML</summary>
        public void SaveXML()
        {
            string lsFile = Path.Combine(Config.RutaConfiguraciones, this.Nombre) + ".XML";
            this.SaveXML(lsFile);
        }
        public void SaveXML(string asRutaXML)
        {
            try
            {
                // Antes que nada Validar los datos minimos
                if (!Validar())
                {
                    throw new Exception("The data is not valid or missing");
                }

                File.WriteAllText(asRutaXML, this.ToXML(), Encoding.Default);
                this._RutaXML = asRutaXML;
                Log.EscribeLog("Datos guardados en disco. XML " + asRutaXML, "Test.SaveXML", Log.Tipo.INFO);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se a podido guardar el XML, " + ex.Message, "Test.SaveXML", Log.Tipo.ERROR);
                throw ex;
            }
        }

        public bool Validar()
        {
            bool lRes = true;

            if (string.IsNullOrEmpty(this.Nombre))
            {
                lRes = false;
            }

            return lRes;
        }

        #region XML
        public string ToXML()
        {
            return Utiles.ObjectToString(this);
        }

        public static Test StringToObject(string aStr)
        {
            Test lRes = null;
            try
            {
                //Create our own namespaces for the output 
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value 
                ns.Add("", @"https://pruebarana.dyndns-remote.com/CFGS/DAM");

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Test));

                System.IO.MemoryStream lMemoryStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(aStr));
                lRes = (Test)x.Deserialize(lMemoryStream);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("Al intentar serializar un XML al Test. Err[" + ex.Message + "] XML[" + aStr + "]", "Test.StringToObject", Log.Tipo.ERROR);
            }

            return lRes;
        }
        #endregion
        #endregion
    }
}