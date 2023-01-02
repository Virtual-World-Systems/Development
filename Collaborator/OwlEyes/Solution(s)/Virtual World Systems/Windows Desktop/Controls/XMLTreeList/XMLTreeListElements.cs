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
	internal class XMLTreeListElements : IDisposable
	{
		public XMLTreeListElements(Control control, Element element)
		{
			Control = control;
			Element = element;
			Size = Measure();
		}
		internal Control Control { get; private set; }
		internal Element Element { get; private set; }
		
		internal Size Size { get; private set; }
		internal Size Measure()
		{
			using (Graphics g = Control.CreateGraphics())
			{
				Items.Clear();

				Size sz = Size.Empty, sz0; XMLTreeListItem item;

				for (int i = 0; i < Element.ChildNodes.Count; i++)
				{
					Items.Add(item = new XMLTreeListItem((XMLTreeListPanel)Control,
						(Element)Element.ChildNodes[i], i));
					sz0 = item.MeasureClosed((XMLTreeListPanel)Control, g);
					sz.Height += sz0.Height;
					sz.Width = Math.Max(sz0.Width, sz.Width);
				}
				Size = sz;
			}
			return Size;
		}
		internal class ItemList : List<XMLTreeListItem>
		{
			internal ItemList(Point origin) : base() { Origin = origin; }
			internal Point Origin { get; set; }
			internal Size Size
			{
				get
				{
					Size szT = Size.Empty, sz;

					foreach (XMLTreeListItem item in this)
					{
						sz = item.Size;
						szT.Width = Math.Max(szT.Width, sz.Width);
						szT.Height += sz.Height;
					}
					Debug.WriteLine($"ItemList.Size = {szT}");
					return szT;
				}
			}
		}
		internal ItemList Items = new ItemList(new Point(0, 0));

		internal XMLTreeListElements Delete() { Dispose(); return null; }
		public void Dispose() {}

		internal void Paint(Graphics g, Rectangle clip, Rectangle client)
		{
			using (Brush b = new SolidBrush(Control.ForeColor))
			{
				int i = -1; XMLTreeListItem item;
				int Y = 0;

				while (++i < Items.Count)
				{
					item = Items[i];

					if ((Y + item.Height) <= clip.Top)
					{
						Y += item.Height;
						continue;
					}
					while (Y < clip.Bottom)
					{
						Rectangle r = client;
						r.Y += Y; r.Height = item.Height;
						item.Draw((XMLTreeListPanel)Control, g, r.Location, r.Size);
						Y += item.Height;
						if ((i + 1) >= Items.Count) break;
						item = Items[++i];
					}
					break;
				}
			}
		}
			}
		}
