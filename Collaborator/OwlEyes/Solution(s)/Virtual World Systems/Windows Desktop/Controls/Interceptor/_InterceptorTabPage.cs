using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VWS.IO;
using XML;

namespace VWS.WindowsDesktop.Controls
{
	public partial class InterceptorTabPage : TabPage
	{
		public InterceptorTabPage()
		{
			InitializeComponent();

			DataGridView DataGrid = new DataGridView();
			DataGrid.Dock = DockStyle.Fill;
			//DataGrid.AutoSize = true;
			DataGrid.Height = 400;
			DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			TopPanel.Controls.Add(DataGrid);
		}

		Visible_NxN Content { get { return BorderedScrollableInterceptor.Scrollable.Interceptor; } }

		private void Listeners_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			TCPListener listener = (TCPListener)e.Item.Tag;

			if (listener == null)
			{
				int port = int.Parse(e.Item.SubItems[1].Text);
				listener = new TCPListener(port);
				e.Item.Tag = listener;
				listener.ConnectionAccepted += Listener_ConnectionAccepted;

			}
			if (e.Item.Checked) listener.Start(); else listener.Stop();
		}
		void Listener_ConnectionAccepted(object sender, TCPConnection c)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { Listener_ConnectionAccepted(sender, c); }));
				return;
			}
			ListViewItem lvi = new ListViewItem(new string[] { "TCP", "" + c.Port, c.ID });
			lvi.Tag = c; Connections.Items.Add(lvi);
			c.MessageReceived += Connection_RawMessageReceived;
			c.HTTPMessageReceived += Connection_HTTPMessageReceived;
			c.ConnectionClosed += Connection_Closed;
			addUDPListener(c.ID);
		}

		private void Connection_RawMessageReceived(TCPConnection sender, byte[] bytes)
		{
			throw new NotImplementedException();
		}

		private void Connection_Closed(TCPConnection c)
		{
			if (InvokeRequired)
			{
				Invoke(new MethodInvoker(() => { Connection_Closed(c); }));
				return;
			}
			ListViewItem lvi_found = null;
			foreach (ListViewItem lvi in Connections.Items)
				if (lvi.SubItems[2].Text == c.ID) lvi_found = lvi;
			if (lvi_found != null) lvi_found.Remove();
		}

		bool udpOpen = false;
		void addUDPListener(string id)
		{
			if (udpOpen) return; udpOpen = true;
			int port = 17009;// 17000 + int.Parse(id.Substring(2));
			UDPListener udpClient = new UDPListener(port, id);
			string udpPort = "" + udpClient.Client.LocalEndPoint;
			udpPort = udpPort.Substring(udpPort.IndexOf(":") + 1);
			ListViewItem lvi = new ListViewItem(new string[] { udpPort, id });
			lvi.Tag = udpClient; UDPListeners.Items.Add(lvi);
			udpClient.Send(new byte[0], 0, "virtual-world-systems.net", port);
			udpClient.Listen();
		}

		private void Connection_HTTPMessageReceived(TCPConnection c, HTTPMessage msg)
		{
			Debug.WriteLine($"\r\n{c} incoming\r\n{msg.MetaInfo}{msg.BodyAsAscii()}");

			if (msg.Command == "GET")
			{
				if (msg.URL == "/get_grid_info")
				{
					process__get_grid_info(c, msg);
					return;
				}
				if (msg.URL.StartsWith("/welcome?"))
				{
					process__welcome(c, msg);
					return;
				}
				throw new NotImplementedException($"received GET, URL not recognized: {msg.URL}");
			}
			if (msg.Command == "POST")
			{
				if (msg.URL == "/")
				{
					process__post_(c, msg);
					return;
				}
				throw new NotImplementedException($"received POST, URL not recognized: {msg.URL}");
			}
			throw new NotImplementedException($"received {msg.Command}, not recognized");
			//c.Send(buf);
		}

		private void process__welcome(TCPConnection c, HTTPMessage msg)
		{
			c.SendHTTP(c, H, B);
		}

		private void process__post_(TCPConnection c, HTTPMessage msg)
		{
			byte[] body = msg.Body;
			string xmlS = Encoding.ASCII.GetString(body);
			//Debug.WriteLine($"{xmlS}");
			string hh = "<?xml version=\"1.0\"?>";
			xmlS = xmlS.Substring(hh.Length);

			//msg.Headers["Host"] = "kitely.com:8002";
			msg.Headers["Host"] = "ernsoft.selfhost.eu:8002";

			//using (Element xml = Program.XML.ReadString(xmlS))
			//{
			//	Element e = xml.SelectElement("params/param/value/struct/member/name[text()='passwd']");
			//	e.Parent.SelectElement("value/string").InnerText = "t4084.4084";
			//	xmlS = hh + e.OuterXml;
			//}
			//body = Encoding.ASCII.GetBytes(xmlS);
			//msg.Headers["Content-Length"] = "" + body.Length;

			HTTPMessage msgR = null;

			//using (TcpClient tcpClient = new TcpClient("kitely.com", 8002))
			using (TcpClient tcpClient = new TcpClient("ernsoft.selfhost.eu", 8002))
			{
				NetworkStream str = tcpClient.GetStream();
				byte[] buf0 = Encoding.ASCII.GetBytes($"{msg.MetaInfo}");
				byte[] buf = new byte[buf0.Length + body.Length];
				Array.Copy(buf0, 0, buf, 0, buf0.Length);
				Array.Copy(body, 0, buf, buf0.Length, body.Length);
				str.Write(buf, 0, buf.Length); str.Flush();
				byte[] bufI = new byte[4096];
				int len = str.Read(bufI, 0, bufI.Length);
				byte[] bufR = new byte[len];
				Array.Copy(bufI, 0, bufR, 0, len);
				msgR = new HTTPMessage(bufR, str, c.ID);
				tcpClient.Close();
			}
			xmlS = msgR.BodyAsAscii();
			Debug.WriteLine($"\r\nLogin Response:\r\n{msgR.MetaInfo}{xmlS}\r\n");
			c.SendHTTP(c, msgR.MetaInfo, xmlS);
		}

		private void process__get_grid_info(TCPConnection c, HTTPMessage msg)
		{
			//msg.Headers["Host"] = "kitely.com:8002";
			msg.Headers["Host"] = "ernsoft.selfhost.eu:8002";
			int ViewerPort = 0;
			try
			{
				int.TryParse("" + msg.Headers["X-SecondLife-UDP-Listen-Port"], out ViewerPort);
				if (ViewerPort != 0) msg.Headers["X-SecondLife-UDP-Listen-Port"] = "17009";
			}
			catch { }
			Debug.WriteLine($"\r\nmodified\r\n{msg.MetaInfo}\r\n");
			HTTPMessage msgR = null;
			//using (TcpClient tcpClient = new TcpClient("kitely.com", 8002))
			using (TcpClient tcpClient = new TcpClient("ernsoft.selfhost.eu", 8002))
			{
				NetworkStream str = tcpClient.GetStream();
				byte[] buf = Encoding.ASCII.GetBytes($"{msg.MetaInfo}");
				str.Write(buf, 0, buf.Length); str.Flush();
				byte[] bufI = new byte[4096];
				int len = str.Read(bufI, 0, bufI.Length);
				byte[] bufR = new byte[len];
				Array.Copy(bufI, 0, bufR, 0, len);
				msgR = new HTTPMessage(bufR, str, c.ID);
				tcpClient.Close();
			}
			Debug.WriteLine($"\r\nResponse:\r\n{msgR.MetaInfo}\r\n");
			msgR.Headers["Content-Length"] = "{?}";
			string xml = Encoding.UTF8.GetString(msgR.Body);
			Element ee = (Element)Program.XML.ReadString(xml);
			Replace(ee, "economy", "http://virtual-world-systems.net:5404/economy");
			Replace(ee, "gatekeeper", "http://virtual-world-systems.net:5404/");
			Replace(ee, "gridname", "_rOWLplay");
			Replace(ee, "gridnick", "_rOWLplay");
			Replace(ee, "login", "http://virtual-world-systems.net:5404/");
			Replace(ee, "uas", "http://virtual-world-systems.net:5404/uas");
			Replace(ee, "welcome", "http://virtual-world-systems.net:5404/welcome");
			Replace(ee, "about", "http://virtual-world-systems.net:5404/about");
			Replace(ee, "GridStatus", "http://virtual-world-systems.net:5404/GridStatus");
			Replace(ee, "GridStatusRSS", "http://virtual-world-systems.net:5404/GridStatusRSS");
			Replace(ee, "help", "http://virtual-world-systems.net:5404/help");
			Replace(ee, "password", "http://virtual-world-systems.net:5404/password");
			Replace(ee, "register", "http://virtual-world-systems.net:5404/register");
			void Replace(Element elem, string name, string value)
			{
				elem = elem.SelectElement(name);
				if (elem != null) elem.InnerText = value;
			}
			c.SendHTTP(c, $"{msgR.MetaInfo}", ee.OuterXml);
		}

		static string H = @"HTTP/1.1 200 OK
Cache-Control: no-cache
Pragma: no-cache
Content-Type: text/html; charset=utf-8
Connection: Keep-Alive
Expires: -1
Server: Microsoft-IIS/10.0
X-AspNet-Version: 4.0.30319
Set-Cookie: .=1; domain=virtual-world-systems.net; expires=Sat, 07-Jan-2023 14:53:13 GMT; path=/; secure; SameSite=Strict
X-Powered-By: ASP.NET
Date: Sat, 07 Jan 2023 14:52:53 GMT
Content-Length: {?}

";
		static string B = @"<html><head><title>XXX</title></head><body>TEST</body></html>";
	}
}
