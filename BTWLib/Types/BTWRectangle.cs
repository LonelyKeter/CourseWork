using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib
{
	public class BTWRectangle
	{
		public BTWPoint LU { get; protected set; }

		public int Width { get; set; }
		public int Height { get; set; }
		
		public int GetLeft()
		{
			return LU.X;
		}
		public int GetRight()
		{
			return LU.X + Width;
		}

		public int GetUppper()
		{
			return LU.Y;
		}
		public int GetLower()
		{
			return LU.Y + Height;
		}
	}
}
