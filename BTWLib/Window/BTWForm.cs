using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BTWLib.ControlEvents;

namespace BTWLib
{
	public partial class BTWForm : Form
	{
		#region Fields and properties
		public Queue<BTWEvent> CommandQueue { get; private set; } = new Queue<BTWEvent>();
		#endregion

		#region Events
		public event Action LoopTicked;
		#endregion

		public BTWForm(int Rate)
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
			UpdateStyles();

			LoopTimer.Interval = (int)(1000 / Rate);
		}

		#region Methods
		#region Drawing
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		private const int WM_SETREDRAW = 11;

		public void SuspendDrawing()
		{
			SendMessage(this.Handle, WM_SETREDRAW, false, 0);
		}

		public void ResumeDrawing()
		{
			SendMessage(this.Handle, WM_SETREDRAW, true, 0);
			this.Refresh();
		}
		#endregion


		public void RefreshPublic()
		{
			this.Refresh();
		}
		#endregion

		#region Event Handlers
		private void LoopTimer_Tick(object sender, EventArgs e)
		{
			LoopTicked?.Invoke();
			this.Refresh();
		}		
		#endregion

		private void BTWForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			e.IsInputKey = true;
		}
	}
}
