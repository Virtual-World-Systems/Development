using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using VWS.WindowsDesktop.Properties;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class MiniButton
	{
		internal MiniButton(string name)
		{
			Normal = GetImage(name, "normal");
			Checked = GetImage(name, "checked");
			Disabled = GetImage(name, "disabled");
		}
		System.Drawing.Image GetImage(string n, string v)
		{
			return (System.Drawing.Image) typeof(Resources).GetProperty(n + "_" + v,
				BindingFlags.Static | BindingFlags.NonPublic).GetValue(null, null);
		}
		internal System.Drawing.Image Normal { get; private set; }
		internal System.Drawing.Image Checked { get; private set; }
		internal System.Drawing.Image Disabled { get; private set; }
		internal System.Drawing.Image GetStateImage(string state)
		{
			switch (state)
			{
				case "normal": return Normal;
				case "checked": return Checked;
				case "disabled": return Disabled;
			}
			return null;
		}
	}
}
