using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VWS.IO;

namespace VWS.WindowsDesktop
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MMF_Exit_Click(object sender, EventArgs e)
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

		private void Listener_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (e.Item.Tag == null) e.Item.Tag = new TCPListener(5404);
			TCPListener listener = (TCPListener) e.Item.Tag;
			if (e.Item.Checked) listener.Start(); else listener.Stop();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}
	}
}
