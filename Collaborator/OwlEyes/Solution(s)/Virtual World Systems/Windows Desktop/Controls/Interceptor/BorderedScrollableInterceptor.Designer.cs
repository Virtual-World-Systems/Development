namespace VWS.WindowsDesktop.Controls
{
	partial class BorderedScrollableInterceptor
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
			this.Scrollable = new VWS.WindowsDesktop.Controls.ScrollableInterceptor();
			this.SuspendLayout();
			// 
			// Scrollable
			// 
			this.Scrollable.AutoScroll = true;
			this.Scrollable.AutoScrollMinSize = new System.Drawing.Size(320, 200);
			this.Scrollable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Scrollable.Location = new System.Drawing.Point(10, 10);
			this.Scrollable.Name = "Scrollable";
			this.Scrollable.Padding = new System.Windows.Forms.Padding(3);
			this.Scrollable.Size = new System.Drawing.Size(434, 380);
			this.Scrollable.TabIndex = 0;
			this.Scrollable.Text = "ScrollableInterceptor";
			// 
			// BorderedScrollableInterceptor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.Scrollable);
			this.Name = "BorderedScrollableInterceptor";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(454, 400);
			this.ResumeLayout(false);

		}

		#endregion

		internal ScrollableInterceptor Scrollable;
	}
}
