using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSimulator
{
	public partial class Objects
	{
		public class Server : _
		{
			public Server(string name) : base(name) { }
			static public __<Server> List = new __<Server>("Servers");

			public string CCC { get; set; }

			public override List<string> GetHiddenProperties()
			{
				List<string> hidden = base.GetHiddenProperties();
				hidden.Add("CCC");
				return hidden;
			}
		}
	}
}
