using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MM_Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			using (Pen p = new Pen(Color.FromArgb(0, 0, 0), 5))
			{
				e.Graphics.DrawLine(p, Point.Empty, Point.Empty + ClientRectangle.Size);
			}
		}
	}
}
