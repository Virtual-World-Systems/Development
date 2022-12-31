using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Converter
{
	[ToolboxItem(false)]
	public partial class Stream : UserControl
	{
		public Stream()
		{
			InitializeComponent();
		}

		private void Input_Load(object sender, EventArgs e)
		{
			int item = -1;
			foreach (Element x in Program.XML.Root.SelectElements("mime:Types/Type"))
			{
				int i = FormatSettings.Selector.Items.Add(x.DisplayName);
				if (x.DisplayName == "Text/Collada") item = i;
			}
			if (item > -1) { FormatSettings.Selector.SelectedIndex = item; }
		}
	}
}
