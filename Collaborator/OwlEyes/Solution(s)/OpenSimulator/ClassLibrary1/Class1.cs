using System;
using System.Collections;

namespace ClassLibrary1
{
	public class Class1
	{
		public static string TestString { get { return "TestString"; } }
		public static IEnumerator TestString2
		{
			get 
			{
				yield return "TestString";
			}
		}
		public static (int,char) xyz(string x)
		{
			return (2, 's');
		}
	}
}
