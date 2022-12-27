using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VWS.WindowsDesktop.Properties;
using static System.Windows.Forms.AxHost;

namespace VWS.WindowsDesktop.Controls.Nodes
{
	public partial class TreeNodeButton : UserControl
	{
		public TreeNodeButton()
		{
			InitializeComponent();
			BackColor = Color.Transparent;
		}

		public enum ButtonState { opened, closed }
		public ButtonState State { get; set; } = ButtonState.closed;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			VerifyBitmaps();
			//e.Graphics.Clear(Color.Wheat);
			e.Graphics.DrawImage(StateBitmap, new Point());
		}
		static Image Bitmap_opened = null;
		static Image Bitmap_closed = null;

		//protected override void OnPaintBackground(PaintEventArgs e)
		//{
		//	base.OnPaintBackground(e);
		//	e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(1, Color.Transparent)), ClientRectangle);
		//}
		Image StateBitmap
		{
			get
			{
				VerifyBitmaps();
				return (State == ButtonState.opened) ? Bitmap_opened : Bitmap_closed;
			}
		}
		static void VerifyBitmaps()
		{
			Bitmap_closed = Bitmap_closed ?? Image.FromFile(Program.Path + "Resources\\PNG_16x16\\TreeNodeButton_closed.png");
			Bitmap_opened = Bitmap_opened ?? Image.FromFile(Program.Path + "Resources\\PNG_16x16\\TreeNodeButton_opened.png");
		}
		static Image ImageFrom(string path)
		{
			string fn = Program.Path + "Resources\\" + path;
			Debug.WriteLine(fn);
			return Image.FromFile(fn);
		}
		private void TreeNodeButton_Click(object sender, EventArgs e)
		{
			if (State == ButtonState.closed)
				State = ButtonState.opened; else
				State = ButtonState.closed;
			Debug.WriteLine(State.ToString());
			Invalidate();
		}
	}
}
