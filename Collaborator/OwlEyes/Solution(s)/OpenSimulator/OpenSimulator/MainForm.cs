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
		#region Lifetime
		public static MainForm Instance;
		public MainForm()
		{
			Instance = this;
			InitializeComponent();
		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			Tree.ImageList = IconList.Instance;
			Tree.Load();
		}
		O O;
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			NotifyIcon.Dispose();
		}

		#endregion
		#region Log
		public static void Log(string text)
		{
			Instance.Log_(text);
		}
		public void Log_(string text)
		{
			TextBox tb = (TextBox)Instance.Panel_Content.Controls[0].Controls[0];
			tb.Text += text + "\r\n";
		}
		#endregion

		#region Tree
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
		private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			VerifyPropertyGrid();

			List<string> hidden = (e.Node.Tag is Objects._)
				? ((Objects._)e.Node.Tag).GetHiddenProperties()
				: new List<string>() { "Capacity", "Count" };
			PropertyGrid.SelectedObject = new PropertiesWrapper(e.Node.Tag, hidden);
		}
		#endregion

		#region PropertyGrid
		void VerifyPropertyGrid()
		{
			Panel_Content.Controls.Clear();

			Panel panel = new Panel();
			Panel_Content.Controls.Add(panel);
			panel.Height = 100;
			panel.Dock = DockStyle.Bottom;
			panel.Visible = true;
			panel.Show();

			TextBox textBox = new TextBox();
			textBox.Name = "LogTextBox";
			panel.Controls.Add(textBox);
			textBox.Multiline = true;
			textBox.Width = 400;
			textBox.ReadOnly = true;
			textBox.Dock = DockStyle.Left;
			textBox.Visible = true;
			textBox.Show();

			webBrowser = new WebBrowser();
			webBrowser.AllowNavigation = true;
			//webBrowser.Url = new Uri("http://ethikratie.net");
			webBrowser.Dock = DockStyle.Fill;
			webBrowser.Visible = true;
			webBrowser.Show();

			PropertyGrid = new PropertyGrid();
			Panel_Content.Controls.Add(PropertyGrid);
			PropertyGrid.Dock = DockStyle.Fill;
			PropertyGrid.Visible = true;
			PropertyGrid.Show();
		}
		PropertyGrid PropertyGrid;
		WebBrowser webBrowser;

		private void NodeContext_ShowMetainfo_Click(object sender, EventArgs e)
		{
			VerifyPropertyGrid();
			PropertyGrid.SelectedObject = ((ToolStripMenuItem)sender).Owner.Tag;
		}
		#endregion

		#region ColladaFromDB
		private void colladaFromDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool dbg = false;
#if DEBUG
			dbg = true;
			F_colladaFromDB = null;
#endif
			if (dbg || (F_colladaFromDB == null))
				F_colladaFromDB = Dialog.from("/File/Import/ColladaFromDB");

			(int n, char str) = ClassLibrary1.Class1.xyz("bbb");
			switch (F_colladaFromDB.ShowDialog())
			{
				case DialogResult.OK: MessageBox.Show("" + str); return;
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

		#endregion

		#region Tests
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

		private void demoAssemblyBuilderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DemoAssemblyBuilder.Run();
		}

		private void iLGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TestILGenerator.Run();
		}
		#endregion

		#region NotifyIcon
		private void NotifyIcon_BalloonTipShown(object sender, EventArgs e)
		{
			Log_("shown");
		}
		private void NotifyIcon_Click(object sender, EventArgs e)
		{
			switch (((MouseEventArgs)e).Button)
			{
				case MouseButtons.Left:
					NotifyMenu.Show(Cursor.Position, ToolStripDropDownDirection.Default);
					return;
				case MouseButtons.Right:
					NotifyContextMenu.Show(Cursor.Position, ToolStripDropDownDirection.Default);
					return;
				case MouseButtons.Middle:
					NotifyIcon.ShowBalloonTip(3000);
					return;
			}
		}

		private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			Log_("clicked");
		}

		private void NotifyIcon_BalloonTipClosed(object sender, EventArgs e)
		{
			Log_("closed");
		}
		#endregion

		private void ShowWebbrowser_Click(object sender, EventArgs e)
		{
			//webBrowser.Navigate("https://ethikratie.net");
		}
	}
}
