using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
			foreach (Element e in Program.XML.Root.ChildNodes) nodes.Add(e);
			bsA.DataSource = new BindingList<Element>(nodes);
			//bsA.DataMember = "ElementXML";
			DataSource = bsA;
			//this.Rows[1].Cells[1].
			//this.Columns[1].CellTemplate.

			RowHeadersWidth = 200;
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
			Debug.WriteLine($"Cell {e.RowIndex} {e.ColumnIndex}");

			if (!inited)
			{
				inited = true;
				Rows[1].Height = 70;
			}
			base.OnCellPainting(e);
			if ((e.RowIndex != 0) || (e.ColumnIndex != 3)) return;

			Rectangle r = e.CellBounds;
			e.Graphics.FillRectangle(Brushes.LightYellow, r);
			e.Graphics.DrawLine(SystemPens.ControlDark, r.Right-1, r.Top, r.Right-1, r.Bottom);
			e.Graphics.DrawLine(SystemPens.ControlDark, r.Left, r.Bottom-1, r.Right, r.Bottom-1);
			r.Size -= new Size(1, 1);
			r.Inflate(-3, -3);
			e.Graphics.DrawRectangle(Pens.Red, r);
			e.Handled = true;
		}
		bool inited = false;
	}
}
