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
	}
}
