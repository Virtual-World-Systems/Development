using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class ItemView
	{
		#region misc
		internal ItemView(ListView p, Element e, int i)
		{
			ItemList = p;
			Element = e;
			Index = i;
		}
		internal ItemView(ListView p, XML.Attribute a, int i)
		{
			ItemList = p;
			Attribute = a;
			Element = a.Element;
			Index = i;
		}

		ListView ItemList;
		internal int Index;
		internal Element Element;
		internal XML.Attribute Attribute = null;

		internal XMLTreeListPanel Panel
		{
			get => (XMLTreeListPanel)ItemList.Control;
		}
		internal XMLTreeListPanel TopTreeListPanel
		{
			get
			{
				XMLTreeListPanel p = Panel;
				while (p.Parent is XMLTreeListPanel)
					p = (XMLTreeListPanel)p.Parent;
				return p;
			}
		}
		#endregion

		#region Sizing

		internal Size Size;
		internal Size HeaderSize;
		internal int Width { get => Size.Width; }
		internal int Height { get => Size.Height; }

		int ContentIndent { get => 12; }
		internal Size ComputeHeaderSize(XMLTreeListPanel panel, Graphics g)
		{
			if (Attribute == null)
				return (Size = (HeaderSize = XMLTreeListPanel.Painter.MeasureHeader(g, panel.Font, Element.DisplayName)));
			return (Size = (HeaderSize = XMLTreeListPanel.Painter.MeasureAttribute(g, Panel.Font, Attribute)));
		}

		#endregion

		#region Content

		internal ContentView ContentView = null;
		internal void SetContentCorner(Point pt)
		{
			//Debug.WriteLine($"SetContentCorner {pt}, ContentSize={ContentView.ListView.Size}");
			Size szNew = new Size(pt);
			if (szNew.Width < HeaderSize.Width) szNew.Width = HeaderSize.Width;
			if (Size == szNew) return;
			Size szOld = Size; Size = szNew;
			ItemList.ChangedItemHeight(this, szNew.Height - szOld.Height);
		}

		#endregion

		#region Targetting
		internal Target TargetFromPoint(Point pt)
		{
			//Debug.WriteLine($"TargeFromPoint, Item={Index}, Point={pt}");
			Rectangle rect = new Rectangle(Point.Empty, HeaderSize);
			if (rect.Contains(pt)) return XMLTreeListPanel.Painter.TargetFromPoint(this, pt);
			if (pt.Y < HeaderSize.Height) return new Target(this, "^", rect);
			rect = new Rectangle(Point.Empty, Size);
			if ((ContentView == null) || (!ContentView.IsOpen)) return new Target(this, "^", rect);
			rect = new Rectangle(new Point(ContentIndent, HeaderSize.Height), ContentView.Size);
			if (pt.X < rect.Left) return new Target(this, "|", rect);
			pt -= new Size(rect.Location);
			Target target = ContentView.TargetFromPoint(pt);
			if (target == null) return new Target(this, "|", rect);
			target.rect.Offset(ContentIndent, HeaderSize.Height);
			return target;
		}

		#endregion

		#region States
		string GetState(string name)
		{
			switch (name)
			{
				case "MetaButton": return "disabled";
				case "AttributesButton": return (!Element.HasAttributes) ? "disabled"
						: (ContentView == null) ? "normal" : ContentView.OpenState_Attributes ? "checked" : "normal";
				case "ChildElementsButton": return (!Element.HasChildElements) ? "disabled"
						: (ContentView == null) ? "normal" : ContentView.OpenState_ChildElements ? "checked" : "normal";
				case "ObjectButton": return "normal";
			}
			return "disabled";
		}

		#endregion

		internal void Paint(Graphics g, Rectangle client)
		{
			using (RT.I I = RT.IN)
			{
				//Debug.WriteLine($"{I.S}Item[{Index}].Paint: client={client} >> {Element.DisplayName}");

				Control panel = ItemList.Control;
				Size szD = new Size(client.Width, HeaderSize.Height);

				if (Attribute == null)
					XMLTreeListPanel.Painter.DrawItemHeader(g,
						panel.Font, Element.DisplayName, client.Location, szD,
						panel.ForeColor, panel.BackColor, GetState);
				else
					XMLTreeListPanel.Painter.DrawAttribute(g,
							panel.Font, Attribute, client.Location, szD,
							panel.ForeColor, panel.BackColor);

				if (ContentView == null) return;
				if (!ContentView.IsOpen) return;

				client.X += ContentIndent;
				client.Width -= ContentIndent;

				client.Y += HeaderSize.Height;
				client.Height -= HeaderSize.Height;

				ContentView.Paint(g, client);
			}
		}
		
		internal void Click(Target target)
		{
			Debug.WriteLine($"clicked [{Element.DisplayName}] item={target.item.Index}, rect={target.rect}, part={target.part}");
			if (!("" + target.part).EndsWith("Button")) return;
			if (ContentView == null) ContentView = new ContentView(this, new Point(ContentIndent, HeaderSize.Height));
			string propName = "OpenState_" + target.part.ToString();
			if (propName.EndsWith("Button")) propName = propName.Substring(0, propName.Length - 6);
			PropertyInfo pi = typeof(ContentView).GetProperty(propName);
			bool v = (bool)pi.GetValue(ContentView, null);
			pi.SetValue(ContentView, v ? false : true);
		}
	}
}
