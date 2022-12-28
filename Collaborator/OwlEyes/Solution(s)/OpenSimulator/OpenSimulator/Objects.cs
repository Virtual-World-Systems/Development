using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenSimulator
{
	public partial class Objects
	{
		public class _
		{
			internal _(string name) { Name = name; }
			public string _Type_ { get { return _.ToString(this); } }
			public string Name { get; set; }

			public string URL { get; set; }

			virtual public List<string> GetHiddenProperties() { return new List<string>(); }

			internal static string ToString(object t)
			{
				string s = t.ToString();
				if (s.IndexOf("+") != -1) s = s.Substring(s.IndexOf("+") + 1);
				return s;
			}
		}
		public class __<T> : List<T>
		{
			public __(string name) { Name = name; }

			public string _Type_ { get { return __<T>.ToString(this); } }

			public string Name { get; set; }

			internal static string ToString(__<T> t)
			{
				string s = t.ToString();
				s = "List of " + t.Name;
				//string[] ss = s.Split('[', ']');
				//s = ss[1].Substring(ss[1].IndexOf("+") + 1);
				//MessageBox.Show(s);
				return s;
				//Assembly.GetExecutingAssembly().LoadModule("xxx", null);
			}
		}
	}
}
