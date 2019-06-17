using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTW
{
	class SpaceController
	{
		public Space Space {get;set;}

		public int Id { get; set; }

		public PlayerController Player { get; set; }
		public List<AIController> AIs { get; set; } = new List<AIController>();
		public List<Projectile> Projectiles { get; set; } = new List<Projectile>();

		public SpaceController(int x, int y, int width, int height, int id)
		{
			Space = new Space(x, y, width, height);
			Id = id;
		}
	}
}
