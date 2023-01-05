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
		#region misc
		public XMLTreeListPanel()
		{
			InitializeComponent();
		}
		internal XMLTreeList TreeList { get => (XMLTreeList)Parent; }

		Element parentElement;
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
			}
		}
		internal ListView ElementList { get; private set; }

		#endregion

		#region Sizing / Scrolling

		internal Point PaddedOffset
		{
			get => new Point(
				AutoScrollPosition.X + Padding.Left,
				AutoScrollPosition.Y + Padding.Top);
		}
		internal void SetListSize(Size sz)
		{
			AutoScrollMinSize = sz + Padding.Size;
			Invalidate(true);
		}
		private void XMLTreeListPanel_Resize(object sender, EventArgs e)
		{
			Invalidate(true);
		}

		#endregion

		#region Mouse / Targetting

		Target target = null;
		void DrawHoverFrame()
		{
			Rectangle r = Target.rect;
			r.Offset(Point.Empty + new Size(PaddedOffset));
			r = RectangleToScreen(r);

			ControlPaint.DrawReversibleFrame(
				r, Color.DarkRed, FrameStyle.Dashed);
		}
		internal Target Target
		{
			get { return target; }
			set
			{
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
		Target FindMouseTarget()
		{
			Point pt = PointToClient(MousePosition);
			pt = pt - new Size(PaddedOffset);
			return ElementList.TargetFromPoint(pt);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Target = FindMouseTarget();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			if (Target != null) Target = null;
			base.OnMouseLeave(e);
		}
		protected override void OnClick(EventArgs e)
		{
			if (Target == null) return;
			Target T = Target;
			Target = null;
			T.Click();
		}
		#endregion

		#region Drawing

		internal static XMLElementPainter Painter = new XMLElementPainter();
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rList = new Rectangle(PaddedOffset, ElementList.Size);
			Debug.WriteLine($"Control.Paint: client={ClientRectangle}, clip={e.ClipRectangle}, list={rList}");
			if (ElementList == null) return;

			Rectangle client = new Rectangle(PaddedOffset, Size.Empty);
			client.Size = ClientRectangle.Size - new Size(client.Location);

			Rectangle clip = e.ClipRectangle; clip.Intersect(rList);
			clip.Offset(Point.Empty - new Size(PaddedOffset));

			ElementList.Paint(e.Graphics, clip, client);
		}

		#endregion
	}
}
