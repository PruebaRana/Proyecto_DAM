using System;
using System.Data;
using System.Data.Odbc;

namespace TestsSGBD.Clases
{
	public class DatosODBC : DatosBase
	{
		#region Constructor 
		public DatosODBC():this(string.Empty)
		{
		}
		public DatosODBC(string asCadena)
		{
			this.Cadena = asCadena;
		}
		#endregion

		#region Apertura y cierre de la conexion
		public override IDbConnection Open(string asCadena)
		{
			lock (this._Lock)
			{
				if (this._conexion == null)
				{
					this._conexion = new OdbcConnection(asCadena);
				}
				if (this._conexion.State != ConnectionState.Open)
				{
					//MvcApplication.AddMsg("BBDD Open");
					this._conexion.Open();
				}
			}
			return this._conexion;
		}
		#endregion

		#region Metodos de BD
		public override DataTable ObtenerDataTable(string asSQL)
		{
			DataTable lRespuesta = null;
			OdbcCommand lCommand = null;
			OdbcDataReader lDataRead = null;
			OdbcDataAdapter lDat = null;
			try
			{
				//Log.EscribeLog("Entramos en ObtenerDataTable. SQL [" + asSQL + "]", "Datos.ObtenerDataTable", Log.Tipo.INFO);
				lCommand = new OdbcCommand(asSQL, (OdbcConnection)this.Open());
				lCommand.CommandType = CommandType.Text;

				// Pasamos todos los datos a un DataTable
				lDataRead = lCommand.ExecuteReader(CommandBehavior.SequentialAccess);

				//lDat = new MySqlDataAdapter(asSQL, this.Open());
				//lDat.MissingSchemaAction = MissingSchemaAction.AddWithKey;
				//lDat.Fill(lRespuesta);

				lRespuesta = new DataTable();
				LoadTabla(lRespuesta, lDataRead, true);
			}
			catch (OdbcException ex)
			{
				//Log.EscribeLog("SQL [" + asSQL + "] Error [" + ex.Message + "]", "Datos.ObtenerDataTable", Log.Tipo.ERROR);
				throw ex;
			}
			finally
			{
				if (lDataRead != null)
				{
					lDataRead.Close();
					lDataRead.Dispose();
					lDataRead = null;
				}
				if (lDat != null)
				{
					lDat.Dispose();
					lDat = null;
				}
				if (lCommand != null)
				{
					lCommand.Dispose();
					lCommand = null;
				}
			}
			return lRespuesta;
		}
		public override int EjecutarCount(string asSQL)
		{
			int liId = -1;
			OdbcCommand lCommand = null;
			try
			{
				//Log.EscribeLog("Entramos en EjecutarCount. SQL [" + asSQL + "]", "Datos.EjecutarCount", Log.Tipo.INFO);
				lCommand = new OdbcCommand(asSQL, (OdbcConnection)this.Open());
				lCommand.CommandType = CommandType.Text;
				// Lanzamos la consulta y retornamos el valor
				liId = Convert.ToInt32(lCommand.ExecuteScalar());
			}
			catch (OdbcException ex)
			{
				Log.EscribeLog("SQL [" + asSQL + "] Error [" + ex.Message + "]", "Datos.EjecutarCount", Log.Tipo.ERROR);
			}
			finally
			{
				if (lCommand != null)
				{
					lCommand.Dispose();
					lCommand = null;
				}
			}
			return liId;
		}
		public override bool EjecutarNonQuery(string asSQL)
		{
			bool lswRespuesta = false;
			OdbcCommand lCommand = null;
			try
			{
				Log.EscribeLog("Entramos en EjecutarNonQuery. SQL [" + asSQL + "]", "Datos.EjecutarNonQuery", Log.Tipo.INFO);
				lCommand = new OdbcCommand(asSQL, (OdbcConnection)this.Open());
				lCommand.CommandType = CommandType.Text;
				// Lanzamos la consulta y retornamos el valor
				lswRespuesta = lCommand.ExecuteNonQuery() > 0 ? true : false;
				//long ll = lCommand.LastInsertedId;
			}
			catch (OdbcException ex)
			{
				Log.EscribeLog("SQL [" + asSQL + "] Error: " + ex.Message, "Datos.EjecutarNonQuery", Log.Tipo.ERROR);
			}
			finally
			{
				if (lCommand != null)
				{
					lCommand.Dispose();
					lCommand = null;
				}
			}
			return lswRespuesta;
		}
		public override int EjecutarNonQueryYObtenerLastId(string asSQL)
		{
			int lsRespuesta = -1;
			OdbcCommand lCommand = null;
			try
			{
				Log.EscribeLog("Entramos en EjecutarNonQueryYObtenerLastId. SQL [" + asSQL + "]", "Datos.EjecutarNonQueryYObtenerLastId", Log.Tipo.INFO);
				lCommand = new OdbcCommand(asSQL, (OdbcConnection)this.Open());
				lCommand.CommandType = CommandType.Text;
				// Lanzamos la consulta y retornamos el valor
				if (lCommand.ExecuteNonQuery() > 0)
				{
					lCommand.CommandText = "SELECT LAST_INSERT_ID();";
					lsRespuesta = DatosBase.ObtenNumero(lCommand.ExecuteScalar().ToString());
					//lsRespuesta = EjecutarEscalar("SELECT @@IDENTITY as Id;");
					//lsRespuesta = EjecutarEscalar("SELECT LAST_INSERT_ID();");
				}
			}
			catch (OdbcException ex)
			{
				Log.EscribeLog("SQL [" + asSQL + "] Error: " + ex.Message, "Datos.EjecutarNonQueryYObtenerLastId", Log.Tipo.ERROR);
			}
			finally
			{
				if (lCommand != null)
				{
					lCommand.Dispose();
					lCommand = null;
				}
			}
			return lsRespuesta;
		}
		public override int EjecutarEscalar(string asSQL)
		{
			int liRespuesta = 0;
			OdbcCommand lCommand = null;
			try
			{
				Log.EscribeLog("Entramos en EjecutarEscalar. SQL [" + asSQL + "]", "Datos.EjecutarEscalar", Log.Tipo.INFO);
				lCommand = new OdbcCommand(asSQL, (OdbcConnection)this.Open());
				lCommand.CommandType = CommandType.Text;
				// Lanzamos la consulta y retornamos el valor
				liRespuesta = Convert.ToInt32(lCommand.ExecuteScalar());
				//long ll = lCommand.LastInsertedId;
			}
			catch (OdbcException ex)
			{
				Log.EscribeLog("SQL [" + asSQL + "] Error: " + ex.Message, "Datos.EjecutarEscalar", Log.Tipo.ERROR);
			}
			finally
			{
				if (lCommand != null)
				{
					lCommand.Dispose();
					lCommand = null;
				}
			}
			return liRespuesta;
		}
		#endregion
	}
}
