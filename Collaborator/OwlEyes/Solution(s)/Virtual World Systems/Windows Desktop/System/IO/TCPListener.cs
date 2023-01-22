using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VWS.IO
{
	internal class TCPListener : TcpListener, IDisposable
	{
		public TCPListener(int Port) : base(IPAddress.Any, Port) { this.Port = Port; }
		public int Port { get; set; }
		public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
		public virtual void Dispose() { }
		string Specification { get { return "TCP:" + Port; } }

		internal new void Start() { base.Start(10); BeginAcceptSocket(OnAcceptSocket, null); }

		private void OnAcceptSocket(IAsyncResult ar)
		{
			TCPConnection conn = null;
			try { conn = new TCPConnection(EndAcceptSocket(ar), Port, (++NewID).ToString().Substring(1)); }
			catch (ObjectDisposedException) { return; }
			if (ConnectionAccepted != null) ConnectionAccepted(this, conn);
			conn.BeginReceive();
			BeginAcceptSocket(OnAcceptSocket, null);
		}
		static int NewID = 100000;

		internal event ConnectionAcceptedHandler ConnectionAccepted;
		internal delegate void ConnectionAcceptedHandler(object sender, TCPConnection c);
	}
}
