using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using VWS.IO;

namespace VWS.WindowsDesktop.Logging
{
	public class Log
	{
		static internal void Write(string text, EventLogEntryType entryType)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(NOW);
			sb.Append($"{entryType} ");
			sb.Append(entryType.ToString()[0]).Append(' ');
			sb.AppendFormat("({0}) ", Thread.CurrentThread.GetHashCode());
			sb.Append(text);
			Console.WriteLine(sb.ToString());
		}

		static internal void Write(string text, EventLogEntryType entryType, short category)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(NOW);
			sb.Append($"{category}:{entryType} ");
			sb.Append(entryType.ToString()[0]).Append(' ');
			sb.AppendFormat("({0}) ", Thread.CurrentThread.GetHashCode());
			sb.Append(text);
			Console.WriteLine(sb.ToString());
		}

		static string NOW { get { return string.Format("{0:dd.MM.yyyy HH:mm:ss.fff} ", DateTime.Now); } }

		static internal void Error(string text) { Write(text, EventLogEntryType.Error); }
		static internal void Info(string text) { Write(text, EventLogEntryType.Information); }
		static internal void Info(string text, short category) { Write(text, EventLogEntryType.Information, category); }

		static internal void Error(TCPListener listener, string text) { Write(with(listener, text), EventLogEntryType.Error); }
		static internal void Info(TCPListener listener, string text) { Write(with(listener, text), EventLogEntryType.Information); }
		static private string with(TCPListener listener, string text) { return ">< " + text; }

		static internal void Error(TCPConnection handler, string text) { Write(with(handler, text), EventLogEntryType.Error); }
		static internal void Info(TCPConnection handler, string text) { Write(with(handler, text), EventLogEntryType.Information); }
		static private string with(TCPConnection handler, string text) { return String.Format("<{0}> {1}", handler.ID, text); }

		static internal void Error(HTTPMessage message, string text) { Write(with(message, text), EventLogEntryType.Error); }
		static internal void Info(HTTPMessage message, string text) { Write(with(message, text), EventLogEntryType.Information); }
		static private string with(HTTPMessage message, string text) { return String.Format("<{0}> {1}", message.ID, text); }

		static internal void Info(TCPConnection message, string text, string data)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(text);
			foreach (string s in data.Split('\r', '\n')) sb.Append((s.Length == 0) ? "" : "\n   ").Append(s);
			Info(message, sb.ToString());
		}

		static internal void Info(HTTPMessage message, string text, string data)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(text);
			foreach (string s in data.Split('\r', '\n')) sb.Append((s.Length == 0) ? "" : "\n   ").Append(s);
			Info(message, sb.ToString());
		}
	}
}
