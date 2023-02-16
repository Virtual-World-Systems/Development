using VWS.WindowsDesktop.Controls;

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
			this.MM_File = new System.Windows.Forms.ToolStripMenuItem();
			this.MMF_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.Tools = new System.Windows.Forms.ToolStripContainer();
			this.MainTabs = new System.Windows.Forms.TabControl();
			this.Interceptor = new VWS.WindowsDesktop.Controls.InterceptorTabPage();
			this.TestPage = new VWS.WindowsDesktop.Controls.TestTabPage();
			this.DataGridTabPage = new VWS.WindowsDesktop.Controls.DataGridTabPage();
			this.TODO_Page = new System.Windows.Forms.TabPage();
			this.MainLeftSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.ObjectTree = new VWS.WindowsDesktop.Controls.XMLTreeList.XMLTreeList();
			this.MainToolStrip = new System.Windows.Forms.ToolStrip();
			this.MainEditModeButton = new VWS.WindowsDesktop.Controls.ToolStrip.CheckButton();
			this.TODO_Control = new VWS.WindowsDesktop.Controls.TODO_Control();
			this.MainMenu.SuspendLayout();
			this.Tools.ContentPanel.SuspendLayout();
			this.Tools.TopToolStripPanel.SuspendLayout();
			this.Tools.SuspendLayout();
			this.MainTabs.SuspendLayout();
			this.TODO_Page.SuspendLayout();
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
			this.MainTabs.Controls.Add(this.TestPage);
			this.MainTabs.Controls.Add(this.DataGridTabPage);
			this.MainTabs.Controls.Add(this.TODO_Page);
			this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTabs.Location = new System.Drawing.Point(181, 0);
			this.MainTabs.Name = "MainTabs";
			this.MainTabs.SelectedIndex = 0;
			this.MainTabs.Size = new System.Drawing.Size(1153, 740);
			this.MainTabs.TabIndex = 3;
			// 
			// Interceptor
			// 
			this.Interceptor.Location = new System.Drawing.Point(4, 22);
			this.Interceptor.Name = "Interceptor";
			this.Interceptor.Size = new System.Drawing.Size(1145, 714);
			this.Interceptor.TabIndex = 0;
			this.Interceptor.Text = "Interceptor";
			// 
			// TestPage
			// 
			this.TestPage.Location = new System.Drawing.Point(4, 22);
			this.TestPage.Name = "TestPage";
			this.TestPage.Size = new System.Drawing.Size(1145, 714);
			this.TestPage.TabIndex = 1;
			this.TestPage.Text = "TestPage";
			this.TestPage.UseVisualStyleBackColor = true;
			// 
			// DataGridTabPage
			// 
			this.DataGridTabPage.Location = new System.Drawing.Point(4, 22);
			this.DataGridTabPage.Name = "DataGridTabPage";
			this.DataGridTabPage.Size = new System.Drawing.Size(1145, 714);
			this.DataGridTabPage.TabIndex = 2;
			this.DataGridTabPage.Text = "DataGrid";
			this.DataGridTabPage.UseVisualStyleBackColor = true;
			// 
			// TODO_Page
			// 
			this.TODO_Page.AutoScroll = true;
			this.TODO_Page.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.TODO_Page.Controls.Add(this.TODO_Control);
			this.TODO_Page.Location = new System.Drawing.Point(4, 22);
			this.TODO_Page.Name = "TODO_Page";
			this.TODO_Page.Size = new System.Drawing.Size(1145, 714);
			this.TODO_Page.TabIndex = 3;
			this.TODO_Page.Text = "TODO";
			this.TODO_Page.UseVisualStyleBackColor = true;
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
			// TODO_Control
			// 
			this.TODO_Control.AutoSize = true;
			this.TODO_Control.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TODO_Control.BackColor = System.Drawing.Color.Ivory;
			this.TODO_Control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TODO_Control.Location = new System.Drawing.Point(0, 0);
			this.TODO_Control.Name = "TODO_Control";
			this.TODO_Control.Size = new System.Drawing.Size(1141, 710);
			this.TODO_Control.TabIndex = 0;
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
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.Tools.ContentPanel.ResumeLayout(false);
			this.Tools.TopToolStripPanel.ResumeLayout(false);
			this.Tools.TopToolStripPanel.PerformLayout();
			this.Tools.ResumeLayout(false);
			this.Tools.PerformLayout();
			this.MainTabs.ResumeLayout(false);
			this.TODO_Page.ResumeLayout(false);
			this.TODO_Page.PerformLayout();
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
		private System.Windows.Forms.ToolStrip MainToolStrip;
		private VWS.WindowsDesktop.Controls.ToolStrip.CheckButton MainEditModeButton;
		private System.Windows.Forms.TabControl MainTabs;
		private Controls.InterceptorTabPage Interceptor;
		private Controls.TestTabPage TestPage;
		private Controls.DataGridTabPage DataGridTabPage;
		private System.Windows.Forms.TabPage TODO_Page;
		private TODO_Control TODO_Control;
	}
}