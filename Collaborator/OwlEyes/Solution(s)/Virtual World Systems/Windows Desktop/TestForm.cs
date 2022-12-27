﻿using System;
using XML;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			PreInitialize(); // incl. TransparencyKey fixes
			InitializeComponent();
			InitializeRuntime(); // incl. SplitContainer fixes
		}

		private void MM_File_Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void EditMode_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
