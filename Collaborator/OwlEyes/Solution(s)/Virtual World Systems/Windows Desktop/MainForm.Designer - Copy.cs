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
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "5404",
            "TCP"}, -1);
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.MM_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MMF_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.Tools = new System.Windows.Forms.ToolStripContainer();
			this.MainTabs = new System.Windows.Forms.TabControl();
			this.Interceptor = new VWS.WindowsDesktop.Controls.InterceptorTabPage();
			this.InterceptorRightSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.ListenerPanel = new System.Windows.Forms.Panel();
			this.ConnectionListPanel = new System.Windows.Forms.Panel();
			this.Connections = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ConnectionTitleBar = new VWS.WindowsDesktop.Controls.TitleBar();
			this.ListenerPanelTopSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.ListenerListPanel = new System.Windows.Forms.Panel();
			this.Listeners = new System.Windows.Forms.ListView();
			this.ListenerActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerTitleBar = new VWS.WindowsDesktop.Controls.TitleBar();
			this.MainLeftSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.ObjectTree = new VWS.WindowsDesktop.Controls.XMLTreeList.XMLTreeList();
			this.MainToolStrip = new System.Windows.Forms.ToolStrip();
			this.MainEditModeButton = new VWS.WindowsDesktop.Controls.ToolStrip.CheckButton();
			this.MainMenu.SuspendLayout();
			this.Tools.ContentPanel.SuspendLayout();
			this.Tools.TopToolStripPanel.SuspendLayout();
			this.Tools.SuspendLayout();
			this.MainTabs.SuspendLayout();
			this.Interceptor.SuspendLayout();
			this.ListenerPanel.SuspendLayout();
			this.ConnectionListPanel.SuspendLayout();
			this.ListenerListPanel.SuspendLayout();
			this.MainToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MM_File});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(1334, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "menuStrip1";
			// 
			// MM_File
			// 
			this.MM_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MMF_Exit});
			this.MM_File.Name = "MM_File";
			this.MM_File.Size = new System.Drawing.Size(37, 20);
			this.MM_File.Text = "&File";
			// 
			// MMF_Exit
			// 
			this.MMF_Exit.Name = "MMF_Exit";
			this.MMF_Exit.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.MMF_Exit.Size = new System.Drawing.Size(111, 22);
			this.MMF_Exit.Text = "E&xit";
			this.MMF_Exit.Click += new System.EventHandler(this.MMF_Exit_Click);
			// 
			// StatusBar
			// 
			this.StatusBar.Location = new System.Drawing.Point(0, 789);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1334, 22);
			this.StatusBar.TabIndex = 3;
			this.StatusBar.Text = "StatusBar";
			// 
			// Tools
			// 
			this.Tools.BottomToolStripPanelVisible = false;
			// 
			// Tools.ContentPanel
			// 
			this.Tools.ContentPanel.Controls.Add(this.MainTabs);
			this.Tools.ContentPanel.Controls.Add(this.MainLeftSplitter);
			this.Tools.ContentPanel.Controls.Add(this.ObjectTree);
			this.Tools.ContentPanel.Size = new System.Drawing.Size(1334, 740);
			this.Tools.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tools.LeftToolStripPanelVisible = false;
			this.Tools.Location = new System.Drawing.Point(0, 24);
			this.Tools.Name = "Tools";
			this.Tools.RightToolStripPanelVisible = false;
			this.Tools.Size = new System.Drawing.Size(1334, 765);
			this.Tools.TabIndex = 1;
			this.Tools.Text = "toolStripContainer1";
			// 
			// Tools.TopToolStripPanel
			// 
			this.Tools.TopToolStripPanel.Controls.Add(this.MainToolStrip);
			this.Tools.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			// 
			// MainTabs
			// 
			this.MainTabs.Controls.Add(this.Interceptor);
			this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTabs.Location = new System.Drawing.Point(181, 0);
			this.MainTabs.Name = "MainTabs";
			this.MainTabs.SelectedIndex = 0;
			this.MainTabs.Size = new System.Drawing.Size(1153, 740);
			this.MainTabs.TabIndex = 3;
			// 
			// Interceptor
			// 
			this.Interceptor.Controls.Add(this.InterceptorRightSplitter);
			this.Interceptor.Controls.Add(this.ListenerPanel);
			this.Interceptor.Location = new System.Drawing.Point(4, 22);
			this.Interceptor.Name = "Interceptor";
			this.Interceptor.Size = new System.Drawing.Size(1145, 714);
			this.Interceptor.TabIndex = 0;
			this.Interceptor.Text = "Interceptor";
			// 
			// InterceptorRightSplitter
			// 
			this.InterceptorRightSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.InterceptorRightSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.InterceptorRightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.InterceptorRightSplitter.Location = new System.Drawing.Point(937, 0);
			this.InterceptorRightSplitter.Name = "InterceptorRightSplitter";
			this.InterceptorRightSplitter.Size = new System.Drawing.Size(8, 714);
			this.InterceptorRightSplitter.TabIndex = 4;
			// 
			// ListenerPanel
			// 
			this.ListenerPanel.Controls.Add(this.ConnectionListPanel);
			this.ListenerPanel.Controls.Add(this.ListenerPanelTopSplitter);
			this.ListenerPanel.Controls.Add(this.ListenerListPanel);
			this.ListenerPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.ListenerPanel.Location = new System.Drawing.Point(945, 0);
			this.ListenerPanel.Name = "ListenerPanel";
			this.ListenerPanel.Size = new System.Drawing.Size(200, 714);
			this.ListenerPanel.TabIndex = 3;
			// 
			// ConnectionListPanel
			// 
			this.ConnectionListPanel.Controls.Add(this.Connections);
			this.ConnectionListPanel.Controls.Add(this.ConnectionTitleBar);
			this.ConnectionListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConnectionListPanel.Location = new System.Drawing.Point(0, 108);
			this.ConnectionListPanel.Name = "ConnectionListPanel";
			this.ConnectionListPanel.Size = new System.Drawing.Size(200, 606);
			this.ConnectionListPanel.TabIndex = 6;
			// 
			// Connections
			// 
			this.Connections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
			this.Connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.Connections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Connections.HideSelection = false;
			this.Connections.Location = new System.Drawing.Point(0, 19);
			this.Connections.Name = "Connections";
			this.Connections.Size = new System.Drawing.Size(200, 587);
			this.Connections.TabIndex = 1;
			this.Connections.UseCompatibleStateImageBehavior = false;
			this.Connections.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Type";
			this.columnHeader1.Width = 36;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Port";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 44;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "ID";
			this.columnHeader3.Width = 44;
			// 
			// ConnectionTitleBar
			// 
			this.ConnectionTitleBar.BorderThickness = 2;
			this.ConnectionTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.ConnectionTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.ConnectionTitleBar.Location = new System.Drawing.Point(0, 0);
			this.ConnectionTitleBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ConnectionTitleBar.Name = "ConnectionTitleBar";
			this.ConnectionTitleBar.Size = new System.Drawing.Size(200, 19);
			this.ConnectionTitleBar.TabIndex = 0;
			this.ConnectionTitleBar.Text = "Connections";
			// 
			// ListenerPanelTopSplitter
			// 
			this.ListenerPanelTopSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.ListenerPanelTopSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.ListenerPanelTopSplitter.Location = new System.Drawing.Point(0, 100);
			this.ListenerPanelTopSplitter.Name = "ListenerPanelTopSplitter";
			this.ListenerPanelTopSplitter.Size = new System.Drawing.Size(200, 8);
			this.ListenerPanelTopSplitter.TabIndex = 2;
			// 
			// ListenerListPanel
			// 
			this.ListenerListPanel.BackColor = System.Drawing.Color.Snow;
			this.ListenerListPanel.Controls.Add(this.Listeners);
			this.ListenerListPanel.Controls.Add(this.ListenerTitleBar);
			this.ListenerListPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ListenerListPanel.Location = new System.Drawing.Point(0, 0);
			this.ListenerListPanel.Name = "ListenerListPanel";
			this.ListenerListPanel.Size = new System.Drawing.Size(200, 100);
			this.ListenerListPanel.TabIndex = 5;
			// 
			// Listeners
			// 
			this.Listeners.BackColor = System.Drawing.SystemColors.Info;
			this.Listeners.CheckBoxes = true;
			this.Listeners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListenerActive,
            this.ListenerPort,
            this.ListenerType});
			this.Listeners.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Listeners.FullRowSelect = true;
			this.Listeners.HideSelection = false;
			listViewItem2.StateImageIndex = 0;
			this.Listeners.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
			this.Listeners.Location = new System.Drawing.Point(0, 19);
			this.Listeners.Name = "Listeners";
			this.Listeners.Size = new System.Drawing.Size(200, 81);
			this.Listeners.TabIndex = 0;
			this.Listeners.UseCompatibleStateImageBehavior = false;
			this.Listeners.View = System.Windows.Forms.View.Details;
			this.Listeners.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Listener_ItemChecked);
			// 
			// ListenerActive
			// 
			this.ListenerActive.Text = "";
			this.ListenerActive.Width = 24;
			// 
			// ListenerPort
			// 
			this.ListenerPort.Text = "Port";
			this.ListenerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ListenerPort.Width = 44;
			// 
			// ListenerType
			// 
			this.ListenerType.Text = "Type";
			this.ListenerType.Width = 36;
			// 
			// ListenerTitleBar
			// 
			this.ListenerTitleBar.BorderThickness = 2;
			this.ListenerTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.ListenerTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.ListenerTitleBar.Location = new System.Drawing.Point(0, 0);
			this.ListenerTitleBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ListenerTitleBar.Name = "ListenerTitleBar";
			this.ListenerTitleBar.Size = new System.Drawing.Size(200, 19);
			this.ListenerTitleBar.TabIndex = 1;
			this.ListenerTitleBar.Text = "Listener";
			// 
			// MainLeftSplitter
			// 
			this.MainLeftSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.MainLeftSplitter.Dock = System.Windows.Forms.DockStyle.Left;
			this.MainLeftSplitter.Location = new System.Drawing.Point(171, 0);
			this.MainLeftSplitter.Name = "MainLeftSplitter";
			this.MainLeftSplitter.Size = new System.Drawing.Size(10, 740);
			this.MainLeftSplitter.TabIndex = 2;
			// 
			// ObjectTree
			// 
			this.ObjectTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.ObjectTree.Location = new System.Drawing.Point(0, 0);
			this.ObjectTree.Name = "ObjectTree";
			this.ObjectTree.Size = new System.Drawing.Size(171, 740);
			this.ObjectTree.TabIndex = 1;
			this.ObjectTree.XPathSelector = null;
			// 
			// MainToolStrip
			// 
			this.MainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainEditModeButton});
			this.MainToolStrip.Location = new System.Drawing.Point(3, 0);
			this.MainToolStrip.Name = "MainToolStrip";
			this.MainToolStrip.Size = new System.Drawing.Size(26, 25);
			this.MainToolStrip.TabIndex = 0;
			// 
			// MainEditModeButton
			// 
			this.MainEditModeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.MainEditModeButton.CheckOnClick = true;
			this.MainEditModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.MainEditModeButton.Image = global::VWS.WindowsDesktop.Properties.Resources.edit;
			this.MainEditModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MainEditModeButton.Name = "MainEditModeButton";
			this.MainEditModeButton.Size = new System.Drawing.Size(23, 22);
			this.MainEditModeButton.Text = "MainEditMode";
			this.MainEditModeButton.ToolTipText = "Edit Mode";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1334, 811);
			this.Controls.Add(this.Tools);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.MainMenu);
			this.Location = new System.Drawing.Point(8, 32);
			this.MainMenuStrip = this.MainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MainForm";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.Tools.ContentPanel.ResumeLayout(false);
			this.Tools.TopToolStripPanel.ResumeLayout(false);
			this.Tools.TopToolStripPanel.PerformLayout();
			this.Tools.ResumeLayout(false);
			this.Tools.PerformLayout();
			this.MainTabs.ResumeLayout(false);
			this.Interceptor.ResumeLayout(false);
			this.ListenerPanel.ResumeLayout(false);
			this.ConnectionListPanel.ResumeLayout(false);
			this.ListenerListPanel.ResumeLayout(false);
			this.MainToolStrip.ResumeLayout(false);
			this.MainToolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem MM_File;
		private System.Windows.Forms.ToolStripMenuItem MMF_Exit;
		private System.Windows.Forms.ToolStripContainer Tools;
		private Controls.Splitter MainLeftSplitter;
		private Controls.XMLTreeList.XMLTreeList ObjectTree;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.TabControl MainTabs;
		private VWS.WindowsDesktop.Controls.InterceptorTabPage Interceptor;
		private System.Windows.Forms.ListView Listeners;
		private System.Windows.Forms.ToolStrip MainToolStrip;
		private VWS.WindowsDesktop.Controls.ToolStrip.CheckButton MainEditModeButton;
		private Controls.Splitter InterceptorRightSplitter;
		private System.Windows.Forms.Panel ListenerListPanel;
		private System.Windows.Forms.ColumnHeader ListenerActive;
		private System.Windows.Forms.ColumnHeader ListenerPort;
		private System.Windows.Forms.ColumnHeader ListenerType;
		private Controls.Splitter ListenerPanelTopSplitter;
		private Controls.TitleBar ListenerTitleBar;
		private System.Windows.Forms.Panel ListenerPanel;
		private System.Windows.Forms.Panel ConnectionListPanel;
		private System.Windows.Forms.ListView Connections;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private Controls.TitleBar ConnectionTitleBar;
	}
}