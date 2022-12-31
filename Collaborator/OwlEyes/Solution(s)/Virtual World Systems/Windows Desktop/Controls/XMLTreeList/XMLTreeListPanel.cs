using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	public partial class XMLTreeListPanel : ScrollableControl
	{
		public XMLTreeListPanel()
		{
			InitializeComponent();
		}
		internal XMLTreeList TreeList { get => (XMLTreeList)Parent; }

		internal static XMLElementPainter Painter = new XMLElementPainter();

		public XML.Element ParentElement
		{
			get { return parentElement; }
			set
			{
				parentElement = value;
				if (parentElement == null) return;
				Items.Clear();

				Size sz = Size.Empty, sz0; XMLTreeListItem item;

				using (Graphics g = CreateGraphics())
				{
					for (int i = 0; i < parentElement.ChildNodes.Count; i++)
					{
						Items.Add(item = new XMLTreeListItem(this,
							(Element)parentElement.ChildNodes[i], i));
						sz0 = item.MeasureClosed(this, g);
						sz.Height += sz0.Height;
						sz.Width = Math.Max(sz0.Width, sz.Width);
					}
				}
				AutoScrollMinSize = sz + Padding.Size;
			}
		}
		XML.Element parentElement;

		List<XMLTreeListItem> Items = new List<XMLTreeListItem>();

		protected override void OnPaint(PaintEventArgs e)
		{
			using (Brush b = new SolidBrush(ForeColor))
			{
				int i = -1; XMLTreeListItem item;
				int Y = AutoScrollPosition.Y + Padding.Top;

				while (++i < Items.Count)
				{
					item = Items[i];

					if ((Y + item.Height) <= e.ClipRectangle.Top)
					{
						Y += item.Height;
						continue;
					}
					while (Y < e.ClipRectangle.Bottom)
					{
						Point pt = new Point(AutoScrollPosition.X + Padding.Left, Y);
						Size sz = item.Size;
						sz.Width = ClientRectangle.Width - pt.X;
						item.Draw(this, e.Graphics, pt, sz);
						Y += item.Height;
						if ((i + 1) >= Items.Count) break;
						item = Items[++i];
					}
					break;
				}
			}
		}
		protected override void OnResize(EventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Offset(r.Width - Padding.Right, 0);
			r.Width = Padding.Right;
			Invalidate();
			base.OnResize(e);
		}

		int ElementCount
		{
			get { return (parentElement == null) 
					? 0 : parentElement.ChildNodes.Count; }
		}

		public string GetDisplayName(int i)
		{
			XML.Element e = GetElement(i);
			if (e != null) return GetElement(i).DisplayName;
			return "";
		}
		public XML.Element GetElement(int i)
		{
			if (parentElement == null) return null;
			if (i >= ElementCount) return null;
			return (XML.Element) parentElement.ChildNodes[i];
		}

		private void XMLTreeListPanel_Scroll(object sender, ScrollEventArgs e)
		{
			Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			MouseEventArgs a = (MouseEventArgs) e;

			int i = -1; XMLTreeListItem item;
			int Y = AutoScrollPosition.Y + Padding.Top;

			while (++i < Items.Count)
			{
				item = Items[i];
				if ((Y + item.Height) <= a.Y)
				{
					Y += item.Height;
					continue;
				}
				Debug.WriteLine($"found {item}[{item.Index}]");
				break;
			}
			base.OnClick(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Point pt = PointToClient(MousePosition);
			
			int i = -1; XMLTreeListItem item = null;
			int Y = AutoScrollPosition.Y + Padding.Top;

			while (++i < Items.Count)
			{
				item = Items[i];
				if ((Y + item.Height) <= pt.Y)
				{
					Y += item.Height;
					item = null;
					continue;
				}

				//Debug.WriteLine($"found \"{item.Element.DisplayName}\"");
				break;
			}
			if (item != HoveredItem)
			{
				if (HoveredItem != null) HoverItem(HoveredItem, false);
				HoveredItem = item;
				if (HoveredItem != null) HoverItem(HoveredItem, true);
			}
			base.OnMouseMove(e);
		}
		XMLTreeListItem HoveredItem = null;
		void HoverItem(XMLTreeListItem item, bool isHovered)
		{
			DrawItemRect(item);
		}

		void DrawItemRect(XMLTreeListItem item)
		{
			Rectangle r = GetItemRect(item);
			r.Offset(0, Padding.Top);
			r = RectangleToScreen(r);
			ControlPaint.DrawReversibleFrame(r, Color.DarkRed, FrameStyle.Thick);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (HoveredItem != null)
			{
				DrawItemRect(HoveredItem);
				HoveredItem = null;
			}
			base.OnMouseLeave(e);
		}

		Rectangle GetItemRect(XMLTreeListItem item)
		{
			int Y = 0;

			foreach (XMLTreeListItem it in Items)
			{
				if (it == item) break;
				Y += it.Size.Height;
			}
			Rectangle r = new Rectangle(0, Y, ClientRectangle.Width, item.Size.Height);
			//r.Offset(Padding.Left, Padding.Top);
			return r;
		}
	}
}
