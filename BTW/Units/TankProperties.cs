using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{	
	struct TankProperties
	{
		public int MaxHP;
		public Projectile Projectile;
		public int Speed;
		public int Width;
		public int Height;
		public int ShotCooldown;

		public static TankProperties Normal = new TankProperties() {
			MaxHP = 10,
			Projectile = new NormalProjectile(BTWDirection.None),
			Speed = 2,
			Width = 50,
			Height = 50,
			ShotCooldown = 60,
		};
	}

	enum TankType
	{
		None,
		Normal
	}
}
