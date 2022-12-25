<%@ WebHandler Language="C#" Class="Resource" %>

using System;
using System.Web;

public class Resource : IHttpHandler
{

	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "text/text";
		object[] oo = null;
		try
		{
			string name = context.Request.Params[null];
			oo = GetResource(name);
			string mimeType = (string)oo[0];
			context.Response.ContentType = mimeType;
			if (mimeType == "text/text")
			{
				context.Response.Write((string)oo[1]);
			}
			else
			{
				byte[] fileContents = (byte[])oo[1];
				context.Response.Headers["Content-Disposition"] = "attachment; filename = \"" + name + "\"";
				context.Response.BinaryWrite(fileContents);
			}
			return;
		}
		catch (Exception ex)
		{
			context.Response.Write(ex.Message + "\r\n" + ex.StackTrace);
		}
	}

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}

	public static object[] GetResource(string path)
	{
		string s = null;
		path = "C:\\WebResources\\Resources\\" + path;
		try
		{
			byte[] bytes = System.IO.File.ReadAllBytes(path);
			if (path.EndsWith(".webm")) s = "video/webm";
			return new object[] { s, bytes };
		}
		catch (Exception ex)
		{
			return new object[] { "text/text", ex.Message + "\r\n" + ex.StackTrace };
		}
	}
}