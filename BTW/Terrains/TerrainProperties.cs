using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	struct TerrainProperties
	{
		public bool IsPassible;
		
		public int Width;
		public int Height;

		public static TerrainProperties Wall = new TerrainProperties() {
			IsPassible = false,
			Width = 100,
			Height = 100,
		};

		public static TerrainProperties Bush = new TerrainProperties()
		{
			IsPassible = true,
			Width = 100,
			Height = 100,
		};
	}

	enum TerrainType
	{
		None,
		Wall,
		Bush
	}
}
