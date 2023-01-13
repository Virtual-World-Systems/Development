using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.misc
{
	public class Rect<T>
	{
		public T Object { get; private set; } = default;
		public Size Size { get; private set; } = default;
		public Point Location { get; private set; } = default;

		public Rect() { }
		public Rect<T> Attach(T obj)
		{
			Object = obj;
			return this;
		}
	}

	// X: vdvdv
	// Y: vdvdv

	// PTL: (24,24)
	// STL: ( 5,20)
	// PCC: (24,24)
	// SRB: ( 9, 9)
	// PRB: (24,24)

	// R((0,3),(5,1),TCPPipe)
	// R((0,0),(1,1),ClientIncoming)
	// R((0,3),(3,1),TCPPipe)
	// R((0,3),(3,1),TCPPipe)
}
