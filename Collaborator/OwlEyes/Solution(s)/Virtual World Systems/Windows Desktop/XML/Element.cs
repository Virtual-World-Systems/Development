using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XML;

namespace XML
{
	public class Element : XmlElement
	{
		#region miscellaneous
		public Element(string prefix, string localName, string namespaceURI, Document doc)
			: base(prefix, localName, namespaceURI, doc) { }

		public Element() : base(null, "_", null, Document.Instance) { }

		public Document Document { get { return (Document)OwnerDocument; } }
		public Element Root { get { return Document.Root; } }
		public Element Parent { get { return (Element) ParentNode; } }

		public static Element @new(string name) { return Document.Instance.CreateElement(name); }

		public XmlNodeList SelectElements(string selector)
		{
			return SelectNodes(selector, Document.NamespaceManager);
		}
		public Element SelectElement(string selector)
		{
			return (Element)SelectSingleNode(selector, Document.NamespaceManager);
		}

		public XmlNodeList SelectAttributes(string selector)
		{
			return SelectNodes(selector, Document.NamespaceManager);
		}
		public Attribute SelectAttribute(string selector)
		{
			return (Attribute)SelectSingleNode(selector, Document.NamespaceManager);
		}

		public void WriteFile(string path)
		{
			Debug.WriteLine("**** writing XML to " + path);
			int o = path.LastIndexOf('/');
			if (o == -1) o = path.LastIndexOf('\\');
			string p0 = path.Substring(0, o);
			if (!Directory.Exists(p0)) { Directory.CreateDirectory(p0); }

			XmlWriterSettings s = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = true
			};

			using (FileStream sr = new FileStream(path, FileMode.Create))
			{
				using (XmlWriter rdr = XmlWriter.Create(sr, s))
					WriteTo(rdr);
			}
		}
		public void WriteTo(StringBuilder sb)
		{
			XmlWriterSettings s = new XmlWriterSettings()
			{
				Indent = true,
				IndentChars = "\t",
				OmitXmlDeclaration = true
			};
			StringWriter sw = new StringWriter(sb);

			using (XmlWriter wr = XmlWriter.Create(sw, s))
			{
				WriteTo(wr);
			}
		}

		#endregion
	}
}
