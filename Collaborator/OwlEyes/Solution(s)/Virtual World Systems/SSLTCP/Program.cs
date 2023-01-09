using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SSLTCP
{
	public static class Program
	{
		public static int Main(string[] args)
		{
			int rc = -1;
			if (args.Length < 1) DisplayUsage();
			else if (args[0] == "/c") rc = MainClient(ArgsShift(args));
			else if (args[0] == "/s") rc = MainServer(ArgsShift(args));
			else DisplayUsage();
			Console.ReadLine();
			return rc;
		}
		static string[] ArgsShift(string[] args)
		{
			string[] ss = new string[args.Length - 1];
			Array.Copy(args, 1, ss, 0, ss.Length);
			return ss;
		}
		private static void DisplayUsage()
		{
			DisplayClientUsage();
			DisplayServerUsage();
		}
		public static int MainServer(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Server uses Certificate from Store");
				var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
				X509Certificate2 certificate = null;
				store.Open(OpenFlags.ReadOnly);
				try
				{
					var certificateCollection = store.Certificates.Find(X509FindType.FindByIssuerName, "OSSL-DEV", true);
					if (certificateCollection.Count > 0) certificate = certificateCollection[0];
				}
				finally
				{
					store.Close();
				}
				if (certificate != null)
					SslTcpServer.RunServer(certificate, 5404);

				return 0;
			}
			string s_certificate = null;
			if (args == null || args.Length < 1)
			{
				DisplayServerUsage();
			}
			s_certificate = args[0];
			Console.WriteLine("Server uses Certificate " + s_certificate);
			SslTcpServer.RunServer(s_certificate, 5404);
			return 0;
		}
		public static int MainClient(string[] args)
		{
			string serverCertificateName = null;
			string machineName = null;
			if (args == null || args.Length < 1)
			{
				DisplayClientUsage();
			}
			// User can specify the machine name and server name.
			// Server name must match the name on the server's certificate.
			machineName = args[0];
			if (args.Length < 2)
			{
				serverCertificateName = machineName;
			}
			else
			{
				serverCertificateName = args[1];
			}
			SslTcpClient.RunClient(machineName, serverCertificateName);
			return 0;
		}
		private static void DisplayClientUsage()
		{
			Console.WriteLine("To start the client specify:");
			Console.WriteLine("SSLTCP /c machineName [serverName]");
		}
		private static void DisplayServerUsage()
		{
			Console.WriteLine("To start the server specify:");
			Console.WriteLine("SSLTCP /s certificateFile.cer");
		}
	}
}
