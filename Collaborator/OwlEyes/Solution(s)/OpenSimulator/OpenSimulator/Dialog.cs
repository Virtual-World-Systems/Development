using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Diagnostics;

namespace OpenSimulator
{
	public partial class Dialog : Form
	{
		public Dialog()
		{
			InitializeComponent();
		}

		internal static string Path(string p)
		{
			if (_path == null)
			{
				_path = Assembly.GetExecutingAssembly().CodeBase;
				if (_path.StartsWith("file:///")) _path = _path.Substring(8);
				_path = _path.Replace("/", "\\");
				_path = _path.Substring(0, _path.LastIndexOf("\\") + 1);
			}
			return _path + p;
		}
		static string _path = null;

		internal static Form from(string Index)
		{
			bool dbg = false;
#if DEBUG
			dbg = true;
			Debug.WriteLine("debugging");
#endif
			if (true)//dbg || (Dialogs == null))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(Path("Dialogs.xml"));
				Debug.WriteLine("reading XML");
				Dialogs = doc.DocumentElement;
			}
			if (dbg || (!_dialogs.ContainsKey(Index)))
				_dialogs[Index] = new Dialog((XmlElement)Dialogs.SelectSingleNode(Index));
			return _dialogs[Index];
		}
		static XmlElement Dialogs = null;
		static Dictionary<string, Dialog> _dialogs = new Dictionary<string, Dialog>();

		class POV
		{
			public POV(PropertyInfo p, object o, object v)
			{ this.p = p; this.o = o; this.v = v; }
			public PropertyInfo p;
			public object o;
			public object v;
		}

		Dialog(XmlElement x) : this()
		{
			xml = x;

			string Text = x.SelectSingleNode("Title").Value;
			//int Width = int.Parse(x.SelectSingleNode("Width").InnerText);
			//int Height = int.Parse(x.SelectSingleNode("Height").InnerText);
			//this.ClientSize = new System.Drawing.Size(Width, Height);
			this.Text = Text;

			SuspendLayout();

			int bot = 0, rgt = 0;
			List<Control> ctls0 = new List<Control>();

			foreach (Control v in Controls)
			{
				v.SuspendLayout();
				ctls0.Add(v);
			}
			List<POV> Lazies = new List<POV>();

			foreach (XmlElement e in x.SelectNodes("Controls/*"))
			{
				string type = e.Name;
				Type L = typeof(Control).Assembly.GetType("System.Windows.Forms." + type);
				ConstructorInfo CI = L.GetConstructor(new Type[] { });
				Control ctl = (Control) CI.Invoke(new Object[] { });
				Controls.Add(ctl);
				Controls.SetChildIndex(ctl, Controls.Count - 3);
				ctl.SuspendLayout();

				foreach (XmlElement a in e.SelectNodes("*"))
				{
					if (a.Name.StartsWith("_")) continue;
					string[] ss;
					object o = null;
					bool lazy = false;
					PropertyInfo pi = L.GetProperty(a.Name, BindingFlags.Public | BindingFlags.Instance);
					switch (pi.PropertyType.Name)
					{
						case "Boolean": o = (a.InnerText.ToLower() == "true"); break;
						case "String": o = a.InnerText; break;
						case "Point":
							ss = a.InnerText.Split(';');
							Point p = new Point();
							p.X = int.Parse(ss[0]);
							p.Y = int.Parse(ss[1]);
							o = p;
							break;
						case "Size":
							ss = a.InnerText.Split(';');
							Size sz = new Size();
							sz.Width = int.Parse(ss[0]);
							sz.Height = int.Parse(ss[1]);
							o = sz;
							break;
						case "AnchorStyles":
							int ast = 0;
							foreach (string s in a.InnerText.Split(','))
								ast |= (int)Enum.Parse(typeof(AnchorStyles), s);
							o = ast;
							lazy = true;
							break;
						case "Int32":
							o = int.Parse(a.InnerText);
							break;
						default:
							MessageBox.Show("unknown: " + pi.PropertyType.Name);
							break;
					}
					if (o != null)
					{
						if (lazy) Lazies.Add(new POV(pi, ctl, o));
						else pi.SetValue(ctl, o, null);
					}
				}
				ctl.ResumeLayout();
				ctl.PerformLayout();
				bot = Math.Max(bot, ctl.Bottom);
				rgt = Math.Max(rgt, ctl.Right);
			}
			foreach (Control v in ctls0)
			{
				v.ResumeLayout();
				v.PerformLayout();
				bot = Math.Max(bot, v.Bottom);
				rgt = Math.Max(rgt, v.Right);
			}
			ResumeLayout();
			PerformLayout();

			AutoSize = false;
			bot = bot + 40;
			rgt = rgt + 12;
			ClientSize = new Size(rgt, bot);
			MinimumSize = Size;

			foreach (POV pov in Lazies)
				pov.p.SetValue(pov.o, pov.v, null);
		}
		XmlElement xml;

		private void OK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
