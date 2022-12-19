using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

/// <summary>
/// Summary description for DB
/// </summary>
public class DB : IDisposable
{
	public DB(string name) {}
	static DB() { Instance = new DB("DB"); }
	static DB Instance;

	public static string GetDBConnectionString()
	{
		string cs = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
		cs = cs.Replace("{DB}", HttpContext.Current.Server.MapPath("/App_Data/") + "Database.mdf");
		Debug.WriteLine("ConnectionString: " + cs);
		return cs;
	}
	public static string GetSasquatchConnectionString()
	{
		string cs = ConfigurationManager.ConnectionStrings["Sasquatch"].ConnectionString;
		return cs;
	}

	SqlConnection CONN = null;
	internal SqlConnection connection
	{
		get
		{
			if (CONN == null)
				try
				{
					//C:\github\Virtual-World-Systems\Development\Collaborator\OwlEyes\Solution(s)\WWW\WWW\App_Data\Database.mdf
					SqlConnection c = new SqlConnection(GetDBConnectionString());
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
	public static SqlConnection Connection { get { return Instance.connection; } }

	public void Dispose()
	{
		Close();
	}
	public static void Close()
	{
		if (Instance.CONN == null) return;
		Instance.CONN.Close();
		Instance.CONN.Dispose();
		Instance.CONN = null;
	}
	public static string select(string table, string q)
	{
		DataTable T = new DataTable("T");
		StringBuilder sb = new StringBuilder();
		sb.Append("<result>");
		try
		{
			SqlCommand cmd = new SqlCommand("SELECT " + q + " FROM " + table + " FOR XML AUTO", Instance.connection);
			using (SqlDataReader rdr = cmd.ExecuteReader()) while (rdr.Read()) sb.Append(rdr.GetString(0));
		}
		catch(Exception e) { sb.Append("<ERROR>" + e.Message + "</ERROR>"); }
		sb.Append("</result>");
		return sb.ToString();
	}
}