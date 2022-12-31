namespace VWS.WindowsDesktop.Converter
{
	partial class FormatSettings
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
			this.FormatLabel = new System.Windows.Forms.Label();
			this.Selector = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// FormatLabel
			// 
			this.FormatLabel.AutoSize = true;
			this.FormatLabel.Location = new System.Drawing.Point(4, 6);
			this.FormatLabel.Name = "FormatLabel";
			this.FormatLabel.Size = new System.Drawing.Size(39, 13);
			this.FormatLabel.TabIndex = 0;
			this.FormatLabel.Text = "Format";
			// 
			// Selector
			// 
			this.Selector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Selector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Selector.FormattingEnabled = true;
			this.Selector.Location = new System.Drawing.Point(49, 3);
			this.Selector.Name = "Selector";
			this.Selector.Size = new System.Drawing.Size(197, 21);
			this.Selector.TabIndex = 1;
			// 
			// FormatSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.Selector);
			this.Controls.Add(this.FormatLabel);
			this.Name = "FormatSettings";
			this.Size = new System.Drawing.Size(251, 27);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label FormatLabel;
		public System.Windows.Forms.ComboBox Selector;
	}
}
