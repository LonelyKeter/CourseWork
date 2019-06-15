using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class NormalProjectile : Projectile
	{
		public override uint ID { get; } = (uint)ProjectileId.Normal;

		public override ProjectileType Type { get; } = ProjectileType.Normal;

		public NormalProjectile(BTWDirection direction) : base(ProjectileProperties.Normal, direction) { }	
	}
}
