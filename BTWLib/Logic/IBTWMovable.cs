﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWMovable
	{
		void Move(int dist, BTWDirection direction);
	}
	
	public enum BTWDirection
	{
		None = 0,
		Up,
		Right,
		Down,
		Left
	}
}
