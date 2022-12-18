using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

partial class HttpHandler
{
	/// <summary>
	/// Summary description for Index
	/// </summary>
	public class Index : HttpHandler
	{
		public override string Title { get { return base.Title + " Index"; } }
	}
}
