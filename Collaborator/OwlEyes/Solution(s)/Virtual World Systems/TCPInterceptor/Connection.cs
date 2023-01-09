using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPInterceptor
{
	public class Connection : IDisposable
	{
		internal Connection(Socket socket)
		{
			Socket = socket;
			Console.WriteLine($"	{this} created");
			MemoryStream ms = new MemoryStream();
			Socket.BeginReceive(ByteBuffer, 0, 1, SocketFlags.None, OnReceiving, null);
		}
		Socket Socket;
		internal event OnClosed Closed;
		internal delegate void OnClosed(Connection connection);

		byte[] ByteBuffer = new byte[1];

		public override string ToString()
		{
			return "Connection[" + GetHashCode() + "," + GetSocketHashCode() + "]";
		}
		string GetSocketHashCode()
		{
			try { if (Socket == null) return "Socket[null]"; }
			catch (ObjectDisposedException) { return "Socket[null disposed]"; }
			try { return $"Socket[" + Socket.GetHashCode() + "," + Socket.Connected + "]"; }
			catch (ObjectDisposedException) { return "Socket[disposed]"; }
		}
		private void OnReceiving(IAsyncResult ar)
		{
			Console.WriteLine($"	{this} receiving ...");
			if (Socket == null) return;
			int Length = 0;
			try { Length = Socket.EndReceive(ar); }
			catch (ObjectDisposedException)
			{
				Console.WriteLine($"	{this} already disposed");
				if (Closed == null) { Closed(this); return; }
			}
			if (Length != 1)
			{
				Console.WriteLine($"	{this} error 1a");
				try { Socket.Close(); } catch { }
				Console.WriteLine($"	{this} error 1b");
				if (Closed != null) Closed(this);
				return;
			}
			byte[] b = new byte[1 + Socket.Available]; b[0] = ByteBuffer[0];
			Length = Socket.Receive(b, 1, Socket.Available, SocketFlags.None);
			if (Length != (b.Length - 1))
			{
				Console.WriteLine($"{this} error na");
				try { Socket.Close(); } catch { }
				Console.WriteLine($"{this} error nb");
				if (Closed != null) Closed(this);
				return;
			}
			if (Received != null) Received(this, b);
			Socket.BeginReceive(ByteBuffer, 0, 1, SocketFlags.None, OnReceiving, null);
		}
		internal event OnReceived Received;
		internal delegate void OnReceived(Connection connection, byte[] buffer);

		public void Close()
		{
			Console.WriteLine($"	{this} closing");
			Socket.Close();
		}
		public void Dispose()
		{
			Console.WriteLine($"	{this} disposing");
			Socket.Dispose();
			Socket = null;
		}

		public void Send(string h, string b)
		{
			byte[] bb = Encoding.UTF8.GetBytes(b);
			byte[] bh = Encoding.UTF8.GetBytes(h.Replace("{?}", "" + bb.Length));
			byte[] xx = new byte[bh.Length + bb.Length];
			Array.Copy(bh, 0, xx, 0, bh.Length);
			Array.Copy(bb, 0, xx, bh.Length, bb.Length);
			Socket.Send(xx);
		}
	}
}
