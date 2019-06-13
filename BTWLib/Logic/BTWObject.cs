using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib
{
	public class BTWObject
	{
		protected BTWRectangle Rectangle;

		public BTWPoint Pos
		{
			get { return new BTWPoint(Rectangle.LU.X, Rectangle.LU.Y); }
		}
		
		public BTWObject(BTWPoint pos, int Width, int Height)
		{
			this.Pos = pos;
		}
	}
}
