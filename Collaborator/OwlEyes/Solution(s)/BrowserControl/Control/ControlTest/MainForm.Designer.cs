namespace ControlTest
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
			this.BC = new ernsoft.BrowserControl.BrowserControl();
			this.SuspendLayout();
			// 
			// BC
			// 
			this.BC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BC.Location = new System.Drawing.Point(0, 0);
			this.BC.Name = "BC";
			this.BC.Size = new System.Drawing.Size(800, 450);
			this.BC.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.BC);
			this.Name = "MainForm";
			this.Text = "Chrome Browser Control Test";
			this.ResumeLayout(false);

		}

		#endregion

		private ernsoft.BrowserControl.BrowserControl BC;
	}
}

