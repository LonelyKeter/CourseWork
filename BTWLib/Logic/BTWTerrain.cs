using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Types;

namespace BTWLib.Logic
{
	public abstract class BTWTerrain : BTWObject, IBTWTerrain
	{
		public abstract bool IsPassable { get; protected set; }
		
		public BTWTerrain(bool IsPassable, BTWRectangle rectangle) : base(rectangle)
		{
			this.IsPassable = IsPassable;
		}
		public BTWTerrain(bool IsPassable, BTWPoint Pos, int Width, int Height) : base (Pos, Width, Height)
		{
			this.IsPassable = IsPassable;
		}
		public BTWTerrain(bool IsPassable, int x, int y, int Width, int Height) : base(x, y, Width, Height)
		{
			this.IsPassable = IsPassable;
		}
	}	
}
