using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop
{
	partial class IOMessenger
	{
		partial class Listener
		{
			internal class TCPListener : TcpListener, IDisposable
			{
				internal TCPListener(int Port) : base(IPAddress.Any, Port) { this.Port = Port; }
				internal int Port { get; set; }
				public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
				public virtual void Dispose() { }
				string Specification { get { return "TCP " + Port; } }

				internal new void Start() { base.Start(10); BeginAcceptSocket(OnAcceptSocket, null); }

				private void OnAcceptSocket(IAsyncResult ar)
				{
					TCPConnection conn = null;
					try
					{ conn = new TCPConnection(EndAcceptSocket(ar),
						"TCP", Port, (++NewID).ToString().Substring(1)); }
					catch(ObjectDisposedException) { return; }
					if (ConnectionAccepted != null) ConnectionAccepted(this, conn);
					conn.BeginReceive();
					BeginAcceptSocket(OnAcceptSocket, null);
				}
				static int NewID = 100000;

				internal event ConnectionAcceptedHandler ConnectionAccepted;
				internal delegate void ConnectionAcceptedHandler(object sender, TCPConnection c);
			}

			internal class ReceiverStream : Stream
			{
				public override bool CanRead => true;

				public override bool CanSeek => false;

				public override bool CanWrite => false;

				public override long Length => (CurrentMessage == null) ? 0 : CurrentMessage.Length;

				public override long Position
				{
					get => (CurrentMessage == null) ? 0 : CurrentOffset;
					set {
						if (CurrentMessage == null) return;
						CurrentOffset = Math.Max(0, Math.Min(Length, value));
					}
				}

				void CheckEnd()
				{
					if (CurrentMessage == null) return;
					if (Position < CurrentMessage.Length) return;
					CurrentMessage = null;
					CurrentOffset = 0;
				}

				public override void Flush()
				{
					if (CurrentMessage == null) return;
					Position = CurrentMessage.Length;
				}

				public override int Read(byte[] buffer, int offset, int count)
				{
					if (CurrentMessage == null) return 0;
					if (Position >= Length) { CheckEnd(); return 0; }
					int len = Math.Min(count, (int)(Length - Position));
					if (len > 0) Array.Copy(CurrentMessage, Position, buffer, offset, len);
					Position += len;
					if (Position < Length) return len;
					if (len < count) CheckEnd();
					return len;
				}

				public override long Seek(long offset, SeekOrigin origin)
				{
					throw new NotImplementedException();
				}

				public override void SetLength(long value)
				{
					throw new NotImplementedException();
				}

				public override void Write(byte[] buffer, int offset, int count)
				{
					throw new NotImplementedException();
				}

				internal void AppendMessage(byte[] bytes)
				{
					if (CurrentMessage != null) { MessageList.Add(bytes); return; }
					CurrentMessage = bytes;
					CurrentOffset = 0;
					DataAvailable.Set();
				}

				long CurrentOffset = 0;
				byte[] CurrentMessage = null;
				List<byte[]> MessageList = new List<byte[]>();
				ManualResetEvent DataAvailable = new ManualResetEvent(false);
			}

			internal class TCPConnection : Connection, IDisposable
			{
				internal TCPConnection(Socket socket, string type, int port, string id)
				{
					Socket = socket;
					Type = type;
					Port = port;
					_ID = id;
				}
				internal int Port;
				internal string Type;
				byte[] buf_ = new byte[1];
//				ReceiverStream ReceiverStream = new ReceiverStream();

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
						if (MessageReceived != null) MessageReceived(this, bytes);
						BeginReceive();
					}
					catch (ObjectDisposedException)
					{
						if (ConnectionClosed != null) ConnectionClosed(this);
					}
				}

				internal event MessageReceivedHandler MessageReceived;
				internal delegate void MessageReceivedHandler(TCPConnection sender, byte[] bytes);

				internal event ConnectionClosedHandler ConnectionClosed;
				internal delegate void ConnectionClosedHandler(TCPConnection sender);

				internal void Send(byte[] bytes)
				{
					Socket.Send(bytes);
				}

				Socket Socket;

				public void Dispose()
				{
					if (Socket.Connected) Socket.Close();
					Socket.Dispose();
					if (ConnectionClosed != null) ConnectionClosed(this);
				}
			}
		}
	}
}
