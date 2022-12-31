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
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	public partial class XMLTreeListHeader : UserControl
	{
		public XMLTreeListHeader()
		{
			Font = new Font(Font, FontStyle.Bold);
			InitializeComponent();
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public int BorderThickness { get; set; } = 2;

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Size = GetPreferredSize(new Size(ClientRectangle.Width, 1));
			Invalidate();
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			int fs = BorderThickness * 2 + 2;
			//Debug.WriteLine("GetPreferredSize");
			using (Graphics g = CreateGraphics())
				return Helper.MeasureRenderStringSize(g, Font, Text) + new Size(fs, fs);
		}

		private void XMLTreeListHeader_Paint(object sender, PaintEventArgs e)
		{
			int BorderSize = 2;
			Rectangle r = ClientRectangle;

			r.Height = Helper.MeasureRenderStringSize(
				e.Graphics, Font, "").Height + 2 * BorderSize + 2;

			using (Brush b = Helper.GetGradientBrush(SystemColors.ActiveCaption, r))
				e.Graphics.FillRectangle(b, r);

			for (int i = 0; i < BorderSize; i++)
			{
				ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
				r.Inflate(-1, -1);
			}
			r.Inflate(BorderSize, BorderSize);

			r.Inflate(-(BorderSize + 1), -(BorderSize + 1));

			Helper.DrawRenderString(e.Graphics, Text, r, Font, ForeColor, Color.Transparent);

			r.Offset(0, r.Height);
			r.Height = ClientRectangle.Height - r.Top;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			Invalidate();
			Refresh();
		}
	}
}
