using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class AIController : IAI
	{
		public Tank Tank { get; protected set; }

		public UnitState PrevState { get; private set; }

		private int TickCounter = 80;
		private int CurrentTick = 0;
		private AIOptions CurrentOption = AIOptions.None;

		public int ShotCooldown { get; set; }
		public int CurrentChunkId { get; set; }

		public AIController(Tank tank, int id)
		{
			Tank = tank;
			ShotCooldown = 0;
			PrevState = new UnitState() { Pos = tank.Pos.GetCopy(), Direction = tank.Direction };
			Id = id;
		}

		public void Move(int step, BTWDirection direction)
		{
			PrevState.Direction = Tank.Direction;
			PrevState.Pos = Tank.Pos;

			RotateTexture(direction);

			Tank.Move(step, direction);
		}

		public int Id { get; set; }

		public AIOptions Next(List<Space> Map)
		{
			CurrentTick--;

			

			if (CurrentTick <= 0)
			{
				Random o = new Random(DateTime.Now.Day + DateTime.Now.Millisecond + DateTime.Now.Minute + DateTime.Now.Second);

				CurrentOption = (AIOptions)o.Next(4) + 1;

				CurrentTick = TickCounter;
			}

			return CurrentOption;
		}

		public bool Damage(int amount)
		{
			return Tank.Damage(amount);
		}

		public IBTWProjectile Shoot(BTWDirection direction)
		{
			if (ShotCooldown > 0) return null;
			ShotCooldown = Tank.ShotCooldown;

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
