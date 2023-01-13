using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop
{
	public class IOMessenger
	{
		public class Listener
		{
			public override string ToString() { return $"{GetType().Name}[{Specification}]"; } string Specification { get { return ""; } }
		}

		public class Connection
		{
			public override string ToString() { return $"{GetType().Name}[{Specification}]"; }
			string Specification { get { return "" + _ID; } }
			public string ID { get { return (_ID != null) ? _ID : "a Connection"; } } string _ID { get; set; }
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
