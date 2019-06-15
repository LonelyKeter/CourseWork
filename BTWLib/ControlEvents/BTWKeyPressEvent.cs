using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTWLib.ControlEvents
{
	public class BTWKeyPressEvent : BTWEvent
	{
		public override uint ID { get { return (uint)BTWEventID.KeyPress; } }

		public BTWKeyPressEvent(object sender, KeyPressEventArgs args) : base(sender, args)
		{

		}
	}
}
