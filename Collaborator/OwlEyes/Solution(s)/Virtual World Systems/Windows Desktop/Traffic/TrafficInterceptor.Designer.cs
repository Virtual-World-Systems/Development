namespace VWS.WindowsDesktop.Traffic
{
	partial class TrafficInterceptor
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
			this.RightSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.LeftSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.LeftPanel = new VWS.WindowsDesktop.Traffic.V3Panel();
			this.RightPanel = new VWS.WindowsDesktop.Traffic.V3Panel();
			this.CenterPanel = new VWS.WindowsDesktop.Traffic.V3Panel();
			this.CrossBar = new VWS.WindowsDesktop.Traffic.CrossBar();
			this.SuspendLayout();
			// 
			// RightSplitter
			// 
			this.RightSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.RightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightSplitter.Location = new System.Drawing.Point(432, 0);
			this.RightSplitter.Name = "RightSplitter";
			this.RightSplitter.Size = new System.Drawing.Size(16, 386);
			this.RightSplitter.TabIndex = 3;
			this.RightSplitter.TabStop = false;
			// 
			// LeftSplitter
			// 
			this.LeftSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.LeftSplitter.Location = new System.Drawing.Point(140, 0);
			this.LeftSplitter.Name = "LeftSplitter";
			this.LeftSplitter.Size = new System.Drawing.Size(16, 386);
			this.LeftSplitter.TabIndex = 1;
			this.LeftSplitter.TabStop = false;
			// 
			// LeftPanel
			// 
			this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.LeftPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftPanel.Name = "LeftPanel";
			this.LeftPanel.Size = new System.Drawing.Size(140, 386);
			this.LeftPanel.TabIndex = 0;
			// 
			// RightPanel
			// 
			this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.RightPanel.Location = new System.Drawing.Point(448, 0);
			this.RightPanel.Name = "RightPanel";
			this.RightPanel.Size = new System.Drawing.Size(140, 386);
			this.RightPanel.TabIndex = 0;
			// 
			// CenterPanel
			// 
			this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CenterPanel.Location = new System.Drawing.Point(156, 0);
			this.CenterPanel.Name = "CenterPanel";
			this.CenterPanel.Size = new System.Drawing.Size(276, 386);
			this.CenterPanel.TabIndex = 4;
			// 
			// CrossBar
			// 
			this.CrossBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.CrossBar.Location = new System.Drawing.Point(0, 160);
			this.CrossBar.Name = "CrossBar";
			this.CrossBar.Size = new System.Drawing.Size(588, 66);
			this.CrossBar.TabIndex = 5;
			// 
			// TrafficInterceptor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CrossBar);
			this.Controls.Add(this.CenterPanel);
			this.Controls.Add(this.RightSplitter);
			this.Controls.Add(this.RightPanel);
			this.Controls.Add(this.LeftSplitter);
			this.Controls.Add(this.LeftPanel);
			this.Name = "TrafficInterceptor";
			this.Size = new System.Drawing.Size(588, 386);
			this.ResumeLayout(false);

		}

		#endregion
		internal V3Panel LeftPanel;
		internal V3Panel RightPanel;
		internal V3Panel CenterPanel;
		internal Controls.Splitter LeftSplitter;
		internal Controls.Splitter RightSplitter;
		private CrossBar CrossBar;
	}
}
