using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.WebSockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

/// <summary>
/// Summary description for WebSocket
/// </summary>
public class WebSocket
{
	HttpContext HttpContext;
	string ClientApplicationVersion = "";
	internal WebSocket(HttpContext context) { HttpContext = context; }
	internal async Task RunWebSocket(AspNetWebSocketContext context)
	{
		System.Net.WebSockets.WebSocket socket = context.WebSocket;
		ClientApplicationVersion = context.ServerVariables["HTTP_USER_AGENT"];
		string logPath = context.Server.MapPath("/App_Data") + "\\clientapplog.txt";
		File.AppendAllText(logPath, ClientApplicationVersion + "\r\n");

		while (true)
		{
			ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[256]);
			WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
			if (socket.State == WebSocketState.Open)
			{
				MemoryStream ms = new MemoryStream();
				ms.Write(buffer.Array, 0, result.Count);

				while (!result.EndOfMessage)
				{
					result = await socket.ReceiveAsync(buffer, CancellationToken.None);
					if (result.Count > 0) ms.Write(buffer.Array, 0, result.Count);
				}
				Debug.WriteLine("read " + ms.Length + " bytes");
				string userMessage = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);

				if (userMessage == "ok") continue;

				if (userMessage.StartsWith("<"))
				{
					string r = "";
					XmlDocument doc = new XmlDocument();

					try { doc.LoadXml(userMessage); }
					catch(Exception e) { r = "error^^^" + e.Message; }
					if (r != "") { await SendText(socket, r); continue; }

					if (doc.DocumentElement == null) { await SendText(socket, "error^^^no XML-DocumentElement"); continue; }
					XmlElement el = doc.CreateElement("result");
					doc.DocumentElement.AppendChild(el);
					string t = DB.select("___", "*");
					await SendText(socket, t);

					StringBuilder sb = new StringBuilder();
					using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=sasquatch;pwd=sasquatch;database=sasquatch"))
					{
						conn.Open();
						MySqlCommand cmd = new MySqlCommand("select * from assets"
//							+ " where " +
//							"(id='00000000-0000-1111-9999-000000000001')OR" +
//							"(id='00000000-0000-1111-9999-000000000003')"
							, conn);
						using (MySqlDataReader rdr = cmd.ExecuteReader())
						{
							sb.Append("<test>");
							while (rdr.Read())
							{
								sb.Append("<_");
								string s, k;
								byte[] buf = new byte[0];
								for (int i = 0; i < rdr.FieldCount; i++)
								{
									k = rdr.GetFieldType(i).Name;
									if (k == "Byte[]") k = "Bytes";
									sb.Append(" " + rdr.GetName(i) + "." + k + "=\"");
									if (k == "Bytes")
									{
										try
										{
											buf = (byte[])rdr.GetValue(i);
										}
										catch(Exception e)
										{
											Debug.WriteLine(e.ToString());
										}
										s = Convert.ToBase64String(buf, 0, (int)buf.Length);
									}
									else s = rdr.GetString(i);
									sb.Append(s);
									sb.Append("\"");
								}
								sb.Append("/>");
							}
							sb.Append("</test>");
						}
						conn.Close();
					}
					await SendText(socket, sb.ToString());

					//try
					//{
					//	switch (doc.DocumentElement.Name)
					//	{
					//		case "on_login": await X_on_login(doc.DocumentElement); break;
					//		case "get_cc": await X_get_cc(doc.DocumentElement); break;
					//		case "set_location": await X_set_location(doc.DocumentElement); break;
					//		default: throw new QueryException("not a method: " + doc.DocumentElement.Name);
					//	}
					//}
					//					catch (Exception qe) { r = qe.Message; }
					//					if (r != "") await SendText(socket, "Exception^^^" + r);
					continue;
				}
				await SendText(socket, ">>> " + userMessage + " <<<");
			}
		}
	}
	private async Task SendText(System.Net.WebSockets.WebSocket socket, string str)
	{
		await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(str)), WebSocketMessageType.Text, true, CancellationToken.None);
	}
}