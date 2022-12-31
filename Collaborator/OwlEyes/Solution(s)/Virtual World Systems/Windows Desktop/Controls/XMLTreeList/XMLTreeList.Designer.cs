namespace VWS.WindowsDesktop.Controls.XMLTreeList
{
	partial class XMLTreeList
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
			this.Panel = new VWS.WindowsDesktop.Controls.XMLTreeList.XMLTreeListPanel();
			this.Header = new VWS.WindowsDesktop.Controls.XMLTreeList.XMLTreeListHeader();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.AutoScroll = true;
			this.Panel.AutoScrollMinSize = new System.Drawing.Size(2, 4);
			this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel.Location = new System.Drawing.Point(0, 19);
			this.Panel.Name = "Panel";
			this.Panel.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Panel.ParentElement = null;
			this.Panel.Size = new System.Drawing.Size(272, 193);
			this.Panel.TabIndex = 1;
			// 
			// Header
			// 
			this.Header.AutoSize = true;
			this.Header.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Header.BackColor = System.Drawing.SystemColors.HotTrack;
			this.Header.BorderThickness = 2;
			this.Header.Dock = System.Windows.Forms.DockStyle.Top;
			this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.Header.Location = new System.Drawing.Point(0, 0);
			this.Header.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Header.MinimumSize = new System.Drawing.Size(0, 16);
			this.Header.Name = "Header";
			this.Header.Size = new System.Drawing.Size(272, 19);
			this.Header.TabIndex = 0;
			// 
			// XMLTreeList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.Header);
			this.Name = "XMLTreeList";
			this.Size = new System.Drawing.Size(272, 212);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public XMLTreeListHeader Header;
		public XMLTreeListPanel Panel;
	}
}
