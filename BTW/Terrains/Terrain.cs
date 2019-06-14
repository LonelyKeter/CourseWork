using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	abstract class Terrain : BTWTerrain
	{
		public abstract TerrainType Type { get; }

		public Terrain(TerrainProperties props, int X, int Y) : base(props.IsPassible, X, Y, props.Width, props.Height)
		{			
		}
	}
}
