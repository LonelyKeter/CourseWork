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
			LoopHandler handler = new LoopHandler();
			handler.CurrentKeyDown += handler.GameKeyDown;
			handler.CurrentKeyUp += handler.GameKeyUp;
			handler.CurruntOnPaint += handler.GameOnPaint;
			handler.CurrentLoopHandler = handler.GameLoopHandler;

			handler.Walls = new List<Space>();
			handler.AIs = new List<AIController>();
			handler.Projectiles = new List<Projectile>();

			handler.Walls.Add(new Space(0, 0, 600, 50));
			handler.Walls.Add(new Space(0, 50, 50, 550));
			handler.Walls.Add(new Space(550, 50, 50, 550));
			handler.Walls.Add(new Space(0, 550, 600, 50));
			handler.Walls.Add(new Space(275, 0, 50, 300));

			NormalTank tank = new NormalTank(TankProperties.Normal, BTWDirection.Up, 350, 350);
			tank.Texture = Textures.NormalTank_1;
			handler.Player = new PlayerController(tank, 0);

			tank = new NormalTank(TankProperties.Normal, BTWDirection.Up, 200, 200);
			tank.Texture = Textures.NormalTank_1;
			handler.AIs.Add(new AIController(tank, 0));

			form = new Form1(120);

			form.KeyDown += handler.CurrentKeyDown;
			form.KeyUp += handler.CurrentKeyUp;
			form.Paint += handler.CurruntOnPaint;
			form.LoopTicked += handler.CurrentLoopHandler;

			Application.Run(form);
		}

		static int Fun(int a, int b, int x, int y)
		{
			int d1 = (Math.Abs(x - a) + Math.Abs(x - b) + Math.Abs(y - a) + Math.Abs(y - b)) / 2 - Math.Abs(a - b);

			return Math.Abs(x - y) - d1;
		}
	}
}
