using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWUnit : IBTWMovable, IBTWObject
	{
		int MaxHP { get; set; }
		int HP { get; }
		IBTWProjectile Projectile { get; set; }
		bool IsAlive { get; }
		BTWDirection Direction { get; set; }
		
		bool Damage(int amount);
		IBTWProjectile Shoot(BTWDirection direction);
	}
}
