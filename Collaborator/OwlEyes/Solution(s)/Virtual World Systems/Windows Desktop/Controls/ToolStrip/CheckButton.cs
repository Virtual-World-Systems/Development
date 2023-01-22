using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace VWS.WindowsDesktop.Controls.ToolStrip
{
	internal class CheckButton : ToolStripButton
	{
		protected override void OnPaint(PaintEventArgs e)
		{
			Color c = Checked ? Color.LightGreen : SystemColors.Control;
			Rectangle r = this.Bounds;
			if (Checked) ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.SunkenInner);
			r.Inflate(-1, -1);
			using (Brush b = new SolidBrush(c)) e.Graphics.FillRectangle(b, r);
			r.Inflate(-2, -2);
			r.Width = r.Height = 16;
			e.Graphics.DrawImage(Image, r);
		}
	}
}
