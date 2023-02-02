using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML;
using V = VWS.WindowsDesktop.Controls.XMLTreeList.Visual;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class XMLElementPainter
	{
		internal XMLElementPainter() { }

		internal Size MeasureHeader(Graphics g, Font f, string t)
		{
			return new Size(V.From<string>((object o) => t, null).Measure(g, f).Width + 24, 24);
		}

		internal Size MeasureAttribute(Graphics g, Font f, XML.Attribute attr)
		{
			return new Size(V.From<string>((object o) => GetAttributeText(attr), null).Measure(g, f).Width, 16);
		}

		string GetAttributeText(XML.Attribute attr)
		{
			return "@ " + attr.Name + "=\"" + attr.Value + "\"";
		}

		internal void DrawItemHeader(Graphics g, Font f, string t, Point pt, Size sz, Color fg, Color bg, StateGetter GetState)
		{
			Rectangle rect = new Rectangle(pt, sz);

			if (bg != Color.Transparent) g.FillRectangle(Helper.GetSolidBrush(bg), rect);

			Rectangle r = new Rectangle(pt + new Size(0, 1), new Size(9, 9));

			g.DrawImage(GetStateButton("MetaButton", GetState), r);
			r.Offset(10, 0);
			g.DrawImage(GetStateButton("AttributesButton", GetState), r);
			r.Offset(-10, 10);
			g.DrawImage(GetStateButton("ChildElementsButton", GetState), r);
			r.Offset(10, 0);
			g.DrawImage(GetStateButton("ObjectButton", GetState), r);

			r = rect; r.Offset(24, 0); r.Width -= 24;
			Helper.DrawRenderString(g, t, r, f, fg, bg);
		}
		internal void DrawAttribute(Graphics g, Font f, XML.Attribute attr, Point pt, Size sz, Color fg, Color bg)
		{
			Rectangle rect = new Rectangle(pt, sz);

			if (bg != Color.Transparent) g.FillRectangle(Helper.GetSolidBrush(bg), rect);

			Rectangle r = new Rectangle(pt + new Size(0, 1), new Size(9, 9));

			r = rect;
			Helper.DrawRenderString(g, GetAttributeText(attr), r, f, fg, bg);
		}

		internal Target TargetFromPoint(ItemView item, Point pt)
		{
			Rectangle r = new Rectangle(new Point(0, 1), new Size(9, 9));

			if (item.Attribute == null)
			{
				if (r.Contains(pt)) return new Target(item, "MetaButton", r);
				r.Offset(10, 0);
				if (r.Contains(pt)) return new Target(item, "AttributesButton", r);
				r.Offset(-10, 10);
				if (r.Contains(pt)) return new Target(item, "ChildElementsButton", r);
				r.Offset(10, 0);
				if (r.Contains(pt)) return new Target(item, "ObjectButton", r);

				r = new Rectangle(new Point(24, 0), item.HeaderSize - new Size(24, 0));
				return new Target(item, "Text", r);
			}
			r = new Rectangle(Point.Empty, item.HeaderSize);
			return new Target(item, "Text", r);
		}
		
		#region static Initialization / MiniButtons

		static XMLElementPainter()
		{
			MiniButtons = new Dictionary<string, MiniButton>();
			AddMiniButton("MetaButton");
			AddMiniButton("AttributesButton");
			AddMiniButton("ChildElementsButton");
			AddMiniButton("ObjectButton");
		}

		static Dictionary<string, MiniButton> MiniButtons;

		internal delegate string StateGetter(string buttonName);
		static void AddMiniButton(string name) { MiniButtons[name] = new MiniButton(name); }
		internal System.Drawing.Image GetStateButton(string name, StateGetter GetState)
		{
			return MiniButtons[name].GetStateImage(GetState(name));
		}

		#endregion
	}
}
