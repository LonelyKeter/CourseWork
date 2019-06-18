using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	[Serializable]
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

		public AIOptions Next(List<Space> Map, PlayerController player)
		{
			CurrentTick--;

			int difY = Tank.Pos.Y - player.Tank.Pos.Y;

			if (Math.Abs(difY) < player.Tank.Height / 2)
			{
				int dif = Tank.Pos.X - player.Tank.Pos.X;

				if (dif > 0)
				{
					bool flag = true;

					foreach (Space w in Map)
					{
						int wallPlayer = w.Pos.X - player.Tank.Pos.X;

						if (wallPlayer > 0 && wallPlayer < dif)
							if (w.Height + w.Pos.Y > Tank.Pos.Y + Tank.Height / 2 - 1) 
							{
								flag = false;
								break;
							} 
					}

					if (flag)
					{
						this.Tank.Direction = BTWDirection.Left; 
						RotateTexture(BTWDirection.Left);
						return AIOptions.Shoot;
					}
				}
				else
				{
					bool flag = true;

					foreach (Space w in Map)
					{
						int wallPlayer = w.Pos.X - player.Tank.Pos.X;

						if (wallPlayer < 0 && wallPlayer > dif)
							if (w.Height + w.Pos.Y > Tank.Pos.Y + Tank.Height / 2 - 1) 
							{
								flag = false;
								break;
							} 
					}

					if (flag)
					{
						this.Tank.Direction = BTWDirection.Right;
						RotateTexture(BTWDirection.Right);
						return AIOptions.Shoot;
					}
				}								
			}

			int difX = Tank.Pos.X - player.Tank.Pos.X;

			if (Math.Abs(difX) < player.Tank.Height / 2)
			{
				int dif = Tank.Pos.Y - player.Tank.Pos.Y;

				if (dif > 0)
				{
					bool flag = true;

					foreach (Space w in Map)
					{
						int wallPlayer = w.Pos.Y - player.Tank.Pos.Y;

						if (wallPlayer > 0 && wallPlayer < dif)
							if (w.Width + w.Pos.X > Tank.Pos.X + Tank.Width/ 2 - 1)
							{
								flag = false;
								break;
							}
					}

					if (flag)
					{
						this.Tank.Direction = BTWDirection.Up;
						RotateTexture(BTWDirection.Up);
						return AIOptions.Shoot;
					}
				}
				else
				{
					bool flag = true;

					foreach (Space w in Map)
					{
						int wallPlayer = w.Pos.Y - player.Tank.Pos.Y;

						if (wallPlayer < 0 && wallPlayer > dif)
							if (w.Width+ w.Pos.X > Tank.Pos.X + Tank.Width/ 2 - 1)
							{
								flag = false;
								break;
							}
					}

					if (flag)
					{
						this.Tank.Direction = BTWDirection.Down;
						RotateTexture(BTWDirection.Down);
						return AIOptions.Shoot;
					}

				}
			}

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

		public void RotateTexture(BTWDirection direction)
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
