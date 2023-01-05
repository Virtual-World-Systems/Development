using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class ContentView
	{
		#region misc
		internal ContentView(ItemView itemView, Point offset)
		{
			Offset = offset;
			ItemView = itemView;
		}
		internal Point Offset;
		internal ItemView ItemView = null;

		ListView MetaView = null, AttributesView = null, ChildElementsView = null, ObjectView = null;

		internal Size Size
		{
			get
			{
				Size sz = Size.Empty;
				//if (MetaView == null) return sz;
				sz = IncludeSize(sz, _osMeta, MetaView);
				sz = IncludeSize(sz, _osAttributes, AttributesView);
				sz = IncludeSize(sz, _osChildElements, ChildElementsView);
				sz = IncludeSize(sz, _osObject, ObjectView);
				return sz;
			}
		}
		Size IncludeSize(Size sz, bool isOpen, ListView v)
		{
			if (!isOpen) return sz;
			if (v.Size.Width > sz.Width) sz.Width = v.Size.Width;
			sz.Height += v.Size.Height;
			return sz;
		}
		internal void UpdateSize() { ItemView.SetContentCorner(Offset + Size); }

		#endregion

		internal Target TargetFromPoint(Point pt)
		{
			Target target = null;
			if (_osMeta) { if ((target = MetaView.TargetFromPoint(pt)) != null) return target; pt.Y -= MetaView.Size.Height; }
			if (_osAttributes) { if ((target = AttributesView.TargetFromPoint(pt)) != null) return target; pt.Y -= AttributesView.Size.Height; }
			if (_osChildElements) { if ((target = ChildElementsView.TargetFromPoint(pt)) != null) return target; pt.Y -= ChildElementsView.Size.Height; }
			if (_osObject) { if ((target = ObjectView.TargetFromPoint(pt)) != null) return target; pt.Y -= ObjectView.Size.Height; }
			return null;
		}

		#region OpenState
		bool _osMeta = false; public bool OpenState_Meta { get => _osMeta; set { _set(ref _osMeta, value, ref MetaView); } }
		bool _osAttributes = false; public bool OpenState_Attributes { get => _osAttributes; set { _set(ref _osAttributes, value, ref AttributesView); } }
		bool _osChildElements = false; public bool OpenState_ChildElements { get => _osChildElements; set { _set(ref _osChildElements, value, ref ChildElementsView); } }
		bool _osObject = false; public bool OpenState_Object { get => _osObject; set { _set(ref _osObject, value, ref ObjectView); } }

		void _set(ref bool oldState, bool newState, ref ListView partView)
		{
			if (oldState == newState) return;
			if (newState && (partView == null)) { partView = new ListView(this); }
			oldState = newState;
			if (!IsOpen) ItemView.SetContentCorner(new Point(ItemView.HeaderSize));
			else ItemView.SetContentCorner(Offset + Size);
		}
		internal bool IsOpen { get => _osMeta || _osAttributes || _osChildElements || _osObject; }

		#endregion

		internal void Paint(Graphics g, Rectangle client)
		{
			if (_osMeta) { MetaView.Paint(g, client); client.Y += MetaView.Size.Height; client.Height += MetaView.Size.Height; }
			if (_osAttributes) { AttributesView.Paint(g, client); client.Y += AttributesView.Size.Height; client.Height += AttributesView.Size.Height; }
			if (_osChildElements) { ChildElementsView.Paint(g, client); client.Y += ChildElementsView.Size.Height; client.Height += ChildElementsView.Size.Height; }
			if (_osObject) { ObjectView.Paint(g, client); client.Y += ObjectView.Size.Height; client.Height += ObjectView.Size.Height; }
		}
	}
}
