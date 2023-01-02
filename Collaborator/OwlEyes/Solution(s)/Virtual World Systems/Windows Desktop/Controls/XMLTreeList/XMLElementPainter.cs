using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V = VWS.WindowsDesktop.Controls.XMLTreeList.Visual.Visual;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class XMLElementPainter
	{
		internal XMLElementPainter() { }

		internal Size Measure(Graphics g, Font f, string t)
		{
			return V.From<string>((object o) => t, null).Measure(g, f) + new Size(13, 0);
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
	}
}
