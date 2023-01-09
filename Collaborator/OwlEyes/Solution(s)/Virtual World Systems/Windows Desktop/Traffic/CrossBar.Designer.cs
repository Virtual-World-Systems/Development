namespace VWS.WindowsDesktop.Traffic
{
	partial class CrossBar
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
			this.LeftPanel = new WindowsDesktop.Traffic.P_LC();
			this.RightPanel = new WindowsDesktop.Traffic.P_RC();
			this.CenterPanel = new System.Windows.Forms.Panel();
			this.RightSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.LeftSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.SuspendLayout();
			// 
			// LeftPanel
			// 
			this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.Size = new System.Drawing.Size(140, 66);
			this.LeftPanel.TabIndex = 0;
			// 
			// RightPanel
			// 
			this.RightPanel.BackColor = System.Drawing.Color.Honeydew;
			this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightPanel.Location = new System.Drawing.Point(388, 0);
			this.RightPanel.Name = "RightPanel";
			this.RightPanel.Size = new System.Drawing.Size(140, 66);
			this.RightPanel.TabIndex = 2;
			// 
			// CenterPanel
			// 
			this.CenterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CenterPanel.Location = new System.Drawing.Point(156, 0);
			this.CenterPanel.Name = "CenterPanel";
			this.CenterPanel.Size = new System.Drawing.Size(216, 66);
			this.CenterPanel.TabIndex = 4;
			// 
			// RightSplitter
			// 
			this.RightSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.RightSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.RightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightSplitter.Location = new System.Drawing.Point(372, 0);
			this.RightSplitter.Name = "RightSplitter";
			this.RightSplitter.Size = new System.Drawing.Size(16, 66);
			this.RightSplitter.TabIndex = 3;
			this.RightSplitter.TabStop = false;
			// 
			// LeftSplitter
			// 
			this.LeftSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.LeftSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.LeftSplitter.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftSplitter.Location = new System.Drawing.Point(140, 0);
			this.LeftSplitter.Name = "LeftSplitter";
			this.LeftSplitter.Size = new System.Drawing.Size(16, 66);
			this.LeftSplitter.TabIndex = 1;
			this.LeftSplitter.TabStop = false;
			// 
			// CrossBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CenterPanel);
			this.Controls.Add(this.RightSplitter);
			this.Controls.Add(this.RightPanel);
			this.Controls.Add(this.LeftSplitter);
			this.Controls.Add(this.LeftPanel);
			this.Name = "CrossBar";
			this.Size = new System.Drawing.Size(528, 66);
			this.ParentChanged += new System.EventHandler(this.CrossBar_ParentChanged);
			this.ResumeLayout(false);

		}

		#endregion
		internal Controls.Splitter RightSplitter;
		internal WindowsDesktop.Traffic.P_RC RightPanel;
		internal System.Windows.Forms.Panel CenterPanel;
		internal WindowsDesktop.Traffic.P_LC LeftPanel;
		internal Controls.Splitter LeftSplitter;
	}
}
