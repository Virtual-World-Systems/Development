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
	public partial class Splitter : System.Windows.Forms.Splitter
	{
		public Splitter()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			e.Graphics.FillRectangle(Helper.GetSolidBrush(SystemColors.ControlDark), r);
			if ((Dock == DockStyle.Left) || (Dock == DockStyle.Right)) { r.Inflate(0, 2); }
			if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom)) { r.Inflate(2, 0); }
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			new  MemoryStream();
		}

		void SetTarget()
		{
			target = null;

			foreach (Control c in Parent.Controls)
			{
				if (c.Dock == DockStyle.Fill)
					filler = c;
				else
				{
					if (c.Dock != Dock) continue;
					if (c == this) continue;
					target = c;
					Debug.WriteLine($"target={target}");
				}
			}
		}
		Control target = null;
		Control filler = null;
		Point ptStart;
		Size ptSize;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			ptStart = new Point(e.X, e.Y);
			ptStart = PointToScreen(ptStart);
			SetTarget();
			if (target != null) ptSize = target.Size;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button != MouseButtons.Left) return;
			if (target != null)
			{
				Point pt = PointToScreen(new Point(e.X, e.Y));

				Size pd = new Size(ptStart - new Size(pt));
				if ((Dock == DockStyle.Top) || (Dock == DockStyle.Left))
					pd = Size.Empty - pd;

				if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom)) pd.Width = 0;
				if ((Dock == DockStyle.Left) || (Dock == DockStyle.Right)) pd.Height = 0;
				pd = ptSize + pd;
				target.Size = pd;
				target.Invalidate(true);
			}
			if (filler != null) filler.Invalidate(true);
		}
	}
}
