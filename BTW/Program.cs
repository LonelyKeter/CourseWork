using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTWLib;
using BTWLib.Logic;
using BTWLib.Types;
using BTWLib.ControlEvents;
using System.Drawing;

namespace BTW
{
	static class Program
	{
		public static int Rate = 60;
		static Form1 form;		

		[STAThread]
		static void Main()
		{
			Console.WriteLine(Fun(0, 4, 2, 6));
			Console.WriteLine(Fun(2, 6, 4, 0));
			Console.WriteLine(Fun(0, 6, 4, 2));
			Console.WriteLine(Fun(4, 2, 0, 6));
			Console.WriteLine(Fun(0, 3, 4, 7));

		}

		static int Fun(int a, int b, int x, int y)
		{
			int d1 = (Math.Abs(x - a) + Math.Abs(x - b) + Math.Abs(y - a) + Math.Abs(y - b)) / 2 - Math.Abs(a - b);

			return Math.Abs(x - y) - d1;
		}
	}
}
