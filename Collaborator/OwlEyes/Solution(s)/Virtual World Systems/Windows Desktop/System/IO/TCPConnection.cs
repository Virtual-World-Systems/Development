using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VWS.IO
{
	public class TCPConnection : IDisposable
	{
		public TCPConnection(Socket socket, int port, string id)
		{
			Socket = socket;
			Port = port;
			ID = id;
		}
		internal int Port;
		internal string ID { get; private set; }

		byte[] buf_ = new byte[1];

		internal void BeginReceive() { Socket.BeginReceive(buf_, 0, 1, SocketFlags.None, OnReceived, null); }
		private void OnReceived(IAsyncResult ar)
		{
			try
			{
				int len = Socket.EndReceive(ar);
				if (len != 1)
				{
					Debug.WriteLine($"{this}: len == {len}");
					if (len == 0) { Dispose(); return; }
					BeginReceive();
					return;
				}
				byte[] bytes = new byte[Socket.Available + 1];
				bytes[0] = buf_[0];
				if (Socket.Available > 0) Socket.Receive(bytes, 1, Socket.Available, SocketFlags.None);

				if ((bytes[0] < 'A') || (bytes[0] > 'Z'))
				{
					if (MessageReceived != null) MessageReceived(this, bytes);
				}
				else
				{
					HTTPMessage msg = new HTTPMessage(bytes, new NetworkStream(Socket), ID);
					
					if (HTTPMessageReceived != null) HTTPMessageReceived(this, msg);
				}
				BeginReceive();
			}
			catch (ObjectDisposedException)
			{
				if (ConnectionClosed != null) ConnectionClosed(this);
			}
			catch (SocketException)
			{
				if (ConnectionClosed != null) ConnectionClosed(this);
			}
		}

		public event MessageReceivedHandler MessageReceived;
		public delegate void MessageReceivedHandler(TCPConnection sender, byte[] bytes);

		public event HTTPMessageReceivedHandler HTTPMessageReceived;
		public delegate void HTTPMessageReceivedHandler(TCPConnection sender, HTTPMessage msg);

		public event ConnectionClosedHandler ConnectionClosed;
		public delegate void ConnectionClosedHandler(TCPConnection sender);

		public void Send(byte[] bytes) { Socket.Send(bytes); }

		Socket Socket;

		public void Dispose()
		{
			if (disposed) { Debug.WriteLine($"{this} already disposed"); return; }
			disposed = true; if (Socket.Connected) Socket.Close(); Socket.Dispose();
			if (ConnectionClosed != null) ConnectionClosed(this);
		}
		bool disposed = false;

		#region HTTP
		public void SendHTTP(TCPConnection c, string h, byte[] bb)
		{
			Debug.WriteLine("\r\nsending binary data (Length=" + bb.Length + ")\r\n");
			string hNew = h.Replace("{?}", "" + bb.Length);
			byte[] bh = Encoding.UTF8.GetBytes(hNew);
			byte[] xx = new byte[bh.Length + bb.Length];
			Array.Copy(bh, 0, xx, 0, bh.Length);
			Array.Copy(bb, 0, xx, bh.Length, bb.Length);
			c.Send(xx);
		}
		public void SendHTTP(TCPConnection c, string h, string b)
		{
			byte[] bb = Encoding.UTF8.GetBytes(b);
			string hNew = h.Replace("{?}", "" + bb.Length);
			Debug.WriteLine("\r\nsending\r\n" + hNew + b + "\r\n");
			SendHTTP(c, h, bb);
		}
		#endregion
	}
}
