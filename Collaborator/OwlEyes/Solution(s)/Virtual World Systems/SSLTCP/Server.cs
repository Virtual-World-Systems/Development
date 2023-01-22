using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SSLTCP
{
	public sealed class SslTcpServer
	{
		static X509Certificate serverCertificate = null;
		// The certificate parameter specifies the name of the file
		// containing the machine certificate.
		public static void RunServer(string certificate, int port)
		{
			RunServer(X509Certificate.CreateFromCertFile(certificate), port);
		}
		public static void RunServer(X509Certificate certificate, int port)
		{
			serverCertificate = certificate;

			// Create a TCP/IP (IPv4) socket and listen for incoming connections.
			TcpListener listener = new TcpListener(IPAddress.Any, port);
			listener.Start();
			while (true)
			{
				Console.WriteLine("Waiting for a client to connect...");
				// Application blocks while waiting for an incoming connection.
				// Type CNTL-C to terminate the server.
				client = listener.AcceptTcpClient();
				ProcessClient(client);
			}
		}
		static void ProcessClient(TcpClient client)
		{
			// A client has connected. Create the
			// SslStream using the client's network stream.
			SslStream sslStream = new SslStream(strm = client.GetStream(), false);

			// Authenticate the server but don't require the client to authenticate.
			try
			{
				sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);

				// Display the properties and settings for the authenticated stream.
				DisplaySecurityLevel(sslStream);
				DisplaySecurityServices(sslStream);
				DisplayCertificateInformation(sslStream);
				DisplayStreamProperties(sslStream);

				// Set timeouts for the read and write to 5 seconds.
				sslStream.ReadTimeout = 5000;
				sslStream.WriteTimeout = 5000;
				// Read a message from the client.
				Console.WriteLine("Waiting for client message...");
				string messageData = ReadMessage(sslStream);
				Console.WriteLine("Received: {0}", messageData);
				Send(sslStream, H, B);
			}
			catch (AuthenticationException e)
			{
				Console.WriteLine("Exception: {0}", e.Message);
				if (e.InnerException != null)
				{
					Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
				}
				Console.WriteLine("Authentication failed - closing the connection.");
				sslStream.Close();
				client.Close();
				return;
			}
			finally
			{
				// The client stream will be closed with the sslStream
				// because we specified this behavior when creating
				// the sslStream.
				sslStream.Close();
				client.Close();
			}
		}
		public static void Send(SslStream str, string h, string b)
		{
			byte[] bb = Encoding.UTF8.GetBytes(b);
			byte[] bh = Encoding.UTF8.GetBytes(h.Replace("{?}", "" + bb.Length));
			byte[] xx = new byte[bh.Length + bb.Length];
			Array.Copy(bh, 0, xx, 0, bh.Length);
			Array.Copy(bb, 0, xx, bh.Length, bb.Length);
			str.Write(xx);
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


		static string ReadMessage(SslStream sslStream)
		{
			// Read the  message sent by the client.
			// The client signals the end of the message using the
			// "<EOF>" marker.
			ms = new MemoryStream();

			ReceivedEvent.Reset();
			//sslStream.ReadTimeout = 1;
			//sslStream.BeginRead(buffer, 0, buffer.Length, OnReceive, sslStream);
			strm.BeginRead(buffer, 0, buffer.Length, OnReceive, sslStream);
			ReceivedEvent.WaitOne();
			ReceivedEvent.Reset();
			return msg;
		}

		private static ManualResetEvent ReceivedEvent = new ManualResetEvent(false);

		private static void OnReceive(IAsyncResult ar)
		{
			SslStream sslStream = (SslStream)ar.AsyncState;
			int len = 0;
			//try { len = sslStream.EndRead(ar); } catch { }
			try { len = strm.EndRead(ar); } catch { }
			if (len > 0)
			{
				Console.WriteLine($"read {len} bytes");
				ms.Write(buffer, 0, len);
				//sslStream.ReadTimeout = 1;
				//sslStream.BeginRead(buffer, 0, buffer.Length, OnReceive, sslStream);
				if (len == buffer.Length)
				{
					strm.BeginRead(buffer, 0, buffer.Length, OnReceive, sslStream);
					return;
				}
			}
			msg = Encoding.UTF8.GetString(ms.GetBuffer());
			ReceivedEvent.Set();
		}
		static string msg = "";
		static MemoryStream ms;
		static TcpClient client;
		static NetworkStream strm;
		static byte[] buffer = new byte[4097];

		static void DisplaySecurityLevel(SslStream stream)
		{
			Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength);
			Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength);
			Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
			Console.WriteLine("Protocol: {0}", stream.SslProtocol);
		}
		static void DisplaySecurityServices(SslStream stream)
		{
			Console.WriteLine("Is authenticated: {0} as server? {1}", stream.IsAuthenticated, stream.IsServer);
			Console.WriteLine("IsSigned: {0}", stream.IsSigned);
			Console.WriteLine("Is Encrypted: {0}", stream.IsEncrypted);
		}
		static void DisplayStreamProperties(SslStream stream)
		{
			Console.WriteLine("Can read: {0}, write {1}", stream.CanRead, stream.CanWrite);
			Console.WriteLine("Can timeout: {0}", stream.CanTimeout);
		}
		static void DisplayCertificateInformation(SslStream stream)
		{
			Console.WriteLine("Certificate revocation list checked: {0}", stream.CheckCertRevocationStatus);

			X509Certificate localCertificate = stream.LocalCertificate;
			if (stream.LocalCertificate != null)
			{
				Console.WriteLine("Local cert was issued to {0} and is valid from {1} until {2}.",
					localCertificate.Subject,
					localCertificate.GetEffectiveDateString(),
					localCertificate.GetExpirationDateString());
			}
			else
			{
				Console.WriteLine("Local certificate is null.");
			}
			// Display the properties of the client's certificate.
			X509Certificate remoteCertificate = stream.RemoteCertificate;
			if (stream.RemoteCertificate != null)
			{
				Console.WriteLine("Remote cert was issued to {0} and is valid from {1} until {2}.",
					remoteCertificate.Subject,
					remoteCertificate.GetEffectiveDateString(),
					remoteCertificate.GetExpirationDateString());
			}
			else
			{
				Console.WriteLine("Remote certificate is null.");
			}
		}
		private static void DisplayUsage()
		{
			Console.WriteLine("To start the server specify:");
			Console.WriteLine("serverSync certificateFile.cer");
			Environment.Exit(1);
		}
	}
}
