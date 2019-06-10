using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTWLib;
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
			BTWLogic LOGIC = new BTWLogic();
			BTWIO IO = new BTWIO();

			LOGIC.IO = IO;
			IO.LOGIC = LOGIC;

			IO.Init();
			LOGIC.Init();		

			KTApplication App = new KTApplication(LOGIC, IO, 20);

			App.Init();

			App.Run();
		}
	}
}
