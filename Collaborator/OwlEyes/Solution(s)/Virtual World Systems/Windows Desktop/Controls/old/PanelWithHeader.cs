using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace VWS.WindowsDesktop.Controls
{
	[Designer(typeof(PanelWithHeaderDesigner))]
	public partial class PanelWithHeader : UserControl
	{
		public class PanelWithHeaderDesigner : ParentControlDesigner
		{
			public override void Initialize(IComponent component)
			{
				base.Initialize(component);
				var contentsPanel = ((PanelWithHeader)this.Control).ContentsPanel;
				this.EnableDesignMode(contentsPanel, "ContentsPanel");
			}
			public override bool CanParent(Control control)
			{
				return false;
			}
			protected override void OnDragOver(DragEventArgs de)
			{
				de.Effect = DragDropEffects.None;
			}
			protected override IComponent[] CreateToolCore(ToolboxItem tool,
				int x, int y, int width, int height, bool hasLocation, bool hasSize)
			{
				return null;
			}
		}

		public PanelWithHeader()
		{
			InitializeComponent();
			Dock = DockStyle.None;
		}
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public string Title { get; set; }
		//{
		//	get { return titleLabel.Text; }
		//	set { titleLabel.Text = value; }
		//}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public UserControl ContentsPanel
		{
			get { return contentsPanel; }
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			TitlePanel.Font = Font;
		}
	}
}
