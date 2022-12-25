using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace VWS.WindowsDesktop.Controls
{
	public class ScrollableContentsPanel : Panel
	{
		//TypeDescriptor.AddAttributes(this.ContentsPanel,
		//		new DesignerAttribute(typeof(ContentPanelDesigner)));
			[Designer(typeof(ContentPanelDesigner))]
		public class ContentPanelDesigner : ParentControlDesigner
		{
			public override SelectionRules SelectionRules
			{
				get
				{
					SelectionRules selectionRules = base.SelectionRules;
					selectionRules &= ~SelectionRules.AllSizeable;
					return selectionRules;
				}
			}
			protected override void PostFilterAttributes(IDictionary attributes)
			{
				base.PostFilterAttributes(attributes);
				//attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
			}
			protected override void PostFilterProperties(IDictionary properties)
			{
				base.PostFilterProperties(properties);
				var propertiesToRemove = new string[] {
					"Dock", "Anchor",
					"Size", "Location", "Width", "Height",
					"MinimumSize", "MaximumSize",
					"AutoSize", "AutoSizeMode",
					"Visible", "Enabled",
				};
				foreach (var item in propertiesToRemove)
				{
					if (properties.Contains(item))
						properties[item] = TypeDescriptor.CreateProperty(this.Component.GetType(),
							(PropertyDescriptor)properties[item],
							new BrowsableAttribute(false));
				}
			}
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ScrollableContentsPanel
			// 
			this.AutoScroll = true;
			this.ResumeLayout(false);

		}
	}
}
