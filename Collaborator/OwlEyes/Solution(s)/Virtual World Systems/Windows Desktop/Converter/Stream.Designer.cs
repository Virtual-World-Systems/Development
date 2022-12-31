namespace VWS.WindowsDesktop.Converter
{
	partial class Stream
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
			this.FormatSettings = new VWS.WindowsDesktop.Converter.FormatSettings();
			this.SuspendLayout();
			// 
			// FormatSettings
			// 
			this.FormatSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FormatSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.FormatSettings.Location = new System.Drawing.Point(0, 0);
			this.FormatSettings.Name = "FormatSettings";
			this.FormatSettings.Size = new System.Drawing.Size(496, 28);
			this.FormatSettings.TabIndex = 0;
			// 
			// Input
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FormatSettings);
			this.Name = "Input";
			this.Size = new System.Drawing.Size(496, 317);
			this.Load += new System.EventHandler(this.Input_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private FormatSettings FormatSettings;
	}
}
