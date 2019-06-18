using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;
using BTWLib.Types;
using System.Drawing;

namespace BTW
{
	[Serializable]
	class Space : BTWObject
	{
		public override uint ID { get; } = 0x3000;

		[NonSerialized]
		public TextureBrush Brush;

		public Space(int x, int y, int width, int height) : base(x, y, width, height)
		{
			
		}
	}
}
