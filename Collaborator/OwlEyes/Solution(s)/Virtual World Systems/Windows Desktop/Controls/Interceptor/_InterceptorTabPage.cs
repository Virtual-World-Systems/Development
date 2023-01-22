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
			c.HTTPMessageReceived += Connection_HTTPMessageReceived;
			c.ConnectionClosed += Connection_Closed;
			//addUDPListener(c.ID);
		}

		void addUDPListener(string id)
		{
			int port = 17000 + int.Parse(id.Substring(2));
			UDPListener udpClient = new UDPListener(port, id);
			string udpPort = "" + udpClient.Client.LocalEndPoint;
			udpPort = udpPort.Substring(udpPort.IndexOf(":") + 1);
			ListViewItem lvi = new ListViewItem(new string[] { udpPort, id });
			lvi.Tag = udpClient; UDPListeners.Items.Add(lvi);
			udpClient.Listen();
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

		private void Connection_HTTPMessageReceived(TCPConnection c, HTTPMessage msg)
		{
			Debug.WriteLine($"\r\n{c} incoming\r\n{msg.MetaInfo}\r\n");

			if ((msg.Command == "GET") && (msg.URL == "/get_grid_info"))
			{
				//msg.Headers["Host"] = "kitely.com:8002";
				msg.Headers["Host"] = "ernsoft.selfhost.eu:8002";
				int ViewerPort = int.Parse(msg.Headers["X-SecondLife-UDP-Listen-Port"].ToString());
				msg.Headers["X-SecondLife-UDP-Listen-Port"] = "17009";
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
				string xxx = @"<gridinfo>
<gridnick>VWS rOWLplay</gridnick>
<register>http://ernsoft.selfhost.eu/register</register>
<gridname>virtual-world-systems</gridname>
<gatekeeper>http://virtual-world-systems.net:5404/</gatekeeper>
<password>http://ernsoft.selfhost.eu/password</password>
<platform>OpenSim</platform>
<login>http://virtual-world-systems.net:5404/</login>
<welcome>https://virtual-world-systems.net/</welcome>
<about>http://ernsoft.selfhost.eu/about</about>
<GridStatusRSS>http://ernsoft.selfhost.eu:8002/GridStatusRSS</GridStatusRSS>
<help>http://ernsoft.selfhost.eu/help</help>
<GridStatus>http://ernsoft.selfhost.eu:8002/GridStatus</GridStatus>
</gridinfo>";

				Send(c, $"{msgR.MetaInfo}", ee.OuterXml);
			}
			else if ((msg.Command == "POST") && (msg.URL == "/"))
			{
				byte[] body = msg.Body;
				string xmlS = Encoding.ASCII.GetString(body);
				Debug.WriteLine($"{xmlS}");
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
				Send(c, msgR.MetaInfo, xmlS);
				return;
			}
			//c.Send(buf);
			Send(c, H, B);
		}

		string MSG_grid_info_response = @"<gridinfo>
<economy>http://grid.kitely.com:8002/</economy>
<gatekeeper>http://grid.kitely.com:8002/</gatekeeper>
<gridname>Kitely</gridname>
<gridnick>Kitely</gridnick>
<login>http://grid.kitely.com:8002/</login>
<platform>OpenSim</platform>
<uas>http://grid.kitely.com:8002/</uas>
<welcome>http://www.kitely.com/viewer_login</welcome>
</gridinfo>";

		string MSG_00000_Info = @"GET /get_grid_info HTTP/1.1
Host: virtual-world-systems.net:5404
Accept-Encoding: deflate, gzip
Connection: keep-alive
Keep-alive: 300
Accept: application/llsd+xml
Content-Type: application/llsd+xml
X-SecondLife-UDP-Listen-Port: 51247";

		string Login_Message = @"
<methodCall>
	<methodName>login_to_simulator</methodName>
	<params>
		<param>
			<value>
				<struct>
					<member>
						<name>address_size</name>
						<value><int>64</int></value>
					</member>
					<member>
						<name>agree_to_tos</name>
						<value><int>0</int></value>
					</member>
					<member>
						<name>channel</name>
						<value><string>Firestorm-MyViewer</string></value>
					</member>
					<member>
						<name>extended_errors</name>
						<value><int>1</int></value>
					</member>
					<member>
						<name>first</name>
						<value><string>Tom</string></value>
					</member>
					<member>
						<name>host_id</name>
						<value><string/></value>
					</member>
					<member>
						<name>id0</name>
						<value><string>08fc2f897b5c0bd473a264a803585b6d</string></value>
					</member>
					<member>
						<name>last</name>
						<value><string>Ernst</string></value>
					</member>
					<member>
						<name>last_exec_duration</name>
						<value><int>0</int></value>
					</member>
					<member>
						<name>last_exec_event</name>
						<value><int>0</int></value>
					</member>
					<member>
						<name>mac</name>
						<value><string>9807fa52169778545778cf3f3b4aaaa6</string></value>
					</member>
					<member>
						<name>passwd</name>
						<value><string>$1$</string></value>
					</member>
					<member>
						<name>platform</name>
						<value><string>win</string></value>
					</member>
					<member>
						<name>platform_string</name>
						<value><string>Windows Server 64-bit</string></value>
					</member>
					<member>
						<name>platform_version</name>
						<value><string>10.0.17763</string></value>
					</member>
					<member>
						<name>read_critical</name>
						<value><int>0</int></value>
					</member>
					<member>
						<name>start</name>
						<value><string>last</string></value>
					</member>
					<member>
						<name>version</name>
						<value><string>6.5.4.65581</string></value>
					</member>
					<member>
						<name>options</name>
						<value>
							<array>
								<data>
									<value><string>inventory-root</string></value>
									<value><string>inventory-skeleton</string></value>
									<value><string>inventory-lib-root</string></value>
									<value><string>inventory-lib-owner</string></value>
									<value><string>inventory-skel-lib</string></value>
									<value><string>initial-outfit</string></value>
									<value><string>gestures</string></value>
									<value><string>display_names</string></value>
									<value><string>event_categories</string></value>
									<value><string>event_notifications</string></value>
									<value><string>classified_categories</string></value>
									<value><string>adult_compliant</string></value>
									<value><string>buddy-list</string></value>
									<value><string>newuser-config</string></value>
									<value><string>ui-config</string></value>
									<value><string>advanced-mode</string></value>
									<value><string>max-agent-groups</string></value>
									<value><string>map-server-url</string></value>
									<value><string>voice-config</string></value>
									<value><string>tutorial_setting</string></value>
									<value><string>login-flags</string></value>
									<value><string>global-textures</string></value>
									<value><string>currency</string></value>
									<value><string>max_groups</string></value>
									<value><string>search</string></value>
									<value><string>destination_guide_url</string></value>
									<value><string>avatar_picker_url</string></value>
								</data>
							</array>
						</value>
					</member>
				</struct>
			</value>
		</param>
	</params>
</methodCall>
";
		void Send(TCPConnection c, string h, string b)
		{
			byte[] bb = Encoding.UTF8.GetBytes(b);
			string hNew = h.Replace("{?}", "" + bb.Length);
			Debug.WriteLine("\r\nsending\r\n" + hNew + b + "\r\n");
			byte[] bh = Encoding.UTF8.GetBytes(hNew);
			byte[] xx = new byte[bh.Length + bb.Length];
			Array.Copy(bh, 0, xx, 0, bh.Length);
			Array.Copy(bb, 0, xx, bh.Length, bb.Length);
			c.Send(xx);
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
