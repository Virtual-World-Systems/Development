using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls.Container
{
	public partial class TreeListItem : UserControl
	{
		public TreeListItem()
		{
			InitializeComponent();
		}
		public TreeListItem(object tag)
		{
			Tag = tag;
			InitializeComponent();
		}

		internal void MeasureItem(ListBox ListBox, MeasureItemEventArgs e)
		{
			e.ItemHeight = 16;// e.Index + 14;
			e.ItemWidth = 200;
		}

		internal void DrawItem(ListBox ListBox, DrawItemEventArgs e)
		{
			Rectangle r = new Rectangle(e.Bounds.Location, e.Bounds.Size);
			Color c = (((e.Index & 1) == 0) ? Color.Green : Color.Red);
			TreeListItem Item = (TreeListItem)ListBox.Items[e.Index];
			r.Offset(-ListBox.AutoScrollOffset.X, -ListBox.AutoScrollOffset.Y);
			e.Graphics.FillRectangle(new SolidBrush(c), r);
			Helper.DrawString(e.Graphics, r, Tag, Font, ListBox.ForeColor);
		}
	}
}
