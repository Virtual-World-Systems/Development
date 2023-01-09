using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VWS.WindowsDesktop.Traffic
{
	public partial class CrossBar : UserControl
	{
		public CrossBar()
		{
			InitializeComponent();
		}

		private void CrossBar_ParentChanged(object sender, EventArgs e)
		{
			IP = null;
			if (Parent == null) return;
			if (!(Parent is TrafficInterceptor)) return;
			IP = (TrafficInterceptor) Parent;

			//Debug.WriteLine($"Sizes : {IP.Height} {Height}");

			LastIPHeight = IP.Height;
			IP.SizeChanged += IP_SizeChanged;

			ConstHeight = Height;
			int y = (IP.Height - Height) / 2;
			TopHeight = LT.Height = CT.Height = RT.Height = y;
			BottomHeight = LB.Height = CB.Height = RB.Height = IP.ClientRectangle.Height - y - Height;

			//Debug.WriteLine($"Sizes after: {IP.Height} {TopHeight} {BottomHeight} {Height}");

			LP.SizeChanged += V3P_SizeChanged;
			RP.SizeChanged += V3P_SizeChanged;

			LeftPanel.SizeChanged += Panel_SizeChanged;
			RightPanel.SizeChanged += Panel_SizeChanged;

			LeftPanel.Width = LP.Width;
			RightPanel.Width = RP.Width;

			Top = CC.Top;
			Height = CC.Height;
		}
		int ConstHeight = 0;
		int LastIPHeight = 0;

		int TopHeight = 0;
		int BottomHeight = 0;

		private void IP_SizeChanged(object sender, EventArgs e)
		{
			int d = IP.Height - LastIPHeight;
			//Debug.WriteLine($"Size changed : {IP.Height} {LastIPHeight}");
			int dT = d / 2; int dB = d - dT;

			//Debug.WriteLine($"Size changed : {IP.Height} {d} {dT} {dB} {IP.Height-TopHeight-dT-dB-BottomHeight}");

			TopHeight = (LT.Height = CT.Height = RT.Height = TopHeight + dT);
			BottomHeight = (LB.Height = CB.Height = RB.Height = BottomHeight + dB);

			LastIPHeight = IP.Height;

			Top = TopHeight;
			Height = ConstHeight;
		}

		private void Panel_SizeChanged(object sender, EventArgs e)
		{
			Control P = (Control)sender;
			Control PT = (P == LeftPanel) ? LP : RP;
			if (PT.Width != P.Width) PT.Width = P.Width;
		}

		private void V3P_SizeChanged(object sender, EventArgs e)
		{
			Control P = (Control)sender;
			Control PT = (P == LP) ? ((Panel)LeftPanel) : (Panel)RightPanel;
			if (PT.Width != P.Width) PT.Width = P.Width;
		}

		TrafficInterceptor IP = null;

		internal V3Panel LP { get { return (IP == null) ? null : IP.LeftPanel; } }
		internal Controls.Splitter LS { get { return (IP == null) ? null : IP.LeftSplitter; } }
		internal Controls.Splitter RS { get { return (IP == null) ? null : IP.RightSplitter; } }
		internal V3Panel RP { get { return (IP == null) ? null : IP.RightPanel; } }

		internal V3Panel CIP { get { return (IP == null) ? null : IP.CenterPanel; } }

		internal Control LT { get { return (IP == null) ? null : LP.TopPanel; } }
		internal Control LC { get { return (IP == null) ? null : LP.CenterPanel; } }
		internal Control LB { get { return (IP == null) ? null : LP.BottomPanel; } }

		internal Control CT { get { return (IP == null) ? null : CIP.TopPanel; } }
		internal Control CC { get { return (IP == null) ? null : CIP.CenterPanel; } }
		internal Control CB { get { return (IP == null) ? null : CIP.BottomPanel; } }

		internal Control RT { get { return (IP == null) ? null : RP.TopPanel; } }
		internal Control RC { get { return (IP == null) ? null : RP.CenterPanel; } }
		internal Control RB { get { return (IP == null) ? null : RP.BottomPanel; } }
	}
}
