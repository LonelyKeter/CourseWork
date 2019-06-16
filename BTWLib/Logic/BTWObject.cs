using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using BTWLib.Types;

namespace BTWLib.Logic
{
	public abstract class BTWObject : IBTWObject
	{
		public BTWRectangle Rectangle { get; protected set;}
		public BTWPoint Pos { get { return Rectangle.LU; } set { Rectangle.LU = value; } }
		public int Width { get { return Rectangle.Width; } }
		public int Height { get { return Rectangle.Height; } }

		public abstract uint ID { get; }
		
		public int Overlapses(BTWObject _object)
		{
			int Fun(int a, int b, int x, int y)
			{
				int d1 = (Abs(x - a) + Abs(x - b) + Abs(y - a) + Abs(y - b)) / 2 - Abs(a - b);

				return Abs(x - y) - d1;
			}

			int X = Fun(this.Pos.X, this.Pos.X + this.Width, _object.Pos.X, _object.Pos.X + _object.Width);
			int Y = Fun(this.Pos.Y, this.Pos.Y + this.Height, _object.Pos.Y, _object.Pos.Y + _object.Width);

			if (X < 0 || Y < 0) return -1;

			return X * Y;
		}

		protected BTWObject() { }
		public BTWObject(BTWRectangle rectangle)
		{
			this.Rectangle = rectangle;
		}
		public BTWObject(BTWPoint Pos, int Width, int Height)
		{
			this.Rectangle = new BTWRectangle(Pos, Width, Height);
		}
		public BTWObject(int X, int Y, int Width, int Height)
		{
			this.Rectangle = new BTWRectangle(new BTWPoint(X,Y), Width, Height);
		}
	}
}
