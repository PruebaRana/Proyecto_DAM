using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Tests", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Tests : IDisposable, IEquatable<Tests>
    {
        #region Propiedades
        private bool disposed = false;
        private string _RutaXML;
        [XmlIgnore]
        public string RutaXML
        {
            get { return this._RutaXML; }
            set { this._RutaXML = value; }
        }

        private List<TestInfo> _TestInfo;
        [XmlElement("TestInfo", Order = 1)]
        public List<TestInfo> TestInfo
        {
            get { return this._TestInfo; }
            set { this._TestInfo = value; }
        }
        #endregion

        #region Constructores, serializacion, clone y comparadores
        #region Constructores
        public Tests()
            : this("", new List<TestInfo>())
        {
        }

        public Tests(string asRutaXML)
            : this(asRutaXML, new List<TestInfo>())
        {
        }

        public Tests(string asRutaXML, List<TestInfo> aItem)
        {
            this._RutaXML = asRutaXML;
            this._TestInfo = aItem;
        }

        public Tests(Tests aItem)
        {
            this._RutaXML = aItem._RutaXML;
            this._TestInfo = aItem._TestInfo;
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
                    this._TestInfo.Clear();
                    this._TestInfo = null;
                }
                // shared cleanup logic
                disposed = true;
            }
        }

        ~Tests()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Serializacion y Operaciones con XML y Ficheros XML
        /// <summary>Metodo encargado de montar la clase desde un XML</summary>
        public bool LoadXML()
        {
            return this.LoadXML(this._RutaXML);
        }
        public bool LoadXML(string asRutaXML)
        {
            bool lswRespuesta = true;
            try
            {
                if (!File.Exists(asRutaXML))
                {
                    // No existe ese fichero
                    Log.EscribeLog("No existe el XML [" + asRutaXML + "]", "Tests.LoadXML", Log.Tipo.INFO);
                    return false;
                }
                Tests lItem = StringToObject(File.ReadAllText(asRutaXML, Encoding.Default));
                //Configuraciones lConf = new Configuraciones();
                //Configuracion.StringToObject(File.ReadAllText(asRutaXML), lConf);

                this._TestInfo = lItem._TestInfo;
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se ha podido parsear el fichero al objeto Conectores [" + asRutaXML + "]", "Tests.LoadXML", Log.Tipo.ERROR);
                lswRespuesta = false;
            }
            return lswRespuesta;
        }

        /// <summary>Metodo que guardara nuestra clase a un XML</summary>
        public void SaveXML()
        {
            this.SaveXML(this._RutaXML);
        }
        public void SaveXML(string asRutaXML)
        {
            try
            {
                File.WriteAllText(asRutaXML, this.ToXML(), Encoding.Default);
                Log.EscribeLog("Datos guardados en disco. XML " + asRutaXML, "Test.SaveXML", Log.Tipo.INFO);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se a podido guardar el XML, " + ex.Message, "Test.SaveXML", Log.Tipo.ERROR);
                throw ex;
            }
        }

        #region XML
        public string ToXML()
        {
            return ObjectToString(this);
        }

        public static Tests StringToObject(string aStr)
        {
            Tests lRes = null;
            try
            {
                //Create our own namespaces for the output 
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value 
                ns.Add("", @"https://pruebarana.dyndns-remote.com/CFGS/DAM");

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Tests));

                System.IO.MemoryStream lMemoryStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(aStr));
                lRes = (Tests)x.Deserialize(lMemoryStream);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("Al intentar serializar un XML al Config. Err[" + ex.Message + "] XML[" + aStr + "]", "Tests.StringToObject", Log.Tipo.ERROR);
            }

            return lRes;
        }

        private static string ObjectToString(object aObj)
        {
            string lsRespuesta = string.Empty;
            //Create our own namespaces for the output 
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //Add an empty namespace and empty value 
            ns.Add("", @"https://pruebarana.dyndns-remote.com/CFGS/DAM");

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(aObj.GetType());

            System.IO.MemoryStream lMemoryStream = new System.IO.MemoryStream();
            x.Serialize(lMemoryStream, aObj, ns);

            lMemoryStream.Position = 0;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(lMemoryStream))
            {
                lsRespuesta = sr.ReadToEnd();
                sr.Close();
            }
            lMemoryStream.Close();
            lMemoryStream.Dispose();

            return lsRespuesta;
        }
        #endregion
        #endregion
        
        #region Clone
        public Tests Clone()
        {
            Tests lItem = new Tests();

            lItem._RutaXML = this._RutaXML;
            foreach (TestInfo lObj in this._TestInfo)
            {
                lItem._TestInfo.Add(lObj.Clone());
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
            Tests p = obj as Tests;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._TestInfo.Count == p._TestInfo.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._TestInfo.Count; i++)
                {
                    lswIdentico = (this._TestInfo[i] != p._TestInfo[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._RutaXML == p._RutaXML && lswIdentico);
        }

        public bool Equals(Tests p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._TestInfo.Count == p._TestInfo.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < this._TestInfo.Count; i++)
                {
                    lswIdentico = (this._TestInfo[i] != p._TestInfo[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (this._RutaXML == p._RutaXML && lswIdentico);
        }

        public static bool operator ==(Tests a, Tests b)
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

            if (a._TestInfo.Count == b._TestInfo.Count)
            {
                lswIdentico = true;
                for (int i = 0; i < a._TestInfo.Count; i++)
                {
                    lswIdentico = (a._TestInfo[i] != b._TestInfo[i]);
                    if (lswIdentico)
                    {
                        break;
                    }
                }
                lswIdentico = !lswIdentico;
            }
            // Return true if the fields match:
            return (a._RutaXML == b._RutaXML && lswIdentico);
        }

        public static bool operator !=(Tests a, Tests b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
        

    }
}
