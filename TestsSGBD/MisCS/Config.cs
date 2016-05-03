namespace TestsSGBD
{
    /// <summary>Clase de acceso a los parametros de configuracion del servicio</summary>
    /// <remarks>Todos los metodos son estaticos para poder llamarlos sin instanciar a la clase</remarks>
    // Esta clase la tengo que cambiar y acceder a los paremetros como metodos GET y SET.
    public class Config
    {
        public Config() { }

        private static string _rutaApp = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
        /// <summary>La cadena de conexion a la Base de datos</summary>
        /// <remarks>Variable privada, para uso interno de la clase</remarks> 
        private static string _cadenaConexion = null;
        /// <summary>Acceso a la variable privada <see cref="_cadenaConexion"/>.</summary>
        /// <value>La cadena conexion.</value>
        /// <remarks>Propiedad de solo lectura, GET, sin implementar el SET</remarks> 
        public static string CadenaConexion
        {
            get
            {
                if (_cadenaConexion == null)
                    _cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
                return _cadenaConexion;
            }
            set { Config._cadenaConexion = value; }
        }
        /// <summary>Directorio de los logs</summary>
        /// <remarks>Variable privada, para uso interno de la clase</remarks> 
        private static string _rutaLog = null;
        /// <summary>Acceso a la variable privada <see cref="_rutaLog"/>.</summary>
        /// <value>El directorio de los logs.</value>
        /// <remarks>Propiedad de solo lectura, GET, sin implementar el SET</remarks> 
        public static string RutaLog
        {
            get
            {
                if (_rutaLog == null)
                    _rutaLog = System.Configuration.ConfigurationManager.AppSettings["rutaLog"];
                return _rutaLog;
            }
        }
        /// <summary>El tipo de log <see cref="Log.Tipo">Ver Tipo.Log</see></summary>
        /// <remarks>Variable privada, para uso interno de la clase</remarks> 
        private static string _tipoLog;
        /// <summary>Acceso a la variable privada <see cref="_tipoLog"/>.</summary>
        /// <value>El tipo log.</value>
        /// <remarks>Propiedad de solo lectura, GET, sin implementar el SET</remarks> 
        public static string TipoLog
        {
            get
            {
                if (_tipoLog == null)
                {
                    _tipoLog = System.Configuration.ConfigurationManager.AppSettings["tipoLog"];
                    if (_tipoLog == null) _tipoLog = "0";
                    if (int.Parse(_tipoLog) > 2) _tipoLog = "2";
                }
                return _tipoLog;
            }
        }

        /// <summary>Directorio de los ficheros de configuracion</summary>
        /// <remarks>Variable privada, para uso interno de la clase</remarks> 
        private static string _RutaConfiguraciones = null;
        /// <summary>Acceso a la variable privada <see cref="_RutaConfiguraciones"/>.</summary>
        /// <value>El directorio de los ficheros de configuracion.</value>
        /// <remarks>Propiedad de solo lectura, GET, sin implementar el SET</remarks> 
        public static string RutaConfiguraciones
        {
            get
            {
                if (_RutaConfiguraciones == null)
                {
                    string lsRuta = System.Configuration.ConfigurationManager.AppSettings["RutaConfiguraciones"];
                    if (string.IsNullOrEmpty(lsRuta))
                    {
                        lsRuta = Config._rutaApp;
                    }
                    _RutaConfiguraciones = System.IO.Path.Combine(lsRuta, "") + @"\Config";
                }
                return _RutaConfiguraciones;
            }
        }
    }
}
