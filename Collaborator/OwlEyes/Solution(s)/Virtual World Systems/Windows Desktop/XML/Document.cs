using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VWS.WindowsDesktop;
using VWS.ObjectModel;

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
				NSM = new _NamespaceManager(this);
				NSM.AddNamespace("_", VWSNS);
				AppendChild(new Element(null, "_", null, this));
				orphans = Orphans; orphaning.Push(true);

			}
			catch (Exception ex)
			{
				Program.Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
		public Element Orphans
		{
			get
			{
				if (orphans == null)
					Root.PrependChild(orphans = (Element)CreateElement("orphans", "_", "orphans"));
				return orphans;
			}
		}
		Element orphans = null;
		Stack<bool> orphaning = new Stack<bool>();
		bool isOrphaning { get { return (orphaning.Count > 0) ? orphaning.Peek() : false; } }

		internal string VWSNS { get; }
		internal _NamespaceManager NSM { get; set; }

		public Element Root { get { return (Element)base.DocumentElement; } }
		public new Element DocumentElement { get { return (Element)base.DocumentElement; } }

		//public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
		//{
		//	Element e = new Element(prefix, localName, namespaceURI, this);
		//	if (isOrphaning && (DocumentElement != null) && (Orphans != null)) Orphans.AppendChild(e);
		//	return e;
		//}
		public override XmlElement CreateElement(string prefix, string localName, string namespaceURI)
		{
			return CreateElement(isOrphaning, prefix, localName, namespaceURI);
		}
		public Element CreateElement(bool orphaning, string prefix, string localName, string namespaceURI)
		{
			if ((prefix != null) && (prefix != "") && !NSM.HasNamespace(prefix)) NSM.AddNamespace(prefix, namespaceURI);
			Element e = new Element(prefix, localName, namespaceURI, this);
			if (orphaning && (DocumentElement != null) && (Orphans != null)) Orphans.AppendChild(e);
			return e;
		}

		public new Element CreateElement(string name)
		{
			return (Element)CreateElement(null, name, null);
		}
		public new Element CreateElement(string qualname, string uri)
		{
			string[] ss = qualname.Split(':');
			return (Element)CreateElement(ss[0], ss[1], uri);
		}

		static Element NewElement(string name)
		{
			return Instance.CreateElement(name);
		}
		static Attribute NewAttribute(string name)
		{
			return Instance.CreateAttribute(name);
		}

		public override XmlAttribute CreateAttribute(string prefix, string localName, string namespaceURI)
		{
			return new Attribute(prefix, localName, namespaceURI, this);
		}
		public new Attribute CreateAttribute(string name)
		{
			return (Attribute)CreateAttribute(null, name, null);
		}

		public Element ReadFile(string path)
		{
			orphaning.Push(false);

			Debug.WriteLine("**** reading XML from " + path);

			XmlReaderSettings s = new XmlReaderSettings()
			{
				IgnoreWhitespace = true,
				NameTable = NameTable
			};
			Element e = null;

			using (FileStream sr = new FileStream(path, FileMode.OpenOrCreate))
			{
				using (XmlReader rdr = XmlReader.Create(sr, s))
				{
					try
					{
						e = (Element)ReadNode(rdr);
					}
					catch(Exception ex)
					{
						Debug.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
						e = null;
					}
				}
				if (e == null) { orphaning.Pop(); return null; }
				e.SetAttribute("runtime:Path", path);
			}
			orphaning.Pop();
			//Debug.WriteLine("orphaning : " + e.ElementXML);
			Orphans.AppendChild(e);
			return e;
		}
	}
}
