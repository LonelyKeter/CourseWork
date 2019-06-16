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

			handler.Map.AddNode(new Space(50,50,600, 600));

			NormalTank tank = new NormalTank(TankProperties.Normal, BTWDirection.Up, 400, 400);
			tank.Texture = Textures.NormalTank_1;
			handler.Player = new Player(tank , 0, 30);

			Bitmap MapText = new Bitmap(1280, 720);
			Graphics g = Graphics.FromImage(MapText);
			g.DrawRectangle(Pens.Green, 0, 0, 50, 700);
			g.DrawRectangle(Pens.Green, 0, 0, 700, 50);
			g.DrawRectangle(Pens.Green, 650, 0, 50, 700);
			g.DrawRectangle(Pens.Green, 0, 650, 700, 50);
			handler.MapTexture = MapText;

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
