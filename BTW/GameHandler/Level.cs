using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BTWLib.Logic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using BTWLib.Types;
using BTWLib;

namespace BTW
{
	[Serializable]
	class Level
	{
		public Size Size { get; private set; } 
		public Bitmap Background { get; set; }

		private Bitmap aiTexture;
		private Bitmap wallTexture;

		public PlayerController Player { get; private set; }
		public List<AIController> AIs { get; private set; }
		public List<Space> Walls { get; private set; }


		public int WallWidth { get; set; } = 30;

		[field:NonSerialized()]
		private TextureBrush WallBrush = new TextureBrush(new Bitmap(50, 50));
		
		public Bitmap PlayerTexture
		{
			get
			{
				return Player.Tank.Texture;
			}
			set
			{
				Player.Tank.Texture = value;
			}
		}
		public Bitmap AITexture
		{
			get { return aiTexture; }
			set
			{
				aiTexture = value;
				foreach (AIController ai in AIs) ai.Tank.Texture = ai.Tank.Texture;
			}
		}
		public Bitmap WallTexture
		{
			get { return wallTexture; }
			set
			{
				wallTexture = value;
				WallBrush = new TextureBrush(wallTexture, System.Drawing.Drawing2D.WrapMode.Tile);
			}
		}

		public Level(PlayerController player, IEnumerable<AIController> ais, IEnumerable<Space> walls, Size size) 
		{
			this.Player = player;

			this.AIs = new List<AIController>();
			AIs.AddRange(ais);

			this.Walls = new List<Space>();
			Walls.AddRange(walls);
		}
		public Level(Size size)
		{
			AIs = new List<AIController>();
			Walls = new List<Space>();
			Size = size;
		}

		public void AddPlayer(BTWPoint pos, BTWDirection direction)
		{
			Player = new PlayerController(new NormalTank(TankProperties.Normal, direction, pos.X, pos.Y), 0);
			Player.RotateTexture(direction);
		}
		public void AddAI(BTWPoint pos, BTWDirection direction)
		{
			AIs.Add(new AIController(new NormalTank(TankProperties.Normal, direction, pos.X, pos.Y), 0));
			AIs.Last().RotateTexture(direction);
		}

		public void AddWall(int x, int y, int widh, int length, Orientation orientation)
		{
			if (orientation == Orientation.Horizontal)
			{
				int buff = widh;
				widh = length;
				length = buff;
			}

			Walls.Add(new Space(x, y, widh, length));
		}
		public void AddWall(int x, int y, int length, Orientation orientation)
		{
			AddWall(x, y, WallWidth, length, orientation);
		}

		public void MovePlayer(BTWPoint newPos)
		{
			Player.Tank.Pos = newPos;
		}
		public void MoveAI(BTWPoint newPos, int index)
		{
			AIs[index].Tank.Pos = newPos;
		}
		public void Movewall(BTWPoint newPos, int index)
		{
			Walls[index].Pos = newPos;
		}

		
		public Bitmap GetExample()
		{
			Bitmap result = new Bitmap(Size.Width, Size.Height);

			Graphics g = Graphics.FromImage(result);
			Font labelFont = new Font("Arial", 11, FontStyle.Bold);

			if (Background != null) g.DrawImage(Background, 0, 0);

			for (int i = 0; i < Walls.Count; i++)
			{
				Space s = Walls[i];
				g.FillRectangle(WallBrush, s.Pos.X, s.Pos.Y, s.Width, s.Height);
				g.DrawString($"{i}", new Font(labelFont.FontFamily, 20, FontStyle.Bold), Brushes.DarkBlue, s.Pos.X + s.Width / 2 - 1, s.Pos.Y);
			}

			if (Player != null)
			{
				g.DrawImage(PlayerTexture, Player.Tank.Pos.X, Player.Tank.Pos.Y, Player.Tank.Width, Player.Tank.Height);
				g.DrawString("Player", labelFont, Brushes.MediumVioletRed, Player.Tank.Pos.X, Player.Tank.Pos.Y + Player.Tank.Height);
			}

			for (int i = 0; i < AIs.Count; i++)
			{
				AIController ai = AIs[i];
				g.DrawImage(aiTexture, ai.Tank.Pos.X, ai.Tank.Pos.Y, ai.Tank.Width, ai.Tank.Height);
				g.DrawString($"AI {i}", labelFont, Brushes.MediumVioletRed, ai.Tank.Pos.X, ai.Tank.Pos.Y+ ai.Tank.Height);
			}

			for (int i = 50; ; i += 50)
			{
				if (i < this.Size.Width) g.DrawLine(Pens.Red, i, 0, i, Size.Height);

				if (i < this.Size.Height) g.DrawLine(Pens.Red, 0, i, Size.Width, i);

				if (i > this.Size.Width && i > this.Size.Height) break;
			}

			return result;
		}
		public void GetView()
		{
			using(BTWForm form = new BTWForm(1000))
			{
				form.LoopTimer.Enabled = false;
				form.ClientSize = this.Size;
				form.BackgroundImage = GetExample();
				form.Refresh();
				form.ShowDialog();
			}
		}

		public bool SaveResults(string filepath)
		{
			if (this.Size.IsEmpty) return false;
			if (this.Background == null) Background = new Bitmap(Size.Width, Size.Height);
			if (Player != null && PlayerTexture == null) return false;
			if (AIs.Count > 0 && aiTexture == null) return false;
			if (Walls.Count > 0 && wallTexture == null) return false;

			using (FileStream stream = new FileStream(filepath, FileMode.OpenOrCreate))
			{
				BinaryFormatter formatter = new BinaryFormatter();

				formatter.Serialize(stream, this);
			}
			return true;
		}
		public static Level GetLevel(string filepath)
		{
			if (!File.Exists(filepath)) return null;
			try
			{
				using (FileStream stream = new FileStream(filepath, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();

					Level result = (Level)formatter.Deserialize(stream);
					result.WallBrush = new TextureBrush(result.wallTexture, System.Drawing.Drawing2D.WrapMode.Tile);

					return result;
				}
			}
			catch (DivideByZeroException)
			{
				return null;
			}
		}
	}

	public enum Orientation
	{
		Horizontal,
		Verical
	}
}
