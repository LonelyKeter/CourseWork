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

namespace BTWLib
{
	public partial class BTWForm : Form
	{
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


		public BTWForm()
		{
			InitializeComponent();
		}
	}
}
