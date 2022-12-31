using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VWS.WindowsDesktop.Controls
{
	internal class Helper
	{
		internal static Size MeasureStringSize(Graphics g, Font font, string text)
		{
			int len = text.Length;
			if (len == 0) text = "|";
			CharacterRange[] characterRanges = { new CharacterRange(0, text.Length) };
			StringFormat.SetMeasurableCharacterRanges(characterRanges);
			Region[] rgs = g.MeasureCharacterRanges(text, font, MaxRectF, StringFormat);
			SizeF sizeF = rgs[0].GetBounds(g).Size;
			if (len == 0) sizeF.Width = 0;
			return new Size((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height));
		}
		static StringFormat StringFormat
		{
			get
			{
				if (stringFormat == null)
				{
					stringFormat = (StringFormat)StringFormat.GenericTypographic.Clone();
					stringFormat.FormatFlags = StringFormatFlags.NoClip | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox;
				}
				return stringFormat;
			}
		}
		static StringFormat stringFormat = null;
		static RectangleF MaxRectF = new RectangleF(0, 0, float.MaxValue, float.MaxValue);

		static (int, int, int) ScaleColor(Color c, int d)
		{
			return (shaded(c.R, d), shaded(c.G, d), shaded(c.B, d));
		}
		static int shaded(double c, int d)
		{
			double f = c / 256;
			if (d < 0) f = f * f * f * f;
			else f = Math.Sqrt(Math.Sqrt(Math.Sqrt(f)));
			return (int)(256 * f);
		}
		internal static Brush GetGradientBrush(Color c, Rectangle r)
		{
			Color bg = SystemColors.ActiveCaption;
			int R, G, B;
			(R, G, B) = Helper.ScaleColor(bg, 1);
			Color ca = Color.FromArgb(R, G, B);
			(R, G, B) = Helper.ScaleColor(bg, -1);
			Color ce = Color.FromArgb(R, G, B);
			return new LinearGradientBrush(r, ca, ce, LinearGradientMode.ForwardDiagonal);
		}
		internal static Brush GetSolidBrush(Color c)
		{
			if (SolidBrushes.ContainsKey(c)) return SolidBrushes[c];
			return (SolidBrushes[c] = new SolidBrush(c));
		}
		internal static Dictionary<Color, Brush>
			SolidBrushes = new Dictionary<Color, Brush>();

		internal static void DrawString(Graphics g, string t, int x, int y, Font f, Brush b)
		{
			g.DrawString(t, f, b, x, y, StringFormat);
		}
		internal static void DrawRenderString(Graphics g,
			string t, Rectangle r, Font f, Color ct, Color cb)
		{
			TextRenderer.DrawText(g, t, f, r, ct, cb,
				TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding |
				TextFormatFlags.Left | TextFormatFlags.SingleLine |
				TextFormatFlags.VerticalCenter);
		}
		static Size MaxSize = new Size(int.MaxValue, int.MaxValue);
		internal static Size MeasureRenderStringSize(Graphics g, Font f, string t)
		{
			Size sz;
			string tt = (t == "") ? "|" : t;
			if (g == null)
				sz = TextRenderer.MeasureText(tt, f, MaxSize,
					TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding |
					TextFormatFlags.Left | TextFormatFlags.SingleLine |
					TextFormatFlags.VerticalCenter);
			else
				sz = TextRenderer.MeasureText(g, tt, f, MaxSize,
					TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding |
					TextFormatFlags.Left | TextFormatFlags.SingleLine |
					TextFormatFlags.VerticalCenter);
			if (t == "") sz.Width = 0;
			return sz;
		}
	}
}
