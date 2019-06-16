using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using BTWLib.Logic;
using System.Windows.Forms;
using BTWLib.Types;

namespace BTW
{
	class LoopHandler
	{
		public Tree<Space> Map = new Tree<Space>();
		public Bitmap MapTexture;

		public Player Player;
		public List<AI> AI = new List<AI>();

		public List<Projectile> Projectiles = new List<Projectile>();
		public List<int> ProjectileChunks = new List<int>();

		public Bitmap LastFrame;

		public Action CurrentLoopHandler;
		public KeyEventHandler CurrentKeyDown;
		public KeyEventHandler CurrentKeyUp;
		public MouseEventArgs CurrentMouseDown;
		public MouseEventArgs CurrentMouseUp;
		public PaintEventHandler CurruntOnPaint;

		public void GameLoopHandler()
		{
			MovePlayer();
			MoveAI();
			MoveProjectiles();
			CheckCollisions();
		}

		public void MovePlayer()
		{
			Player.Move(Player.Tank.Speed, Player.MoveDirection);
			if (Player.IsShooting)
			{
				IBTWProjectile projectile = Player.Shoot(Player.Tank.Direction);
				if (projectile != null)
				{
					Projectiles.Add((Projectile)projectile);
					ProjectileChunks.Add(Player.CurrentChunkId);
				}
			}
			Player.ShotCooldown--;
		}
		public void MoveAI()
		{
			foreach (AI ai in AI)
			{
				AIOptions next = ai.Next();

				switch (next)
				{
					case AIOptions.Down:
						ai.Move(Player.Tank.Speed, BTWDirection.Down);
						ai.ShotCooldown--;
						return;
					case AIOptions.Up:
						ai.Move(Player.Tank.Speed, BTWDirection.Up);
						ai.ShotCooldown--;
						return;
					case AIOptions.Left:
						ai.Move(Player.Tank.Speed, BTWDirection.Left);
						ai.ShotCooldown--;
						return;
					case AIOptions.Right:
						ai.Move(Player.Tank.Speed, BTWDirection.Right);
						ai.ShotCooldown--;
						return;
					case AIOptions.Shoot:
						ai.Shoot(ai.Tank.Direction);
						return;
				}
			}	
		}
		public void MoveProjectiles()
		{
			foreach (Projectile p in Projectiles) p.Move(p.Speed, p.Direction);
		}
		public bool CheckCollisions()
		{
			int cursquare = Map[Player.CurrentChunkId].Body.Overlapses(Player.Tank);
			int square = Player.Square();

			if (cursquare != square)
			{
				Space curspace = Map[Player.CurrentChunkId].Body;

				int dX = Player.Tank.Pos.X - curspace.Pos.X; 
				int dY = Player.Tank.Pos.Y - curspace.Pos.Y;

				bool AddCheck()
				{
					if (dX < 0) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Left])
						{
							cursquare += n.Body.Overlapses(Player.Tank);
							if (cursquare == square) return true;
						}
					if (dX > curspace.Width) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Right])
						{
							cursquare += n.Body.Overlapses(Player.Tank);
							if (cursquare == square) return true;
						}
					if (dY < 0) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Up])
						{
							cursquare += n.Body.Overlapses(Player.Tank);
							if (cursquare == square) return true;
						}
					if (dY > curspace.Height) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Down])
						{
							cursquare += n.Body.Overlapses(Player.Tank);
							if (cursquare == square) return true;
						}
					return false;
				}

				if (!AddCheck()) Player.ReverseMove();				
			}			

			foreach(AI ai in AI)
			{
				cursquare = Map[ai.CurrentChunkId].Body.Overlapses(ai.Tank);
				square = ai.Square();

				if (cursquare != square)
				{
					Space curspace = Map[ai.CurrentChunkId].Body;

					int dX = ai.Tank.Pos.X - curspace.Pos.X;
					int dY = ai.Tank.Pos.Y - curspace.Pos.Y;

					bool AddCheck()
					{
						if (dX < 0) foreach (Tree<Space>.Node<Space> n in Map[ai.CurrentChunkId][BTWDirection.Left])
							{
								cursquare += n.Body.Overlapses(ai.Tank);
								if (cursquare == square) return true;
							}
						if (dX > curspace.Width) foreach (Tree<Space>.Node<Space> n in Map[ai.CurrentChunkId][BTWDirection.Right])
							{
								cursquare += n.Body.Overlapses(ai.Tank);
								if (cursquare == square) return true;
							}
						if (dY < 0) foreach (Tree<Space>.Node<Space> n in Map[ai.CurrentChunkId][BTWDirection.Up])
							{
								cursquare += n.Body.Overlapses(ai.Tank);
								if (cursquare == square) return true;
							}
						if (dY > curspace.Height) foreach (Tree<Space>.Node<Space> n in Map[ai.CurrentChunkId][BTWDirection.Down])
							{
								cursquare += n.Body.Overlapses(ai.Tank);
								if (cursquare == square) return true;
							}
						return false;
					}

					if (!AddCheck()) ai.ReverseMove();
				}
			}

			for (int a = Projectiles.Count - 1; a >= 0; a--)
			{
				cursquare = Map[ProjectileChunks[a]].Body.Overlapses(Projectiles[a]);
				square = Projectiles[a].Width * Projectiles[a].Height;

				if (cursquare != square)
				{
					Space curspace = Map[ProjectileChunks[a]].Body;

					int dX = Projectiles[a].Pos.X - curspace.Pos.X;
					int dY = Projectiles[a].Pos.Y - curspace.Pos.Y;

					bool AddCheck()
					{
						if (dX < 0) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Left])
							{
								cursquare += n.Body.Overlapses(Projectiles[a]);
								if (cursquare == square) return true;
							}
						if (dX > curspace.Width) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Right])
							{
								cursquare += n.Body.Overlapses(Projectiles[a]);
								if (cursquare == square) return true;
							}
						if (dY < 0) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Up])
							{
								cursquare += n.Body.Overlapses(Projectiles[a]);
								if (cursquare == square) return true;
							}
						if (dY > curspace.Height) foreach (Tree<Space>.Node<Space> n in Map[Player.CurrentChunkId][BTWDirection.Down])
							{
								cursquare += n.Body.Overlapses(Projectiles[a]);
								if (cursquare == square) return true;
							}
						return false;
					}

					if (!AddCheck())
					{
						Projectiles.RemoveAt(a);
						ProjectileChunks.RemoveAt(a);
					}
				}
			}

			for (int a = Projectiles.Count - 1; a >= 0; a--)
			{
				if (Projectiles[a].Overlapses(Player.Tank) > 0)
				{
					if (!Player.Damage(Projectiles[a].Damage)) return true;
					else Projectiles.RemoveAt(a);
				}

				for (int j = AI.Count - 1; j >= 0; j--)
				{
					for (int i = Projectiles.Count - 1; i >= 0; i--)
					{
						if (Projectiles[i].Overlapses(AI[i].Tank) > 0)
						{
							if (!AI[i].Damage(Projectiles[i].Damage)) AI.RemoveAt(i);
							Projectiles.RemoveAt(i);
						}
					}
				}
			}

			return false;
		}

		public void GameKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.A:
					Player.MoveDirection = BTWDirection.Left;
					break;
				case Keys.W:
					Player.MoveDirection = BTWDirection.Up;
					break;
				case Keys.D:
					Player.MoveDirection = BTWDirection.Right;
					break;
				case Keys.S:
					Player.MoveDirection = BTWDirection.Down;
					break;
				case Keys.Space:
					Player.IsShooting = true;
					break;
				case Keys.Escape:
					InitPause();
					break;
			}
		}
		public void GameKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.A:
					if (Player.MoveDirection == BTWDirection.Left) Player.MoveDirection = BTWDirection.None;
					break;
				case Keys.W:
					if (Player.MoveDirection == BTWDirection.Up) Player.MoveDirection = BTWDirection.None;
					break;
				case Keys.S:
					if (Player.MoveDirection == BTWDirection.Down) Player.MoveDirection = BTWDirection.None;
					break;
				case Keys.D:
					if (Player.MoveDirection == BTWDirection.Right) Player.MoveDirection = BTWDirection.None;
					break;
				case Keys.Space:
					Player.IsShooting = false;
					break;
			}
		}

		public void GameOnPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImage(MapTexture, 0, 0);

			g.DrawImage(Player.Tank.Texture, Player.Tank.Pos.X, Player.Tank.Pos.Y, Player.Tank.Width, Player.Tank.Height);

			foreach(Projectile p in Projectiles)
			{
				g.DrawRectangle(Pens.Red, p.Pos.X, p.Pos.Y, p.Width, p.Height);
			}
		}

		public void InitPause()
		{

		}
	}
}
