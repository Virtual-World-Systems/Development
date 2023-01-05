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

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	public partial class XMLTreeList : UserControl
	{
		public XMLTreeList()
		{
			InitializeComponent();
		}

		#region Selector

		[Category("_"), Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string XPathSelector
		{
			get { return selector; }
			set
			{
				selector = value;
				Element = string.IsNullOrEmpty(value)
					? Program.XML.Root
					: Program.XML.Root.SelectElement(value);
				Invalidate(true);
			}
		}
		private string selector;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Element Element
		{
			get { return element; }
			set { element = value;
				Header.Text = element.DisplayName;
				Panel.ParentElement = element;
			}
		}
		Element element = null;

		#endregion
	}
}
