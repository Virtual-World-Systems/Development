using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VWS.Data
{
	public class TypeSet : DataSet
	{
		public TypeSet()
		{
			I = this;
			Tables.Add(T_Mimetype = new MimeType()); // Map Guid to (Type,ID)
			Tables.Add(T_M = new _M()); // Map Guid to (Type,ID)
			Relations.Add("CN", T_M.Columns["ID"], T_Mimetype.Columns["ID"]);
//			ds.Relations.Add("CustOrd", ds.Tables!Cust.Columns!CustomerID, _
//ds.Tables!Orders.Columns!CustomerID)
		}
		internal static TypeSet I;

		static TypeSet()
		{
			I = new TypeSet();
		}

		public static MimeType T_Mimetype;
		public static _M T_M;

		public class _M : DataTable
		{
			public _M() : base("_M")
			{
				Columns.Add("GUID", typeof(Guid));
				Columns.Add("Type", typeof(DataTable));
				Columns.Add("ID", typeof(UInt64));
				Rows.Add(new object[] { Guid.NewGuid(), I.Tables["MimeType"], 0 });
				Rows.Add(new object[] { Guid.NewGuid(), I.Tables["MimeType"], 1 });
			}
		}
		public class MimeType : DataTable
		{
			public MimeType() : base("MimeType")
			{
				Columns.Add("ID", typeof(byte));
				Columns.Add("Name", typeof(String));
				Columns.Add("Extension", typeof(string));
				Rows.Add(new object[] { 0, "Application/Raw", "raw" });
				Rows.Add(new object[] { 1, "Application/Collada", "dae" });
			}
		}
	}
}
