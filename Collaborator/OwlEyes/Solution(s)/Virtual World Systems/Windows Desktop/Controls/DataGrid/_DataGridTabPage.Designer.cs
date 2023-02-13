namespace VWS.WindowsDesktop.Controls
{
	partial class DataGridTabPage
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DataGrid = new VWS.WindowsDesktop.Controls.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGrid
			// 
			this.DataGrid.DataMember = "";
			this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGrid.Location = new System.Drawing.Point(0, 0);
			this.DataGrid.Name = "DataGrid";
			this.DataGrid.Size = new System.Drawing.Size(368, 334);
			this.DataGrid.TabIndex = 0;
			// 
			// DataGridTabPage
			// 
			this.Controls.Add(this.DataGrid);
			this.Size = new System.Drawing.Size(372, 338);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.DataGridTabPage_Paint);
			((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridView DataGrid;
	}
}
