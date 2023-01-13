namespace VWS.WindowsDesktop
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MM_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.scrollRect1 = new VWS.WindowsDesktop.Controls.ScrollRect();
			this.MainMenu.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(1334, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_Exit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// MM_Exit
			// 
			this.MM_Exit.Name = "MM_Exit";
			this.MM_Exit.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.MM_Exit.Size = new System.Drawing.Size(111, 22);
			this.MM_Exit.Text = "E&xit";
			this.MM_Exit.Click += new System.EventHandler(this.MM_Exit_Click);
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.scrollRect1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1334, 762);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(1334, 787);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// scrollRect1
			// 
			this.scrollRect1.AutoScroll = true;
			this.scrollRect1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.scrollRect1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scrollRect1.Location = new System.Drawing.Point(0, 0);
			this.scrollRect1.Name = "scrollRect1";
			this.scrollRect1.Size = new System.Drawing.Size(1334, 762);
			this.scrollRect1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1334, 811);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.MainMenu);
			this.Location = new System.Drawing.Point(8, 32);
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MainForm";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem MM_Exit;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private Controls.ScrollRect scrollRect1;
	}
}