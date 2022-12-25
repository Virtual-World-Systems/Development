using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;

namespace VWS.WindowsDesktop.Controls
{
	[Designer("System.Windows.Forms.Design.LabelDesigner")]
	[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem")]
	public partial class TitleBar : UserControl
	{
		public TitleBar()
		{
			InitializeComponent();
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

		private void TitleBar_Paint(object sender, PaintEventArgs e)
		{
			Rectangle r = new Rectangle(new Point(), ComputeSize(e.Graphics) + new Size(8, 8));
			if (MinimumSize != r.Size) MinimumSize = r.Size;
			r.Width = ClientRectangle.Width;
			if (r.Height != Height) Height = r.Height;
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1); r.Y--;
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			using (Brush b = GetBrush(r)) e.Graphics.FillRectangle(b, r);
			DrawCaptionText(e.Graphics, r.X + 2, r.Y, Text);
			Debug.WriteLine("Paint Dock=" + Parent.Dock.ToString());
			if (Parent.Dock != DockStyle.Fill) Parent.Dock = DockStyle.Fill;
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get => base.Text;
			set { base.Text = value; Invalidate(); }
		}
		protected override void OnFontChanged(EventArgs e)
		{
			size = Size.Empty;
			base.OnFontChanged(e);
			Invalidate();
			Debug.WriteLine("Font changed");
		}
		protected override void OnTextChanged(EventArgs e)
		{
			size = Size.Empty;
			base.OnTextChanged(e);
			Invalidate();
			Debug.WriteLine("Text changed");
		}
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			Debug.WriteLine("on resize " + size.ToString());
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

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);
		}


		public override Size GetPreferredSize(Size proposedSize)
		{
			Debug.WriteLine("GetPreferredSize");
			return ComputeSize(null);
		}

		/// <summary>
		/// Performs the work of setting the specified bounds of this control.
		/// </summary>
		protected override void SetBoundsCore(int x, int y, int width, int height,
				BoundsSpecified specified)
		{
			Rectangle r = new Rectangle(x, y, width, height);
			Debug.WriteLine("SetBoundsCore xywh=" + r.ToString());
			//  Only when the size is affected...
			if (true // this.AutoSize
				&& (specified & BoundsSpecified.Size) != 0)
			{
				Debug.WriteLine("size affected (AutoSize=" + this.AutoSize.ToString() + ")");
				Size sz = ComputeSize(null);

				r = new Rectangle(x, y, width, height);
				Debug.WriteLine("RS size=" + size.ToString()
					+ ", sz=" + sz.ToString() + ", rect=" + r.ToString());

				//width = sz.Width;
				height = sz.Height;
			}
			r = new Rectangle(x, y, width, height);
			Debug.WriteLine("! SetBoundsCore " + size.ToString()
				+ ", rect=" + r.ToString());
			base.SetBoundsCore(x, y, width, height, specified);
		}
		protected override Size SizeFromClientSize(Size clientSize)
		{
			Size sz = new Size(
				Math.Max(size.Width, clientSize.Width),
				Math.Max(size.Width, clientSize.Width));
			Debug.WriteLine("SetBoundsCore sz=" + size.ToString());
			return sz;

			//return base.SizeFromClientSize(clientSize);
		}
		//private void AutoSizeControl(Control control, int textPadding)
		//{
		//	// Create a Graphics object for the Control.
		//	Graphics g = control.CreateGraphics();

		//	// Get the Size needed to accommodate the formatted Text.
		//	Size preferredSize = g.MeasureString(
		//	   control.Text, control.Font).ToSize();

		//	// Pad the text and resize the control.
		//	control.ClientSize = new Size(
		//	   preferredSize.Width + (textPadding * 2),
		//	   preferredSize.Height + (textPadding * 2));

		//	// Clean up the Graphics object.
		//	g.Dispose();
		//} 
	}
}
