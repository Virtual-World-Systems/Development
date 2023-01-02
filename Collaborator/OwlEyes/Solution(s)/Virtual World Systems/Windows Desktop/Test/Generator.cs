using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BA = System.Reflection.Emit.AssemblyBuilderAccess;
using System.Diagnostics;

namespace VWS.WindowsDesktop.Test
{
	internal class Generator
	{
		static Assembly CreateAssembly()
		{
			string Name = "_" + Guid.NewGuid().ToString("N").ToUpper();

			AppDomain AD = AppDomain.CurrentDomain;
			AssemblyName AN = new AssemblyName(Name);
			AssemblyBuilder AB = AD.DefineDynamicAssembly(AN, BA.RunAndCollect);
			ModuleBuilder MB = AB.DefineDynamicModule("M" + Name);

			TypeBuilder TB = MB.DefineType("Global", TypeAttributes.Public);

			MethodBuilder B = TB.DefineMethod("M1",
				MethodAttributes.Public | MethodAttributes.Static,
				null, null);

			ILGenerator ILG = B.GetILGenerator();
			ILG.EmitWriteLine("Hello World");
			ILG.Emit(OpCodes.Ret);

			TB.CreateType();

			return AB;
		}

		internal static void ShowAssemblies()
		{
			GC.Collect();
			Debug.WriteLine("_____________");
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
				if (a.GetName().Name.StartsWith("_"))
					Debug.WriteLine(a.GetName().Name);
			Debug.WriteLine("-------------");
		}
		internal static void Run()
		{
			ShowAssemblies();

			if (MethodInfo == null)
			{
				Assembly A = CreateAssembly();
				object O = A.CreateInstance("Global");
				MethodInfo = O.GetType().GetMethod("M1");
			}
			ShowAssemblies();
			MethodInfo.Invoke(null, new object[] { });
			MethodInfo = null;
			ShowAssemblies();
		}
		static MethodInfo MethodInfo = null;
	}
}
