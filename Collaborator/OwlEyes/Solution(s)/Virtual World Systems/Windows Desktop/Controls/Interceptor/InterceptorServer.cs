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
	public partial class InterceptorServer : UserControl
	{
		public InterceptorServer()
		{
			InitializeComponent();
		}

		internal Font TitleFont
		{
			get
			{
				if (_TitleFont == null)
					_TitleFont = new Font(Font, FontStyle.Bold | FontStyle.Underline);
				return _TitleFont;
			}
		}
		Font _TitleFont = null;

		[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text { get => base.Text; set => base.Text = value; }

		protected override void OnLayout(LayoutEventArgs e)
		{
			Size = new Size(100, ClientRectangle.Height);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Size -= new Size(1, 1);
			e.Graphics.DrawRectangle(SystemPens.Control, r);
			r.Size += new Size(1, 1);

			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
			r.Inflate(-1, -1);
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);

			r.Inflate(-1, -1);
			r.Size -= new Size(1, 1);
			e.Graphics.DrawRectangle(SystemPens.Control, r);
			r.Size += new Size(1, 1);

			r.Inflate(-1, -1);
			e.Graphics.FillRectangle(SystemBrushes.Control, r);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			r.Offset(Padding.Left, Padding.Top);
			r.Width = ClientRectangle.Width - (Padding.Left + Padding.Right);
			r.Height = ClientRectangle.Height - (Padding.Top + Padding.Bottom);

			Rectangle rT = r;
			rT.Height = Helper.MeasureRenderStringSize(e.Graphics, TitleFont, Text).Height;
			Helper.DrawRenderString(e.Graphics, Text, rT, TitleFont, ForeColor, BackColor);
		}
	}
}
