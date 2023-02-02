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
	public partial class TestTabPage : TabPage
	{
		public TestTabPage()
		{
			InitializeComponent();
			BindingSource BindingSource = new BindingSource();
			BindingSource.DataSource = Program.XML.Root;// VWS.Data.TypeSet.I.Tables["MimeType"];
			DataGridView.DataSource = BindingSource;
//			ChildDataGridView.DataSource = new BindingSource(BindingSource.M, "ChildNodes");
		}
	}
}
