using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.IO
{
	public class HTTPMessage
	{
		public HTTPMessage(byte[] bytes, Stream stream, string id)
		{
			int eoh = -1; ID = id;
			for (int i = 0; i < bytes.Length; i++) if (is_double_EOL(bytes, i)) { eoh = i + 1; break; }
			if (eoh == -1) throw new EndOfStreamException();
			string msg = Encoding.ASCII.GetString(bytes, 0, eoh);
			Debug.WriteLine($"\r\nHTTPMessage\r\n>>>{msg}<<<");
			StringReader stringReader = new StringReader(msg);
			(string H1, string H2, string H3) = RH_from(stringReader.ReadLine());
			if (H1 == "HTTP/1.1") (Marker, Code, Desc) = (H1, int.Parse(H2), H3);
			else (Command, URL, Marker) = (H1, H2, H3);
			string line; int contentLength = 0;
			while ((line = stringReader.ReadLine()) != "")
			{
				if (line == null) break;
				(string HKey, string HVal) = H_from(line);
				if (string.IsNullOrEmpty(HKey)) continue;
				Headers[HKey] = HVal;
			}
			if (Headers.Contains("Content-Length")) contentLength = int.Parse(Headers["Content-Length"].ToString());
			if (eoh < bytes.Length) ms.Write(bytes, eoh, bytes.Length - eoh);
			if (ms.Length < contentLength) fill_Body_from(stream, contentLength - (int)ms.Length);
			Body = ms.GetBuffer(); ms.Dispose();
		}
		public string ID { get; private set; }
		public string Marker, Desc, Command = "", URL = ""; public int Code = -1;
		public OrderedDictionary Headers = new OrderedDictionary();
		MemoryStream ms = new MemoryStream();
		public byte[] Body { get; private set; }

		public string MetaInfo
		{
			get
			{
				string s = (Command == "") ? $"{Marker} {Code} {Desc}" : $"{Command} {URL} {Marker}";
				foreach (DictionaryEntry kvp in Headers) s += $"\r\n{kvp.Key}: {kvp.Value}";
				return s + "\r\n\r\n";
			}
		}

		bool is_double_EOL(byte[] bytes, int i)
		{
			if (bytes[i] != '\n') return false;
			int o = i - 1; if (o < 0) return false;
			if (bytes[o] == '\n') return true;
			o = i - 3; if (o < 0) return false;
			if ((bytes[o] == '\r') && (bytes[o+1] == '\n') && (bytes[o+2] == '\r') && (bytes[o+3] == '\n')) return true;
			return false;
		}
		(string, string, string) RH_from(string line)
		{
			Regex regex = new Regex(
				@"(?<H1>[^\s]*)\s(?<H2>[^\s]*)\s(?<H3>[^\s]*)$",
				RegexOptions.ExplicitCapture | RegexOptions.Singleline);
			Match match = regex.Match(line);
			return (match.Groups["H1"].Value, match.Groups["H2"].Value, match.Groups["H3"].Value);
		}
		(string, string) H_from(string line)
		{
			Regex regex = new Regex(
				@"(?<H1>[^\:]*):\s(?<H2>[^$]*)$",
				RegexOptions.ExplicitCapture | RegexOptions.Singleline);
			Match match = regex.Match(line);
			string HKey = match.Groups["H1"].Value;
			string HVal = match.Groups["H2"].Value;
			StringBuilder sb = new StringBuilder();
			bool bUpper = true;
			foreach (char c in HKey)
			{
				char cr = c;
				if (bUpper) cr = char.ToUpper(cr);
				sb.Append(cr);
				bUpper = (cr == '-');
			}
			return (sb.ToString(), HVal);
		}
		void fill_Body_from(Stream stream, int len)
		{
			int o = 0, ln;
			byte[] buf = new byte[len];
			while ((ln = stream.Read(buf, o, len)) < len) { o += ln; len -= ln; }
			ms.Write(buf, 0, buf.Length);
		}

		public byte[] ToBytes()
		{
			byte[] buf0 = Encoding.ASCII.GetBytes(MetaInfo);
			byte[] buf = new byte[buf0.Length + Body.Length];
			Array.Copy(buf0, 0, buf, 0, buf0.Length);
			Array.Copy(Body, 0, buf, buf0.Length, Body.Length);
			return buf;
		}
		public string BodyAsAscii()
		{
			return Encoding.ASCII.GetString(Body);
		}
	}
}
