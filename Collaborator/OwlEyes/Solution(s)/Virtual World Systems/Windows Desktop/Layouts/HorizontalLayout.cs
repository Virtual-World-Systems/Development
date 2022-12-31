using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Layouts
{
	public class HorizontalLayout : _Layout
	{
		// 
		public HorizontalLayout(params object[] nodes)
		{
			Nodes = nodes;
		}
		object[] Nodes = null;
	}
}
