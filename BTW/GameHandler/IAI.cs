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
		int CurrentChunkId { get; set; }
		void Move(int step, BTWDirection direction);

		AIOptions Next();

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
