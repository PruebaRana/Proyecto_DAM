using System;
using System.Data;

namespace TestsSGBD.Clases
{
	/// <summary>Clase de acceso a los datos.</summary>
	public abstract class DatosBase
	{
		private string _Cadena = string.Empty;
		public string Cadena
		{
			get { return _Cadena; }
			set { _Cadena = value; }
		}

		public IDbConnection _conexion = null;
		public string _Lock = string.Empty;

		#region Apertura y cierre de la conexion
		/// <summary>Metodo que abre la conexion, si esta cerrada</summary>
		/// 15/07/2011 by jaguila
		public IDbConnection Open()
		{
			return this.Open(this._Cadena);
		}
		public abstract IDbConnection Open(string asCadena);

		/// <summary>Metodo que cierra la conexion al finalizar cada proceso</summary>
		/// 15/07/2011 by jaguila
		public void Close()
		{
			lock (this._Lock)
			{
				//MvcApplication.AddMsg("BBDD Close");
				if (this._conexion != null)
				{
					this._conexion.Close();
					this._conexion.Dispose();
					this._conexion = null;
				}
			}
		}
		#endregion

		#region Metodos de BD
		public abstract DataTable ObtenerDataTable(string asSQL);
		public abstract int EjecutarCount(string asSQL);
		public abstract bool EjecutarNonQuery(string asSQL);
		public abstract int EjecutarNonQueryYObtenerLastId(string asSQL);
		public abstract int EjecutarEscalar(string asSQL);
		#endregion

		#region Metodos Comunes y utiles
		public static string ObtenString(string asItem)
		{
			string lsRes = string.Empty;
			try
			{
				if (!string.IsNullOrEmpty(asItem))
				{
					lsRes = asItem.ToString().Replace("''", "'");
				}
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error al intentar convertir [" + asItem + "] en string. " + ex.Message, "Datos.ObtenString", Log.Tipo.ERROR);
			}
			return lsRes;
		}

		public static DateTime ObtenFecha(string asFecha, string asFormato = "dd/MM/yyyy H:mm:ss")
		{
			DateTime lFecha = new DateTime();
			try
			{
				if (!string.IsNullOrEmpty(asFecha))
				{
					lFecha = DateTime.ParseExact(asFecha, asFormato, System.Globalization.CultureInfo.InvariantCulture);
				}
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error al intentar convertir [" + asFecha + "] en una fecha. " + ex.Message, "Dao.ObtenFecha", Log.Tipo.ERROR);
				if (asFormato.Length == 10 && asFecha.Length > 10)
				{
					lFecha = ObtenFecha(asFecha, asFormato + " HH:mm:ss");
				}
			}
			return lFecha;
		}

		public static int ObtenNumero(string asItem)
		{
			int liItem = 0;
			try
			{
				if (!string.IsNullOrEmpty(asItem))
				{
					liItem = int.Parse(asItem);
				}
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error al intentar convertir [" + asItem + "] en un numero. " + ex.Message, "Dao.ObtenNumero", Log.Tipo.ERROR);
			}
			return liItem;
		}
		public static float ObtenNumeroDecimal(string asItem)
		{
			float liItem = 0F;
			asItem = asItem.Replace(".", ",");
			try
			{
				if (!string.IsNullOrEmpty(asItem))
				{
					liItem = float.Parse(asItem);
				}
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error al intentar convertir [" + asItem + "] en un numero decimal. " + ex.Message, "Dao.ObtenNumeroDecimal", Log.Tipo.ERROR);
			}
			return liItem;
		}
		public static bool ObtenSiNo(string asItem)
		{
			bool lswRes = false;
			try
			{
				if (!string.IsNullOrEmpty(asItem))
				{
					string lsItem = asItem.ToLower();
					lswRes = (lsItem == "si" || lsItem == "1" || lsItem == "true" || lsItem == "verdadero");
				}
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error al intentar convertir [" + asItem + "] en booleano. " + ex.Message, "Datos.ObtenSiNo", Log.Tipo.ERROR);
			}
			return lswRes;
		}
		// Cargar un DataTable desde un DataReader, por temas de MySQL
		public static void LoadTabla(DataTable table, IDataReader reader, bool createColumns)
		{
			try
			{
				if (createColumns)
				{
					table.Columns.Clear();
					var schemaTable = reader.GetSchemaTable();

					foreach (DataRowView row in schemaTable.DefaultView)
					{
						var columnName = (string)row["ColumnName"];
						var type = (Type)row["DataType"];
						table.Columns.Add(columnName, type);
					}
					schemaTable.Dispose();
					schemaTable = null;
				}
				DataSet ds = new DataSet();
				ds.Tables.Add(table);
				ds.EnforceConstraints = false;

				table.Load(reader, LoadOption.OverwriteChanges, FillErrorHandler);

				ds.Dispose();
			}
			catch (Exception ex)
			{
				Log.EscribeLog("Error [" + ex.Message + "]", "Datos.LoadTabla", Log.Tipo.ERROR);
			}

		}
		public static void FillErrorHandler(object sender, FillErrorEventArgs e)
		{
			// You can use the e.Errors value to determine exactly what
			// went wrong.
			if (e.Errors.GetType() == typeof(System.FormatException))
			{
				Log.EscribeLog("Error [" + e.Values[0] + "]", "Datos.LoadTabla", Log.Tipo.ERROR);
			}
			else
			{
				Log.EscribeLog("Error [" + e.Values[0] + "]", "Datos.LoadTabla", Log.Tipo.ERROR);
			}

			// Setting e.Continue to True tells the Load
			// method to continue trying. Setting it to False
			// indicates that an error has occurred, and the 
			// Load method raises the exception that got 
			// you here.
			e.Continue = true;
		}

		public static string ObtenOrder(string asOrder)
		{
			string lsRes = " asc";
			if (asOrder.ToLower() == "asc" || asOrder.ToLower() == "desc")
			{
				lsRes = " " + asOrder;
			}
			return lsRes;
		}
		public static string ObtenLimit(int aiPA, int aiIP)
		{
			string lsRes = " LIMIT ";
			if (aiIP < 1)
			{
				aiIP = 10;
			}
			if (aiPA < 1)
			{
				lsRes = string.Empty;
			}
			else
			{
				lsRes += (aiIP * (aiPA - 1)) + ", " + aiIP;
			}
			return lsRes;
		}
		#endregion

	}
}
