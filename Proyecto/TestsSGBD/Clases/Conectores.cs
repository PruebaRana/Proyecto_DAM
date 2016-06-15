using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TestsSGBD.MisCS;

namespace TestsSGBD.Clases
{
    [Serializable]
    [XmlRoot("Conectores", IsNullable = true, Namespace = @"https://pruebarana.dyndns-remote.com/CFGS/DAM")]
    public class Conectores : IEquatable<Conectores>
    {
        #region Propiedades
        private string _RutaXML;
        [XmlIgnore]
        public string RutaXML
        {
            get { return this._RutaXML; }
            set { this._RutaXML = value; }
        }

        private List<Conector> _Conector;
        [XmlElement("Conector", Order = 1)]
        public List<Conector> Conector
        {
            get { return this._Conector; }
            set { this._Conector = value; }
        }
        #endregion

        #region Constructores, serializacion, clone y comparadores
        #region Constructores
        public Conectores() : this("")
        {

        }
        public Conectores(string asRutaXML)
        {
            this._RutaXML = asRutaXML;
            this._Conector = new List<Conector>();
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
                    Log.EscribeLog("No existe el XML [" + asRutaXML + "]", "Conectores.LoadXML", Log.Tipo.INFO);
                    return false;
                }
                Conectores lConectores = StringToObject(File.ReadAllText(asRutaXML, Encoding.Default));
                //Configuraciones lConf = new Configuraciones();
                //Configuracion.StringToObject(File.ReadAllText(asRutaXML), lConf);

                this._Conector = lConectores.Conector;
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se ha podido parsear el fichero al objeto Conectores [" + asRutaXML + "]", "Conectores.LoadXML", Log.Tipo.ERROR);
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
                Log.EscribeLog("Datos guardados en disco. XML " + asRutaXML, "Conectores.SaveXML", Log.Tipo.INFO);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("No se a podido guardar el XML, " + ex.Message, "Conectores.SaveXML", Log.Tipo.ERROR);
                throw ex;
            }
        }

        #region XML
        public string ToXML()
        {
            return Utiles.ObjectToString(this);
        }

        public static Conectores StringToObject(string aStr)
        {
            Conectores lRes = null;
            try
            {
                //Create our own namespaces for the output 
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value 
                ns.Add("", @"https://pruebarana.dyndns-remote.com/CFGS/DAM");

                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Conectores));

                System.IO.MemoryStream lMemoryStream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(aStr));
                lRes = (Conectores)x.Deserialize(lMemoryStream);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("Al intentar serializar un XML al Config. Err[" + ex.Message + "] XML[" + aStr + "]", "Conectores.StringToObject", Log.Tipo.ERROR);
            }

            return lRes;
        }
        #endregion
        #endregion

        #region Clone
        public Conectores Clone()
        {
            Conectores lItem = new Conectores();

            lItem.RutaXML = this.RutaXML;
            foreach (Conector lObj in this._Conector)
            {
                lItem.Conector.Add(lObj.Clone());
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
            Conectores p = obj as Conectores;
            if ((System.Object)p == null)
            {
                return false;
            }

            if (this._Conector.Count == p._Conector.Count)
            {
                lswIdentico = true;
                if (this._Conector.Count > 0)
                {
                    for (int i = 0; i < this._Conector.Count; i++)
                    {
                        lswIdentico = (this._Conector[i] != p._Conector[i]);
                        if (lswIdentico)
                        {
                            break;
                        }
                    }
                    lswIdentico = !lswIdentico;
                }
            }
            // Return true if the fields match:
            return (this._RutaXML == p._RutaXML && lswIdentico);
        }

        public bool Equals(Conectores p)
        {
            bool lswIdentico = false;
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            if (this._Conector.Count == p._Conector.Count)
            {
                lswIdentico = true;
                if (this._Conector.Count > 0)
                {
                    for (int i = 0; i < this._Conector.Count; i++)
                    {
                        lswIdentico = (this._Conector[i] != p._Conector[i]);
                        if (lswIdentico)
                        {
                            break;
                        }
                    }
                    lswIdentico = !lswIdentico;
                }
            }
            // Return true if the fields match:
            return (this._RutaXML == p._RutaXML && lswIdentico);
        }

        public static bool operator ==(Conectores a, Conectores b)
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

            if (a._Conector.Count == b._Conector.Count)
            {
                lswIdentico = true;
                if (a._Conector.Count > 0)
                {
                    for (int i = 0; i < a._Conector.Count; i++)
                    {
                        lswIdentico = (a._Conector[i] != b._Conector[i]);
                        if (lswIdentico)
                        {
                            break;
                        }
                    }
                    lswIdentico = !lswIdentico;
                }
            }
            // Return true if the fields match:
            return (a._RutaXML == b._RutaXML && lswIdentico);
        }

        public static bool operator !=(Conectores a, Conectores b)
        {
            return !(a == b);
        }
        #endregion
        #endregion
    }
}
