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
		protected override void OnCheckedChanged(EventArgs e)
		{
			Control p = Parent; while (!(p is ToolStripContainer)) p = p.Parent;
			p = ((ToolStripContainer)p).ContentPanel;

			if (!Checked) RemoveTools(p);
			base.OnCheckedChanged(e);
			if (Checked) AddTools(p);
		}
		void AddTools(Control p)
		{
			Control c;
			p.Controls.Add(c = new Splitter());
			c.Dock = DockStyle.Left;
			c.Cursor = Cursors.VSplit;
			p.Controls.Add(c = new Panel());
			c.Dock = DockStyle.Left;
			((Panel)c).BorderStyle = BorderStyle.Fixed3D;
			c.Padding = new Padding(4);
			((Panel)c).AutoScroll = true;
			((Panel)c).AutoScrollMinSize = new Size(508, 708);
			c.Paint += C_Paint;
			Panel c2;
			c.Controls.Add(c2 = new Panel());
			c2.Size = new Size(500, 700);
			c2.BackColor = Color.Green;
			c2.Dock = DockStyle.Fill;
		}

		private void C_Paint(object sender, PaintEventArgs e)
		{
			Debug.WriteLine($"{e.ClipRectangle}");
			Panel p = (Panel)sender;
			Rectangle r = new Rectangle(0, 0, 496, 696);
			r.Offset(4 + p.AutoScrollPosition.X, 4 + p.AutoScrollPosition.Y);
			e.Graphics.DrawLine(Pens.Blue, r.X, r.Y, r.Right, r.Bottom);
		}

		void RemoveTools(Control p)
		{
			p.Controls[p.Controls.Count - 1].Paint -= C_Paint;
			p.Controls[p.Controls.Count - 1].Dispose();
			p.Controls[p.Controls.Count - 1].Dispose();
			//p.Controls.RemoveAt(p.Controls.Count - 1);
			//p.Controls.RemoveAt(p.Controls.Count - 1);
		}
	}
}
