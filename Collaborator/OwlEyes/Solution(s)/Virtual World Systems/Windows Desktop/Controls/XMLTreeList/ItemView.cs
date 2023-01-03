using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

		int ContentIndent { get => 12; }
		internal Size ComputeHeaderSize(XMLTreeListPanel panel, Graphics g)
		{
			return (Size = (HeaderSize = XMLTreeListPanel.Painter.
				Measure(g, panel.Font, Element.DisplayName)));
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

			Rectangle r = Rectangle.Empty;
			r.Height = HeaderSize.Height;
			r.Width = HeaderSize.Width;

			if (r.Contains(pt))
			{
				r.Width = 10;

				if (r.Contains(pt))
					return new Target(this, "Button", r);

				r.Offset(r.Width, 0);
				r.Width = HeaderSize.Width - r.Left;
				return new Target(this, "Text", r);
			}
			if (pt.Y < HeaderSize.Height)
				return new Target(this, "^", r);

			r = new Rectangle(Point.Empty, Size);

			if ((ContentView == null) || (!ContentView.IsOpen))
				return new Target(this, "^", r);

			r = new Rectangle(
				new Point(ContentIndent, HeaderSize.Height),
				ContentView.ListView.Size);

			if (pt.X < r.Left)
				return new Target(this, "|", r);

			pt -= new Size(r.Location);

			Target target = ContentView.ListView.TargetFromPoint(pt);

			if (target == null)
				return new Target(this, "|", r);

			target.rect.Offset(ContentIndent, HeaderSize.Height);
			return target;
		}
		internal void Click(Target target)
		{
			Debug.WriteLine($"clicked [{Element.DisplayName}] item={target.item.Index}, rect={target.rect}, part={target.part}");

			if (target.part.ToString() == "Button")
			{
				if (ContentView == null)
					ContentView = new ContentView(this,
						new Point(ContentIndent, HeaderSize.Height));

				if (ContentView.IsOpen) ContentView.Close();
				else ContentView.Open();

				TopTreeListPanel.Invalidate(true);
			}
		}

		#endregion

		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			//Debug.WriteLine($"Paint Items[{Index}]  clip={clip}, client={client}");

			Control panel = ItemList.Control;
			Size szD = new Size(client.Width, HeaderSize.Height);

			XMLTreeListPanel.Painter.Draw(g, panel.Font,
				Element.DisplayName, client.Location, szD,
				panel.ForeColor, panel.BackColor);

			if (ContentView == null) return;
			if (!ContentView.IsOpen) return;

			clip.Height -= HeaderSize.Height;

			client.X += ContentIndent;
			client.Width -= ContentIndent;

			client.Y += HeaderSize.Height;
			client.Height -= HeaderSize.Height;

			ContentView.ListView.Paint(g, clip, client);
		}
	}
}
