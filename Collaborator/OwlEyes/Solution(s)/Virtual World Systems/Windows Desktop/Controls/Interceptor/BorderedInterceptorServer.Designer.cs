namespace VWS.WindowsDesktop.Controls.Interceptor
{
	partial class BorderedInterceptorServer
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
			this.Server = new VWS.WindowsDesktop.Controls.InterceptorServer();
			this.SuspendLayout();
			// 
			// Server
			// 
			this.Server.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Server.Location = new System.Drawing.Point(4, 4);
			this.Server.Name = "Server";
			this.Server.Size = new System.Drawing.Size(142, 142);
			this.Server.TabIndex = 0;
			// 
			// BorderedInterceptorServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Server);
			this.Name = "BorderedInterceptorServer";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.ResumeLayout(false);

		}

		#endregion

		private InterceptorServer Server;
	}
}
