using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	[Serializable]
	class NormalTank : Tank
	{
		public override TankType Type { get; } = TankType.Normal;

		public override uint ID { get; } = (uint)TankId.Normal;

		public NormalTank(TankProperties props, BTWDirection direction, int x, int y) : base(TankProperties.Normal, direction, x, y) { }
	}
}
