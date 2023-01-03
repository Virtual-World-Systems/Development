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

			if (ContentView != null)
				ContentView.ItemView.SetContentCorner(ContentView.Offset + Size);
			else
				((XMLTreeListPanel)Control).SetListSize(Size);
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
				foreach (Element child in Element.ChildNodes)
				{
					Items.Add(item = new ItemView(this, child, index++));
					item.ComputeSize((XMLTreeListPanel)Control, g);
				}
			}
		}

		#endregion
		
		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			Debug.WriteLine($"Paint ItemList clip={clip}, client={client}");

			(int Y, ItemView item) = ItemFromPoint(clip.Location);
			clip.Height -= Y; if (clip.Height < 0) clip.Height = 0;

			if (item == null) return;

			using (Brush b = new SolidBrush(Control.ForeColor))
			{
				int i = item.Index;

				while (clip.Height > 0)
				{
					Rectangle r = client;
					r.Y += Y; r.Height = item.Height;

					item.Paint(g, clip, r);

					Y += item.Height;

					clip.Height -= item.Height;
					if (clip.Height < 0) break;

					if ((i + 1) >= Items.Count) break;
					item = Items[++i];
				}
			}
		}

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
	}
}
