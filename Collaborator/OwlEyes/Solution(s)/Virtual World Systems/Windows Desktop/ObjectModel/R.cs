using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.ObjectModel
{
	public interface R
	{
		string Name { get; set; }
	}
	public interface named : R { }

	class Test
	{
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private string name = null;

		
	}
}
