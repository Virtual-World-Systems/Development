using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB : IDisposable
{
	public DB(string name) {}
	static DB() { Instance = new DB("DB"); }
	static DB Instance;

	SqlConnection CONN = null;
	internal SqlConnection connection
	{
		get
		{
			if (CONN == null)
				try
				{
					SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
					c.Open();
					CONN = c;
				}
				catch (Exception)
				{
					CONN = null;
				}
			return CONN;
		}
	}

	public void Dispose()
	{
		if (CONN != null) { CONN.Close(); CONN.Dispose(); CONN = null; }
	}
	public static string select(string table, string q)
	{
		DataTable T = new DataTable("T");
		StringBuilder sb = new StringBuilder();
		sb.Append("<result>");
		try
		{
			SqlCommand cmd = new SqlCommand("SELECT " + q + " FROM " + table + " FOR XML AUTO", Instance.connection);
			using (SqlDataReader rdr = cmd.ExecuteReader())
			{
				while (rdr.Read()) { sb.Append(rdr.GetString(0)); }
			}
		}
		catch(Exception e) { sb.Append("<ERROR>" + e.Message + "</ERROR>"); }
		sb.Append("</result>");
		return sb.ToString();
	}
}