using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsSGBD.Clases
{
    public static class DatosBaseFactory
    {
        public static DatosBase CreateInstance(string asTipoDatosBase)
        {
            DatosBase resultado;

            switch (asTipoDatosBase)
            {
                case "MySQL":
                    resultado = new DatosMySQL();
                    break;
                case "ODBC":
                    resultado = new DatosODBC();
                    break;
                default:
                    resultado = null;
                    break;
            }

            return resultado;
        }

        public static DatosBase CreateInstance(Conector aConector)
        {
            DatosBase resultado;

            switch (aConector.Tipo)
            {
                case "MySQL":
                    resultado = new DatosMySQL(aConector.CadenaConexion);
                    break;
                case "ODBC":
                    resultado = new DatosODBC(aConector.CadenaConexion);
                    break;
                default:
                    resultado = null;
                    break;
            }

            return resultado;
        }

        public static DatosBase CreateInstance(DatosBase aDatos)
        {
            DatosBase resultado;

            switch (aDatos.GetType().ToString())
            {
                case "TestsSGBD.Clases.DatosMySQL":
                    resultado = new DatosMySQL(aDatos.Cadena);
                    break;
                case "TestsSGBD.Clases.DatosODBC":
                    resultado = new DatosODBC(aDatos.Cadena);
                    break;
                default:
                    resultado = null;
                    break;
            }

            return resultado;
        }
    }
}