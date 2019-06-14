using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;
using System.Drawing;

namespace BTW
{
	abstract class Tank : BTWUnit
	{
		public abstract TankType Type { get; }

		public Tank(TankProperties props, BTWDirection direction, int x, int y)
		{
			this.MaxHP = props.MaxHP;
			this.Speed = props.Speed;
			this.Projectile = props.Projectile;
			this.Direction = direction;
			this.HP = this.MaxHP;
			
			this.Rectangle = new BTWRectangle(new BTWPoint(x,y), props.Width, props.Height);
		}
	}
}
