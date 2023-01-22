namespace VWS.WindowsDesktop.Controls.Interceptor
{
	partial class InterceptorPipe
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
			this.interceptorServer1 = new VWS.WindowsDesktop.Controls.InterceptorServer();
			this.SuspendLayout();
			// 
			// interceptorServer1
			// 
			this.interceptorServer1.Dock = System.Windows.Forms.DockStyle.Right;
			this.interceptorServer1.Location = new System.Drawing.Point(342, 0);
			this.interceptorServer1.Name = "interceptorServer1";
			this.interceptorServer1.Padding = new System.Windows.Forms.Padding(6);
			this.interceptorServer1.Size = new System.Drawing.Size(296, 218);
			this.interceptorServer1.TabIndex = 0;
			this.interceptorServer1.Text = "Listener";
			// 
			// InterceptorPipe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.interceptorServer1);
			this.Name = "InterceptorPipe";
			this.Size = new System.Drawing.Size(638, 218);
			this.ResumeLayout(false);

		}

		#endregion

		private InterceptorServer interceptorServer1;
	}
}
