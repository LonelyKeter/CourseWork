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

		public static TankProperties Normal = new TankProperties() {
			MaxHP = 10,
			Projectile = new NormalProjectile(BTWDirection.None),
			Speed = 20,
			Width = 80,
			Height = 80,
		};
	}

	enum TankType
	{
		None,
		Normal
	}
}
