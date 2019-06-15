using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTWLib.ControlEvents
{
	public class BTWKeyDownEvent : BTWEvent
	{
		public override uint ID { get { return (uint)BTWEventID.KeyDown; } }

		public BTWKeyDownEvent(object sender, KeyEventArgs args) : base(sender, args)
		{

		}
	}
}
