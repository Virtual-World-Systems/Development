using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls.Container
{
	public partial class TreeListHeader : UserControl
	{
		public TreeListHeader()
		{
			InitializeComponent();
		}

		private void TreeListHeader_Paint(object sender, PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Inflate(-3, -3);
			DrawCaptionText(e.Graphics, r.X, r.Y, Parent.Text);
//			Debug.WriteLine("Paint Dock=" + Parent.Dock.ToString());
//			e.Graphics.FillRectangle(Brushes.Yellow, e.ClipRectangle);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Rectangle r;
			r = new Rectangle(new Point(), ComputeSize(e.Graphics) + new Size(8, 8));
			if (MinimumSize != r.Size) MinimumSize = r.Size;
			r.Width = ClientRectangle.Width;
			if (r.Height != Height) Height = r.Height;
			r = ClientRectangle;
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			//r.Inflate(-1, -1);
			//ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			using (Brush b = GetBrush(r)) e.Graphics.FillRectangle(b, r);
		}
		Size ComputeSize(Graphics g)
		{
			Graphics gg = g ?? CreateGraphics();
			Size sz = Helper.MeasureStringSize(gg, CaptionFont, Text);
			if (g == null) gg.Dispose();
			if (sz != size) { size = sz; Invalidate(); }
			Debug.WriteLine("ComputeSize " + size.ToString());
			return size;
		}
		Size size = Size.Empty;
		internal static Brush GetBrush(Rectangle r)
		{
			return Helper.GetGradientBrush(SystemColors.ActiveCaption, r);
		}
		internal static void DrawCaptionText(Graphics g, int x, int y, string t)
		{
			TextRenderer.DrawText(g, t, CaptionFont, new Point(x, y), Color.Black);
			//Helper.DrawStringFormat(g, t, x, y, CaptionFont, SystemBrushes.ActiveCaptionText);
		}
		static Font CaptionFont
		{
			get
			{
				if (captionFont == null)
				{
					captionFont = new Font(SystemFonts.CaptionFont.FontFamily, 12, FontStyle.Bold, GraphicsUnit.Pixel);
				}
				return captionFont;
			}
		}
		static Font captionFont = null;
	}
}
