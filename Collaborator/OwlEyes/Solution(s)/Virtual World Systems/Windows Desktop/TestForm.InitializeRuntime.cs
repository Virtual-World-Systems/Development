using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;
using System.Xml;

namespace VWS.WindowsDesktop
{
	partial class TestForm
	{
		void PreInitialize()
		{
			//SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			//SetStyle(ControlStyles.Opaque, true);
			//this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			string path = Program.ApplicationData + "ApplicationProperties.xml";

			if (!Directory.Exists(Program.ApplicationData))
				Directory.CreateDirectory(Program.ApplicationData);

			if (!File.Exists(path))
			{
				File.WriteAllText(path,
					"<User><ApplicationProperties><Width>1000</Width></ApplicationProperties></User>"
				);
			}
			Program.XML.DocumentElement.AppendChild(Program.XML.ReadFile(path));

			//Debug.WriteLine(Program.XML.OuterXml);
			//Debug.WriteLine(Program.XML.DocumentElement.FirstChild.OuterXml);
		}

		void InitializeRuntime()
		{
			SetDoubleBuffered(this);
			//foreach (Element e in Program.XML.DocumentElement.SelectElements("User/ApplicationProperties"))
			//{
			//	Debug.WriteLine(e.Prefix + "[" + e.NamespaceURI + "]:" + e.Name + " :: " + e.OuterXml);
			//}

			foreach (Element e in Program.XML.DocumentElement
				.SelectElements("User/ApplicationProperties/*"))
			{
				object o = this, ol = this;
				PropertyInfo pi = null;
				foreach (string s in e.Name.Split('.'))
				{
					pi = o.GetType().GetProperty(s);
					ol = o; o = pi.GetValue(o, null);
				}
				//Debug.WriteLine(e.Name + " old : " + o);
				object v = Convert.ChangeType(e.InnerText, pi.PropertyType);
				//Debug.WriteLine(e.Name + " new : " + v);
				pi.SetValue(ol, v);
			}
			StringBuilder sb = new StringBuilder();
			Program.XML.DocumentElement.WriteTo(sb);
			Debug.WriteLine(sb.ToString());
		}

		void SetDoubleBuffered(Control c)
		{
			c.GetType().GetProperty("DoubleBuffered",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public
				).SetValue(c, true);

			foreach (Control cx in c.Controls) SetDoubleBuffered(cx);
		}


	}
}
