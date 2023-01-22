namespace VWS.WindowsDesktop.Controls
{
	partial class ScrollableInterceptor
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
			this.Interceptor = new VWS.WindowsDesktop.Controls.InterceptorContent();
			this.SuspendLayout();
			// 
			// Interceptor
			// 
			this.Interceptor.CellCount = new System.Drawing.Size(0, 0);
			this.Interceptor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Interceptor.Location = new System.Drawing.Point(0, 0);
			this.Interceptor.Name = "Interceptor";
			this.Interceptor.Size = new System.Drawing.Size(780, 569);
			this.Interceptor.TabIndex = 0;
			// 
			// ScrollableInterceptor
			// 
			this.AutoScroll = true;
			this.Controls.Add(this.Interceptor);
			this.Name = "ScrollRect";
			this.Size = new System.Drawing.Size(780, 569);
			this.ResumeLayout(false);

		}

		#endregion

		internal InterceptorContent Interceptor;
	}
}
