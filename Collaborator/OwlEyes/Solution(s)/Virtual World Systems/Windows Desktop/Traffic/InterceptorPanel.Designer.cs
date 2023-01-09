namespace VWS.WindowsDesktop.Traffic
{
	partial class InterceptorPanel
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
			this.V3Panel = new VWS.WindowsDesktop.Traffic.V3Panel();
			this.SuspendLayout();
			// 
			// V3Panel
			// 
			this.V3Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.V3Panel.Location = new System.Drawing.Point(0, 0);
			this.V3Panel.Name = "V3Panel";
			this.V3Panel.Size = new System.Drawing.Size(260, 462);
			this.V3Panel.TabIndex = 0;
			// 
			// InterceptorPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.V3Panel);
			this.Name = "InterceptorPanel";
			this.Size = new System.Drawing.Size(260, 462);
			this.ResumeLayout(false);

		}

		#endregion

		private V3Panel V3Panel;
	}
}
