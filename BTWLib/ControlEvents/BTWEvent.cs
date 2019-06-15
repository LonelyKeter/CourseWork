using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTWLib.ControlEvents
{
	public abstract class BTWEvent
	{
		public abstract uint ID { get; }
		public object Sender { get; protected set; }

		public EventArgs Args { get; protected set; }

		public BTWEvent(object sender, EventArgs args)
		{
			Sender = sender;
			Args = args;
		}
	}

	public enum BTWEventID : uint
	{
		KeyDown = 0x9000,
		KeyPress,
		KeyUp,
		MouseDown,
		MouseMove,
		MouseUp
	}
}
