using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls
{
	public partial class RaisedRectangle : UserControl
	{
		public RaisedRectangle()
		{
			InitializeComponent();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Size -= new Size(1, 1);
			e.Graphics.DrawRectangle(SystemPens.Control, r);
			r.Offset(1, 1); r.Size -= new Size(1, 1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			e.Graphics.FillRectangle(SystemBrushes.Control, r);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Inflate(-4, -4);
			Helper.DrawRenderString(e.Graphics, Text, r, Font, ForeColor, BackColor);
		}
	}
}
