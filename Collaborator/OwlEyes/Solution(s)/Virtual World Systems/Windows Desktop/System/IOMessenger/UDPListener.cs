using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop
{
	partial class IOMessenger
	{
		partial class Listener
		{
			internal class UDPListener : UdpClient
			{
				internal UDPListener(int port, string id) : base(port) { _ID = id; }
				public string ID { get { return _ID; } } string _ID = "";

				internal void Listen()
				{
					Task.Run(async () =>
					{
						while (true)
						{
							var udp = await ReceiveAsync();
							string txt = Encoding.ASCII.GetString(udp.Buffer);
							Debug.WriteLine($"\r\nUDPListener[{ID}]\r\n" + txt + "\r\n");
						}
					});
				}
			}
		}
	}
}
