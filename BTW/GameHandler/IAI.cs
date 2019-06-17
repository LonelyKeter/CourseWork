using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	interface IAI
	{
		Tank Tank {get;}
		int ShotCooldown { get; set; }
		void Move(int step, BTWDirection direction);

		AIOptions Next(List<Space> Map);

		void ReverseMove();

		bool Damage(int amount);
		IBTWProjectile Shoot(BTWDirection direction);
	}

	public enum AIOptions
	{
		None,
		Up,
		Down,
		Right,
		Left,
		Shoot
	}
}
