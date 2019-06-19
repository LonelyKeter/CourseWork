using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using System.Drawing;

namespace BTW
{
	interface IPLayer : IUnitController
	{	
		BTWDirection MoveDirection { get; set; }

		bool IsShooting { get; set; }	
	}
}
