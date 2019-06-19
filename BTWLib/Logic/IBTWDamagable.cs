using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.Logic
{
	public interface IBTWDamagable
	{
		int HP { get; }
		bool Damage(int amount);
	}
}
