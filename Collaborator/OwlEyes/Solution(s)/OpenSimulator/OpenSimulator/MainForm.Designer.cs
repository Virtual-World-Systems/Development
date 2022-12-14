namespace OpenSimulator
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
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colladaFromDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPanelOuter = new System.Windows.Forms.Panel();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.MainSplit = new System.Windows.Forms.SplitContainer();
			this.Panel_Tree = new System.Windows.Forms.Panel();
			this.Tree = new OpenSimulator.ObjectTree();
			this.Panel_Content = new System.Windows.Forms.Panel();
			this.MainMenu.SuspendLayout();
			this.MainPanelOuter.SuspendLayout();
			this.MainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
			this.MainSplit.Panel1.SuspendLayout();
			this.MainSplit.Panel2.SuspendLayout();
			this.MainSplit.SuspendLayout();
			this.Panel_Tree.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(800, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "MainMenu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colladaFromDBToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.importToolStripMenuItem.Text = "&Import";
			// 
			// colladaFromDBToolStripMenuItem
			// 
			this.colladaFromDBToolStripMenuItem.Name = "colladaFromDBToolStripMenuItem";
			this.colladaFromDBToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.colladaFromDBToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.colladaFromDBToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.colladaFromDBToolStripMenuItem.Text = "Collada from DB …";
			this.colladaFromDBToolStripMenuItem.Click += new System.EventHandler(this.colladaFromDBToolStripMenuItem_Click);
			// 
			// MainPanelOuter
			// 
			this.MainPanelOuter.Controls.Add(this.MainPanel);
			this.MainPanelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanelOuter.Location = new System.Drawing.Point(0, 24);
			this.MainPanelOuter.Name = "MainPanelOuter";
			this.MainPanelOuter.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
			this.MainPanelOuter.Size = new System.Drawing.Size(800, 203);
			this.MainPanelOuter.TabIndex = 1;
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.MainSplit);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(4, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(792, 199);
			this.MainPanel.TabIndex = 0;
			// 
			// MainSplit
			// 
			this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainSplit.Location = new System.Drawing.Point(0, 0);
			this.MainSplit.Name = "MainSplit";
			// 
			// MainSplit.Panel1
			// 
			this.MainSplit.Panel1.Controls.Add(this.Panel_Tree);
			// 
			// MainSplit.Panel2
			// 
			this.MainSplit.Panel2.Controls.Add(this.Panel_Content);
			this.MainSplit.Size = new System.Drawing.Size(792, 199);
			this.MainSplit.SplitterDistance = 164;
			this.MainSplit.SplitterWidth = 6;
			this.MainSplit.TabIndex = 0;
			// 
			// Panel_Tree
			// 
			this.Panel_Tree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel_Tree.Controls.Add(this.Tree);
			this.Panel_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel_Tree.Location = new System.Drawing.Point(0, 0);
			this.Panel_Tree.Name = "Panel_Tree";
			this.Panel_Tree.Size = new System.Drawing.Size(164, 199);
			this.Panel_Tree.TabIndex = 0;
			// 
			// Tree
			// 
			this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tree.Location = new System.Drawing.Point(0, 0);
			this.Tree.Name = "Tree";
			this.Tree.Size = new System.Drawing.Size(160, 195);
			this.Tree.TabIndex = 0;
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterSelect);
			this.Tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tree_NodeMouseClick);
			// 
			// Panel_Content
			// 
			this.Panel_Content.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel_Content.Location = new System.Drawing.Point(0, 0);
			this.Panel_Content.Name = "Panel_Content";
			this.Panel_Content.Size = new System.Drawing.Size(622, 199);
			this.Panel_Content.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 227);
			this.Controls.Add(this.MainPanelOuter);
			this.Controls.Add(this.MainMenu);
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.Text = "OpenSimulator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.MainPanelOuter.ResumeLayout(false);
			this.MainPanel.ResumeLayout(false);
			this.MainSplit.Panel1.ResumeLayout(false);
			this.MainSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
			this.MainSplit.ResumeLayout(false);
			this.Panel_Tree.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colladaFromDBToolStripMenuItem;
		private System.Windows.Forms.Panel MainPanelOuter;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.SplitContainer MainSplit;
		private System.Windows.Forms.Panel Panel_Tree;
		private System.Windows.Forms.Panel Panel_Content;
		private ObjectTree Tree;
	}
}

