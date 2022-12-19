using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Applications
{
	public partial class GetOSAsset : HttpHandler
	{
		public override string Title { get { return base.Title + " : GetOSAsset"; } }

		override protected IEnumerable Contents
		{
			get
			{
				yield return "<h2>" + Title
					+ "<span id='Tab_Meta' class='TabButton state_unselected' style='margin-left:20px' onclick='clickedButton(this)'>Meta</span>"
					+ "<span id='connectionState' style='margin-left:10px'></span>"
					+ "</h2>";
				yield return github.User.test();

				yield return "<div style='margin-top:10px'><img src='/images/fun/gollum.gif'></img></div>";

				foreach (string key in HttpContext.Current.Request.Headers.Keys)
					yield return "<br/>" + key + ": " + HttpContext.Current.Request.Headers[key];

				yield return "<br/><br/>";

				yield return DB.select("__T", "*").Replace("<", "&lt;").Replace(">", "&gt;");
				DB.Close();

				yield return "<br/>";

				yield return CookieMessage(CName);
			}
		}
	}
}
