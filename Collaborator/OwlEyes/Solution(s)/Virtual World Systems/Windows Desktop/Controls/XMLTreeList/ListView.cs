using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class ListView : IDisposable
	{
		#region misc
		public ListView(Control control, Element element)
		{
			Control = control;
			Element = element;
			ContentView = null;
			CreateItemList();
			ComputeSize();
		}
		internal ListView Delete() { Dispose(); return null; }
		public void Dispose() { }

		internal Control Control { get; private set; }
		internal Element Element { get; private set; }

		#endregion

		#region Sizing
		internal Size Size { get; private set; }
		internal void ComputeSize()
		{
			Size = Items.Size;
		}
		internal void ChangedItemHeight(ItemView itemView, int cy)
		{
			ComputeSize();
			if (ContentView != null) ContentView.UpdateSize();
			else ((XMLTreeListPanel)Control).SetListSize(Size);
		}
		internal (int, ItemView) FindItemFromY(int yT)
		{
			int Y = 0, N;
			ItemView item = null;

			foreach (ItemView i in Items)
			{
				N = Y + i.Height;
				if (N > yT) { item = i; break; }
				Y = N;
			}
			return (Y, item);
		}
		#endregion

		#region Container
		public ListView(ContentView ContentView)
			: this(ContentView.ItemView.Panel, ContentView.ItemView.Element)
		{
			this.ContentView = ContentView;
		}
		internal ContentView ContentView { get; private set; } = null;

		#endregion

		#region Items
		internal class ItemList : List<ItemView>
		{
			internal ItemList() : base() { }
			internal Size Size
			{
				get
				{
					Size szT = Size.Empty, sz;

					foreach (ItemView item in this)
					{
						sz = item.Size;
						szT.Width = Math.Max(szT.Width, sz.Width);
						szT.Height += sz.Height;
					}
					//Debug.WriteLine($"ItemList.Size = {szT}");
					return szT;
				}
			}
		}
		internal ItemList Items = new ItemList();
		internal void CreateItemList()
		{
			Items.Clear();
			int index = 0;
			ItemView item;

			using (Graphics g = Control.CreateGraphics())
			{
				foreach (Element child in Element.SelectElements("*"))
				{
					Items.Add(item = new ItemView(this, child, index++));
					item.ComputeHeaderSize((XMLTreeListPanel)Control, g);
				}
			}
		}

		#endregion

		#region Targetting
		(int, ItemView) ItemFromPoint(Point pt)
		{
			int i = -1; int Y = 0;
			ItemView item = null;

			while (++i < Items.Count)
			{
				item = Items[i];

				if ((Y + item.Height) > pt.Y) break;

				Y += item.Height;
				item = null;
			}
			//if (item != null) Debug.WriteLine($"ItemFromPoint {item.Element.DisplayName}");
			return (Y, item);
		}

		internal Target TargetFromPoint(Point pt)
		{
			(int Y, ItemView item) = ItemFromPoint(pt);

			if (item == null) return null;
			pt.Y -= Y;
			Target Target = item.TargetFromPoint(pt);
			if (Target == null) return null;
			Target.rect.Offset(0, Y);
			return Target;
		}

		#endregion
		
		#region Painting
		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			Debug.WriteLine($"{RT.S}>> List.Paint: client={client}, clip={clip}");

			(int Y, ItemView item) = FindItemFromY(clip.Top);
			if (item == null) return;

			for (int i = item.Index; i < Items.Count; i++)
			{
				if (Y >= clip.Bottom) break;

				item = Items[i];

				Rectangle r = client;
				r.Y += Y; r.Height = item.Height;

				item.Paint(g, r);

				Y += item.Height;
			}
		}
		internal void Paint(Graphics g, Rectangle client)
		{
			using (RT.I I = RT.IN)
			{
				Debug.WriteLine($"{RT.S}List.Paint: client={client}");

				int Y = 0;
				ItemView item;

				for (int i = 0; i < Items.Count; i++)
				{
					item = Items[i];

					Rectangle r = client;
					r.Y += Y; r.Height = item.Height;

					item.Paint(g, r);

					Y += item.Height;
				}
			}
		}

		#endregion
	}
}
