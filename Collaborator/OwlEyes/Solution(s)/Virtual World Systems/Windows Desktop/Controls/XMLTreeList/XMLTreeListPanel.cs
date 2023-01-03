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
	[ToolboxItem(false)]
	public partial class XMLTreeListPanel : ScrollableControl
	{
		public XMLTreeListPanel()
		{
			InitializeComponent();
		}
		internal XMLTreeList TreeList { get => (XMLTreeList)Parent; }

		internal static XMLElementPainter Painter = new XMLElementPainter();

		internal ListView ElementList { get; private set; }
		public Element ParentElement
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
				ElementList = new ListView(this, parentElement);
				//Debug.WriteLine($"new Panel, Size={ElementList.Size}");
				AutoScrollMinSize = ElementList.Size + Padding.Size;
				Size = AutoScrollMinSize;
			}
		}
		Element parentElement;

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
			//Debug.WriteLine($"OnPaint: clip={clip}, client={client}");
			ElementList.Paint(e.Graphics, clip, client);
		}
		protected override void OnResize(EventArgs e)
		{
			Invalidate();
			base.OnResize(e);
		}

		private void XMLTreeListPanel_Scroll(object sender, ScrollEventArgs e)
		{
			Debug.WriteLine($"on Scroll : AutoScrollPosition={AutoScrollPosition}, PaddedOffset={PaddedOffset}");
			Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			if (Target == null) return;
			Target T = Target;
			Target = null;
			T.Click();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Target = FindMouseTarget();
		}

		internal Target Target
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
			r.Offset(Point.Empty + new Size(PaddedOffset));
			r = RectangleToScreen(r);

			ControlPaint.DrawReversibleFrame(
				r, Color.DarkRed, FrameStyle.Dashed);
		}

		Target FindMouseTarget()
		{
			Point pt = PointToClient(MousePosition);
			pt = pt - new Size(PaddedOffset);
			return ElementList.TargetFromMouse(pt);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (Target != null) Target = null;
			base.OnMouseLeave(e);
		}

		internal void Place(XMLTreeListPanel cp, Point pt)
		{
			pt = pt + new Size(PaddedOffset);
			cp.Location = pt;
			cp.Visible = true;
			Controls.Add(cp);
		}

		internal void ChangeHeight(int cy)
		{
			AutoScrollMinSize += new Size(0, cy);
			if (Parent is XMLTreeListPanel) SetSize(AutoScrollMinSize);
		}

		internal void SetSize(Size szNew)
		{
			//int cy = szNew.Height - Size.Height;
			//((XMLTreeListPanel)Parent).ElementList.Change
		}
	}
}
