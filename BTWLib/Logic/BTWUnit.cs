using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;

namespace BTWLib.Logic
{
	[Serializable]
	public abstract class BTWUnit : BTWObject, IBTWUnit
	{
		public int MaxHP { get; set; } 
		public int HP { get; protected set; }
		public IBTWProjectile Projectile { get; set; }
		public bool IsAlive { get; protected set; } = true;
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
		public bool Damage(int ammount)
		{
			HP -= ammount;
			if (HP <= 0) IsAlive = false;
			return IsAlive;
		}
		public IBTWProjectile Shoot(BTWDirection direction)
		{
			IBTWProjectile result = (IBTWProjectile)Projectile.Clone();
			result.Direction = direction;
			switch (direction)
			{
				case BTWDirection.Down:
					result.Pos = this.Pos + new BTWPoint(this.Width / 2 - result.Width/2, this.Height + 1);
					break;
				case BTWDirection.Up:
					result.Pos = this.Pos + new BTWPoint(this.Width / 2 - result.Width / 2, -(result.Height));
					break;
				case BTWDirection.Left:
					result.Pos = this.Pos + new BTWPoint(-result.Width, this.Height / 2 - result.Height / 2);
					break;
				case BTWDirection.Right:
					result.Pos = this.Pos + new BTWPoint(this.Width + 1, this.Height / 2 - result.Height / 2);
					break;
			}
			return result;
		}
	}
}
