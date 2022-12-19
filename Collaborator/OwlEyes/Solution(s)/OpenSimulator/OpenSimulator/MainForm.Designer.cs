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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colladaFromDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Test_XML = new System.Windows.Forms.ToolStripMenuItem();
			this.oDataRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Test_O_DataRow = new System.Windows.Forms.ToolStripMenuItem();
			this.reflectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Test_AssemblyName = new System.Windows.Forms.ToolStripMenuItem();
			this.demoAssemblyBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iLGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPanelOuter = new System.Windows.Forms.Panel();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.MainSplit = new System.Windows.Forms.SplitContainer();
			this.Panel_Tree = new System.Windows.Forms.Panel();
			this.Tree = new OpenSimulator.ObjectTree();
			this.Panel_Content = new System.Windows.Forms.Panel();
			this.NodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.NodeContext_ShowMetainfo = new System.Windows.Forms.ToolStripMenuItem();
			this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ShowWebbrowser = new System.Windows.Forms.ToolStripMenuItem();
			this.NotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.testCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainMenu.SuspendLayout();
			this.MainPanelOuter.SuspendLayout();
			this.MainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
			this.MainSplit.Panel1.SuspendLayout();
			this.MainSplit.Panel2.SuspendLayout();
			this.MainSplit.SuspendLayout();
			this.Panel_Tree.SuspendLayout();
			this.NodeContextMenu.SuspendLayout();
			this.NotifyMenu.SuspendLayout();
			this.NotifyContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.testToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(1038, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "MainMenu";
			// 
			// FileMenu
			// 
			this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.File_Exit});
			this.FileMenu.Name = "FileMenu";
			this.FileMenu.Size = new System.Drawing.Size(37, 20);
			this.FileMenu.Text = "&File";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colladaFromDBToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
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
			// File_Exit
			// 
			this.File_Exit.Name = "File_Exit";
			this.File_Exit.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.File_Exit.Size = new System.Drawing.Size(111, 22);
			this.File_Exit.Text = "Exit";
			this.File_Exit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Test_XML,
            this.oDataRowToolStripMenuItem,
            this.reflectionToolStripMenuItem,
            this.demoAssemblyBuilderToolStripMenuItem,
            this.iLGeneratorToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.testToolStripMenuItem.Text = "&Test";
			// 
			// Test_XML
			// 
			this.Test_XML.Name = "Test_XML";
			this.Test_XML.Size = new System.Drawing.Size(197, 22);
			this.Test_XML.Tag = "Test+Test_XML";
			this.Test_XML.Text = "XML";
			this.Test_XML.Click += new System.EventHandler(this.Test_XML_Click);
			// 
			// oDataRowToolStripMenuItem
			// 
			this.oDataRowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Test_O_DataRow});
			this.oDataRowToolStripMenuItem.Name = "oDataRowToolStripMenuItem";
			this.oDataRowToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.oDataRowToolStripMenuItem.Text = "O";
			// 
			// Test_O_DataRow
			// 
			this.Test_O_DataRow.Name = "Test_O_DataRow";
			this.Test_O_DataRow.Size = new System.Drawing.Size(121, 22);
			this.Test_O_DataRow.Tag = "Test+Test_O_DataRow";
			this.Test_O_DataRow.Text = "DataRow";
			this.Test_O_DataRow.Click += new System.EventHandler(this.Test_O_DataRow_Click);
			// 
			// reflectionToolStripMenuItem
			// 
			this.reflectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Test_AssemblyName});
			this.reflectionToolStripMenuItem.Name = "reflectionToolStripMenuItem";
			this.reflectionToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.reflectionToolStripMenuItem.Text = "Reflection";
			// 
			// Test_AssemblyName
			// 
			this.Test_AssemblyName.Name = "Test_AssemblyName";
			this.Test_AssemblyName.Size = new System.Drawing.Size(157, 22);
			this.Test_AssemblyName.Text = "AssemblyName";
			this.Test_AssemblyName.Click += new System.EventHandler(this.Test_AssemblyName_Click);
			// 
			// demoAssemblyBuilderToolStripMenuItem
			// 
			this.demoAssemblyBuilderToolStripMenuItem.Name = "demoAssemblyBuilderToolStripMenuItem";
			this.demoAssemblyBuilderToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.demoAssemblyBuilderToolStripMenuItem.Text = "Demo AssemblyBuilder";
			this.demoAssemblyBuilderToolStripMenuItem.Click += new System.EventHandler(this.demoAssemblyBuilderToolStripMenuItem_Click);
			// 
			// iLGeneratorToolStripMenuItem
			// 
			this.iLGeneratorToolStripMenuItem.Name = "iLGeneratorToolStripMenuItem";
			this.iLGeneratorToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
			this.iLGeneratorToolStripMenuItem.Text = "IL Generator";
			this.iLGeneratorToolStripMenuItem.Click += new System.EventHandler(this.iLGeneratorToolStripMenuItem_Click);
			// 
			// MainPanelOuter
			// 
			this.MainPanelOuter.Controls.Add(this.MainPanel);
			this.MainPanelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanelOuter.Location = new System.Drawing.Point(0, 24);
			this.MainPanelOuter.Name = "MainPanelOuter";
			this.MainPanelOuter.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
			this.MainPanelOuter.Size = new System.Drawing.Size(1038, 519);
			this.MainPanelOuter.TabIndex = 1;
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.MainSplit);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(4, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(1030, 515);
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
			this.MainSplit.Size = new System.Drawing.Size(1030, 515);
			this.MainSplit.SplitterDistance = 213;
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
			this.Panel_Tree.Size = new System.Drawing.Size(213, 515);
			this.Panel_Tree.TabIndex = 0;
			// 
			// Tree
			// 
			this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tree.Location = new System.Drawing.Point(0, 0);
			this.Tree.Name = "Tree";
			this.Tree.Size = new System.Drawing.Size(209, 511);
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
			this.Panel_Content.Size = new System.Drawing.Size(811, 515);
			this.Panel_Content.TabIndex = 0;
			// 
			// NodeContextMenu
			// 
			this.NodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NodeContext_ShowMetainfo});
			this.NodeContextMenu.Name = "NodeContextMenu";
			this.NodeContextMenu.Size = new System.Drawing.Size(155, 26);
			// 
			// NodeContext_ShowMetainfo
			// 
			this.NodeContext_ShowMetainfo.Name = "NodeContext_ShowMetainfo";
			this.NodeContext_ShowMetainfo.Size = new System.Drawing.Size(154, 22);
			this.NodeContext_ShowMetainfo.Text = "Show Metainfo";
			this.NodeContext_ShowMetainfo.Click += new System.EventHandler(this.NodeContext_ShowMetainfo_Click);
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.NotifyIcon.BalloonTipText = "Open Simulator\r\nManager";
			this.NotifyIcon.BalloonTipTitle = "Open Simulator";
			this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Visible = true;
			this.NotifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_BalloonTipClicked);
			this.NotifyIcon.BalloonTipClosed += new System.EventHandler(this.NotifyIcon_BalloonTipClosed);
			this.NotifyIcon.BalloonTipShown += new System.EventHandler(this.NotifyIcon_BalloonTipShown);
			this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
			// 
			// NotifyMenu
			// 
			this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowWebbrowser});
			this.NotifyMenu.Name = "NotifyMenu";
			this.NotifyMenu.Size = new System.Drawing.Size(173, 26);
			// 
			// ShowWebbrowser
			// 
			this.ShowWebbrowser.Name = "ShowWebbrowser";
			this.ShowWebbrowser.Size = new System.Drawing.Size(172, 22);
			this.ShowWebbrowser.Text = "Show Webbrowser";
			this.ShowWebbrowser.Click += new System.EventHandler(this.ShowWebbrowser_Click);
			// 
			// NotifyContextMenu
			// 
			this.NotifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testCToolStripMenuItem});
			this.NotifyContextMenu.Name = "NotifyContextMenu";
			this.NotifyContextMenu.Size = new System.Drawing.Size(103, 26);
			// 
			// testCToolStripMenuItem
			// 
			this.testCToolStripMenuItem.Name = "testCToolStripMenuItem";
			this.testCToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.testCToolStripMenuItem.Text = "test c";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1038, 543);
			this.Controls.Add(this.MainPanelOuter);
			this.Controls.Add(this.MainMenu);
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.Text = "OpenSimulator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
			this.NodeContextMenu.ResumeLayout(false);
			this.NotifyMenu.ResumeLayout(false);
			this.NotifyContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem colladaFromDBToolStripMenuItem;
		private System.Windows.Forms.Panel MainPanelOuter;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.SplitContainer MainSplit;
		private System.Windows.Forms.Panel Panel_Tree;
		private System.Windows.Forms.Panel Panel_Content;
		private ObjectTree Tree;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Test_XML;
		private System.Windows.Forms.ToolStripMenuItem oDataRowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Test_O_DataRow;
		private System.Windows.Forms.ToolStripMenuItem reflectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Test_AssemblyName;
		private System.Windows.Forms.ContextMenuStrip NodeContextMenu;
		private System.Windows.Forms.ToolStripMenuItem NodeContext_ShowMetainfo;
		private System.Windows.Forms.ToolStripMenuItem File_Exit;
		private System.Windows.Forms.ToolStripMenuItem demoAssemblyBuilderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iLGeneratorToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon NotifyIcon;
		private System.Windows.Forms.ContextMenuStrip NotifyMenu;
		private System.Windows.Forms.ContextMenuStrip NotifyContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ShowWebbrowser;
		private System.Windows.Forms.ToolStripMenuItem testCToolStripMenuItem;
	}
}

