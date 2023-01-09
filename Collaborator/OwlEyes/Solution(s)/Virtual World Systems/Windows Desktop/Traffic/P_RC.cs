using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWS.WindowsDesktop.Controls;
using VWS.WindowsDesktop.Properties;

namespace VWS.WindowsDesktop.Traffic
{
	public partial class P_RC : Panel
	{
		public P_RC()
		{
			InitializeComponent();
		}

		private void P_RC_Paint(object sender, PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, Border3DSide.All^Border3DSide.Left);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, Border3DSide.All ^ Border3DSide.Left);
			r.Inflate(-1, -1);
			using (Brush b = new SolidBrush(BackColor)) { e.Graphics.FillRectangle(b, r); }
			r.Inflate(-1, -1);
			Rectangle rX = r; rX.Offset(rX.Width - 48, 0); rX.Width = 48; rX.Height = 24;
			e.Graphics.DrawImage(Resources.Kitely_128x64, rX);

			using (Font f = new Font(Font.FontFamily, Font.Height + 3, FontStyle.Bold, GraphicsUnit.Pixel))
			{
				Size sz = Helper.MeasureRenderStringSize(e.Graphics, f, "Kitely");
				rX.Offset(-4 - sz.Width, 0); rX.Width = sz.Width;
				Helper.DrawRenderString(e.Graphics, "Kitely", rX, f, ForeColor, BackColor);
				int cx = r.Right - rX.X + 4;
				if (MinimumSize.Width < cx)
				{
					SetMinWidth(this, cx);
					if (Parent is CrossBar) SetMinWidth(((CrossBar)Parent).RP, cx);
				}
			}
		}
		void SetMinWidth(Control control, int cx) { Size sz = control.MinimumSize; sz.Width = cx; control.MinimumSize = sz; }

		private void P_RC_SizeChanged(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
}
