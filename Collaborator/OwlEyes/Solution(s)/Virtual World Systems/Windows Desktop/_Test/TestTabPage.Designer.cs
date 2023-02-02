namespace VWS.WindowsDesktop.Controls
{ 
	partial class TestTabPage
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
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.splitter1 = new VWS.WindowsDesktop.Controls.Splitter();
			this.ChildDataGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ChildDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGridView
			// 
			this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView.Dock = System.Windows.Forms.DockStyle.Top;
			this.DataGridView.Location = new System.Drawing.Point(0, 0);
			this.DataGridView.Name = "DataGridView";
			this.DataGridView.Size = new System.Drawing.Size(405, 150);
			this.DataGridView.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 150);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(405, 6);
			this.splitter1.TabIndex = 1;
			// 
			// ChildDataGridView
			// 
			this.ChildDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ChildDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ChildDataGridView.Location = new System.Drawing.Point(0, 156);
			this.ChildDataGridView.Name = "ChildDataGridView";
			this.ChildDataGridView.Size = new System.Drawing.Size(405, 156);
			this.ChildDataGridView.TabIndex = 2;
			// 
			// TestTabPage
			// 
			this.Controls.Add(this.ChildDataGridView);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.DataGridView);
			this.Name = "TestTabPage";
			this.Size = new System.Drawing.Size(405, 312);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ChildDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView DataGridView;
		private Controls.Splitter splitter1;
		private System.Windows.Forms.DataGridView ChildDataGridView;
	}
}
