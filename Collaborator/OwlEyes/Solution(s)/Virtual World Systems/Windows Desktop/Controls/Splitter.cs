using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls
{
	public partial class Splitter : System.Windows.Forms.UserControl
	{
		public Splitter()
		{
			Dock = DockStyle.Left;
			Cursor = Cursors.VSplit;
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			e.Graphics.FillRectangle(Helper.GetSolidBrush(BackColor), r);

			Size sz = new Size();
			Border3DSide sideH = Border3DSide.Top | Border3DSide.Bottom;
			Border3DSide sideV = Border3DSide.Left | Border3DSide.Right;
			Border3DSide side = 0;
			if ((Dock == DockStyle.Left) || (Dock == DockStyle.Right)) { sz.Width = -1; side = sideV; }
			if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom)) { sz.Height = -1; side = sideH; }

			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, side);
			r.Inflate(sz);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, side);
		}



		void SetTarget()
		{
			target = null;

			foreach (Control c in Parent.Controls)
			{
				if (c.Dock != Dock) continue;
				if (c == this) continue;
				target = c;
				//Debug.WriteLine($"target={target} name={target.Name}");
			}
		}
		Point ptStart;
		Control target = null;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			ptStart = new Point(e.X, e.Y);
			ptStart = PointToScreen(ptStart);
			SetTarget();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
			{
				base.OnMouseMove(e);
				return;
			}
			if (target == null)
			{
				base.OnMouseMove(e);
				return;
			}
			base.OnMouseMove(e);

			Point pt = PointToScreen(new Point(e.X, e.Y));

			Size pd = new Size(ptStart - new Size(pt));
			if ((Dock == DockStyle.Top) || (Dock == DockStyle.Left)) pd = Size.Empty - pd;
			if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom)) pd.Width = 0;
			if ((Dock == DockStyle.Left) || (Dock == DockStyle.Right)) pd.Height = 0;

			base.OnMouseUp(e);
			target.Size += pd;

			Update(); Parent.Update();

			ptStart = pt;
			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			//Invalidate(true);
		}

		protected override void OnMove(EventArgs e)
		{
			if (Parent == null) return;
			//Parent.Invalidate(oldRect, true);
			base.OnMove(e);
			//oldRect = Parent.RectangleToClient(RectangleToScreen(ClientRectangle));
			//oldRect.Inflate(3, 3);
		}
		//Rectangle oldRect;
	}
}
