using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWMoving : IBTWMovable
	{
		int Speed { get; set; }
		BTWDirection Direction { get; set; }
	}
}
