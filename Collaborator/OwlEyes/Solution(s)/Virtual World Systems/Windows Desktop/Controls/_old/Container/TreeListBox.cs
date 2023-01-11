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
	public partial class TreeListBox : UserControl
	{
		public TreeListBox()
		{
			InitializeComponent();
		}

		[Category("Data"), Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public XML.Element XMLElement { get; set; }
	}
}
