namespace BTWLib
{
	partial class BTWForm
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
		protected void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTWForm));
			this.LoopTimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// LoopTimer
			// 
			this.LoopTimer.Enabled = true;
			this.LoopTimer.Tick += new System.EventHandler(this.LoopTimer_Tick);
			// 
			// BTWForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1280, 720);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Name = "BTWForm";
			this.Text = "BTW";
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.BTWForm_PreviewKeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Timer LoopTimer;
	}
}