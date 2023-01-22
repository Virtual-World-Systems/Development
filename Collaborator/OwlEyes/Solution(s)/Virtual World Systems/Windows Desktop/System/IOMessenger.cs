using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop
{
	public partial class IOMessenger
	{
		public abstract partial class Listener : IDisposable
		{
			public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
			public virtual void Dispose() { }
			string Specification { get { return ""; } }
		}

		public class Connection
		{
			public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
			string Specification { get { return "" + _ID; } }
			internal string _ID { get; set; }
			public string ID { get { return (_ID != null) ? _ID : "a Connection"; } }
		}

		public class Message
		{
			public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
			string Specification { get { return "" + _ID; } }
			public string ID { get { return (_ID != null) ? _ID : "a Message"; } }
			string _ID { get; set; }
		}
	}
}
