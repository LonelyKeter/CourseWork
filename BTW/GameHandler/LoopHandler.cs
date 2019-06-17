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
		public Action CurrentLoopHandler;
		public KeyEventHandler CurrentKeyDown;
		public KeyEventHandler CurrentKeyUp;
		public MouseEventArgs CurrentMouseDown;
		public MouseEventArgs CurrentMouseUp;
		public PaintEventHandler CurruntOnPaint;

		public LoopHandler()
		{
			g = Graphics.FromImage(LastFrame);
		}

		public void InitPause()
		{

		}
		public void InitScoreScreen(bool win)
		{

		}

		#region GameLoop
		public List<Space> Walls;
		public PlayerController Player;
		public List<AIController> AIs;
		public List<Projectile> Projectiles;

		TextureBrush WallBrush = new TextureBrush(Textures.Wall_1, new Rectangle(0, 0, 50, 50));
		public Bitmap LastFrame = new Bitmap(1280, 720);
		Graphics g;

		public void GameLoopHandler()
		{
			MovePlayer();
			MoveAI();
			MoveProjectiles();
			CheckCollisions();
			CheckResults();
		}

		public void MovePlayer()
		{
			Player.ShotCooldown--;
			Player.Move(Player.Tank.Speed, Player.MoveDirection);
			if (Player.IsShooting)
			{
				IBTWProjectile projectile = Player.Shoot(Player.Tank.Direction);
				if (projectile != null)
				{
					Projectiles.Add((Projectile)projectile);
				}
			}
		}
		public void MoveAI()
		{
			foreach (AIController ai in AIs)
			{
				AIOptions next = ai.Next(Walls);

				switch (next)
				{
					case AIOptions.Down:
						ai.Move(Player.Tank.Speed, BTWDirection.Down);
						break;
					case AIOptions.Up:
						ai.Move(Player.Tank.Speed, BTWDirection.Up);
						break;
					case AIOptions.Left:
						ai.Move(Player.Tank.Speed, BTWDirection.Left);
						break;
					case AIOptions.Right:
						ai.Move(Player.Tank.Speed, BTWDirection.Right);
						break;
					case AIOptions.Shoot:
						IBTWProjectile projectile = ai.Shoot(ai.Tank.Direction);
						if (projectile == null) break;
						Projectiles.Add((Projectile)projectile);
						break;
				}

				ai.ShotCooldown--;
			}
		}
		public void MoveProjectiles()
		{			
			foreach (Projectile p in Projectiles) p.Move(p.Speed, p.Direction);
		}
		public void CheckCollisions()
		{
			foreach (Space w in Walls)
			{
				if (Player.Tank.Overlapses(w) > 0) Player.ReverseMove();

				foreach (AIController Ai in AIs) if (Ai.Tank.Overlapses(w)> 0) Ai.ReverseMove();

				for (int i = Projectiles.Count - 1; i >= 0; i--) if (Projectiles[i].Overlapses(w) > 0) Projectiles.RemoveAt(i);
			}

			foreach (AIController Ai in AIs)
				if (Player.Tank.Overlapses(Ai.Tank) > 0)
				{
					Ai.ReverseMove();
					Player.ReverseMove();
				}

			for (int i = 0; i < AIs.Count; i++)
				for (int j = i + 1; j < AIs.Count; j++)
					if (AIs[i].Tank.Overlapses(AIs[j].Tank) > 0)
					{
						AIs[i].ReverseMove();
						AIs[j].ReverseMove();
					}

			for (int i = Projectiles.Count - 1; i >= 0; i--)
			{
				if (Projectiles[i].Overlapses(Player.Tank) > 0)
				{
					Player.Damage(Projectiles[i].Damage);
					Projectiles.RemoveAt(i);
					continue;
				}

				foreach(AIController Ai in AIs)
					if (Projectiles[i].Overlapses(Ai.Tank) > 0)
					{
						Ai.Damage(Projectiles[i].Damage);
						Projectiles.RemoveAt(i);
						continue;
					}
			}

			
		}
		public void CheckResults()
		{
			if (!Player.Tank.IsAlive)
			{
				InitScoreScreen(false);
				return;
			}

			if (AIs.Count == 0)
			{
				InitScoreScreen(true);
				return;
			}

			for (int i = AIs.Count - 1; i >= 0; i--)
			{
				if (!AIs[i].Tank.IsAlive) AIs.RemoveAt(i);
			}

			//Dobavit
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
			g.Clear(Color.Black);

			g.DrawImage(Player.Tank.Texture, Player.Tank.Pos.X, Player.Tank.Pos.Y, Player.Tank.Width, Player.Tank.Height);

			foreach (AIController Ai in AIs)
			{
				g.DrawImage(Ai.Tank.Texture, Ai.Tank.Pos.X, Ai.Tank.Pos.Y, Ai.Tank.Width, Ai.Tank.Height);
			}

			foreach(Space w in Walls)
			{
				g.FillRectangle(WallBrush, w.Pos.X, w.Pos.Y, w.Width, w.Height);
			}

			foreach(Projectile p in Projectiles)
			{
				g.FillRectangle(Brushes.Brown, p.Pos.X, p.Pos.Y, p.Width, p.Height);
			}

			e.Graphics.DrawImage(LastFrame, 0, 0);
		}
		#endregion

		#region ScoreLoop
		public List<GameButton> Buttons;
		public MenuState CurrentScoreState;
		public Bitmap ScoreMenuBackground;

		public void ScoreLoopHandler()
		{
			
		}

		public void ScoreOnPaint(object sender, PaintEventArgs e)
		{

		}
		#endregion

		#region MenuLoop
		#endregion
	}

	public enum MenuState
	{
		None,
		NewGame,
		Exit,
		Continue,
	}
}
