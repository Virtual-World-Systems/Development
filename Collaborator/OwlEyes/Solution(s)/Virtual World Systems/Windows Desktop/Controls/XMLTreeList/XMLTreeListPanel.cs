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
		internal static XMLElementPainter Painter = new XMLElementPainter();

		public XMLTreeListPanel()
		{
			InitializeComponent();
		}

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

		internal XMLTreeList TreeList { get => (XMLTreeList) Parent; }

		protected override void OnPaint(PaintEventArgs e)
		{
			using (Brush b = new SolidBrush(ForeColor))
			{
				int i = -1; XMLTreeListItem item;
				int Y = AutoScrollPosition.Y + Padding.Top;

				while (++i < Items.Count)
				{
					item = Items[i];
					if ((Y + item.Height) <= e.ClipRectangle.Top) continue;

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
	}
}
