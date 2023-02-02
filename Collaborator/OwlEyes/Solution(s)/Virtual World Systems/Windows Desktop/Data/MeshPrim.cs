using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.OSSL.Types
{
	public abstract class MeshPrim
	{
		public class Mesh : MeshPrim { }
		public class Prim : MeshPrim { }
	}
}
