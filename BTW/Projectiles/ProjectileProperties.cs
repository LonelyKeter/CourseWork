using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;

namespace BTW
{
	struct ProjectileProperties
	{
		public int Damage;
		public int Speed;
		public int X;
		public int Y;
		public int Width;
		public int Height;

		public static ProjectileProperties Normal = new ProjectileProperties() { Speed = 6, Damage = 4, X = 0, Y = 0, Width = 10, Height = 10 };
	}

	enum ProjectileType
	{
		None,
		Normal
	}
}
