using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OpenSimulator
{
	public class Test
	{
		public partial class Test_XML
		{
			public Test_XML(string path)
			{
				string sXML = @"<_>
</_>";
				XmlDocument doc = new XmlDocument();
				XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
				doc.LoadXml(sXML);
				Debug.WriteLine(doc.InnerXml);
			}
		}
		public class Test_O_DataRow
		{
			public Test_O_DataRow()
			{
				DataTable T = new DataTable();
				T.Columns.Add("Key", typeof(Guid));
				T.Columns.Add("Value", typeof(O));
				o = new O(T.NewRow());

				Debug.WriteLine(o.ToString());
			}
			public O o;
		}

		internal class Test_AssemblyName
		{
			public Test_AssemblyName()
			{
				Debug.WriteLine(AssemblyName.GetAssemblyName(@"C:\github\Virtual-World-Systems\Development\Collaborator\OwlEyes\Solution(s)\OpenSimulator\OpenSimulator\bin\Debug\OpenSimulator.exe").FullName);
			}
		}

		internal class Test_TreeNodeRightClick
		{
			public Test_TreeNodeRightClick(System.Windows.Forms.TreeNode node)
			{
				string k = node.Name;
				string t = node.Text;
				object o = node.Tag;
				if (k != t) t = k + ": " + t;
				Debug.WriteLine(t);
			}
		}
	}
}
