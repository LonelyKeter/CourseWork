﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWProjectile : IBTWMoving, IBTWObject, ICloneable
	{
		int Damage { get; set; }
	}
}
