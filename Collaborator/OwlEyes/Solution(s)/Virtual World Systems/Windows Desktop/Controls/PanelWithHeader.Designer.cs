namespace VWS.WindowsDesktop.Controls
{
	partial class PanelWithHeader
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
			this.contentsPanel = new VWS.WindowsDesktop.Controls.ScrollableContentsPanel();
			this.TitlePanel = new VWS.WindowsDesktop.Controls.TitleBar();
			this.SuspendLayout();
			// 
			// contentsPanel
			// 
			this.contentsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.contentsPanel.BackColor = System.Drawing.Color.LightGreen;
			this.contentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentsPanel.Location = new System.Drawing.Point(0, 24);
			this.contentsPanel.Name = "contentsPanel";
			this.contentsPanel.Size = new System.Drawing.Size(862, 514);
			this.contentsPanel.TabIndex = 0;
			// 
			// TitlePanel
			// 
			this.TitlePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TitlePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitlePanel.Location = new System.Drawing.Point(0, 0);
			this.TitlePanel.MinimumSize = new System.Drawing.Size(56, 24);
			this.TitlePanel.Name = "TitlePanel";
			this.TitlePanel.Size = new System.Drawing.Size(862, 24);
			this.TitlePanel.TabIndex = 0;
			this.TitlePanel.Text = "AÜ|_Wjq";
			// 
			// PanelWithHeader
			// 
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.contentsPanel);
			this.Controls.Add(this.TitlePanel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "PanelWithHeader";
			this.Size = new System.Drawing.Size(862, 538);
			this.ResumeLayout(false);

		}

		#endregion

		private ScrollableContentsPanel contentsPanel;
		private TitleBar TitlePanel;
	}
}
