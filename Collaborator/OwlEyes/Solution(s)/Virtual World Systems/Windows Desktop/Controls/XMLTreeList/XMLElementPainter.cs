using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class XMLElementPainter
	{
		internal XMLElementPainter() { }

		internal Size Measure(Graphics g, Font f, string t)
		{
			return Helper.MeasureRenderStringSize(g, f, t) + new Size(13, 0);
		}
		internal void Draw(Graphics g, Font f, string t, Point pt, Size sz, Color fg, Color bg)
		{
			Rectangle rect = new Rectangle(pt, sz);

			if (bg != Color.Transparent)
				g.FillRectangle(Helper.GetSolidBrush(bg), rect);

			Rectangle r = new Rectangle(pt + new Size(0, 1), new Size(9, 9));
			g.DrawImage(Properties.Resources.ToggleButton_closed, r);

			r = rect; r.Offset(11, 0); r.Width -= 11;
			Helper.DrawRenderString(g, t, r, f, fg, bg);
		}
		internal Size RenderAt(XMLTreeListPanel p,
			Graphics g, XML.Element element, Font f, Point pt)
		{
			Brush b = null;
			Size sz = Size.Empty;
			bool paint = (g != null);
			if (!paint) g = p.CreateGraphics();
			if (paint) b = new SolidBrush(p.ForeColor);

			try
			{
				string t = (element == null) ? "" : element.DisplayName;
				Rectangle rect = new Rectangle(pt.X + 2, pt.Y + 1, 9, 9);
				if (b != null) g.DrawImage(Properties.Resources.ToggleButton_closed, rect);
				if (b != null) Helper.DrawString(g, t, pt.X + 13, pt.Y, f, b);
				sz = Helper.MeasureStringSize(g, f, t);
			}
			finally
			{
				if (paint) b.Dispose();
				if (!paint) g.Dispose();
			}
			return sz + new Size(15, 0);
		}
	}
}
