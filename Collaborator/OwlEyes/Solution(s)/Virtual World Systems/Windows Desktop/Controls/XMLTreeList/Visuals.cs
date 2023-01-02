using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML;

namespace VWS.WindowsDesktop.Controls.XMLTreeList.Visual
{
	internal abstract class Visual
	{
		internal delegate object M(object Argument);

		internal Visual(M MethodInfo, object Argument)
		{
			this.Argument = Argument;
			this.MethodInfo = MethodInfo;
		}
		internal M MethodInfo;
		internal object Argument;
		internal Size Size = Size.Empty;

		internal abstract Size Measure(Graphics g, Font f = null);
		internal abstract void Draw(Graphics g,
			Rectangle r, Font f = null, Color? ct = null, Color? cb = null);

		internal static Visual From<T>(M MethodInfo, object Argument)
		{
			if (typeof(T) == typeof(string)) return new String(MethodInfo, Argument);
			if (typeof(T) == typeof(System.Drawing.Image)) return new Image(MethodInfo, Argument);
			return null;
		}
		internal static Visual From(Image Image, M MethodInfo, object Argument)
		{ return new Image(MethodInfo, Argument); }
	}

	internal class String : Visual
	{
		internal String(M MethodInfo, object Argument) : base(MethodInfo, Argument) {}

		string GetString()
		{
			return (string) MethodInfo(Argument);
		}
		internal override Size Measure(Graphics g, Font f = null)
		{
			if (Size != Size.Empty) return Size;
			return (Size = Helper.MeasureRenderStringSize(g, f, GetString()));
		}
		internal override void Draw(Graphics g, Rectangle r, Font f, Color? ct, Color? cb)
		{
			Helper.DrawRenderString(g, GetString(), r, f,
				ct ?? Color.Black, cb ?? Color.Transparent);
		}
	}
	internal class Image : Visual
	{
		internal Image(M MethodInfo, object Argument)
			: base(MethodInfo, Argument) { }

		System.Drawing.Image GetImage()
		{
			return (System.Drawing.Image) MethodInfo(Argument);
		}
		internal override Size Measure(Graphics g, Font f)
		{
			if (Size != Size.Empty) return Size;
			return (Size = GetImage().Size);
		}
		internal override void Draw(Graphics g, Rectangle r, Font f, Color? ct, Color? cb)
		{
			g.DrawImage(GetImage(), r);
		}
	}
}
