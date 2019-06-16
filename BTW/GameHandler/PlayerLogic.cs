using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class Player : IPLayer
	{
		public Tank Tank { get; private set;}
		public int CurrentChunkId { get; set; }

		public BTWDirection MoveDirection { get; set; }

		public bool IsShooting { get; set; }

		public UnitState PrevState { get; private set; }

		public int ShotCooldown { get; set; }

		public Player(Tank tank, int currentChunkid, int shotCooldown)
		{
			Tank = tank;
			CurrentChunkId = currentChunkid;
			ShotCooldown = 0;
			PrevState = new UnitState();
		}

		public void Move(int step, BTWDirection direction)
		{
			PrevState.Direction = Tank.Direction;
			PrevState.Pos = Tank.Pos;

			RotateTexture(direction);

			Tank.Move(step, direction);
		}
		public bool Damage(int amount)
		{
			return Tank.Damage(amount);
		}
		public IBTWProjectile Shoot(BTWDirection direction)
		{
			if (ShotCooldown > 0) return null;
			else
			{
				ShotCooldown = Tank.ShotCooldown;
				IsShooting = false;
			}

			return Tank.Shoot(direction);
		}
		public void ReverseMove()
		{
			Tank.Pos = PrevState.Pos;
		}

		private void RotateTexture(BTWDirection direction)
		{
			if (direction == BTWDirection.None || Tank.Direction == direction ) return;

			int x = (int)Tank.Direction;
			int y = (int)direction;
			
			Tank.Texture.RotateFlip((System.Drawing.RotateFlipType)((2*(x % 2) + x + y) % 4));
			Tank.Direction = direction;
		}
		public int Square()
		{
			return Tank.Width * Tank.Height;
		}
	}
}
