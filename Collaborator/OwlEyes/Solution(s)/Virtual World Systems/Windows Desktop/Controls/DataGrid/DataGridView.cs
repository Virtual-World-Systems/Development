using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML;

namespace VWS.WindowsDesktop.Controls
{
	public partial class DataGridView : System.Windows.Forms.DataGridView
	{
		public DataGridView()
		{
			InitializeComponent();

			DataSet ds = CreateAirplaneSchema();
			DataTable airplanes = ds.Tables["Airplane"];
			airplanes.Rows.Add(null, "N1");
			airplanes.Rows.Add(null, "N2");
			airplanes.Rows.Add(null, "N3");

			BindingSource bsA = new BindingSource();
			List<Element> nodes = new List<Element>();
			nodes.Add(Program.XML.Root);
			//foreach (Element e in Program.XML.Document.ChildNodes) nodes.Add(e);
			bsA.DataSource = new BindingList<Element>(nodes);
			//bsA.DataMember = "ElementXML";
			DataSource = bsA;
			//this.Rows[1].Cells[1].
			//this.Columns[1].CellTemplate.
		}

		

		DataSet CreateAirplaneSchema()
		{
			DataSet ds = new DataSet();

			// Create Airplane table
			DataTable airplanes = ds.Tables.Add("Airplane");
			DataColumn a_id = airplanes.Columns.Add("ID", typeof(int));
			a_id.AutoIncrement = true;
			a_id.AutoIncrementSeed = 1;
			a_id.AutoIncrementStep = 1;
			DataColumn a_name = airplanes.Columns.Add("Name", typeof(string));

			//// Create parent-child relationship
			//DataRelation relation = ds.Relations.Add("Airplane_Passengers",
			//	airplanes.Columns["ID"],
			//	passengers.Columns["AirplaneID"], true);

			return ds;
		}

		protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
		{
			base.OnCellPainting(e);
			if ((e.RowIndex != 1) || (e.ColumnIndex != 1)) return;
			Rectangle r = e.CellBounds;
			r.Inflate(-3, -3);
			e.Graphics.DrawRectangle(Pens.Red, r);
		}
	}
}
