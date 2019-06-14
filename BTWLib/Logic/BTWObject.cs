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
		public BTWRectangle Rectangle { get; protected set; }
		public BTWPoint Pos { get { return Rectangle.LU; } set { Rectangle.LU = value; } }
		public int Width { get { return Rectangle.Width; } }
		public int Height { get { return Rectangle.Height; } }

		public abstract uint ID { get; }

		public bool Collides(BTWObject _object)
		{
			BTWPoint difference = this.Pos - _object.Pos;

			if (Abs(difference.X) >= (_object.Width + this.Width)) return false;
			if (Abs(difference.Y) >= (_object.Height + this.Height)) return false;
			return true;					
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
