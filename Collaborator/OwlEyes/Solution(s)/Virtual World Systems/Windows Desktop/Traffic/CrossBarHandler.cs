using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Traffic
{
	public partial class CrossBarHandler : Component
	{
		public CrossBarHandler()
		{
			InitializeComponent();
		}

		public CrossBarHandler(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public Control CenterControl { get; set; }
	}
}
