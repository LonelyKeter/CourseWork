using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTWLib.Logic;

namespace BTW
{
	interface IAIController : IUnitController
	{
		AIOptions Next(List<Space> Map, PlayerController player);
	}

	public enum AIOptions
	{
		None,
		Up,
		Down,
		Right,
		Left,
		Shoot
	}
}
