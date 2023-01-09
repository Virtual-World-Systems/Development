using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static TCPInterceptor.Connection;

namespace TCPInterceptor
{
	public static class Program
	{
		public static int Main(string[] args)
		{
			Instance = Create.Instance("kitely.com", 8002, 5404);
			Instance.Closed += Instance_Closed;
			Instance.Received += Received;
			Instance.Start();
			Console.WriteLine("press any key to stop ...");
			Console.ReadKey();
			Instance.Dispose();
			Console.WriteLine("press any key to close ...");
			Console.ReadKey();
			return 0;
		}

		private static void Instance_Closed(Instance instance)
		{
			Console.WriteLine("*** Instance closed");
			Instance.Dispose();
			Console.WriteLine("press any key to close ...");
			Console.ReadKey();
			Environment.Exit(0);
		}

		static Instance Instance = null;
		private static void Received(Connection connection, byte[] buffer)
		{
			Console.WriteLine("*** Received\n" + Dump(buffer));
			string h = H; H = H.Replace("{?}", "" + B.Length);
			connection.Send(H, B);
		}

		static string H = @"HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: text/html; charset=utf-8
Expires: -1
Server: Microsoft-IIS/10.0
X-AspNet-Version: 4.0.30319
Set-Cookie: .=1; domain=virtual-world-systems.net; expires=Sat, 07-Jan-2023 14:53:13 GMT; path=/; secure; SameSite=Strict
X-Powered-By: ASP.NET
Date: Sat, 07 Jan 2023 14:52:53 GMT
Content-Length: {?}

";
		static string B = @"<html><head><title>XXX</title></head><body>TEST</body></html>";


		private static string Dump(byte[] buffer)
		{
			return Encoding.UTF8.GetString(buffer);
		}
	}
}
