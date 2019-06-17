using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BTW
{
	class GameButton
	{
		string Name { get; set; }
		string Text { get; set; }
		Bitmap BackGround { get; set; }
		Font Font { get; set; }
		Size Size { get; set; }
		Point Pos { get; set; }

		public void Draw(Graphics g)
		{
			g.DrawImage(BackGround, new Rectangle(Pos, Size));
			g.DrawString(Text, Font, Brushes.Crimson, Pos);
		}
	}
}
