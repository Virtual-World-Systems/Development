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
	internal class ItemView
	{
		internal ItemView(ListView p, Element e, int i)
		{
			ItemList = p;
			Element = e;
			Index = i;
		}
		ListView ItemList;
		internal Element Element;
		internal int Index;

		internal Size Size;
		internal Size HeaderSize;
		internal Size ContentSize;

		internal int Width { get => Size.Width; }
		internal int Height { get => Size.Height; }

		internal XMLTreeListPanel Panel
		{
			get => (XMLTreeListPanel)ItemList.Control;
		}
		
		internal XMLTreeListPanel TopTreeListPanel
		{
			get
			{
				XMLTreeListPanel p = Panel;
				while (p.Parent is XMLTreeListPanel)
					p = (XMLTreeListPanel) p.Parent;
				return p;
			}
		}

		internal Size ComputeSize(XMLTreeListPanel panel, Graphics g)
		{
			return (HeaderSize = (Size = XMLTreeListPanel.Painter.
				Measure(g, panel.Font, Element.DisplayName)));
		}

		internal void Draw(XMLTreeListPanel panel, Graphics g, Point pt, Size sz)
		{
			sz.Height = HeaderSize.Height;
			XMLTreeListPanel.Painter.Draw(g, panel.Font,
				Element.DisplayName, pt, sz, panel.ForeColor, panel.BackColor);
		}

		internal Target TargetFromPoint(Point pt)
		{
			//Debug.WriteLine($"TargeFromPoint, Item={Index}, Point={pt}");

			Rectangle r = Rectangle.Empty;
			r.Height = HeaderSize.Height;

			r.Width = 10;
			if (r.Contains(pt))
			{
				return new Target(this, "Button", r);
			}
			r.Offset(r.Width, 0);

			r.Width = Size.Width - r.Left;
			return new Target(this, "Text", r);
		}

		internal void Click(Target target)
		{
			if (target.part.ToString() == "Button")
			{
				if ((childPanel == null) || (!childPanel.Visible))
				{
					if (childPanel == null)
					{
						childPanel = new XMLTreeListPanel();
						childPanel.SizeChanged += ChildPanel_SizeChanged;
						childPanel.ParentElement = Element;
						Size sz = childPanel.AutoScrollMinSize;
						//Debug.WriteLine($"size = {sz}");
						if (sz.Height > 400) sz.Height = 400;
						childPanel.Size = sz;
						ContentSize = new Size(
							Math.Max(HeaderSize.Width, sz.Width + 10),
							HeaderSize.Height + sz.Height);
						SetSize(ContentSize);
						childPanel.Visible = true;
						ItemList.Place(childPanel, this, new Point(10, HeaderSize.Height));
					}
					else
					{
						SetSize(ContentSize);
						childPanel.Visible = true;
					}
				}
				else
				{
					childPanel.Visible = false;
					SetSize(HeaderSize);
				}
				TopTreeListPanel.Invalidate(true);
			}
			Debug.WriteLine($"clicked [{Element.DisplayName}] item={target.item.Index}, rect={target.rect}, part={target.part}");
		}

		private void ChildPanel_SizeChanged(object sender, EventArgs e)
		{
			//Debug.WriteLine($"ChildPanel_SizeChanged");
		}

		void SetSize(Size newSize)
		{
			Size oldSize = Size; Size = newSize;
			ItemList.ItemSizeChanged(this, oldSize, newSize);
		}
		XMLTreeListPanel childPanel = null;
	}
}
