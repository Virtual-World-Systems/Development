//#define DUMP_TREE
#region usings

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VWS.WindowsDesktop.Test;
using XML;

#endregion
namespace VWS.WindowsDesktop
{
	public static class Program
	{
		#region static Initialization
		static Program()
		{
			try
			{
				Element e;
				XML = new Document();
				#region load Paths

				string V = "\\Virtual-World-Systems\\";

				string LoadEnvPath(Environment.SpecialFolder folder, string v)
				{
					string path = Environment.GetFolderPath(folder) + v;
					if (!Directory.Exists(path)) Directory.CreateDirectory(path);
					return path;
				}
				CommonApplicationData = LoadEnvPath(Environment.SpecialFolder.CommonApplicationData, V);

				string XMLPath = CommonApplicationData + "Paths.xml";

				if (File.Exists(XMLPath)) e = XML.ReadFile(XMLPath);
				else
				{
					e = (Element)XML.CreateElement("runtime", "Paths", "runtime");

					string LoadAssPath(Element elem, string an, string v)
					{
						try
						{
							MethodInfo mi = typeof(Assembly).GetMethod("Get" + an, BindingFlags.Public | BindingFlags.Static);
							Assembly val = (Assembly)mi.Invoke(null, new object[] { });
							string s = val.Location;
							s = s.Replace("/", "\\");
							s = s.Substring(0, s.LastIndexOf("\\") + 1);
							Element n = elem.Document.CreateElement(an);
							elem.AppendChild(n);
							n.InnerText = s;
							return s;
						}
						catch (Exception ex)
						{
							Mess(ex.Message + "\r\n" + ex.StackTrace);
							return "";
						}
					}
					ProgramPath = LoadAssPath(e, "EntryAssembly", V);
					e.WriteFile(XMLPath);
				}
				XML.Root.AppendChild(e);

				UserRoamingApplicationData = LoadEnvPath(Environment.SpecialFolder.ApplicationData, V);
				UserLocalApplicationData = LoadEnvPath(Environment.SpecialFolder.LocalApplicationData, V);

				ProgramPath = XML.DocumentElement.SelectElement("runtime:Paths/EntryAssembly").InnerText;

				SourceRoot = ProgramPath;

				if (SourceRoot.EndsWith("Debug\\") || SourceRoot.EndsWith("Release\\"))
					SourceRoot = SourceRoot = SourceRoot.Substring(0, SourceRoot.IndexOf("\\bin\\") + 1);

				UserRoamingFirestormData = LoadEnvPath(Environment.SpecialFolder.ApplicationData, "\\Firestorm_x64\\");

				Debug.WriteLine($"**** SourceRoot: {SourceRoot}");
				Debug.WriteLine($"**** ProgramPath: {ProgramPath}");
				Debug.WriteLine($"**** UserRoamingFirestormData: {UserRoamingFirestormData}");
				#endregion
				#region load ObjectModel

				void LoadObjectModel()
				{
					Element elem = XML.ReadFile(Path + "_.xml");
					XML.DocumentElement.AppendChild(elem);
				}
				LoadObjectModel();

				#endregion
				#region load MimeTypes

				XMLPath = CommonApplicationData + "MimeTypes.xml";

				if (File.Exists(XMLPath)) e = XML.ReadFile(XMLPath);
				else
				{
					e = XML.CreateElement(true, "mime", "Types", "mime");

					void AddMimeType(Element elem, string name)
					{
						Element x = elem.SelectElement("Type[@Name='" + name + "']");
						if (x != null) return;
						Element p = (Element)Program.XML.CreateElement("Type");
						p.SetAttribute("Name", name);
						elem.AppendChild(p);
					}
					Type MT = typeof(System.Net.Mime.MediaTypeNames);

					foreach (Type TC in MT.GetNestedTypes())
						foreach (FieldInfo fi in TC.GetFields(BindingFlags.Public | BindingFlags.Static))
							AddMimeType(e, TC.Name + "/" + fi.Name);

					AddMimeType(e, "Image/Png"); // .png
					AddMimeType(e, "Image/Avif");
					AddMimeType(e, "Image/Webp"); // .webp
					AddMimeType(e, "Image/Apng");
					AddMimeType(e, "Image/Svg+XML");

					AddMimeType(e, "Text/XML"); // .xml
					AddMimeType(e, "Text/glTF"); // .gltf
					AddMimeType(e, "Text/Collada"); // .dae
					AddMimeType(e, "Text/BiovisionHierarchyAnimation"); // .bvh

					AddMimeType(e, "Application/MayaAnimation"); // .anim
					AddMimeType(e, "Application/OSSLAnimation"); // .animatn
					AddMimeType(e, "Application/glB"); // .glb
					AddMimeType(e, "Application/OSSLMesh"); // .llm

					e.WriteFile(XMLPath);
				}
				XML.DocumentElement.AppendChild(e);

				#endregion
				#region load Grids
				XMLPath = UserLocalApplicationData + "OSSL_Grids.xml";

				if (File.Exists(XMLPath)) e = XML.ReadFile(XMLPath);
				else
				{
					e = XML.CreateElement(true, "OSSL", "Grids", "OSSL");
					Element elem = XML.ReadFile(UserRoamingFirestormData + "user_settings\\grids.user.xml");
					e.AppendChild(elem);
					e.WriteFile(XMLPath);
				}
				XML.DocumentElement.AppendChild(e);
				#endregion
				#region load UserData
				void LoadUserData()
				{
					string path = UserRoamingApplicationData + "ApplicationProperties.xml";
					//Debug.WriteLine("UserAppData: " + path);

					if (!File.Exists(path))
					{
						File.WriteAllText(path,
							"<User><ApplicationProperties><Width>1000</Width></ApplicationProperties></User>"
						);
					}
					Element elem = XML.ReadFile(path);
					Element p = (Element)XML.CreateElement("user", "Data", "user");
					XML.Root.AppendChild(p);
					p.AppendChild(elem);
				}
				LoadUserData();
				#endregion
				#region load AvatarSkeleton (disabled)
#if LOAD_AVATAR_SKELETON
				void LoadAvatarSkeleton()
				{
					string path = CommonApplicationData + "Firestorm/avatar_skeleton.xml";
					if (!File.Exists(path)) return;
					Element elem = XML.ReadFile(path);
					Element p = (Element)XML.CreateElement("firestorm", "Data", "firestorm");
					XML.Root.AppendChild(p);
					p.AppendChild(elem);
				}
				LoadAvatarSkeleton();
#endif
				#endregion
				#region dump ObjectModel
#if DUMP_TREE
				StringBuilder sb = new StringBuilder();
				XML.Root.WriteTo(sb);
				Debug.WriteLine("\r\n" + sb.ToString() + "\r\n");
#endif
				#endregion

				dataSet = new DataSet();
				dataSet.ReadXml(new StringReader(@"
<test>
	<t.1>
		<t.1.1 a1='c' a2='def'>asdkl</t.1.1>
		<t.1.2 a1='a' a2='owprwerp'/>
	</t.1>
	<t.2 xxx='yyy'>
		<t.1 ddd='55'/>
	</t.2>
</test>
"));
			}
			catch (Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
		public static DataSet dataSet;
		#endregion

		#region Main incl. XML, Form, Mess
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			//Generator.Run();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form = new MainForm();
			Application.Run(Form);
		}
		public static XML.Document XML;
		public static Form Form = null;
		static public void Mess(string message)
		{
			if (!Directory.Exists("C:\\Logs")) Directory.CreateDirectory("C:\\Logs");
			File.WriteAllText("C:\\Logs\\VWS.txt", message);
			Debug.WriteLine(message);
			MessageBox.Show(message);
		}

		#endregion
		#region Paths
		public static string CommonApplicationData { get; private set; } // ProgramData
		public static string UserLocalApplicationData { get; private set; } // User
		public static string UserRoamingApplicationData { get; private set; } // User
		public static string ProgramPath { get; private set; } = null;
		public static string SourceRoot { get; private set; } = null;
		public static string Path { get { return ProgramPath; } }
		public static string UserRoamingFirestormData { get; private set; }
		#endregion
	}
}
