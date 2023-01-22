using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (UdpClient udpClient = new UdpClient(17009))
			{
				IPHostEntry iphe = Dns.GetHostEntry("kitely.com");
				IPAddress ipkitely = iphe.AddressList[0];
				udpClient.Connect(ipkitely, 17009);
				udpClient.Send(new byte[] { 0, 1, 2 }, 3);
				IPEndPoint ipep = new IPEndPoint(ipkitely, 17009);
				byte[] msg = udpClient.Receive(ref ipep);
				Debug.WriteLine("received: " + UTF8Encoding.UTF8.GetString(msg));
			}
		}
	}
}
