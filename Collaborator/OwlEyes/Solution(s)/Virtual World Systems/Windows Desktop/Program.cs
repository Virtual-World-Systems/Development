using System;
using System.Collections.Generic;
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

namespace VWS.WindowsDesktop
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			//Generator.Run();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(Form = new TestForm());
		}
		public static Form Form = null;

		static Program()
		{
			try
			{
				LoadPaths();
				LoadUserData();
				LoadMimeTypes();
				LoadObjectModel();
				//LoadAvatarSkeleton();
			}
			catch (Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		static void LoadAvatarSkeleton()
		{
			string path = CommonApplicationData + "Firestorm/avatar_skeleton.xml";
			if (!File.Exists(path)) return;
			Element e = XML.ReadFile(path);
			Element p = (Element)XML.CreateElement("firestorm", "Data", "firestorm");
			XML.Root.AppendChild(p);
			p.AppendChild(e);
		}
		static void LoadUserData()
		{
			string path = ApplicationData + "ApplicationProperties.xml";
			//Debug.WriteLine("UserAppData: " + path);

			if (!Directory.Exists(ApplicationData))
				Directory.CreateDirectory(ApplicationData);

			if (!File.Exists(path))
			{
				File.WriteAllText(path,
					"<User><ApplicationProperties><Width>1000</Width></ApplicationProperties></User>"
				);
			}
			Element e = XML.ReadFile(path);
			Element p = (Element)XML.CreateElement("user", "Data", "user");
			XML.Root.AppendChild(p);
			p.AppendChild(e);
		}

		static void LoadMimeTypes()
		{
			Element e = null;
			string path = CommonApplicationData + "MimeTypes.xml";

			if (!File.Exists(path))
			{
				using (e = (Element)XML.CreateElement("mime", "Types", "mime"))
				{
					Type MT = typeof(System.Net.Mime.MediaTypeNames);

					foreach (Type TC in MT.GetNestedTypes())
						foreach (FieldInfo fi in TC.GetFields(BindingFlags.Public | BindingFlags.Static))
							AddMimeType(e, TC.Name + "/" + fi.Name);

					AddMimeType(e, "Image/Png");

					AddMimeType(e, "Text/XML"); // .xml
					AddMimeType(e, "Text/glTF"); // .gltf
					AddMimeType(e, "Text/Collada"); // .dae
					AddMimeType(e, "Text/BiovisionHierarchyAnimation"); // .bvh
					AddMimeType(e, "Application/MayaAnimation"); // .anim
					AddMimeType(e, "Application/OSSLAnimation"); // .animatn
					AddMimeType(e, "Application/glB"); // .glb
					AddMimeType(e, "Application/OSSLMesh"); // .llm

					StringBuilder sb = new StringBuilder();
					e.WriteTo(sb);
					File.WriteAllText(path, sb.ToString());
				}
			}
			XML.DocumentElement.AppendChild(XML.ReadFile(path));
		}
		static void AddMimeType(Element e, string name)
		{
			Element x = e.SelectElement("Type[@Name='" + name + "']");
			if (x != null) return;
			Element p = (Element)XML.CreateElement("Type");
			p.SetAttribute("Name", name);
			e.AppendChild(p);
		}
		public static List<string> MimeTypes = new List<string>();
		static void LoadObjectModel()
		{
			Element e = XML.ReadFile(Path + "_.xml");
			XML.DocumentElement.AppendChild(e);
		}
		static void LoadPaths()
		{
			try
			{
				XML = new XML.Document();

				string V = "\\Virtual-World-Systems\\";
				ApplicationData = LoadEnvPath(Environment.SpecialFolder.ApplicationData, V);
				LocalApplicationData = LoadEnvPath(Environment.SpecialFolder.LocalApplicationData, V);
				CommonApplicationData = LoadEnvPath(Environment.SpecialFolder.CommonApplicationData, V);

				string XMLPath = CommonApplicationData + "Paths.xml";

				if (Assembly.GetEntryAssembly() == null)
				{
					XML.DocumentElement.AppendChild(XML.ReadFile(XMLPath));
					ProgramPath = XML.DocumentElement.SelectElement("runtime:Paths/EntryAssembly").InnerText;
				}
				else
				{
					Element e = (Element)XML.CreateElement("runtime", "Paths", "runtime");
					XML.DocumentElement.AppendChild(e);
					ProgramPath = LoadAssPath(e, "EntryAssembly", V);
					e.WriteFile(XMLPath);
				}
				SourceRoot = ProgramPath;
				if (SourceRoot.EndsWith("Debug\\") || SourceRoot.EndsWith("Release\\"))
					SourceRoot = SourceRoot = SourceRoot.Substring(0, SourceRoot.IndexOf("\\bin\\") + 1);
			}
			catch(Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
			Debug.WriteLine($"**** SourceRoot: {SourceRoot}");
			Debug.WriteLine($"**** ProgramPath: {ProgramPath}");
		}
		static public void Mess(string message)
		{
			if (!Directory.Exists("C:\\Logs")) Directory.CreateDirectory("C:\\Logs");
			File.WriteAllText("C:\\Logs\\VWS.txt", message);
			Debug.WriteLine(message);
			MessageBox.Show(message);
		}
		static string LoadEnvPath(Environment.SpecialFolder folder, string v)
		{
			return Environment.GetFolderPath(folder) + v;
		}
		static string LoadAssPath(Element e, string an, string v)
		{
			try
			{
				MethodInfo mi = typeof(Assembly).
					GetMethod("Get" + an, BindingFlags.Public | BindingFlags.Static);
				Assembly val = (Assembly)mi.Invoke(null, new object[] { });
				string s = val.Location;
				s = s.Replace("/", "\\");
				s = s.Substring(0, s.LastIndexOf("\\") + 1);
				Element n = e.Document.CreateElement(an);
				e.AppendChild(n);
				n.InnerText = s;
				return s;
			}
			catch(Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
				return "";
			}
		}
		public static string ApplicationData { get; private set; } // User
		public static string LocalApplicationData { get; private set; } // User
		public static string CommonApplicationData { get; private set; } // ProgramData
		public static string ProgramPath { get; private set; } = null;
		public static string SourceRoot { get; private set; } = null;

		public static string Path { get {
				if (string.IsNullOrEmpty(ProgramPath)) LoadPaths();
				return ProgramPath; } }

		public static XML.Document XML;
	}
}
