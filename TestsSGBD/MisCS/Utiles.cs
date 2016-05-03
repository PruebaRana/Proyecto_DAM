using System;
using System.IO;
using System.Xml.Serialization;

namespace TestsSGBD.MisCS
{
    class Utiles
    {
        public static bool CheckFolder(string asRuta, int aiEsFile = 0)
        {
            bool sw = false;
            try
            {
                string[] lRuta = asRuta.Split(@"\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string lsTempFolder = lRuta[0];
                int liTope = lRuta.Length - (aiEsFile==0? 0: 1);

                for (int i = 1; i < liTope; i++)
                {
                    lsTempFolder += @"\" + lRuta[i];
                    if (!Directory.Exists(lsTempFolder))
                    {
                        Directory.CreateDirectory(lsTempFolder);
                    }
                }

                sw = Directory.Exists(lsTempFolder);
            }
            catch (Exception ex)
            {
                Log.EscribeLog("Al intentar crear la estructura de carpetas [" + asRuta + "], Err [" + ex.Message + "]", "Utiles.CheckFolder", Log.Tipo.ERROR);
            }
            return sw;
        }

        public static bool DeleteFile(string asFile)
        {
            bool sw = false;
            try
            {
                if (File.Exists(asFile))
                {
                    File.Delete(asFile);
                    sw = !File.Exists(asFile);
                }
            }
            catch (Exception ex)
            {
                Log.EscribeLog("Al intentar eliminar el fichero [" + asFile + "], Err [" + ex.Message + "]", "Utiles.DeleteFile", Log.Tipo.ERROR);
            }
            return sw;
        }

        public static string ObjectToString(object aObj)
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
    }
}
