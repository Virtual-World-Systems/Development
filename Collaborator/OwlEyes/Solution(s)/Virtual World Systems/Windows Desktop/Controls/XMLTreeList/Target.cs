using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class Target
	{
		internal Target(ItemView item, object part, Rectangle rect)
		{
			this.item = item;
			this.rect = rect;
			this.part = part;
		}
		internal ItemView item;
		internal Rectangle rect;
		internal object part;

		internal void Click() { item.Click(this); }

		public bool Equals(Target other)
		{
			return (other == null) ? false :
				(item == other.item) &&
				(rect == other.rect) &&
				(part == other.part);
		}
	}
}
