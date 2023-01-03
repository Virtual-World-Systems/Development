using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	internal class ContentView
	{
		internal ContentView(ItemView itemView, Point offset)
		{
			Offset = offset;
			ItemView = itemView;
		}
		internal Point Offset;
		internal ItemView ItemView = null;
		internal ListView ListView = null;
		internal bool IsOpen
		{
			get => isOpen;
			set
			{
				if (isOpen == value) return;
				isOpen = value;
				VerifyListView();
				if (!IsOpen) ItemView.SetContentCorner(Offset);
				else ItemView.SetContentCorner(Offset + ListView.Size);
			}
		}
		bool isOpen;

		void VerifyListView()
		{
			if (ListView != null) return;
			ListView = new ListView(this);
		}

		internal void Open() { IsOpen = true; }
		internal void Close() { IsOpen = false; }
	}
}
