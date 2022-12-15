using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenSimulator
{
	public partial class O/*bject*/
	{
		O() { }

		private DataRow DataRow = null;
		public O(DataRow row) { DataRow = row; }

		public string DisplayName { get { return "(an object)"; } }

		public partial class L/*ist*/: O
		{
			public L(params O[] oo) {
				foreach (O o in oo) System.Diagnostics.Debug.WriteLine(o.ToString());
			}
		}

		public partial class T/*ype*/: O
		{
		}

		public partial class K/*ey*/: O
		{
		}

		public partial class P/*roperty(Descriptor)*/: O
		{
		}

		public partial class R/*ole(Interface)*/: O
		{
		}
		public static O From(K key) { return new O(key); }
		public O(K key) { }
	}
}
