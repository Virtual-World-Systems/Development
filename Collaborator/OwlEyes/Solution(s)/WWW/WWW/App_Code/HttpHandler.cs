using System;
using System.Collections;
using System.Web;

/// <summary>
/// Summary description for HttpHandler
/// </summary>
public partial class HttpHandler : IHttpHandler
{
	virtual public string Title { get { return "Virtual-World-Systems"; } }
	virtual public string CName { get { return "."; } }
	public static string Tick { get { return DateTime.Now.ToString("yyyyMMddHHmmssfffffff"); } }

	public void ProcessRequest(HttpContext context)
	{
		if (context.IsWebSocketRequest)
		{
			context.AcceptWebSocketRequest(new WebSocket(context).RunWebSocket);
			return;
		}
		HttpResponse R = context.Response;
		R.Expires = 0;
		R.Cache.SetExpires(DateTime.MinValue);
		R.Cache.SetCacheability(HttpCacheability.NoCache);

		WriteContent(context);
	}

	virtual protected void WriteContent(HttpContext C)
	{
		HttpResponse R = C.Response;
		R.ContentType = "text/html";
		R.Write("<html><head>");
		foreach (string s in Headers) R.Write(s);
		R.Write("</head><body>");
		foreach (string s in Contents) R.Write(s);
		R.Write("</body></html>");
	}
	virtual protected IEnumerable Headers
	{
		get
		{
			yield return "<meta charset='utf-8'>";
			yield return "<title>" + Title + "</Title>";
			yield return "<meta content='width=device-width, initial-scale=1' name='viewport'>";
			yield return "<link rel='icon' type='image/x-icon' href='/Images/World.png?" + Tick + "'/>";
			//yield return "<link rel='icon' type='image/x-icon' href='https://Virtual-World-Systems.net/Images/World.png?" + Tick + "'/>";
			yield return "<meta http-equiv='expires' content='0'/>";
		    yield return "<script src='/scripts/jQuery-3.6.0.js'></script>";
			yield return "<link type='text/css' rel='stylesheet' href='/styles/default.css?" + Tick + "'/>";
		    yield return "<script src='/scripts/websocket.js?" + Tick + "'></script>";
		}
	}

		virtual protected IEnumerable Contents
	{
		get
		{
			yield return "<h2>" + Title
				+ "<span id='Tab_Meta' class='TabButton state_unselected' style='margin-left:20px' onclick='clickedButton(this)'>Meta</span>"
				+ "<span id='connectionState' style='margin-left:10px'></span>"
				+ "</h2>";
			yield return github.User.test();

			yield return "<div style='margin-top:10px'><img src='/images/fun/gollum.gif?" + Tick + "'></img></div>";


			foreach (string key in HttpContext.Current.Request.Headers.Keys)
			{
				yield return "<br/>" + key + ": " + HttpContext.Current.Request.Headers[key];
			}

			yield return "<br/>";

			yield return CookieMessage(CName);
		}
	}

	public bool IsReusable { get { return false; } }

	internal string CookieMessage(string CName)
	{
		DateTime ce = DateTime.Now + TimeSpan.FromSeconds(20f);

		string CKey = null;
		string domain = "virtual-world-systems.net";

		if (!UserCookie.CookieExists(CName, null))
		{
			UserCookie.StoreInCookie(CName, domain, CKey, "1", ce, false, SameSiteMode.Strict, true);
			return "<h4>Cookie " + CName + ((CKey == null) ? "" : ("." + CKey)) + " created = 1</h4>";
		}
		else
		{
			string v = UserCookie.GetFromCookie(CName, CKey);
			int n = -1;
			if ((v != null)) n = int.Parse(v) + 1;
			if ((n < 0) || (n >= 4))
			{
				UserCookie.RemoveCookie(CName, null, domain);
				UserCookie.RemoveCookie("Application", null, domain);
				return "<h4>Cookie " + CName + ((CKey == null) ? "" : ("." + CKey)) + " removed</h4>";
			}
			else
			{
				UserCookie.StoreInCookie(CName, domain, CKey, n.ToString(), ce, false, SameSiteMode.Strict, true);
				return "<h4>Cookie " + CName + ((CKey == null) ? "" : ("." + CKey)) + " = " + n.ToString() + "</h4>";
			}
		}
	}
}
