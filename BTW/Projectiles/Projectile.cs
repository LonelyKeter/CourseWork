﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;

namespace BTW
{
	[Serializable]
	abstract class Projectile : BTWProjectile
	{
		public abstract ProjectileType Type { get; }

		public Projectile(ProjectileProperties props, BTWDirection direction) : base (props.X, props.Y, props.Width, props.Height, direction)
		{
			this.Speed = props.Speed;
			this.Damage = props.Damage;
		}
		public Projectile(int x, int y, int width, int height, BTWDirection direction) : base(x, y, width, height, direction)
		{

		}

		public void SetProperties(ProjectileProperties props)
		{
			this.Damage = props.Damage;
			this.Speed = props.Speed;
		}		
	}

	public enum ProjectileId
	{
		Normal = 0x7000,
	}
}
