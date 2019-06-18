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
	[Serializable]
	abstract class Tank : BTWUnit
	{
		public abstract TankType Type { get; }

		public bool IsMoving { get; set; }

		public int ShotCooldown { get; set; }

		public Bitmap Texture { get; set; }

		public Tank(TankProperties props, BTWDirection direction, int x, int y)
		{
			this.MaxHP = props.MaxHP;
			this.Speed = props.Speed;
			this.Projectile = props.Projectile;
			this.Direction = direction;
			this.HP = this.MaxHP;
			this.ShotCooldown = props.ShotCooldown;
			
			this.Rectangle = new BTWRectangle(new BTWPoint(x,y), props.Width, props.Height);
		}
	}

	public enum TankId
	{
		Normal = 0x1000,
	}
}
