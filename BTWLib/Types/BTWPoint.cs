using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib
{
	public class BTWPoint
	{
		public int X { get; set; }
		public int Y { get; set; }

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
	}
}
