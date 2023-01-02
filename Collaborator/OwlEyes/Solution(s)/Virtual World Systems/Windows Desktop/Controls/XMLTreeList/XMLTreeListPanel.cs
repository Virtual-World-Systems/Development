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
using static VWS.WindowsDesktop.Controls.XMLTreeList.XMLTreeListPanel;

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

		internal XMLTreeListElements ElementList { get; private set; }
		public XML.Element ParentElement
		{
			get { return parentElement; }
			set
			{
				if (parentElement != null)
				{
					if (ElementList != null)
						ElementList = ElementList.Delete();
					parentElement = ParentElement.DetatchFrom(this);
				}
				if (value == null) return;

				parentElement = value.AttatchTo(this);
				ElementList = new XMLTreeListElements(this, parentElement);
				AutoScrollMinSize = ElementList.Size + Padding.Size;
			}
		}
		XML.Element parentElement;

		internal class ItemList : List<XMLTreeListItem>
		{
			internal ItemList(Point origin) : base() { Origin = origin; }
			internal Point Origin { get; set; }
			internal Size Size
			{
				get
				{ 
					Size szT = Size.Empty, sz;

					foreach (XMLTreeListItem item in this)
					{
						sz = item.Size;
						szT.Width = Math.Max(szT.Width, sz.Width);
						szT.Height += sz.Height;
					}
					Debug.WriteLine($"ItemList.Size = {szT}");
					return szT;
				} 
			}
		}
		internal ItemList Items = new ItemList(new Point(0, 0));

		internal Point PaddedOffset
		{
			get => new Point(
				AutoScrollPosition.X + Padding.Left,
				AutoScrollPosition.Y + Padding.Top);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle clip = e.ClipRectangle;
			clip.Offset(PaddedOffset);
			Rectangle client = ClientRectangle;
			client.Offset(PaddedOffset);
			client.Size = ClientRectangle.Size - new Size(PaddedOffset);
			Debug.WriteLine($"OnPaint: clip={clip}, client={client}");
			ElementList.Paint(e.Graphics, clip, client);
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
			Debug.WriteLine($"on Scroll : AutoScrollPosition={AutoScrollPosition}, PaddedOffset={PaddedOffset}");
			Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			if (Target == null) return;
			Target.Click();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Target = FindMouseTarget();
		}

		Target Target
		{
			get { return target; }
			set {
				if (target == null)
					if (value == null) return;

				if ((target != null) && target.Equals(value)) return;
				int hc1 = (value == null) ? 0 : value.GetHashCode();
				int hc2 = (target == null) ? 0 : target.GetHashCode();
				if (hc1 == hc2) return;

				if (target != null) DrawHoverFrame();
				target = value;
				if (target != null) DrawHoverFrame();
			}
		}
		Target target = null;

		void DrawHoverFrame()
		{
			Rectangle r = Target.rect;
			r.Offset(Padding.Left, Padding.Top);
			r = RectangleToScreen(r);

			ControlPaint.DrawReversibleFrame(
				r, Color.DarkRed, FrameStyle.Dashed);
		}

		Target FindMouseTarget()
		{
			Point pt = PointToClient(MousePosition);
			pt -= new Size(Padding.Left, Padding.Top);
			pt += new Size(AutoScrollPosition);

			int i = -1; XMLTreeListItem item = null;
			int Y = 0;

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
			if (item != null)
				return item.FindMouseTarget(pt + new Size(0, pt.Y - Y));
			return null;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (Target != null) Target = null;
			base.OnMouseLeave(e);
		}

		internal Rectangle GetItemRect(XMLTreeListItem item)
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
	internal class Target
	{
		internal Target(XMLTreeListItem item, object part, Rectangle rect)
		{
			this.item = item;
			this.rect = rect;
			this.part = part;
		}
		internal XMLTreeListItem item;
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
