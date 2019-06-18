using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Types
{
	[Serializable]
	public class BTWRectangle
	{
		public BTWPoint LU { get; set; }

		public int Width { get; protected set; }
		public int Height { get; protected set; }

		public BTWRectangle(BTWPoint LU, int width, int height)
		{
			this.LU = LU.GetCopy();
			this.Width = width;
			this.Height = height;
		}
		
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
