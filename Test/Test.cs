using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTWLib;
using BTWLib.Logic;
using Keter.Core;

namespace Test
{
	static class Test
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		static void Main()
		{
			BTWForm main = new BTWForm();

			IBTWObject o = new m();

			Application.Run();
		}

		class m : BTWUnit
		{
			public override uint ID { get { return 0; } }
		}
	}
}
