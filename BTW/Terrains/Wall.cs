using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;

namespace BTW
{
	class Wall : Terrain
	{
		public override bool IsPassable { get { return false; } protected set { throw new InvalidOperationException("Coulnd't set \"IsPassable\" value"); } }

		public override uint ID { get { return 0x3000; } }

		public override TerrainType Type { get { return TerrainType.Wall; } }

		public Wall(int X, int Y) : base(TerrainProperties.Wall, X, Y) { }
	}
}
