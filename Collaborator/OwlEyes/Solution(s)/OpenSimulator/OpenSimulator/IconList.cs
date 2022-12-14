using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OpenSimulator
{
	internal class IconList
	{
		IconList()
		{
			ImageList.ImageSize = new Size(16, 16);
			XmlDocument doc = new XmlDocument();
			doc.Load(Dialog.Path("Icons\\_.xml"));
			foreach (XmlElement x in doc.DocumentElement.SelectNodes("*"))
			{
				string key = x.GetAttribute("Key");
				ImageList.Images.Add(key, Image.FromFile(Dialog.Path("Icons\\" + key + ".png")));
			}
		}
		public static implicit operator ImageList(IconList d) => d.ImageList;
		ImageList ImageList = new ImageList();
		public static IconList Instance { get { return _instance ?? (_instance = new IconList()); } }
		static IconList _instance = null;
	}
}
