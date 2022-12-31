using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.ObjectModel
{
	public class A : O, named
	{
		public string Name { get; set; }
	}
}
