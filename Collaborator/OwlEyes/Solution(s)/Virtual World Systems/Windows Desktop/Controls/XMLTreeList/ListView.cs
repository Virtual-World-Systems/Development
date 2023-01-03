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
		public ListView(Control control, Element element)
		{
			Control = control;
			Element = element;
			CreateItemList();
			ComputeSize();
		}
		internal Control Control { get; private set; }
		internal Element Element { get; private set; }

		internal Size Size { get; private set; }
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
		internal void ComputeSize()
		{
			Size = Items.Size;
		}
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

		internal ListView Delete() { Dispose(); return null; }
		public void Dispose() {}

		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			using (Brush b = new SolidBrush(Control.ForeColor))
			{
				(int Y, ItemView item) = ItemFromPoint(clip.Location);
				int i = item.Index;
				while (Y < clip.Bottom)
				{
					Rectangle r = client;
					r.Y += Y; r.Height = item.Height;
					item.Draw((XMLTreeListPanel)Control, g, r.Location, r.Size);
					Y += item.Height;
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

		internal Target TargetFromMouse(Point pt)
		{
			(int Y, ItemView item) = ItemFromPoint(pt);

			if (item == null) return null;
			pt.Y -= Y;
			Target Target = item.TargetFromPoint(pt);
			if (Target == null) return null;
			Target.rect.Offset(0, Y);
			return Target;
		}


		internal void Place(XMLTreeListPanel cp, ItemView item, Point pt)
		{
			Size sz = Size.Empty, sz0 = Size.Empty;

			for (int i = 0; i < Items.Count; i++)
			{
				ItemView ti = Items[i];
				if (ti == item) sz0 = sz;
				sz.Height += ti.Height;
				sz.Width = Math.Max(sz.Width, ti.Width);
			}
			Size = sz;
			((XMLTreeListPanel)Control).Place(cp, pt + new Size(0, sz0.Height));
		}

		internal void ItemSizeChanged(ItemView item, Size oldItemSize, Size newItemSize)
		{
			Size oldSize = Size;
			Size newSize = new Size(
				Math.Max(Size.Width, newItemSize.Width),
				Size.Height + newItemSize.Height - oldItemSize.Height);
			Size = newSize;


			//for (int i = item.Index + 1; i < Items.Count; i++)
			//	Items[i].MoveVertically(newSize.Height - oldSize.Height);

			//Control.ChangeHeight(cy);
		}
	}
}
