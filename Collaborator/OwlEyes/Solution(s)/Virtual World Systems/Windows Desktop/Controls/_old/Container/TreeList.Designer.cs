namespace VWS.WindowsDesktop.Controls.Container
{
	partial class TreeList
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
			this.Header = new VWS.WindowsDesktop.Controls.Container.TreeListHeader();
			this.ListBox = new VWS.WindowsDesktop.Controls.Container.TreeList.LB();
			this.SuspendLayout();
			// 
			// Header
			// 
			this.Header.AutoScroll = true;
			this.Header.AutoScrollMargin = new System.Drawing.Size(20, 20);
			this.Header.AutoScrollMinSize = new System.Drawing.Size(20, 20);
			this.Header.BackColor = System.Drawing.Color.LavenderBlush;
			this.Header.Dock = System.Windows.Forms.DockStyle.Top;
			this.Header.Location = new System.Drawing.Point(0, 0);
			this.Header.MinimumSize = new System.Drawing.Size(8, 24);
			this.Header.Name = "Header";
			this.Header.Size = new System.Drawing.Size(406, 24);
			this.Header.TabIndex = 0;
			// 
			// ListBox
			// 
			this.ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ListBox.FormattingEnabled = true;
			this.ListBox.HorizontalExtent = 300;
			this.ListBox.HorizontalScrollbar = true;
			this.ListBox.IntegralHeight = false;
			this.ListBox.Location = new System.Drawing.Point(0, 24);
			this.ListBox.Name = "ListBox";
			this.ListBox.Size = new System.Drawing.Size(406, 274);
			this.ListBox.TabIndex = 1;
			this.ListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox_DrawItem);
			this.ListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListBox_MeasureItem);
			// 
			// TreeList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ListBox);
			this.Controls.Add(this.Header);
			this.Name = "TreeList";
			this.Size = new System.Drawing.Size(406, 298);
			this.ResumeLayout(false);

		}

		#endregion

		private TreeListHeader Header;
		private LB ListBox;
	}
}
