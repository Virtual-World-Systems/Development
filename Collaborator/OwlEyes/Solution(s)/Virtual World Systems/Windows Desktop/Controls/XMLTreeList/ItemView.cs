using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		ListView ItemList;
		internal int Index;
		internal Element Element;

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
		internal Size ComputeSize(XMLTreeListPanel panel, Graphics g)
		{
			return (HeaderSize = (Size = XMLTreeListPanel.Painter.
				Measure(g, panel.Font, Element.DisplayName)));
		}
		#endregion

		#region Content

		internal ContentView ContentView = null;
		internal void SetContentCorner(Point pt)
		{
			Size szNew = new Size(pt);
			if (szNew.Width < HeaderSize.Width) szNew.Width = HeaderSize.Width;
			if (Size == szNew) return;
			Size = szNew;
			ItemList.ChangedItemHeight(this, szNew.Height - Size.Height);
		}

		#endregion

		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			Debug.WriteLine($"Paint Items[{Index}]  clip={clip}, client={client}");

			Control panel = ItemList.Control;
			Size szD = new Size(client.Width, HeaderSize.Height);

			XMLTreeListPanel.Painter.Draw(g, panel.Font,
				Element.DisplayName, client.Location, szD,
				panel.ForeColor, panel.BackColor);

			if (ContentView == null) return;
			if (!ContentView.IsOpen) return;

			clip.Height -= HeaderSize.Height;

			client.X += 12; client.Width -= 12;

			client.Y += HeaderSize.Height;
			client.Height -= HeaderSize.Height;

			ContentView.ListView.Paint(g, clip, client);
		}

		internal Target TargetFromPoint(Point pt)
		{
			//Debug.WriteLine($"TargeFromPoint, Item={Index}, Point={pt}");

			Rectangle r = Rectangle.Empty;
			r.Height = HeaderSize.Height;
			r.Width = HeaderSize.Width;

			if (r.Contains(pt))
			{
				r.Width = 10;

				if (r.Contains(pt))
					return new Target(this, "Button", r);

				r.Offset(r.Width, 0);
				r.Width = Size.Width - r.Left;
				return new Target(this, "Text", r);
			}
			r = new Rectangle(Point.Empty, Size);

			if (ContentView == null) return new Target(this, "#", r);
			if (!ContentView.IsOpen) return new Target(this, "#", r);

			r.Offset(12, HeaderSize.Height);
			r.Size -= new Size(12, HeaderSize.Height);

			if (!r.Contains(pt)) return new Target(this, "|", r);

			pt -= new Size(r.Location);
			Target target = ContentView.ListView.TargetFromPoint(pt);
			if (target == null) return null;
			target.rect.Offset(12, HeaderSize.Height);
			return target;
		}

		internal void Click(Target target)
		{
			Debug.WriteLine($"clicked [{Element.DisplayName}] item={target.item.Index}, rect={target.rect}, part={target.part}");

			if (target.part.ToString() == "Button")
			{
				if (ContentView == null)
					ContentView = new ContentView(this, new Point(16, HeaderSize.Height));

				if (ContentView.IsOpen) ContentView.Close();
				else ContentView.Open();

				TopTreeListPanel.Invalidate(true);
			}
		}
	}
}
