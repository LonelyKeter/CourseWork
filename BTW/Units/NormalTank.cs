using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	class NormalTank : Tank
	{
		public override TankType Type { get { return TankType.Normal; } }

		public override uint ID { get { return 0x1000; } }

		public NormalTank(TankProperties props, BTWDirection direction) : base(TankProperties.Normal, direction) { }
	}
}
