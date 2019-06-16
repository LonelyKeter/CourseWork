using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BTWLib.Types
{
	public class BTWPoint
	{
		public int X { get; protected set; }
		public int Y { get; protected set; }

		public BTWPoint(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public static BTWPoint operator +(BTWPoint left, BTWPoint right)
		{
			return new BTWPoint(left.X + right.X, left.Y + right.Y);
		} 
		public static BTWPoint operator -(BTWPoint left, BTWPoint right)
		{
			return new BTWPoint(left.X - right.X, left.Y - right.Y);
		} 

		public static implicit operator BTWPoint(Point e)
		{
			return new BTWPoint(e.X, e.Y);
		}
		public static implicit operator Point(BTWPoint e)
		{
			return new Point(e.X, e.Y);
		}
		
		public BTWPoint GetCopy()
		{
			return new BTWPoint(X, Y);
		}
	}
}
