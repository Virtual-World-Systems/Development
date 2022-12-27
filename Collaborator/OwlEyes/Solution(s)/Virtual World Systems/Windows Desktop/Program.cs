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
using XML;

namespace VWS.WindowsDesktop
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Mess("xx");
			Application.Run(Form = new TestForm());
		}
		public static Form Form = null;

		static Program()
		{
			try
			{
				LoadPaths();
				LoadObjectModel();
			}
			catch(Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		static void LoadObjectModel()
		{
			Element e = XML.ReadFile(Path + "ObjectModel.xml");
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
					ProgramPath = XML.DocumentElement.SelectElement("Paths/EntryAssembly").InnerText;
				}
				else
				{
					Element e = XML.CreateElement("Paths");
					XML.DocumentElement.AppendChild(e);
					ProgramPath = LoadAssPath(e, "EntryAssembly", V);
					e.WriteFile(XMLPath);
				}
			}
			catch(Exception ex)
			{
				Mess(ex.Message + "\r\n" + ex.StackTrace);
			}
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
				Element n = e.OwnerDocument.CreateElement(an);
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
		public static string ApplicationData { get; private set; }
		public static string LocalApplicationData { get; private set; }
		public static string CommonApplicationData { get; private set; }
		public static string ProgramPath { get; private set; } = null;

		public static string Path { get {
				if (string.IsNullOrEmpty(ProgramPath)) LoadPaths();
				return ProgramPath; } }

		public static XML.Document XML;
	}
}
