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
		static BTWForm form;

		[STAThread]
		static void Main()
		{
			LoopHandler handler = new LoopHandler();
			handler.GetLevel(@"C:\Users\LonelyKeter\source\repos\CourseWork\BTW\Levels\test1.bin");
			handler.InitGame("");

			handler.LinkForm(form = new BTWForm(120));
			Application.Run(form);

			//	FFF();
		}

		static int Fun(int a, int b, int x, int y)
		{
			int d1 = (Math.Abs(x - a) + Math.Abs(x - b) + Math.Abs(y - a) + Math.Abs(y - b)) / 2 - Math.Abs(a - b);

			return Math.Abs(x - y) - d1;
		}
		static void FFF()
		{
			Level level = Level.GetLevel(@"C:\Users\LonelyKeter\source\repos\CourseWork\BTW\Levels\test1.bin");

			
		

			Console.Write(level.AIs.Count);
			level.GetView();

			//Level level = new Level(new Size(1280, 720));

			//while (true)
			//{
			//	switch (Console.ReadLine())
			//	{
			//		case "AddWall":
			//			string[] Args = Console.ReadLine().Split();
			//			level.AddWall(int.Parse(Args[0]), int.Parse(Args[1]), int.Parse(Args[2]), Args[3] == "h" ? Orientation.Horizontal : Orientation.Verical);
			//			level.GetView();
			//			continue;
			//		case "AddPLayer":
			//			Args = Console.ReadLine().Split();
			//			continue;
			//	}
			//	break;
			//}

			

			level.SaveResults(@"C:\Users\LonelyKeter\source\repos\CourseWork\BTW\Levels\test1.bin");
		}
	}
}
