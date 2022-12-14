using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OpenSimulator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void colladaFromDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (F_colladaFromDB == null)
				F_colladaFromDB = Dialog.from("/File/Import/ColladaFromDB");
			switch (F_colladaFromDB.ShowDialog())
			{
				case DialogResult.OK: MessageBox.Show("OK"); return;
				case DialogResult.Cancel: MessageBox.Show("cancelled"); return;
				case DialogResult.None: MessageBox.Show("none"); return;
				case DialogResult.No: MessageBox.Show("no"); return;
				case DialogResult.Retry: MessageBox.Show("retry"); return;
				case DialogResult.Yes: MessageBox.Show("yes"); return;
				case DialogResult.Abort: MessageBox.Show("abort"); return;
				case DialogResult.Ignore: MessageBox.Show("ignore"); return;
			}
		}
		public Form F_colladaFromDB = null;

		private void MainForm_Load(object sender, EventArgs e)
		{
			Tree.ImageList = IconList.Instance;
			Tree.Load();
		}

		private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				e.Node.TreeView.SelectedNode = e.Node;
				string k = e.Node.Name;
				string t = e.Node.Text;
				if (k != t) t = k + ": " + t;
				MessageBox.Show(t);
			}
		}

		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (Panel_Content.HasChildren)
				foreach (Control c in Panel_Content.Controls)
					Panel_Content.Controls.Remove(c);

			PropertyGrid pg = new PropertyGrid();
			Panel_Content.Controls.Add(pg);
			pg.Dock = DockStyle.Fill;
			List<string> hidden = (e.Node.Tag is Objects._)
				? ((Objects._)e.Node.Tag).GetHiddenProperties()
				: new List<string>() { "Capacity", "Count" };
			pg.SelectedObject = new PropertiesWrapper(e.Node.Tag, hidden);
			pg.Visible = true;
			pg.Show();
		}
	}
}
