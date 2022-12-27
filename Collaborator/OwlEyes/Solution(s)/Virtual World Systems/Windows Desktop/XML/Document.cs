using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VWS.WindowsDesktop;

namespace XML
{
	public class Document : XmlDocument
	{
		internal class _NamespaceManager : XmlNamespaceManager
		{
			internal protected _NamespaceManager(Document doc)
				: base(doc.NameTable)
			{
				Document = doc;
			}
			internal Document Document { get; private set; }
		}

		static internal Document Instance { get; private set; }
		public Document()
		{
			Instance = this;
			try
			{
				VWSNS = "https://Virtual-World-Systems.net";
				NamespaceManager = new _NamespaceManager(this);
				NamespaceManager.AddNamespace("VWS", VWSNS);
				AppendChild(new Element(null, "_", null, this));
			}
			catch (Exception ex)
			{
				Program.Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
		internal string VWSNS { get; }
		internal _NamespaceManager NamespaceManager { get; set; }

		public new Element DocumentElement { get { return (Element)base.DocumentElement; } }
		public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
		{
			return new Element(prefix, localName, namespaceURI, this);
		}
		public new Element CreateElement(string name)
		{
			return (Element)CreateElement(null, name, null);
		}

		public Element ReadFile(string path)
		{
			XmlReaderSettings s = new XmlReaderSettings() { NameTable = NameTable };

			Element e = null;

			using (FileStream sr = new FileStream(path, FileMode.OpenOrCreate))
			{
				using (XmlReader rdr = XmlReader.Create(sr, s))
				{
					e = (Element)Program.XML.ReadNode(rdr);
				}
				if (e == null) return null;
			}
			return e;
		}
	}

	public class Element : XmlElement
	{
		public Element(string prefix, string localName, string namespaceURI, Document doc)
			: base(prefix, localName, namespaceURI, doc) {}

		public new Document OwnerDocument => (Document)base.OwnerDocument;
		public XmlNodeList SelectElements(string selector)
		{
			return SelectNodes(selector, OwnerDocument.NamespaceManager);
		}
		public Element SelectElement(string selector)
		{
			return (Element)SelectSingleNode(selector, OwnerDocument.NamespaceManager);
		}

		public void WriteFile(string path)
		{
			Debug.WriteLine("**** writing XML to " + path);
			int o = path.LastIndexOf('/');
			if (o == -1) o = path.LastIndexOf('\\');
			string p0 = path.Substring(0, o);
			if (!Directory.Exists(p0)) { Directory.CreateDirectory(p0); }

			XmlWriterSettings s = new XmlWriterSettings() {
				Indent = true, IndentChars = "\t", OmitXmlDeclaration = true };

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

			using(XmlWriter wr = XmlWriter.Create(sw, s))
			{
				WriteTo(wr);
			}
		}
	}
}
