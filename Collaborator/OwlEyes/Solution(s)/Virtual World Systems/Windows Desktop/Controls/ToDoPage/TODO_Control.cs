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
	public partial class TODO_Control : UserControl
	{
		public TODO_Control()
		{
			InitializeComponent();

			string Path = Program.SourceRoot + "Data\\_.xml";

			if (!System.IO.File.Exists(Path))
			{
				System.IO.File.WriteAllText(Path, "<_/>");
			}
		}
	}
}
