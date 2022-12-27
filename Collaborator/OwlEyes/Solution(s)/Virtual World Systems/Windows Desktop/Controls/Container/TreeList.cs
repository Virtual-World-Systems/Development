using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Controls.Container
{
	public partial class TreeList : UserControl
	{
		public class LB : ListBox
		{
			public LB()
			{
				SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
				//SetStyle(ControlStyles.UserPaint, true); 
				this.DrawMode = DrawMode.OwnerDrawFixed;
				SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				this.DoubleBuffered = true;
			}
			protected override void OnPaintBackground(PaintEventArgs pevent)
			{
			}
		}
		public TreeList()
		{
			InitializeComponent();
			for (int i = 0; i < 25; i++) { ListBox.Items.Add(new TreeListItem("" + i)); }
		}

		void doP(object sender, EventArgs e) { }

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text { get => base.Text; set => base.Text = value; }

		private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			((TreeListItem)ListBox.Items[e.Index]).MeasureItem(ListBox, e);
		}

		private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			((TreeListItem)ListBox.Items[e.Index]).DrawItem(ListBox, e);
		}
	}
}
