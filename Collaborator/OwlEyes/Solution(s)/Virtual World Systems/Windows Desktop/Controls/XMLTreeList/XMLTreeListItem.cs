using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class XMLTreeListItem
	{
		internal XMLTreeListItem(XMLTreeListPanel p, Element e, int i)
		{
			parent = p;
			Element = e;
			Index = i;
		}
		object parent;
		internal int Index;
		internal Element Element;
		internal Size Size;

		internal int Width { get => Size.Width; }
		internal int Height { get => Size.Height; }

		internal XMLTreeListPanel TreeListPanel
		{
			get
			{
				object o = parent;
				while (o is XMLTreeListItem)
					o = (o as XMLTreeListItem).parent;
				return (o as XMLTreeListPanel);
			}
		}
		//internanl
		internal XMLTreeListItem ParentItem
		{
			get => (parent is XMLTreeList) ? null : (parent as XMLTreeListItem);
		}

		internal Size MeasureClosed(XMLTreeListPanel panel, Graphics g)
		{
			return (Size = XMLTreeListPanel.Painter.
				Measure(g, panel.Font, Element.DisplayName));
		}

		internal void Draw(XMLTreeListPanel panel, Graphics g, Point pt, Size sz)
		{
			XMLTreeListPanel.Painter.Draw(g, panel.Font, Element.DisplayName, pt, sz, panel.ForeColor, panel.BackColor);
		}

		internal void Click(Target target)
		{
			if (target.part.ToString() == "Button")
			{
				if (!Element.HasAttribute("runtime:open"))
				{
					Rectangle r = TreeListPanel.GetItemRect(this);
					r.Offset(16, Size.Height);
					r.Width -= 16;
					r.Height += 50;
					XMLTreeListPanel c = new XMLTreeListPanel();
					c.AutoScroll = true;
					TreeListPanel.Controls.Add(c);
				}
			}
			Debug.WriteLine($"click(1) item={target.item.Index}, rect={target.rect}, part={target.part}");
			Debug.WriteLine($"click(2) {Element.DisplayName}");
		}
		internal Target FindMouseTarget(Point pt)
		{
			string s;
			Rectangle r = TreeListPanel.GetItemRect(this);
			if (pt.X < 10)
			{
				r.Width = 10;
				s = "Button";
			}
			else
			{ 
				r.Offset(10, 0);
				r.Width -= 10;
				s = "Text";
			}
			return new Target(this, s, r);
		}
	}
}
