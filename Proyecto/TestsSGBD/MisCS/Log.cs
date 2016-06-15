using System;
using System.IO;

namespace TestsSGBD
{
    /// <summary>Clase  utilizada para guardar logs del servicio</summary>
    /// <remarks>El metodo EscribeLog tiene 4 sobrecargas, para que sea compatible con los Log antiguos, por si se rehusa codigo antiguo.<br />
    /// <c>Nótese que la llamadas se realizan a métodos estáticos.</c><br /><br />
    /// La ruta donde se guarde el log de la aplicacion vendra del parametro de configuracion <see cref="Config.RutaLog"/>
    /// </remarks>
    /// <example> Ejemplo de la linea guardada por el codigo expuesto<br />20100805 12:12:05  DEBUG Servicio SMSParser iniciado.  [Service.OnStart]
    /// <code>Log.EscribeLog("Servicio SMSParser iniciado.", "Service.OnStart", Log.Tipo.DEBUG);</code>
    /// </example>
    public static class Log
    {
        /// <summary>El nivel del tipo de mensajes a guardar en el log</summary>
        /// <remarks><list type="bullet">
        /// <item><term>INFO</term><description>-Mensajes de cada accion que realiza el codigo</description></item>
        /// <item><term>DEBUG</term><description>-Mensajes de debug el flujo del programa</description></item>
        /// <item><term>ERROR</term><description>-Mensajes de error del programa</description></item>
        /// </list></remarks>
        public enum Tipo {
            /// <summary>Mensajes de cada accion que realiza el codigo</summary>
            INFO = 0,
            /// <summary>Mensajes de debug el flujo del programa</summary>
            DEBUG = 1,
            /// <summary>Mensajes de error del programa</summary>
            ERROR = 2 };
        /// <summary>
        /// Escribe el mensaje en el Log de la Aplicación
        /// </summary>
        /// <param name="asMensaje">El mensaje de log.</param>
        /// <returns>String, con la linea de log generada</returns>
        /// <remarks>Se guardaran los mensajes de tipo igual o superior a los que estan configurados en la aplicacion <see cref="Config.TipoLog"/></remarks>
        public static string EscribeLog(string asMensaje)
        {
            return EscribeLog(asMensaje, "", 0);
        }
        /// <summary>Escribe el mensaje en el Log de la Aplicación</summary>
        /// <remarks>Se guardaran los mensajes de tipo igual o superior a los que estan configurados en la aplicacion <see cref="Config.TipoLog"/></remarks>
        /// <returns>String, con la linea de log generada</returns>
        /// <param name="asMensaje">El mensaje de log.</param>
        /// <param name="asSource">El objeto (ej: clase.metodo) que a generado el log.</param>
        public static string EscribeLog(string asMensaje, string asSource)
        {
            return EscribeLog(asMensaje, asSource, 0);
        }
        /// <summary>Escribe el mensaje en el Log de la Aplicación</summary>
        /// <remarks>Se guardaran los mensajes de tipo igual o superior a los que estan configurados en la aplicacion <see cref="Config.TipoLog"/></remarks>
        /// <returns>String, con la linea de log generada</returns>
        /// <param name="asMensaje">El mensaje de log.</param>
        /// <param name="asSource">El objeto (ej: clase.metodo) que a generado el log.</param>
        /// <param name="aiTipo">El tipo de log <see cref="Tipo"/></param>
        public static string EscribeLog(string asMensaje, string asSource, Tipo aiTipo)
        {
            return EscribeLog(asMensaje, asSource, (int)aiTipo);
        }
        /// <summary>Escribe el mensaje en el Log de la Aplicación</summary>
        /// <remarks>Se guardaran los mensajes de tipo igual o superior a los que estan configurados en la aplicacion <see cref="Config.TipoLog"/></remarks>
        /// <returns>String, con la linea de log generada</returns>
        /// <param name="asMensaje">El mensaje de log.</param>
        /// <param name="asSource">El objeto (ej: clase.metodo) que a generado el log.</param>
        /// <param name="aiTipo">El tipo de log (0, 1, 2).</param>
        public static string EscribeLog(string asMensaje, string asSource, int aiTipo)
        {
            string[] lsTipo = new string[] { "INFO", "DEBUG", "ERROR" };
            if (aiTipo >= int.Parse(Config.TipoLog))
            {
                string asMensajeLog = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "  " + lsTipo[aiTipo] + " " + asMensaje + "  [" + asSource + "]";
                string asRuta = Config.RutaLog;
                if (!asRuta.EndsWith(@"\")) { asRuta += @"\"; }
                asRuta += DateTime.Now.ToString("yyyyMMdd") + ".log";
                // Escribimos e mensaje en el log
                lock (typeof(Log))
                {
                    using (StreamWriter sw = new StreamWriter(asRuta, true))
                    {
                        sw.WriteLine(asMensajeLog);
                        sw.Flush();
                        sw.Close();
                    }
                }
                return asMensajeLog;
            }
            else
            {
                return null;
            }
        }
    }
}