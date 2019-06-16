using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using System.Drawing;

namespace BTW
{
	interface IPLayer
	{
		Tank Tank {get;}
		int CurrentChunkId { get; set; }

		int ShotCooldown { get; set; }
		BTWDirection MoveDirection { get; set; }

		bool IsShooting { get; set; }

		void Move(int step, BTWDirection direction);
		IBTWProjectile Shoot(BTWDirection direction);
		bool Damage(int amount);

		void ReverseMove();
	}
}
