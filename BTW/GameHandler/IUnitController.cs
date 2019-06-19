using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	interface IUnitController
	{
		Tank Tank { get; }

		int ShotCooldown { get; set; }

		void Move(int step, BTWDirection direction);
		IBTWProjectile Shoot(BTWDirection direction);
		bool Damage(int amount);

		void ReverseMove();

	}
}
