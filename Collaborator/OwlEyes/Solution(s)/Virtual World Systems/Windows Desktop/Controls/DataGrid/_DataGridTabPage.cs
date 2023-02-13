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
	public partial class DataGridTabPage : TabPage
	{
		public DataGridTabPage()
		{
			InitializeComponent();
		}

		private void DataGridTabPage_Paint(object sender, PaintEventArgs e)
		{
			Rectangle r = ClientRectangle;
			ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.Raised);
			//r.Inflate(-1, -1);
			//ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.Raised);
		}
	}
}
