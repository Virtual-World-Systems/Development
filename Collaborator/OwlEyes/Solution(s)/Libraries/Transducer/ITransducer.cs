using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ernsoft.Transducer
{
	public interface Interface
	{
		public Interface Create(string args) { }
		string Name { get; set; }
	}
}
