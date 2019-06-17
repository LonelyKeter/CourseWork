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

		public int OverlapsesX(BTWObject _object)
		{
			return Max(this.Pos.X + this.Width, _object.Pos.X + _object.Width) - Min(this.Pos.X, _object.Pos.X) - Abs(this.Pos.X - _object.Pos.X) - Abs(this.Pos.X + this.Width - _object.Pos.X - _object.Width);
		}
			
		public int OverlapsesY(BTWObject _object)
		{
			return Max(this.Pos.Y + this.Height, _object.Pos.Y + _object.Height) - Min(this.Pos.Y, _object.Pos.Y) - Abs(this.Pos.Y - _object.Pos.Y) - Abs(this.Pos.Y + this.Height - _object.Pos.Y - _object.Height);
		}

		public int Overlapses(BTWObject _object)
		{
			int x = OverlapsesX(_object);
			int y = OverlapsesY(_object);

			if (x < 0 || y < 0) return -1;

			return x*y;
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
