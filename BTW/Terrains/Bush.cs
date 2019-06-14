using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;

namespace BTW
{
	class Bush : BTWTerrain
	{
		public override bool IsPassable { get { return true; } protected set { throw new InvalidOperationException("Coulnd't set \"IsPassable\" value"); } }

		public override uint ID { get { return 0x3001; } }

		public Bush(BTWRectangle rectangle) : base(false, rectangle)
		{
			this.Rectangle = rectangle;
		}
		public Bush(BTWPoint Pos, int Width, int Height) : base(false, Pos, Width, Height)
		{
			this.Rectangle = new BTWRectangle(Pos, Width, Height);
		}
		public Bush(int X, int Y, int Width, int Height) : base(false, X, Y, Width, Height)
		{
			this.Rectangle = new BTWRectangle(new BTWPoint(X, Y), Width, Height);
		}
	}
}
