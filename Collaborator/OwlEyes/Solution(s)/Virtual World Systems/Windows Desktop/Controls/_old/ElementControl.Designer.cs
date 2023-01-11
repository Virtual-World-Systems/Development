namespace VWS.WindowsDesktop.Controls
{
	partial class ElementControl
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
			this.Panel = new VWS.WindowsDesktop.Controls.ScrollableContentsPanel();
			this.titleBar1 = new VWS.WindowsDesktop.Controls.TitleBar();
			this.SuspendLayout();
			// 
			// Panel
			// 
			this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel.Location = new System.Drawing.Point(0, 16);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(150, 134);
			this.Panel.TabIndex = 2;
			// 
			// titleBar1
			// 
			this.titleBar1.AutoSize = true;
			this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleBar1.Location = new System.Drawing.Point(0, 0);
			this.titleBar1.MinimumSize = new System.Drawing.Size(57, 24);
			this.titleBar1.Name = "titleBar1";
			this.titleBar1.Size = new System.Drawing.Size(150, 16);
			this.titleBar1.TabIndex = 0;
			this.titleBar1.Text = "titleBar1";
			// 
			// ElementControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.titleBar1);
			this.Name = "ElementControl";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ElementControl_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private TitleBar titleBar1;
		private ScrollableContentsPanel Panel;
	}
}
