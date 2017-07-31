namespace ExceptionFinder
{
	partial class ExceptionFinderView
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
			if(disposing && (components != null))
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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
		private void InitializeComponent()
		{
			this.leakedExceptions = new System.Windows.Forms.TreeView();
			this.methodName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// leakedExceptions
			// 
			this.leakedExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.leakedExceptions.Location = new System.Drawing.Point(12, 57);
			this.leakedExceptions.Name = "leakedExceptions";
			this.leakedExceptions.Size = new System.Drawing.Size(334, 266);
			this.leakedExceptions.TabIndex = 0;
			// 
			// methodName
			// 
			this.methodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.methodName.AutoEllipsis = true;
			this.methodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.methodName.Location = new System.Drawing.Point(12, 16);
			this.methodName.Name = "methodName";
			this.methodName.Size = new System.Drawing.Size(332, 23);
			this.methodName.TabIndex = 1;
			this.methodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ExceptionFinderView
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.Controls.Add(this.methodName);
			this.Controls.Add(this.leakedExceptions);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.Name = "ExceptionFinderView";
			this.Size = new System.Drawing.Size(360, 342);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView leakedExceptions;
		private System.Windows.Forms.Label methodName;

	}
}
