using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTWLib.ControlEvents
{
	public class BTWMouseUpEvent : BTWEvent
	{
		public override uint ID { get { return (uint)BTWEventID.MouseUp; } }

		public BTWMouseUpEvent(object sender, MouseEventArgs args) : base(sender, args)
		{

		}
	}
}
