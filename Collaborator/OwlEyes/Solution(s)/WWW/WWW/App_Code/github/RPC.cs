
using System.IO;
using System.Net;

namespace github
{
	/// <summary>
	/// Summary description for RPC
	/// </summary>
	public class RP
	{
		static bool inited = false;

		public static Stream GET(string s)
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.github.com/" + s);
			Request.Accept = "application/json";
			Request.UserAgent = "curl/7.79.1";
			Request.KeepAlive = true;

			if (inited || !inited)
			{
				inited = true;
				Request.Headers["Authorization"] = Authentication.String;
			}
			return Request.GetResponse().GetResponseStream();
		}
	}
}
