using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls
{
	public partial class ElementControl : UserControl
	{
		public ElementControl()
		{
			InitializeComponent();
		}

		[Category("_"), Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string XML_Selector
		{
			get { return selector; }
			set { selector = value;
				//MessageBox.Show($"Value=\"{value}\" Root={Program.XML}");
				element = string.IsNullOrEmpty(value) ? null : Program.XML.Root.SelectElement(value);
				Invalidate(); }
		}
		private string selector;

		[Category("_"), Browsable(true)]
		public string XML_Element { get { return element.OuterXml; } }
		private XML.Element element;

		private void ElementControl_Paint(object sender, PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;

			using (Brush b = new SolidBrush(Color.LightBlue))
				e.Graphics.FillRectangle(b, r);

			r.Height = Helper.MeasureStringSize(e.Graphics, CaptionFont, "|").Height + 8;

			for (int i = 0; i < 3; i++)
			{
				ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
				r.Inflate(-1, -1);
			}
			using (Brush b = GetBrush(r)) e.Graphics.FillRectangle(b, r);

			r.Inflate(3, 3);

			string t = (element == null) ? "ÄÖ|jpq_"
				: element.HasAttribute("Name") ? element.GetAttribute("Name")
				: element.Name;

			DrawCaptionText(e.Graphics, r.X + 2, r.Y + 4, t);

			r.Offset(0, r.Height);
			r.Height = ClientRectangle.Height - r.Top;

			r.Size = new Size(16, 16);
			ControlPaint.DrawButton(e.Graphics, r, ButtonState.Checked);
		}
		//Size ComputeSize(Graphics g)
		//{
		//	Graphics gg = g ?? CreateGraphics();
		//	Size sz = Helper.MeasureStringSize(gg, Font, element.GetAttribute("Name"));
		//	if (g == null) gg.Dispose();
		//	if (sz != size) { size = sz; Invalidate(); }
		//	Debug.WriteLine("ComputeSize " + size.ToString());
		//	return size;
		//}
		//Size size = Size.Empty;

		protected override void OnFontChanged(EventArgs e)
		{
			//size = Size.Empty;
			base.OnFontChanged(e);
			Invalidate();
			Debug.WriteLine("Font changed");
		}
		protected override void OnTextChanged(EventArgs e)
		{
			//size = Size.Empty;
			base.OnTextChanged(e);
			Invalidate();
			Debug.WriteLine("Text changed");
		}
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			Invalidate();
			//Debug.WriteLine("on resize " + size.ToString());
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

		internal static Brush GetBrush(Rectangle r)
		{
			return Helper.GetGradientBrush(SystemColors.ActiveCaption, r);
		}

	}
}
