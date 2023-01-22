using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VWS.WindowsDesktop.RT;

namespace VWS.WindowsDesktop.Controls.old
{
	public partial class V33 : UserControl
	{
		public V33()
		{
			InitializeComponent();
		}

		//public class Navigator
		//{
		//	internal Navigator(V33 V33)
		//	{
		//		this.V33 = V33;
		//	}
		//	V33 V33;
		//}

		ScrollRect ScrollRect { get { return (Parent == null) ? null : (ScrollRect)Parent; } }

		Rectangle oldBounds = Rectangle.Empty;

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);
			if (ScrollRect == null) return;
			if (Bounds == oldBounds) return;
			VerifyMinSizes();
			DoLayout((oldBounds = Bounds).Size);
			Invalidate();
		}

		void VerifyMinSizes()
		{
			if (minSizes != null) return;

			Size sz = Size.Empty;
			minSizes = new Size[5];

			using (Graphics g = CreateGraphics())
				for (int i = 0; i < 5; i++) sz += (minSizes[i] = MeasureMin(g, i, i));

			minSize = sz;
		}
		Size minSize = Size.Empty;

		Size MeasureMin(Graphics g, int x, int y)
		{
			minSizes[0] = new Size(24, 24); fixedX[0] = false; fixedY[0] = false;
			minSizes[1] = new Size(5, 20); fixedX[1] = true; fixedY[1] = true;
			minSizes[2] = new Size(24, 24); fixedX[2] = false; fixedY[2] = false;
			minSizes[3] = new Size(8, 9); fixedX[3] = true; fixedY[3] = true;
			minSizes[4] = new Size(24, 24); fixedX[4] = false; fixedY[4] = false;
			Size sz = Size.Empty;
			for (int i = 0; i < 5; i++) sz += minSizes[i];
			return sz;
		}

		class SizedObject { internal SizedObject(object o) { O = o; } internal object O; internal Size Size = Size.Empty; }

		SizedObject[] oo = new SizedObject[25];

		Size[] minSizes = null;
		bool[] fixedX = new bool[5];
		bool[] fixedY = new bool[5];


		void DoLayout(Size sz)
		{
			List<int> vX = new List<int>();
			int szX = 0; for (int i = 0; i < 5; i++) { szX += minSizes[i].Width; if (!fixedX[i]) vX.Add(i); }
			if (vX.Count == 0) vX.Add(2);

			List<int> vY = new List<int>();
			int szY = 0; for (int i = 0; i < 5; i++) { szY += minSizes[i].Height; if (!fixedY[i]) vY.Add(i); }
			if (vY.Count == 0) vY.Add(2);
		}

		//Size NegSize = new Size(-1, -1);

		//Size MeasureMin(Graphics g)
		//{
		//	Rectangle r = Rectangle.Empty;
		//	if ((sizes == null) || (sizes.Count == 0))
		//		sizes = new List<Size>() { NegSize, new Size(7, 7), NegSize, new Size(7, 7), NegSize };
		//	for (int i = 0; i < 5; i++) r = MeasureMin(g, new Point(i, i), r);
		//	return new Size(r.Width, r.Height);
		//}

		//Rectangle MeasureMin(Graphics g, Point pt, Rectangle r)
		//{
		//	Size sz = new Size(sizes[pt.X].Width, sizes[pt.Y].Height);
		//	if (sz.Width == -1) sz.Width = 24;
		//	if (sz.Height == -1) sz.Height = 24;
		//	foreach ((int x, int y) in Upper()
		//	return Rectangle.Empty;
		//}

		//Size MeasuerOne()
		//{
		//	//Debug.WriteLine($"Layout {e.AffectedComponent} {e.AffectedControl} {e.AffectedProperty} {Bounds}");

		//	Size szSLT = new Size(5, 20);
		//	Size szSRB = new Size(8, 9);
		//	Size szPTotal = Size - szSLT - szSRB;
		//	Size szPLT = new Size(szPTotal.Width / 3, szPTotal.Height / 3);
		//	Size szPRB = new Size(szPTotal.Width / 3, szPTotal.Height / 3);
		//	Size szPCC = szPTotal - szPLT - szPRB;
		//	sizes = new List<Size>() { szPLT, szSLT, szPCC, szSRB, szPRB };
		//	Rectangle r = Rectangle.Empty, r1, r2;

		//	////Debug.WriteLine($"{sizes[0]} {sizes[1]} {sizes[2]} {sizes[3]} {sizes[4]}");
		//	//using (Graphics g = CreateGraphics())
		//	//	for (int i = 0; i < 5; i++)
		//	//		r = MeasureMin(g, i, i, r);


		//	//{
		//	//	r.Size = szPLT; r = Measure(e, r, 0); r1 = r; r1.Size = szSLT;
		//	//	r.Size = szSLT; r = Measure(e, r, 1);
		//	//	r.Size = szPCC; r = Measure(e, r, 2); r2 = r; r2.Size = szSRB;
		//	//	r.Size = szSRB; r = Measure(e, r, 3);
		//	//	r.Size = szPRB; r = Measure(e, r, 4);
		//	//}
		//	rects.Clear();
		//	r = r1; rects.Add(r); r.X = r2.X; r.Width = r2.Width; rects.Add(r); rects.Add(r);
		//	r = r2; rects.Add(r); r.X = r1.X; r.Width = r1.Width; rects[2] = r;
		//}

		private void V33_Paint(object sender, PaintEventArgs e)
		{
			foreach (ObjectRectangle orc in ObjectRectangles)
				if (orc.Rectangle_at(offsetsX, offsetsY).IntersectsWith(e.ClipRectangle))
					orc.Paint(e.Graphics);
			_Paint(sender, e);
		}

		IEnumerable<ObjectRectangle> ObjectRectangles
		{
			get
			{
				yield return new ObjectRectangle(null);
			}
		}

		int[] offsetsX = new int[5];
		int[] offsetsY = new int[5];

		class ObjectRectangle
		{
			internal ObjectRectangle(object o)
			{
				Object = o;
			}
			internal object Object;

			internal Size Size = Size.Empty;
			internal Rectangle Rectangle_at(int[] offsetsX, int[] offsetsY) { return new Rectangle(Offset, Size); }
			internal Point Offset = Point.Empty;

			internal void Paint(Graphics g) { }
		}

		//object[] objects = new object[]
		//{
		//	ColorRect.Default_R, DragBar.Default_LT_, ColorRect.Default_G, DragBar.Default_RT_, ColorRect.Default_B,
		//	DragBar.Default_TL_, DragBar.Default_TL0, DragBar.Default_TC_, DragBar.Default_TR0, DragBar.Default_TR_,
		//	ColorRect.Default_B, DragBar.Default_LT_, ColorRect.Default_G, DragBar.Default_RT_, ColorRect.Default_B,
		//};

		private void _Paint(object sender, PaintEventArgs e)
		{
			Size szSLT = new Size(5, 20);
			Size szSRB = new Size(8, 9);
			Size szPTotal = Size - szSLT - szSRB;
			Size szPLT = new Size(szPTotal.Width / 3, szPTotal.Height / 3);
			Size szPRB = new Size(szPTotal.Width / 3, szPTotal.Height / 3);
			Size szPCC = szPTotal - szPLT - szPRB;
			sizes = new List<Size>() { szPLT, szSLT, szPCC, szSRB, szPRB };
			Rectangle r = Rectangle.Empty, r1, r2;

			//Debug.WriteLine($"{sizes[0]} {sizes[1]} {sizes[2]} {sizes[3]} {sizes[4]}");
			r.Size = szPLT; r = PaintP(e, r, 0); r1 = r; r1.Size = szSLT;
			r.Size = szSLT; r = PaintS(e, r, 1);
			r.Size = szPCC; r = PaintP(e, r, 2); r2 = r; r2.Size = szSRB;
			r.Size = szSRB; r = PaintS(e, r, 3);
			r.Size = szPRB; r = PaintP(e, r, 4);

			rects.Clear();
			r = r1; rects.Add(r); r.X = r2.X; r.Width = r2.Width; rects.Add(r); rects.Add(r);
			r = r2; rects.Add(r); r.X = r1.X; r.Width = r1.Width; rects[2] = r;

			if (ScrollRect != null) ScrollRect.AutoScrollMinSize = new Size(320, 200);
			//ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.RaisedInner);
		}
		List<Size> sizes = new List<Size>();
		List<Rectangle> rects = new List<Rectangle>();

		Rectangle PaintP(PaintEventArgs e, Rectangle r, int index)
		{
			int cR = 255, cG = 250, cB = 250;
			using (Brush b = new SolidBrush(Color.FromArgb(cR, cG, cB))) { e.Graphics.FillRectangle(b, r); }
			//Debug.WriteLine($"Paint P {r}");

			int c;
			Rectangle rV = r;

			for (int i = index - 1; i >= 0; i--)
			{
				rV.Offset(0, -sizes[i].Height);
				rV.Height = sizes[i].Height;

				if ((i & 1) != 0) continue;

				c = cB; cB = cG; cG = cR; cR = c;
				using (Brush b = new SolidBrush(Color.FromArgb(cR, cG, cB))) e.Graphics.FillRectangle(b, rV);
				//Debug.WriteLine($"Paint Pv {i} {rV}");
			}
			rV = r;
			cR = 255; cG = 250; cB = 250;

			for (int i = index - 1; i >= 0; i--)
			{
				rV.Offset(-sizes[i].Width, 0);
				rV.Width = sizes[i].Width;

				if ((i & 1) != 0) continue;

				c = cB; cB = cG; cG = cR; cR = c;
				using (Brush b = new SolidBrush(Color.FromArgb(cR, cG, cB))) e.Graphics.FillRectangle(b, rV);
				//Debug.WriteLine($"Paint Ph {i} {rV}");
			}
			r.Offset(new Point(r.Size));
			return r;
		}

		Rectangle PaintS(PaintEventArgs e, Rectangle r, int index)
		{
			Rectangle rV;
			Brush b = SystemBrushes.Control;

			rV = r; rV.Y = 0;
			Border3DSide bs = Border3DSide.Left | Border3DSide.Right;

			for (int i = 0; i < 5; i++)
			{
				rV.Height = sizes[i].Height;
				switch (i)
				{
					case 0:
					case 2:
					case 4:
						ControlPaint.DrawBorder3D(e.Graphics, rV, Border3DStyle.RaisedInner, bs);
						rV.Inflate(-1, 0); e.Graphics.FillRectangle(b, rV); rV.Inflate(1, 0);
						break;
					case 1:
					case 3:
						e.Graphics.FillRectangle(b, rV);
						break;
				}
				rV.Offset(0, rV.Height);
			}
			rV = r; rV.X = 0;
			bs = Border3DSide.Top | Border3DSide.Bottom;

			for (int i = 0; i < 5; i++)
			{
				rV.Width = sizes[i].Width;
				switch (i)
				{
					case 0:
					case 2:
					case 4:
						ControlPaint.DrawBorder3D(e.Graphics, rV, Border3DStyle.RaisedInner, bs);
						rV.Inflate(0, -1); e.Graphics.FillRectangle(b, rV); rV.Inflate(0, 1);
						break;
				}
				rV.Offset(rV.Width, 0);
			}
			r.Offset(new Point(r.Size));
			return r;
		}

		bool dragging = false;
		Point ptTarget = new Point(-1, -1);

		private void V33_MouseMove(object sender, MouseEventArgs e)
		{
			if (rects == null) return;
			if (rects.Count == 0) return;
			if (dragging)
			{
				Size szDif = new Size(MousePosition) - new Size(ptStart);
				if (ptTarget.X == -1) szDif.Width = 0;
				if (ptTarget.Y == -1) szDif.Height = 0;

				return;
			}
			Debug.WriteLine($"MouseMove {rects[0]} {rects[1]} {rects[2]} {rects[3]}");
			Rectangle r; ptTarget = Point.Empty;
			Point pt = PointToClient(MousePosition);

			r = rects[0]; if ((pt.X >= r.X) && (pt.X < r.Right)) ptTarget.X = -1;
			r = rects[1]; if ((pt.X >= r.X) && (pt.X < r.Right)) ptTarget.X = 1;
			r = rects[0]; if ((pt.Y >= r.Y) && (pt.Y < r.Bottom)) ptTarget.Y = -1;
			r = rects[2]; if ((pt.Y >= r.Y) && (pt.Y < r.Bottom)) ptTarget.Y = 1;

			if ((ptTarget.X != 0) && (ptTarget.Y != 0)) Cursor = Cursors.SizeAll;
			else if (ptTarget.X != 0) Cursor = Cursors.VSplit;
			else if (ptTarget.Y != 0) Cursor = Cursors.HSplit;
			else Cursor = Cursors.Default;
		}

		private void V33_MouseDown(object sender, MouseEventArgs e)
		{
			Capture = true;
			dragging = true;
			ptStart = MousePosition;
		}
		Point ptStart = Point.Empty;

		private void V33_MouseUp(object sender, MouseEventArgs e)
		{
			dragging = false;
			Capture = false;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}
	}
}
