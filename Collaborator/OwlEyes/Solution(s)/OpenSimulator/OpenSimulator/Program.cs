using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using static System.Environment;

namespace OpenSimulator
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			string[] args = Environment.GetCommandLineArgs();
			XmlDocument doc = new XmlDocument();
			//_.__.___.run();

			//foreach (string f in Enum.GetNames(typeof(SpecialFolder)))
			//{
			//	Debug.WriteLine(f + ": " + GetFolderPath((SpecialFolder)Enum.Parse(typeof(SpecialFolder), f)));
			//}
			Application.Run(new MainForm());

//			Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder..CommonApplicationData));
//			Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
		}
		static Program()
		{
			System.Diagnostics.Debug.WriteLine("" + Environment.CommandLine);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
		}
	}
}
