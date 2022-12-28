namespace VWS.WindowsDesktop
{
	partial class TestForm
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
			this.MM_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MM_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.SplitContainer = new System.Windows.Forms.SplitContainer();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.EditMode = new System.Windows.Forms.ToolStripButton();
			this.elementControl1 = new VWS.WindowsDesktop.Controls.ElementControl();
			this.MainMenu.SuspendLayout();
			this.ToolStripContainer.ContentPanel.SuspendLayout();
			this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
			this.ToolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
			this.SplitContainer.Panel1.SuspendLayout();
			this.SplitContainer.SuspendLayout();
			this.ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_File});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(800, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "Main Menu";
			// 
			// MM_File
			// 
			this.MM_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_File_Exit});
			this.MM_File.Name = "MM_File";
			this.MM_File.Size = new System.Drawing.Size(37, 20);
			this.MM_File.Text = "&File";
			// 
			// MM_File_Exit
			// 
			this.MM_File_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MM_File_Exit.Name = "MM_File_Exit";
			this.MM_File_Exit.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.MM_File_Exit.Size = new System.Drawing.Size(111, 22);
			this.MM_File_Exit.Text = "E&xit";
			this.MM_File_Exit.Click += new System.EventHandler(this.MM_File_Exit_Click);
			// 
			// ToolStripContainer
			// 
			// 
			// ToolStripContainer.ContentPanel
			// 
			this.ToolStripContainer.ContentPanel.Controls.Add(this.SplitContainer);
			this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(800, 401);
			this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ToolStripContainer.Location = new System.Drawing.Point(0, 24);
			this.ToolStripContainer.Name = "ToolStripContainer";
			this.ToolStripContainer.Size = new System.Drawing.Size(800, 426);
			this.ToolStripContainer.TabIndex = 1;
			this.ToolStripContainer.Text = "toolStripContainer1";
			// 
			// ToolStripContainer.TopToolStripPanel
			// 
			this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.ToolStrip);
			// 
			// SplitContainer
			// 
			this.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainer.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			this.SplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Info;
			this.SplitContainer.Panel1.Controls.Add(this.elementControl1);
			this.SplitContainer.Size = new System.Drawing.Size(800, 401);
			this.SplitContainer.SplitterDistance = 330;
			this.SplitContainer.TabIndex = 0;
			this.SplitContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplitContainer_MouseDown);
			this.SplitContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SplitContainer_MouseMove);
			this.SplitContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SplitContainer_MouseUp);
			// 
			// ToolStrip
			// 
			this.ToolStrip.BackColor = System.Drawing.Color.Transparent;
			this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMode});
			this.ToolStrip.Location = new System.Drawing.Point(3, 0);
			this.ToolStrip.Name = "ToolStrip";
			this.ToolStrip.Size = new System.Drawing.Size(26, 25);
			this.ToolStrip.TabIndex = 0;
			// 
			// EditMode
			// 
			this.EditMode.BackColor = System.Drawing.Color.Transparent;
			this.EditMode.CheckOnClick = true;
			this.EditMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.EditMode.Image = global::VWS.WindowsDesktop.Properties.Resources.ObjectTree;
			this.EditMode.Name = "EditMode";
			this.EditMode.Size = new System.Drawing.Size(23, 22);
			this.EditMode.Text = "EditMode";
			this.EditMode.CheckedChanged += new System.EventHandler(this.EditMode_CheckedChanged);
			// 
			// elementControl1
			// 
			this.elementControl1.Location = new System.Drawing.Point(98, 87);
			this.elementControl1.Name = "elementControl1";
			this.elementControl1.Size = new System.Drawing.Size(150, 150);
			this.elementControl1.TabIndex = 0;
			this.elementControl1.XML_Selector = "_";
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ToolStripContainer);
			this.Controls.Add(this.MainMenu);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.MainMenu;
			this.Name = "TestForm";
			this.Text = "TestForm";
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.ToolStripContainer.ContentPanel.ResumeLayout(false);
			this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.ToolStripContainer.TopToolStripPanel.PerformLayout();
			this.ToolStripContainer.ResumeLayout(false);
			this.ToolStripContainer.PerformLayout();
			this.SplitContainer.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
			this.SplitContainer.ResumeLayout(false);
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MM_File;
		private System.Windows.Forms.ToolStripMenuItem MM_File_Exit;
		private System.Windows.Forms.ToolStripContainer ToolStripContainer;
		private System.Windows.Forms.ToolStrip ToolStrip;
		private System.Windows.Forms.ToolStripButton EditMode;
		private System.Windows.Forms.SplitContainer SplitContainer;
		private Controls.ElementControl elementControl1;
	}
}

