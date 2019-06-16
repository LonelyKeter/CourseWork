using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class AI : IAI
	{
		public Tank Tank { get; protected set; }

		public UnitState PrevState { get; private set; }

		public int ShotCooldown { get; set; }

		public void Move(int step, BTWDirection direction)
		{
			PrevState.Direction = Tank.Direction;
			PrevState.Pos = Tank.Pos;

			RotateTexture(direction);

			Tank.Move(step, direction);
		}

		public int CurrentChunkId { get; set; }

		public AIOptions Next()
		{
			return AIOptions.None;
		}

		public bool Damage(int amount)
		{
			return Tank.Damage(amount);
		}

		public IBTWProjectile Shoot(BTWDirection direction)
		{
			if (Tank.ShotCooldown-- > 0) return null;
			else ShotCooldown = Tank.ShotCooldown;

			return Tank.Shoot(direction);
		}

		public void ReverseMove()
		{
			Tank.Pos = PrevState.Pos;
		}

		private void RotateTexture(BTWDirection direction)
		{
			if (direction == BTWDirection.None || Tank.Direction == direction) return;

			int x = (int)Tank.Direction;
			int y = (int)direction;

			Tank.Texture.RotateFlip((System.Drawing.RotateFlipType)((2 * (x % 2) + x + y) % 4));
			Tank.Direction = direction;
		}
		public int Square()
		{
			return Tank.Width * Tank.Height;
		}
	}
}
