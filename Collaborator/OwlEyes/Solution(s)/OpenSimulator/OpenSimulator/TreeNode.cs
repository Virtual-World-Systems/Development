using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenSimulator
{
	public partial class TreeNode : System.Windows.Forms.TreeNode
	{
		public TreeNode()
		{
		}
		public TreeNode(string text, string imageKey)
		{
			Text = text;
			ImageKey = imageKey;
			SelectedImageKey = imageKey;
			
		}

		internal void Draw(DrawTreeNodeEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.Aquamarine, e.Bounds);
		}

		//protected override void OnPaint(PaintEventArgs pe)
		//{
		//	base.OnPaint(pe);
		//}
	}
}
