using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPInterceptor
{
    public static class Create { public static Instance Instance(string url, int port, int localPort) { return new Instance(url, port, localPort); } }
    public class Instance : IDisposable
    {
		internal Instance(string url, int port, int localPort)
		{
			URL = url;
			Port = port;
			LocalPort = localPort;
			IPAddress LocalIPAddress = IPAddress.Any;//.Parse("127.0.0.1");
			Listener = new TcpListener(LocalIPAddress, localPort);
		}
		string URL;
		int Port;
		int LocalPort;
		TcpListener Listener;

		public void Start()
		{
			Listener.Start();
			Console.WriteLine("Waiting for connection...");
			Listener.BeginAcceptSocket(OnSocketAccepting, null);
		}

		private void OnSocketAccepting(IAsyncResult ar)
		{
			Connection conn = null;
			try { conn = new Connection(Listener.EndAcceptSocket(ar)); } catch { }
			if (conn == null)
			{
				Console.WriteLine("Accept interrupted");
				if (Closed != null) Closed(this);
				return;
			}
			conn.Closed += OnConnectionClosed;
			conn.Received += Conn_Received;
			Connections.Add(conn);
			Listener.BeginAcceptSocket(OnSocketAccepting, null);
		}
		List<Connection> Connections = new List<Connection>();

		private void Conn_Received(Connection connection, byte[] buffer)
		{
			Console.WriteLine("Conn_Received " + buffer.Length + " bytes");
			if (Received != null) Received(connection, buffer);
		}
		public event OnReceived Received;
		public delegate void OnReceived(Connection connection, byte[] buffer);

		void OnConnectionClosed(Connection connection)
		{
			Connections.Remove(connection);
			Console.WriteLine("Connection " + connection.GetHashCode() + " closed");
			if (connection != null) connection.Dispose();
			if (Connections.Count == 0)
			{
				Listener.Stop();
				if (Closed != null) Closed(this);
			}
		}
		public void Dispose() 
		{
			List<Connection> conns = new List<Connection>();
			foreach (Connection conn in Connections) conns.Add(conn);
			Console.WriteLine($"Disposing {conns.Count} connections");
			foreach (Connection conn in conns) conn.Close();
		}
		public event OnClosed Closed = null;
		public delegate void OnClosed(Instance instance);
	}
}
