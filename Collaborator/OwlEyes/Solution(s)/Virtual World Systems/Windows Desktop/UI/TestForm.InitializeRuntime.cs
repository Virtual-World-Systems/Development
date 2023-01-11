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
using System.Drawing;
using VWS.WindowsDesktop.Properties;

namespace VWS.WindowsDesktop
{
	partial class TestForm
	{
		void PreInitialize()
		{
			//SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			//SetStyle(ControlStyles.Opaque, true);
			//this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

			Icon = Resources.Multiverse;
			//Debug.WriteLine("\r\n\r\nOrphans: " + Program.XML.Orphans.OuterXml);

			//foreach (string s in Program.MimeTypes) Debug.WriteLine(s);
			//Type MimeTypes = typeof(System.Net.Mime.MediaTypeNames);
			//foreach (Type TC in MimeTypes.GetNestedTypes())
			//{
			//	foreach (FieldInfo fi in TC.GetFields(BindingFlags.Public | BindingFlags.Static))
			//	Debug.WriteLine(TC.Name + "/" + fi.Name);
			//}
		}

		void InitializeRuntime()
		{
			SetDoubleBuffered(this);

			foreach (Element e in Program.XML.Root
				.SelectElements("user:Data/User/ApplicationProperties/*"))
			{
				object o = this, ol = this;
				PropertyInfo pi = null;
				foreach (string s in e.Name.Split('.'))
				{
					pi = o.GetType().GetProperty(s);
					ol = o; o = pi.GetValue(o, null);
				}
				//Debug.WriteLine(e.Name + " old : " + o);
				//object vx = (object)pi.GetValue(ol);
				//Debug.WriteLine($"{vx.GetType()}");
				//string sx = (string)Convert.ChangeType(pi.GetValue(ol), typeof(string));

				object v = null;

				if (pi.PropertyType == typeof(Point)) v = ToPoint(e.InnerText); else
					v = Convert.ChangeType(e.InnerText, pi.PropertyType);

				Point pt = new Point(11, 22);
				string sx = "" + pt;
				//Debug.WriteLine($"Point = {sx}");

				//Debug.WriteLine(e.Name + " new : " + v);
				pi.SetValue(ol, v);
			}

			Point ToPoint(string text)
			{
				string[] ss = text.Split(',', ';');
				return new Point(int.Parse(ss[0]), int.Parse(ss[1]));
			}
			StringBuilder sb = new StringBuilder();
			Program.XML.Root.WriteTo(sb);
			//Debug.WriteLine("\r\nDocument : " + sb.ToString());

			TabControl.SelectTab(TrafficInterceptor);

			//MessageBox.Show(Program.XML.Root.SelectElement("firestorm:Data").OuterXml);
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
