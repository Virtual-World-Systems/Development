using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop
{
	public static class RT
	{
		public class I : IDisposable
		{
			public I() { Indent++; }
			public void Dispose() { if (Indent > 0) Indent--; }

			internal static int Indent = 0;

			public string S { get => new string(' ', Indent * 4); }
		}
		public static I IN { get => new I(); }
		public static string S { get => new string(' ', I.Indent * 4); }
	}
}
