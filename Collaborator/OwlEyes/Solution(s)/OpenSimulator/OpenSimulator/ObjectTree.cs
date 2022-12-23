using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace OpenSimulator
{
	public class ObjectTree : TreeView
	{
		public void Load()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(Dialog.Path("Objects\\_.xml"));
			foreach (XmlElement x in doc.DocumentElement.SelectNodes("*"))
			{
				if (x.Name == "List")
				{
					string typeName = x.GetAttribute("ElementType");

					Type T = GetType().Assembly.GetType("OpenSimulator.Objects");
					Type objectType = T.GetNestedType(typeName);

					FieldInfo f = objectType.GetField("List", BindingFlags.Public | BindingFlags.Static);
					object list = f.GetValue(null);

					PropertyInfo n = list.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
					string listName = n.GetValue(list).ToString();

                    System.Windows.Forms.TreeNode node = Add(Nodes, list.GetType(), listName, list);

					foreach (XmlElement y in x.SelectNodes("*"))
					{
						typeName = y.Name;

						T = GetType().Assembly.GetType("OpenSimulator.Objects");
						objectType = T.GetNestedType(typeName);

						string objectName = y.GetAttribute("Name");
						Add(node.Nodes, objectType, objectName, CreateObject(objectType, objectName));
					}
				}
				else
				{
					string typeName = x.Name;

					Type T = GetType().Assembly.GetType("OpenSimulator.Objects");
					Type objectType = T.GetNestedType(typeName);

					string objectName = x.GetAttribute("Name");
					Add(Nodes, objectType, objectName, CreateObject(objectType, objectName));
				}
			}
	//		Tree.Nodes.Add(
	//"Servers", "Servers", 0, 0).Nodes.Add("Server", "Server 1", 1, 1);
		}

		object CreateObject(Type type, string name)
		{
			ConstructorInfo ci = type.GetConstructor(new Type[] { typeof(String) });
			return ci.Invoke(new object[] { name });
		}
        System.Windows.Forms.TreeNode Add(TreeNodeCollection nodes, Type objectType, string text, object tag)
		{
			string key = objectType.ToString();
			string imageKey = objectType.Name;
			if (imageKey.StartsWith("__"))
			{
				imageKey = text;
				if (text.EndsWith("_"))
					text = text.Substring(0, text.Length - 1);
				text += " …";
			}
			//MessageBox.Show(imageKey);
			TreeNode node = new TreeNode(text, imageKey);
			//System.Windows.Forms.TreeNode node = nodes.Add(key, , text, imageKey, imageKey);
			nodes.Add(node);

			ConstructorInfo ci = objectType.GetConstructor(new Type[] {});
			node.Tag = tag;
			return node;
		}
	}
}
