using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTWLib.ControlEvents
{
	public class BTWKeyUpEvent : BTWEvent
	{
		public override uint ID { get { return (uint)BTWEventID.KeyUp; } }

		public BTWKeyUpEvent(object sender, KeyEventArgs args) : base(sender, args)
		{

		}
	}
}
