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
		public override uint ID { get { return 0x7000; } }

		public override ProjectileType Type { get; protected set; } = ProjectileType.Normal;

		public NormalProjectile(BTWDirection direction) : base(ProjectileProperties.Normal, direction) { }	
	}
}
