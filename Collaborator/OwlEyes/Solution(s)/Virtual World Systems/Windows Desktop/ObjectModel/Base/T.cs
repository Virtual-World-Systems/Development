using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.ObjectModel
{
	public class T : O, named
	{
		public T() { Name = "(n/a)"; }
		public T(string name) { Name = name; }
		public string Name { get; set; }
	}
}
