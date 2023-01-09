namespace VWS.WindowsDesktop.Traffic
{
	partial class V3Panel
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
			this.TopPanel = new System.Windows.Forms.Panel();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.CenterPanel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = System.Drawing.Color.Snow;
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(240, 150);
			this.TopPanel.TabIndex = 0;
			// 
			// BottomPanel
			// 
			this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(250)))));
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 200);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(240, 150);
			this.BottomPanel.TabIndex = 1;
			// 
			// CenterPanel
			// 
			this.CenterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
			this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CenterPanel.Location = new System.Drawing.Point(0, 150);
			this.CenterPanel.Name = "CenterPanel";
			this.CenterPanel.Size = new System.Drawing.Size(240, 50);
			this.CenterPanel.TabIndex = 2;
			// 
			// V3Panel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.CenterPanel);
			this.Controls.Add(this.BottomPanel);
			this.Controls.Add(this.TopPanel);
			this.Name = "V3Panel";
			this.Size = new System.Drawing.Size(240, 350);
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Panel TopPanel;
		internal System.Windows.Forms.Panel BottomPanel;
		internal System.Windows.Forms.Panel CenterPanel;
	}
}
