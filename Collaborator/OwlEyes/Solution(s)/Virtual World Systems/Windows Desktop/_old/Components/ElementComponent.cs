using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Components
{
	public partial class ElementComponent : Component
	{
		public ElementComponent()
		{
			InitializeComponent();
		}

		public ElementComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}
	}
}
