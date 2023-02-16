namespace VWS.WindowsDesktop.Controls
{
	partial class InterceptorTabPage
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "5404",
            "TCP"}, -1);
			this.ListenerPanel = new System.Windows.Forms.Panel();
			this.ConnectionListPanel = new System.Windows.Forms.Panel();
			this.Connections = new System.Windows.Forms.ListView();
			this.ConnectionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ConnectionPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ConnectionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ConnectionTitleBar = new VWS.WindowsDesktop.Controls.TitleBar();
			this.ListenerPanelTopSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.ListenerListPanel = new System.Windows.Forms.Panel();
			this.Listeners = new System.Windows.Forms.ListView();
			this.ListenerActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ListenerTitleBar = new VWS.WindowsDesktop.Controls.TitleBar();
			this.ListenerPanelBottomSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.UDPListPanel = new System.Windows.Forms.Panel();
			this.UDPListeners = new System.Windows.Forms.ListView();
			this.UDPPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.UDPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.UDPListenerTitleBar = new VWS.WindowsDesktop.Controls.TitleBar();
			this.BorderedScrollableInterceptor = new VWS.WindowsDesktop.Controls.BorderedScrollableInterceptor();
			this.InterceptorRightSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.InterceptorTopSplitter = new VWS.WindowsDesktop.Controls.Splitter();
			this.TopPanel = new System.Windows.Forms.Panel();
			this.ListenerPanel.SuspendLayout();
			this.ConnectionListPanel.SuspendLayout();
			this.ListenerListPanel.SuspendLayout();
			this.UDPListPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ListenerPanel
			// 
			this.ListenerPanel.Controls.Add(this.ConnectionListPanel);
			this.ListenerPanel.Controls.Add(this.ListenerPanelTopSplitter);
			this.ListenerPanel.Controls.Add(this.ListenerListPanel);
			this.ListenerPanel.Controls.Add(this.ListenerPanelBottomSplitter);
			this.ListenerPanel.Controls.Add(this.UDPListPanel);
			this.ListenerPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.ListenerPanel.Location = new System.Drawing.Point(533, 0);
			this.ListenerPanel.Name = "ListenerPanel";
			this.ListenerPanel.Size = new System.Drawing.Size(200, 502);
			this.ListenerPanel.TabIndex = 3;
			// 
			// ConnectionListPanel
			// 
			this.ConnectionListPanel.Controls.Add(this.Connections);
			this.ConnectionListPanel.Controls.Add(this.ConnectionTitleBar);
			this.ConnectionListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ConnectionListPanel.Location = new System.Drawing.Point(0, 153);
			this.ConnectionListPanel.Name = "ConnectionListPanel";
			this.ConnectionListPanel.Size = new System.Drawing.Size(200, 149);
			this.ConnectionListPanel.TabIndex = 6;
			// 
			// Connections
			// 
			this.Connections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(246)))));
			this.Connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ConnectionType,
            this.ConnectionPort,
            this.ConnectionID});
			this.Connections.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Connections.FullRowSelect = true;
			this.Connections.HideSelection = false;
			this.Connections.Location = new System.Drawing.Point(0, 19);
			this.Connections.Name = "Connections";
			this.Connections.Size = new System.Drawing.Size(200, 130);
			this.Connections.TabIndex = 1;
			this.Connections.UseCompatibleStateImageBehavior = false;
			this.Connections.View = System.Windows.Forms.View.Details;
			// 
			// ConnectionType
			// 
			this.ConnectionType.Text = "Type";
			this.ConnectionType.Width = 36;
			// 
			// ConnectionPort
			// 
			this.ConnectionPort.Text = "Port";
			this.ConnectionPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ConnectionPort.Width = 44;
			// 
			// ConnectionID
			// 
			this.ConnectionID.Text = "ID";
			this.ConnectionID.Width = 44;
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
			this.ConnectionTitleBar.Text = "TCP-Connections";
			// 
			// ListenerPanelTopSplitter
			// 
			this.ListenerPanelTopSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.ListenerPanelTopSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.ListenerPanelTopSplitter.Location = new System.Drawing.Point(0, 145);
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
			this.ListenerListPanel.Size = new System.Drawing.Size(200, 145);
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
			listViewItem1.StateImageIndex = 0;
			this.Listeners.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.Listeners.Location = new System.Drawing.Point(0, 19);
			this.Listeners.Name = "Listeners";
			this.Listeners.Size = new System.Drawing.Size(200, 126);
			this.Listeners.TabIndex = 0;
			this.Listeners.UseCompatibleStateImageBehavior = false;
			this.Listeners.View = System.Windows.Forms.View.Details;
			this.Listeners.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Listeners_ItemChecked);
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
			this.ListenerTitleBar.Text = "TCP-Listeners";
			// 
			// ListenerPanelBottomSplitter
			// 
			this.ListenerPanelBottomSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.ListenerPanelBottomSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ListenerPanelBottomSplitter.Location = new System.Drawing.Point(0, 302);
			this.ListenerPanelBottomSplitter.Name = "ListenerPanelBottomSplitter";
			this.ListenerPanelBottomSplitter.Size = new System.Drawing.Size(200, 6);
			this.ListenerPanelBottomSplitter.TabIndex = 2;
			// 
			// UDPListPanel
			// 
			this.UDPListPanel.Controls.Add(this.UDPListeners);
			this.UDPListPanel.Controls.Add(this.UDPListenerTitleBar);
			this.UDPListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.UDPListPanel.Location = new System.Drawing.Point(0, 308);
			this.UDPListPanel.Name = "UDPListPanel";
			this.UDPListPanel.Size = new System.Drawing.Size(200, 194);
			this.UDPListPanel.TabIndex = 2;
			// 
			// UDPListeners
			// 
			this.UDPListeners.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
			this.UDPListeners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UDPPort,
            this.UDPID});
			this.UDPListeners.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UDPListeners.FullRowSelect = true;
			this.UDPListeners.HideSelection = false;
			this.UDPListeners.Location = new System.Drawing.Point(0, 19);
			this.UDPListeners.Name = "UDPListeners";
			this.UDPListeners.Size = new System.Drawing.Size(200, 175);
			this.UDPListeners.TabIndex = 1;
			this.UDPListeners.UseCompatibleStateImageBehavior = false;
			this.UDPListeners.View = System.Windows.Forms.View.Details;
			// 
			// UDPPort
			// 
			this.UDPPort.Text = "Port";
			this.UDPPort.Width = 44;
			// 
			// UDPID
			// 
			this.UDPID.Text = "ID";
			this.UDPID.Width = 44;
			// 
			// UDPListenerTitleBar
			// 
			this.UDPListenerTitleBar.BorderThickness = 2;
			this.UDPListenerTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.UDPListenerTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.UDPListenerTitleBar.Location = new System.Drawing.Point(0, 0);
			this.UDPListenerTitleBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.UDPListenerTitleBar.Name = "UDPListenerTitleBar";
			this.UDPListenerTitleBar.Size = new System.Drawing.Size(200, 19);
			this.UDPListenerTitleBar.TabIndex = 0;
			this.UDPListenerTitleBar.Text = "UDP-Listener";
			// 
			// BorderedScrollableInterceptor
			// 
			this.BorderedScrollableInterceptor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.BorderedScrollableInterceptor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BorderedScrollableInterceptor.Location = new System.Drawing.Point(168, 0);
			this.BorderedScrollableInterceptor.Name = "BorderedScrollableInterceptor";
			this.BorderedScrollableInterceptor.Padding = new System.Windows.Forms.Padding(10);
			this.BorderedScrollableInterceptor.Size = new System.Drawing.Size(357, 502);
			this.BorderedScrollableInterceptor.TabIndex = 0;
			// 
			// InterceptorRightSplitter
			// 
			this.InterceptorRightSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.InterceptorRightSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
			this.InterceptorRightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
			this.InterceptorRightSplitter.Location = new System.Drawing.Point(525, 0);
			this.InterceptorRightSplitter.Name = "InterceptorRightSplitter";
			this.InterceptorRightSplitter.Size = new System.Drawing.Size(8, 502);
			this.InterceptorRightSplitter.TabIndex = 4;
			// 
			// InterceptorTopSplitter
			// 
			this.InterceptorTopSplitter.BackColor = System.Drawing.SystemColors.Control;
			this.InterceptorTopSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.InterceptorTopSplitter.Dock = System.Windows.Forms.DockStyle.Top;
			this.InterceptorTopSplitter.Name = "InterceptorTopSplitter";
			this.InterceptorTopSplitter.Size = new System.Drawing.Size(8, 8);
			this.InterceptorTopSplitter.TabIndex = 0;
			// 
			// TopPanel
			// 
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(160, 100);
			this.TopPanel.TabIndex = 0;
			// 
			// InterceptorTabPage
			// 
			this.Controls.Add(this.BorderedScrollableInterceptor);
			this.Controls.Add(this.InterceptorRightSplitter);
			this.Controls.Add(this.ListenerPanel);
			this.Controls.Add(this.InterceptorTopSplitter);
			this.Controls.Add(this.TopPanel);
			this.Name = "InterceptorTabPage";
			this.Size = new System.Drawing.Size(733, 502);
			this.ListenerPanel.ResumeLayout(false);
			this.ConnectionListPanel.ResumeLayout(false);
			this.ListenerListPanel.ResumeLayout(false);
			this.UDPListPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private BorderedScrollableInterceptor BorderedScrollableInterceptor;
		private Splitter InterceptorRightSplitter;
		private System.Windows.Forms.ListView Listeners;
		private System.Windows.Forms.Panel ListenerListPanel;
		private System.Windows.Forms.ColumnHeader ListenerActive;
		private System.Windows.Forms.ColumnHeader ListenerPort;
		private System.Windows.Forms.ColumnHeader ListenerType;
		private Controls.Splitter ListenerPanelTopSplitter;
		private Controls.TitleBar ListenerTitleBar;
		private System.Windows.Forms.Panel ListenerPanel;
		private System.Windows.Forms.Panel ConnectionListPanel;
		private System.Windows.Forms.ListView Connections;
		private System.Windows.Forms.ColumnHeader ConnectionType;
		private System.Windows.Forms.ColumnHeader ConnectionPort;
		private System.Windows.Forms.ColumnHeader ConnectionID;
		private Controls.TitleBar ConnectionTitleBar;
		private Splitter ListenerPanelBottomSplitter;
		private System.Windows.Forms.Panel UDPListPanel;
		private System.Windows.Forms.ListView UDPListeners;
		private System.Windows.Forms.ColumnHeader UDPPort;
		private System.Windows.Forms.ColumnHeader UDPID;
		private TitleBar UDPListenerTitleBar;
		private Splitter InterceptorTopSplitter;
		private System.Windows.Forms.Panel TopPanel;
	}
}
