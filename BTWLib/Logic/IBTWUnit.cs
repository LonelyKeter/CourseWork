using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWUnit : IBTWMoving, IBTWObject, IBTWDamagable
	{
		int MaxHP { get; set; }
		
		IBTWProjectile Projectile { get; set; }
		bool IsAlive { get; }

		IBTWProjectile Shoot(BTWDirection direction);
	}
}
