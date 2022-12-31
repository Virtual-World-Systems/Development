using VWS.WindowsDesktop.Controls;

namespace VWS.WindowsDesktop.Converter
{
	partial class Converter
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
			this.Conversion = new VWS.WindowsDesktop.Converter.Conversion();
			this.Splitter_right = new VWS.WindowsDesktop.Controls.Splitter();
			this.Splitter_left = new VWS.WindowsDesktop.Controls.Splitter();
			this.Input = new VWS.WindowsDesktop.Converter.Input();
			this.Output = new VWS.WindowsDesktop.Converter.Output();
			this.SuspendLayout();
			// 
			// Conversion
			// 
			this.Conversion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Conversion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Conversion.Location = new System.Drawing.Point(208, 0);
			this.Conversion.Name = "Conversion";
			this.Conversion.Size = new System.Drawing.Size(209, 298);
			this.Conversion.TabIndex = 6;
			// 
			// Splitter_right
			// 
			this.Splitter_right.Dock = System.Windows.Forms.DockStyle.Right;
			this.Splitter_right.Location = new System.Drawing.Point(417, 0);
			this.Splitter_right.Name = "Splitter_right";
			this.Splitter_right.Size = new System.Drawing.Size(8, 298);
			this.Splitter_right.TabIndex = 5;
			this.Splitter_right.TabStop = false;
			// 
			// Splitter_left
			// 
			this.Splitter_left.Location = new System.Drawing.Point(200, 0);
			this.Splitter_left.Name = "Splitter_left";
			this.Splitter_left.Size = new System.Drawing.Size(8, 298);
			this.Splitter_left.TabIndex = 1;
			this.Splitter_left.TabStop = false;
			// 
			// Input
			// 
			this.Input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Input.Dock = System.Windows.Forms.DockStyle.Right;
			this.Input.Location = new System.Drawing.Point(425, 0);
			this.Input.Name = "Input";
			this.Input.Size = new System.Drawing.Size(200, 298);
			this.Input.TabIndex = 4;
			// 
			// Output
			// 
			this.Output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Output.Dock = System.Windows.Forms.DockStyle.Left;
			this.Output.Location = new System.Drawing.Point(0, 0);
			this.Output.Name = "Output";
			this.Output.Size = new System.Drawing.Size(200, 298);
			this.Output.TabIndex = 3;
			// 
			// Converter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Conversion);
			this.Controls.Add(this.Splitter_right);
			this.Controls.Add(this.Splitter_left);
			this.Controls.Add(this.Input);
			this.Controls.Add(this.Output);
			this.Name = "Converter";
			this.Size = new System.Drawing.Size(625, 298);
			this.ResumeLayout(false);

		}

		#endregion

		private Splitter Splitter_left;
		private Output Output;
		private Input Input;
		private Splitter Splitter_right;
		private Conversion Conversion;
	}
}
