namespace VWS.WindowsDesktop.Controls
{
	partial class ScrollRect
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
			this.v331 = new VWS.WindowsDesktop.Controls.V33();
			this.SuspendLayout();
			// 
			// v331
			// 
			this.v331.Dock = System.Windows.Forms.DockStyle.Fill;
			this.v331.Location = new System.Drawing.Point(0, 0);
			this.v331.Name = "v331";
			this.v331.Size = new System.Drawing.Size(780, 569);
			this.v331.TabIndex = 0;
			// 
			// ScrollRect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.v331);
			this.Name = "ScrollRect";
			this.Size = new System.Drawing.Size(780, 569);
			this.ResumeLayout(false);

		}

		#endregion

		private V33 v331;
	}
}
