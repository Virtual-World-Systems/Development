using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OpenSimulator
{
	public partial class MainForm : Form
	{
		public static MainForm Instance;
		public MainForm()
		{
			Instance = this;
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
		O O;

		private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				e.Node.TreeView.SelectedNode = e.Node;
				new Test.Test_TreeNodeRightClick(e.Node);
				NodeContextMenu.Tag = e.Node;
				NodeContextMenu.Show((Control)sender, e.Location);
			}
		}

		public static void Log(string text)
		{
			Instance.Log_(text);
		}
		public void Log_(string text)
		{
			TextBox tb = (TextBox)Instance.Panel_Content.Controls[0];
			tb.Text += text + "\r\n";
		}

		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			VerifyPropertyGrid();

			List<string> hidden = (e.Node.Tag is Objects._)
				? ((Objects._)e.Node.Tag).GetHiddenProperties()
				: new List<string>() { "Capacity", "Count" };
			PropertyGrid.SelectedObject = new PropertiesWrapper(e.Node.Tag, hidden);
		}
		void VerifyPropertyGrid()
		{
			Panel_Content.Controls.Clear();

			TextBox textBox = new TextBox();
			Panel_Content.Controls.Add(textBox);
			textBox.Multiline = true;
			textBox.Height = 100;
			textBox.ReadOnly = true;
			textBox.Dock = DockStyle.Bottom;
			textBox.Visible = true;
			textBox.Show();

			PropertyGrid = new PropertyGrid();
			Panel_Content.Controls.Add(PropertyGrid);
			PropertyGrid.Dock = DockStyle.Fill;
			PropertyGrid.Visible = true;
			PropertyGrid.Show();
		}
		PropertyGrid PropertyGrid;

		private void Test_XML_Click(object sender, EventArgs e)
		{
			new Test.Test_XML(Dialog.Path("_.xml"));
		}

		private void Test_O_DataRow_Click(object sender, EventArgs e)
		{
			new Test.Test_O_DataRow();
		}

		private void Test_AssemblyName_Click(object sender, EventArgs e)
		{
			new Test.Test_AssemblyName();
		}

		private void NodeContext_ShowMetainfo_Click(object sender, EventArgs e)
		{
			VerifyPropertyGrid();
			PropertyGrid.SelectedObject = ((ToolStripMenuItem)sender).Owner.Tag;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
