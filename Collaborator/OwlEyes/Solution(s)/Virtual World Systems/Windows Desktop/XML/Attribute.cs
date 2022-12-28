using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
	public class Attribute : XmlAttribute
	{
		public Attribute(string prefix, string localName, string namespaceURI, Document doc)
			: base(prefix, localName, namespaceURI, doc) { }

		public Document Document { get { return (Document)OwnerDocument; } }
		public Element Element { get { return (Element)OwnerElement; } }
		public Element Root { get { return Document.Root; } }
		public Element ParentElement { get { return Element.Parent; } }

		public static Attribute @new(string name) { return Document.Instance.CreateAttribute(name); }
	}
}
