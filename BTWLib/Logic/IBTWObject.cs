using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Types;

namespace BTWLib.Logic
{
	public interface IBTWObject
	{
		BTWRectangle Rectangle { get; }
		BTWPoint Pos { get; set; }
		int Width { get; }
		int Height { get; }

		uint ID { get; }

		bool Collides(BTWObject _object);		
	}
}
