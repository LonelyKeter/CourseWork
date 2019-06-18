using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Types;

namespace BTWLib.Logic
{
	[Serializable]
	public abstract class BTWProjectile : BTWObject, IBTWProjectile, IBTWObject
	{
		public int Damage { get; set; }
		public int Speed { get; set; }
		public BTWDirection Direction { get; set; }

		public void Move(int dist, BTWDirection direction)
		{
			switch (direction)
			{
				case BTWDirection.Down: this.Pos += new BTWPoint(0, dist); return;
				case BTWDirection.Up: this.Pos += new BTWPoint(0, -dist); return;
				case BTWDirection.Left: this.Pos += new BTWPoint(-dist, 0); return;
				case BTWDirection.Right: this.Pos += new BTWPoint(dist, 0); return;
			}
		}

		public BTWProjectile(BTWRectangle rectangle, BTWDirection direction) : base(rectangle)
		{
			this.Direction = direction;
		}
		public BTWProjectile(BTWPoint point, int width, int height, BTWDirection direction): base(point, width, height)
		{
			this.Direction = direction;
		}
		public BTWProjectile(int x, int y, int width, int height, BTWDirection direction) : base(x, y, width, height)
		{
			this.Direction = direction;
		}

		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
