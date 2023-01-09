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
	public partial class P_LC : Panel
	{
		public P_LC()
		{
			InitializeComponent();
		}

		private void P_LC_Paint(object sender, PaintEventArgs e)
		{
			Size sz;
			Rectangle r = ClientRectangle;

			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, Border3DSide.All ^ Border3DSide.Right);
			r.Inflate(-1, -1);

			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner, Border3DSide.All ^ Border3DSide.Right);
			r.Inflate(-1, -1);

			using (Brush b = new SolidBrush(BackColor)) { e.Graphics.FillRectangle(b, r); }
			r.Inflate(-1, -1);

			Rectangle rX = r; rX.Width = 24; rX.Height = 24;
			e.Graphics.DrawImage(Resources.Firestorm_64x64, rX);

			using (Font f = new Font(Font.FontFamily, Font.Height + 3, FontStyle.Bold, GraphicsUnit.Pixel))
			{
				sz = Helper.MeasureRenderStringSize(e.Graphics, f, "Firestorm");
				rX.Offset(24 + 4, 0); rX.Width = sz.Width;
				Helper.DrawRenderString(e.Graphics, "Firestorm", rX, f, ForeColor, BackColor);
			}
			int cx = rX.Right + 4;
			if (MinimumSize.Width < cx)
			{
				SetMinWidth(this, cx);
				if (Parent is CrossBar) SetMinWidth(((CrossBar)Parent).LP, cx);
			}
		}
		void SetMinWidth(Control control, int cx) { Size sz = control.MinimumSize; sz.Width = cx; control.MinimumSize = sz; }

		private void P_LC_SizeChanged(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
}
